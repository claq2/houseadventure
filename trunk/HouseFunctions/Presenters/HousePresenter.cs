//-----------------------------------------------------------------------
// <copyright file="HousePresenter.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    using HouseCore.Interfaces;

    /// <summary>
    /// The functions that can be done in the house
    /// </summary>
    public class HousePresenter
    {
        private Random random = new Random();
        private IHouseView view;
        private Player player;
        private HouseType house;

        /// <summary>
        /// Initializes a new instance of the <see cref="HousePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public HousePresenter(IHouseView view)
            : this(view, new Player(), new HouseType(true))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HousePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="player">The player.</param>
        /// <param name="house">The house.</param>
        public HousePresenter(IHouseView view, Player player, HouseType house)
        {
            this.view = view;
            this.player = player;
            this.house = house;
        }

        /// <summary>
        /// Increments the number of moves.
        /// </summary>
        public void IncrementNumberOfMoves()
        {
            this.player.NumberOfMoves++;
        }

        /// <summary>
        /// Populates the inventory.
        /// </summary>
        public void PopulateInventory()
        {
            this.view.Inventory.Clear();
            this.view.InventoryShortNames.Clear();
            foreach (InanimateObject obj in this.house.Rooms[TheHouseRoomData.LocationInventory].Items)
            {
                this.view.Inventory.Add(obj.Name);
                this.view.InventoryShortNames.Add(obj.ShortName);
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            SaveData saveData = new SaveData(this.player, this.house.Rooms);
            XmlSerializer serializerSaveData = new XmlSerializer(typeof(SaveData));
            using (TextWriter writer = new StreamWriter("housedata.txt"))
            {
                serializerSaveData.Serialize(writer, saveData);
            }

            this.view.Message = "Data saved";
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));

            // Reading the XML document requires a FileStream.
            using (Stream reader = new FileStream("housedata.txt", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                SaveData saveData = new SaveData();
                saveData = (SaveData)serializer.Deserialize(reader);
                reader.Close();
                this.player = saveData.Player;
                this.house.RestoreHouse(saveData.Rooms);
            }

            this.view.Message = "Data loaded";
        }

        /// <summary>
        /// Northes this instance.
        /// </summary>
        public bool North()
        {
            return this.ProcessMovement(Direction.North);
        }

        /// <summary>
        /// Southes this instance.
        /// </summary>
        public bool South()
        {
            return this.ProcessMovement(Direction.South);
        }

        /// <summary>
        /// Easts this instance.
        /// </summary>
        public bool East()
        {
            return this.ProcessMovement(Direction.East);
        }

        /// <summary>
        /// Wests this instance.
        /// </summary>
        public bool West()
        {
            return this.ProcessMovement(Direction.West);
        }

        /// <summary>
        /// Ups this instance.
        /// </summary>
        public bool Up()
        {
            return this.ProcessMovement(Direction.Up);
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public bool Down()
        {
            return this.ProcessMovement(Direction.Down);
        }

        /// <summary>
        /// Processes the movement.
        /// </summary>
        /// <param name="direction">The direction.</param>
        private bool ProcessMovement(Direction direction)
        {
            if (this.Move(direction))
            {
                this.view.ClearScreen = true;
                this.view.Message = String.Empty;
                this.Look(direction == Direction.Up || direction == Direction.Down);
                return true;
            }
            else
            {
                this.view.ClearScreen = false;
                this.view.Message = TheHouseData.DisallowedDirectionValue;
                return false;
            }
        }

        /// <summary>
        /// Moves in the specified direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>Boolean that indicates whether the movement was allowed or not.</returns>
        private bool Move(Direction direction)
        {
            Room roomCurrent = this.house.Rooms[this.player.Location];
            Elevator elevatorCurrent = roomCurrent as Elevator;
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.house.InanimateObjects[TheHouseObjectData.BatteriesShortName] as ConsumableObject;
            if (onOffObjectFlashlight.State == Switch.On)
            {
                consumableObjectBatteries.IncrementTimesUsed();
                if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    onOffObjectFlashlight.State = Switch.Off;
                }
            }

            if (direction == Direction.North || direction == Direction.East || direction == Direction.West || direction == Direction.South)
            {
                if (roomCurrent.Exits.Contains(direction))
                {
                    this.player.Location.RoomNumber = roomCurrent.Exits[direction].ExitDestination;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == Direction.Up)
            {
                if (elevatorCurrent != null && this.player.Location.Floor != Floor.ThirdFloor)
                {
                    this.player.Location.Floor++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == Direction.Down)
            {
                if (elevatorCurrent != null && this.player.Location.Floor != Floor.Basement)
                {
                    this.player.Location.Floor--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Brushes this instance.
        /// </summary>
        public void Brush()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            Room room = this.house.Rooms[this.player.Location];
            Adversary adversaryLeopard = this.house.Adversaries[TheHouseAdversaryData.LeopardShortName];
            PortableObject portableObjectBrush = this.house.InanimateObjects[TheHouseObjectData.BrushShortName] as PortableObject;

            // Trying to brush non adverasry?
            if (!this.house.Adversaries.Contains(this.view.Argument, false))
            {
                stringBuilderMessage.Append("You can't brush that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to brush adversary that is not in the room?
                stringBuilderMessage.Append("I see no ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" here");
            }
            else if (!this.house.Inventory.Contains(portableObjectBrush))
            {
                // Trying to brush adversary in the room but don't have a brush?
                stringBuilderMessage.Append("You have nothing with which to brush the ");
                stringBuilderMessage.Append(this.view.Argument);
            }
            else if (!this.house.Adversaries[this.view.Argument].Equals(adversaryLeopard))
            {
                // Trying to brush adversary in room with your brush but it's not the leopard?
                stringBuilderMessage.Append("The ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" will become angry if you persist!");
            }
            else
            {
                // Must be trying to brush the leopard in the room with the brush
                this.house.HideAdversary(adversaryLeopard, this.player.Location);
                stringBuilderMessage.Append("Purrrrrrr!!!!!!!!  The leopard is very gratified for the grooming and leaves");
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Digs this instance.
        /// </summary>
        public void Dig()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            Room room = this.house.Rooms[this.player.Location];
#if DEBUG
            ////this._player.Inventory.Add(this.house.InanimateObjects[TheHouseData.ShovelShortName]);
#endif
            if (String.Compare(this.view.Argument, "dirt", true, CultureInfo.CurrentCulture) != 0 && String.Compare(this.view.Argument, "floor", true, CultureInfo.CurrentCulture) != 0)
            {
                stringBuilderMessage.Append("You can't dig the ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(".");
            }
            else if (!(room is UnfinishedFlooredRoom))
            {
                stringBuilderMessage.Append("I see no dirt to dig here.");
            }
            else if (!this.house.Inventory.Contains(TheHouseObjectData.ShovelShortName))
            {
                stringBuilderMessage.Append("You don't have anything with which to dig.");
            }
            else
            {
                stringBuilderMessage.Append("Digging... ");
                foreach (InanimateObject inanimateObjectCurrent in room.Items)
                {
                    PortableObject portableObjectCurrent = inanimateObjectCurrent as PortableObject;
                    if (portableObjectCurrent != null && portableObjectCurrent.Buried == true)
                    {
                        portableObjectCurrent.Buried = false;
                        stringBuilderMessage.Append("I found something!");
                        break;
                    }
                }
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        //private void Light(string )
        /// <summary>
        /// Lights the specified state.
        /// </summary>
        public void Light()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            Switch switchDesiredState = Switch.Unknown;
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.house.InanimateObjects[TheHouseObjectData.BatteriesShortName] as ConsumableObject;
            if (String.IsNullOrEmpty(view.Argument))
            {
                if (onOffObjectFlashlight.State == Switch.On)
                    switchDesiredState = Switch.Off;
                else
                    switchDesiredState = Switch.On;
            }
            else
            {
                try
                {
                    switchDesiredState = (Switch)Enum.Parse(typeof(Switch), view.Argument, true);
                }
                catch (ArgumentException)
                {
                    switchDesiredState = Switch.Off;
                }
            }

            if (switchDesiredState == Switch.On)
            {
                if (!this.house.Inventory.Contains(onOffObjectFlashlight.Identity))
                {
                    stringBuilderMessage.Append("You have no light to turn on!");
                }
                else if (!this.house.Inventory.Contains(consumableObjectBatteries.Identity))
                {
                    stringBuilderMessage.Append("It doesn't work");
                }
                else if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    stringBuilderMessage.Append("The batteries are exhausted");
                }
                else
                {
                    onOffObjectFlashlight.State = Switch.On;
                    stringBuilderMessage.Append("Light on");
                    this.player.TimesLookedInDark = 0;
                }
            }
            else
            {
                if (!this.house.Inventory.Contains(onOffObjectFlashlight.Identity))
                {
                    stringBuilderMessage.Append("You have no light to turn off!");
                }
                else if (!this.house.Inventory.Contains(consumableObjectBatteries.Identity))
                {
                    stringBuilderMessage.Append("It doesn't work anyway -- so why turn it off!");
                }
                else if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    stringBuilderMessage.Append("The batteries are already dead!");
                }
                else
                {
                    onOffObjectFlashlight.State = Switch.Off;
                    stringBuilderMessage.Append("Light off");
                }
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Opens this instance.
        /// </summary>
        public void Open()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            LockableDoorObject lockableDoor = this.house.InanimateObjects[TheHouseObjectData.LockedDoorShortName] as LockableDoorObject;
            PortableObject portableObjectKey = this.house.PortableObjects[TheHouseObjectData.RustedKeyShortName] as PortableObject;
#if DEBUG
            /*
            if (!this._player.Inventory.Contains(portableObjectKey))
            {
                this._player.Inventory.Add(portableObjectKey);
            }
            */
#endif
            string stringShortenedArgument = this.view.Argument.Length > 2 ? this.view.Argument.Substring(0, 3) : this.view.Argument;
            if (String.Compare(stringShortenedArgument, lockableDoor.Identity, true, CultureInfo.CurrentCulture) != 0 && String.Compare(this.view.Argument, "drawer", true, CultureInfo.CurrentCulture) != 0)
            {
                stringBuilderMessage.Append("I'm sorry, I only know how to unlock doors and drawers.");
            }
            else if (String.Compare(stringShortenedArgument, "dra", true, CultureInfo.CurrentCulture) == 0)
            {
                stringBuilderMessage.Append("Show me a drawer and I'll open it!!!");
            }
            else if (!this.house.Rooms[this.player.Location].Items.Contains(lockableDoor))
            {
                stringBuilderMessage.Append("I see no door that needs opening!");
            }
            else if (!this.house.Inventory.Contains(portableObjectKey))
            {
                stringBuilderMessage.Append("I need something first!");
            }
            else
            {
                this.house.Rooms[this.player.Location].Items.Remove(lockableDoor);
                this.house.Rooms[this.player.Location].Exits.Add(new RoomExit(lockableDoor.ExitWhenUnlocked.ExitDirection, lockableDoor.ExitWhenUnlocked.ExitDestination));
                stringBuilderMessage.Append("<<<<C-L-I-C-K>>>>\r\nOK, it's open now");
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            PortableObject portableObjectBanjo = this.house.PortableObjects[TheHouseObjectData.BanjoShortName] as PortableObject;
            Adversary adversaryBeast = this.house.Adversaries[TheHouseAdversaryData.BeastShortName];
#if DEBUG
            ////this._player.Inventory.Add(portableObjectBanjo);
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.house.PortableObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
                inanimateObjectTarget = null;
            }

            if (inanimateObjectTarget == null || !inanimateObjectTarget.Equals(portableObjectBanjo))
            {
                stringBuilderMessage.Append("You can't play that!");
            }
            else if (!this.house.Inventory.Contains(portableObjectBanjo))
            {
                stringBuilderMessage.Append("You have no banjo to play");
            }
            else
            {
                // TODO: play sound
                if (this.house.Rooms[this.player.Location].Adversaries.Contains(adversaryBeast))
                {
                    this.house.HideAdversary(adversaryBeast, this.player.Location);
                    stringBuilderMessage.Append("Music hath charm to soothe the savage beast.  The beast wandered off in a state of bliss.");
                }
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        public void Read()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            PortableObject portableObjectSorcerersBook = this.house.InanimateObjects[TheHouseObjectData.BookShortName] as PortableObject;
            PortableObject portableObjectParchment = this.house.InanimateObjects[TheHouseObjectData.ParchmentShortName] as PortableObject;
#if DEBUG
            /*
            if (!this._player.Inventory.Contains(portableObjectSorcerersBook))
            {
                this._player.Inventory.Add(portableObjectSorcerersBook);
            }

            if (!this._player.Inventory.Contains(portableObjectParchment))
            {
                this._player.Inventory.Add(portableObjectParchment);
            }
            */
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.house.InanimateObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            if (inanimateObjectTarget == null || !(inanimateObjectTarget is PortableObject))
            {
                stringBuilderMessage.Append("You can't read that");
            }
            else if (!this.house.Inventory.Contains(inanimateObjectTarget))
            {
                stringBuilderMessage.Append("You don't have a ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" to read.");
            }
            else if (inanimateObjectTarget.Equals(portableObjectSorcerersBook))
            {
                stringBuilderMessage.Append("The writing is blurry -- it reads:\r\n");
                stringBuilderMessage.Append("magic words to make objects . . . one of the following.\r\n");
                string[] stringArrayMagicWords = Enum.GetNames(typeof(MagicWord));
                int intMagicWordCount = stringArrayMagicWords.Length;
                for (int i = 1; i < intMagicWordCount; i++)
                {
                    stringBuilderMessage.Append(stringArrayMagicWords[i]);
                    stringBuilderMessage.Append(Environment.NewLine);
                }

                stringBuilderMessage.Append("Note:  Be sure to use the right word in the . . .");
            }
            else if (inanimateObjectTarget.Equals(portableObjectParchment))
            {
                stringBuilderMessage.Append("The parchment is torn -- it reads:\r\n");
                stringBuilderMessage.Append(". . . is the place to use them:\r\n");
                foreach (Room room in this.house.Rooms.MagicRooms)
                {
                    stringBuilderMessage.Append(room.Name);
                    stringBuilderMessage.Append(Environment.NewLine);
                }

                // One non-magic decoy room to make things a little harder
                LocationType locationTypeDecoyRoom = new LocationType(0, Floor.ThirdFloor);
                stringBuilderMessage.Append(this.house.Rooms[locationTypeDecoyRoom].Name);
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Says this instance.
        /// </summary>
        public void Say()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            bool boolWordIsMagic = false;
            MagicWord theword = MagicWord.NA;
            try
            {
                theword = (MagicWord)Enum.Parse(typeof(MagicWord), this.view.Argument, true);
                boolWordIsMagic = true;
            }
            catch (ArgumentException)
            {
            }

            if (!boolWordIsMagic)
            {
                stringBuilderMessage.Append("Nothing happened");
            }
            else
            {
                if (this.house.Rooms[this.player.Location].Magic && this.house.Rooms[this.player.Location].MagicWordForRoom == theword)
                {
                    foreach (InanimateObject inanimateObjectCurrent in this.house.Rooms[this.player.Location].Items)
                    {
                        PortableObject portableObjectCurrent = inanimateObjectCurrent as PortableObject;
                        if (portableObjectCurrent != null && !portableObjectCurrent.Visible)
                        {
                            portableObjectCurrent.Visible = true;
                        }
                    }

                    stringBuilderMessage.Append("The air shimmers");
                }
                else if (this.house.Rooms[this.player.Location].Magic && this.house.Rooms[this.player.Location].MagicWordForRoom != theword)
                {
                    stringBuilderMessage.Append("You experience disortientation");
#if (DEBUG)
                    int intNewRoom = 2;
                    Floor floorNewFloor = Floor.FirstFloor;
#else
                    int intNewRoom = this.random.Next(10);
                    Floor floorNewFloor = (Floor)this.random.Next(4);
#endif
                    this.player.Location = new LocationType(intNewRoom, floorNewFloor);
                }
                else
                {
                    stringBuilderMessage.Append("Nothing happened");
                }
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Sprays this instance.
        /// </summary>
        public void Spray()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            ConsumableObject consumableObjectBugSpray = this.house.InanimateObjects[TheHouseObjectData.BugSprayShortName] as ConsumableObject;
            Adversary adversaryBlob = this.house.Adversaries[TheHouseAdversaryData.BlobShortName];
#if DEBUG
            /*
            if (!this._player.Inventory.Contains(consumableObjectBugSpray))
            {
                this._player.Inventory.Add(consumableObjectBugSpray);
            }
            */
#endif
            Room room = this.house.Rooms[this.player.Location];

            // Trying to spray adversary in the room but don't have the spray?
            if (!this.house.Inventory.Contains(consumableObjectBugSpray))
            {
                stringBuilderMessage.Append("You have nothing with which to spray the ");
                stringBuilderMessage.Append(this.view.Argument);
            }
            else if (!this.house.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to brush non adverasry?
                stringBuilderMessage.Append("You can't spray that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to spray adversary that is not in the room?
                stringBuilderMessage.Append("I see no ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" here");
            }
            else if (consumableObjectBugSpray.TimesUsed >= consumableObjectBugSpray.UsageLimit)
            {
                stringBuilderMessage.Append("The can is empty");
            }
            else if (!this.house.Adversaries[this.view.Argument].Equals(adversaryBlob))
            {
                // Trying to spray adversary in room with your spray but it's not the blob?
                consumableObjectBugSpray.IncrementTimesUsed();
                stringBuilderMessage.Append("The ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" will become angry if you persist!");
            }
            else
            {
                // Must be trying to spray the blob in the room that has the blob
                consumableObjectBugSpray.IncrementTimesUsed();
                this.house.HideAdversary(adversaryBlob, this.player.Location);
                stringBuilderMessage.Append("Blob runs away");
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Stabs this instance.
        /// </summary>
        public void Stab()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            Room room = this.house.Rooms[this.player.Location];
            PortableObject portableObjectKnife = this.house.PortableObjects[TheHouseObjectData.KnifeShortName] as PortableObject;
            Adversary adversaryMonk = this.house.Adversaries[TheHouseAdversaryData.MonkShortName];
            Adversary adversaryTarget = null;
            try
            {
                adversaryTarget = this.house.Adversaries[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            if (!this.house.Adversaries.Contains(this.view.Argument, false))
            {
                stringBuilderMessage.Append("You can't kill that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                stringBuilderMessage.Append("I see no ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" here");
            }
            else if (!this.house.Inventory.Contains(portableObjectKnife))
            {
                stringBuilderMessage.Append("You have nothing with which to kill the ");
                stringBuilderMessage.Append(this.view.Argument);
            }
            else if (!adversaryTarget.Equals(adversaryMonk))
            {
                stringBuilderMessage.Append("The ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" will become angry if you persist!");
            }
            else
            {
                this.house.HideAdversary(adversaryMonk, this.player.Location);
                stringBuilderMessage.Append("Monk has run away");
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Waves this instance.
        /// </summary>
        public void Wave()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            Room room = this.house.Rooms[this.player.Location];
            PortableObject portableObjectGarlic = this.house.InanimateObjects[TheHouseObjectData.GarlicShortName] as PortableObject;
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName] as OnOffObject;
            Adversary adversaryVampire = this.house.Adversaries[TheHouseAdversaryData.VampireShortName];
            Adversary adversaryWerewolf = this.house.Adversaries[TheHouseAdversaryData.WerewolfShortName];

#if DEBUG
            /*
            ConsumableObject consumableObjectBatteries = this.house.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
            if (!this._player.Inventory.Contains(portableObjectGarlic))
            {
                this._player.Inventory.Add(portableObjectGarlic);
            }

            if (!this._player.Inventory.Contains(onOffObjectFlashlight))
            {
                this._player.Inventory.Add(onOffObjectFlashlight);
            }

            if (!this._player.Inventory.Contains(consumableObjectBatteries))
            {
                this._player.Inventory.Add(consumableObjectBatteries);
            }
            */
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.house.InanimateObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            if (inanimateObjectTarget == null || !(inanimateObjectTarget is PortableObject))
            {
                // is not portable?
                stringBuilderMessage.Append("You can't wave that.");
            }
            else if (!this.house.Inventory.Contains(inanimateObjectTarget))
            {
                // is not in inventory?
                stringBuilderMessage.Append("You don't have a ");
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" to wave.");
            }
            else if (!(inanimateObjectTarget.Equals(portableObjectGarlic) || inanimateObjectTarget.Equals(onOffObjectFlashlight)))
            {
                // is not light nor garlic?
                stringBuilderMessage.Append("That was fun.");
            }
            else if (inanimateObjectTarget.Equals(onOffObjectFlashlight) && onOffObjectFlashlight.State == Switch.On && room.Adversaries.Contains(adversaryVampire))
            {
                // is light and vamp in room and light on?
                stringBuilderMessage.Append("The vampire has fled.");
                this.house.HideAdversary(adversaryVampire, this.player.Location);
            }
            else if (inanimateObjectTarget.Equals(portableObjectGarlic) && room.Adversaries.Contains(adversaryWerewolf))
            {
                // is garlic and ware in room?
                stringBuilderMessage.Append("The warewolf has fled.");
                this.house.HideAdversary(adversaryWerewolf, this.player.Location);
            }
            else
            {
                // otherwise "no effect"
                stringBuilderMessage.Append("It had no effect");
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Quits this instance.
        /// </summary>
        public void Quit()
        {
            this.view.Message = String.Format(CultureInfo.CurrentCulture, "You got {0} items out of the house in {1} moves", this.player.ItemsRemovedFromHouse, this.player.NumberOfMoves);
            this.view.GameEnded = true;
        }

        /// <summary>
        /// Drops this instance.
        /// </summary>
        public void Drop()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            InanimateObject inanimateObjectTarget = null;
            this.view.GameEnded = false;
            InanimateObjectsCollection multiplePieceObjectsInInventory = new InanimateObjectsCollection();
            try
            {
                inanimateObjectTarget = this.house.InanimateObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            PortableObject portableObjectTarget = inanimateObjectTarget as PortableObject;
            if (inanimateObjectTarget == null || portableObjectTarget == null)
            {
                stringBuilderMessage.Append("You can't drop that");
            }
            else if (!this.house.Inventory.Contains(inanimateObjectTarget.ToString()))
            {
                stringBuilderMessage.Append("You don't have a ");
                stringBuilderMessage.Append(this.view.Argument);
            }
            else if (inanimateObjectTarget.Equals(this.house.InanimateObjects[TheHouseObjectData.BatteriesShortName]) || inanimateObjectTarget.Equals(this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName]))
            {
                OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName] as OnOffObject;
                onOffObjectFlashlight.State = Switch.Off;
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" dropped");
            }
            else if (inanimateObjectTarget is ContainerObject && this.house.Inventory.ContainsByType(typeof(MultiplePieceObject), multiplePieceObjectsInInventory))
            {
                stringBuilderMessage.Append("Try dropping the following items first:  ");
                int intCount = 0;
                foreach (InanimateObject mpo in multiplePieceObjectsInInventory)
                {
                    stringBuilderMessage.Append(mpo.Name);
                    intCount++;
                    if (intCount < multiplePieceObjectsInInventory.Count)
                    {
                        stringBuilderMessage.Append(", ");
                    }
                }
            }
            else if (inanimateObjectTarget is ProtectiveObject && this.house.Inventory.ContainsByType(typeof(PainfulObject)))
            {
                stringBuilderMessage.Append("You'll hurt yourself");
            }
            else if (inanimateObjectTarget is DelicateObject && !this.house.Rooms[this.player.Location].Items.ContainsByType(typeof(CushioningObject)))
            {
                stringBuilderMessage.Append("It will break");
            }
            else
            {
                //PortableObject portableObject = inanimateObjectTarget as PortableObject;
                this.house.RemoveFromInventory(portableObjectTarget, this.player.Location);
                //                    this._player.Inventory.Remove(inanimateObjectTarget.ToString());
                //                    this.house.Rooms[this._player.Location].Items.Add(inanimateObjectTarget);
                stringBuilderMessage.Append(this.view.Argument);
                stringBuilderMessage.Append(" dropped");
                if (this.player.Location.Equals(TheHouseRoomData.LocationFirstFloorFrontPorch))
                {
                    this.player.ItemsRemovedFromHouse++;
                    if (this.player.ItemsRemovedFromHouse == this.house.PortableObjects.Count)
                    {
                        this.view.GameEnded = true;
                        stringBuilderMessage.Append(String.Format(CultureInfo.CurrentCulture, "Congratulations--you have successfully completed House Adventure \r\nYou removed all 20 objects in {0} moves", player.NumberOfMoves));
                    }
                }
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        public void Get()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            this.view.ClearScreen = false;
            PortableObject portableObjectTarget = null;
            Room room = this.house.Rooms[this.player.Location];
            this.view.GameEnded = false;

            // Trying to pick up known object?
            try
            {
                portableObjectTarget = this.house.InanimateObjects[this.view.Argument] as PortableObject;
            }
            catch (KeyNotFoundException)
            {
                portableObjectTarget = null;
            }

            // Is a known portable item
            if (portableObjectTarget != null)
            {
                // Item not in room or item in room but buried or invisible
                if (!this.house.Rooms[this.player.Location].Items.Contains(portableObjectTarget) || (this.house.Rooms[this.player.Location].Items.Contains(portableObjectTarget) && (portableObjectTarget.Buried || !portableObjectTarget.Visible)))
                {
                    // Impostor in room and its name is the same as the target item
                    if (portableObjectTarget.Equals(this.house.Adversaries.TheImpostor) && this.house.Rooms[this.player.Location].Adversaries.Contains(this.house.Adversaries.TheImpostor))
                    {
                        this.view.GameEnded = true;
                        stringBuilderMessage.Append("Aughhhh . . .\r\n\r\nRemember?!");
                    }
                    else
                    {
                        // Nothing by that name is in the room
                        stringBuilderMessage.Append("I see no ");
                        stringBuilderMessage.Append(this.view.Argument);
                        stringBuilderMessage.Append(" here");
                    }
                }
                else if (this.house.Rooms[this.player.Location].Adversaries.ContainsNonImpostor())
                {
                    // Room has an adversary that is not the imposter
                    stringBuilderMessage.Append("This room's occupant seems to have grown very attached to the ");
                    stringBuilderMessage.Append(this.view.Argument);
                    stringBuilderMessage.Append(" and won't let you have it");
                }
                else if (this.house.Inventory.Count < TheHouseData.MaximumInventoryItems)
                {
                    if (portableObjectTarget is MultiplePieceObject)
                    {
                        if (this.house.Inventory.ContainsByType(typeof(ContainerObject)))
                        {
                            this.house.AddToInventory(portableObjectTarget);
                            //room.Items.Remove(portableObjectTarget);
                        }
                        else
                        {
                            stringBuilderMessage.Append("You can't pick up that many small items!");
                        }
                    }
                    else if (portableObjectTarget is PainfulObject)
                    {
                        bool boolHasProtectiveItem = false;
                        foreach (InanimateObject inanimateObject in this.house.Inventory)
                        {
                            if (inanimateObject is ProtectiveObject)
                            {
                                boolHasProtectiveItem = true;
                            }
                        }

                        if (boolHasProtectiveItem)
                        {
                            this.house.AddToInventory(portableObjectTarget);
                            //room.Items.Remove(portableObjectTarget);
                        }
                        else
                        {
                            stringBuilderMessage.Append("Ouch! That hurts! You can't pick that up!");
                        }
                    }
                    else
                    {
                        this.house.AddToInventory(portableObjectTarget);
                        //                        this._player.Inventory.Add(portableObjectTarget);
                        //                      room.Items.Remove(portableObjectTarget);
                        stringBuilderMessage.Append(this.view.Argument);
                        stringBuilderMessage.Append(" taken");
                    }
                }
                else
                {
                    stringBuilderMessage.Append("You can't carry that much.  You'll have to drop something.");
                }
            }
            else
            {
                stringBuilderMessage.Append("You can't take the ");
                stringBuilderMessage.Append(this.view.Argument);
            }

            this.view.Message = stringBuilderMessage.ToString();
        }

        /// <summary>
        /// Looks in the current room.
        /// </summary>
        public void Look()
        {
            this.Look(false);
        }

        /// <summary>
        /// Looks in the current room.
        /// </summary>
        private void Look(bool afterVerticalMovement)
        {
            Room room = this.house.Rooms[this.player.Location];
            this.view.GameEnded = false;
            this.view.ClearScreen = true;
            this.view.ExitDirections.Clear();
            this.view.AdversariesInRoom.Clear();
            this.view.ItemsInRoom.Clear();
            this.view.ItemsInRoomShortNames.Clear();
            this.view.RoomName = String.Empty;
            StringBuilder stringBuilderMessage = new StringBuilder();
            bool boolInTelephoneBooth = room as TelephoneBooth != null;
            if (!afterVerticalMovement && this.house.Inventory.Contains(TheHouseObjectData.DimeShortName) && boolInTelephoneBooth)
            {
#if (DEBUG)
                if (this.player.Location.Floor == Floor.ThirdFloor)
                    this.player.Location.Floor = Floor.SecondFloor;
                else
                    this.player.Location.Floor = Floor.ThirdFloor;
#else
                this.player.Location.Floor = (Floor)this.random.Next(4);
#endif
                room = this.house.Rooms[this.player.Location];
            }

            this.view.RoomName = room.Name;
#if (DEBUG)
            this.house.RemoveFrontPorchItems();
            this.house.UpdateMonstersInHangout();
#else
            if (this.random.Next(50) < 10)
            {
                this.house.RemoveFrontPorchItems();
            }

            if (this.random.Next(50) < 40)
            {
                this.house.UpdateMonstersInHangout();
            }
#endif
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName] as OnOffObject;
            if (this.player.Location.Floor == Floor.Basement && onOffObjectFlashlight.State == Switch.Off)
            {
                stringBuilderMessage.Append("nothing--it's too dark!");
                this.player.TimesLookedInDark++;
                if (this.player.TimesLookedInDark > TheHouseData.MaximumLooksInDark)
                {
                    stringBuilderMessage.Append("Aughhhh . . .\r\nBeware of things unseen !!");
                    this.view.GameEnded = true;
                }
            }
            else
            {
                foreach (Adversary adversary in room.Adversaries)
                {
                    this.view.AdversariesInRoom.Add(adversary.Name);
                }

                foreach (InanimateObject inanimateObject in room.Items)
                {
                    PortableObject portableObject = inanimateObject as PortableObject;
                    if (portableObject == null)
                    {
                        // If it's a stationary object
                        this.view.ItemsInRoom.Add(inanimateObject.Name);
                        this.view.ItemsInRoomShortNames.Add(inanimateObject.ShortName);
                    }
                    else if (portableObject.Visible && !portableObject.Buried)
                    {
                        this.view.ItemsInRoom.Add(inanimateObject.Name);
                        this.view.ItemsInRoomShortNames.Add(inanimateObject.ShortName);
                    }
                }

                foreach (RoomExit exit in room.Exits)
                {
                    this.view.ExitDirections.Add(exit.ExitDirection.ToString());
                }
            }

            this.view.Message = stringBuilderMessage.ToString();
        }
    }
}
