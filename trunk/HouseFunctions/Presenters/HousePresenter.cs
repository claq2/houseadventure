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
        //TODO: Add inventory function.
        //TODO: Make views call the inventory function

        private Random random = new Random();
        private IHouseView view;
        
        //TODO:  Move house objects or fields into the presenter

        private Player player;

        private HouseType house;

        /// <summary>
        /// Initializes a new instance of the <see cref="HousePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public HousePresenter(IHouseView view):this(view, new Player(), new HouseType(true))
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
            foreach (InanimateObject obj in this.house.Rooms[TheHouseRoomData.LocationInventory].Items)
            {
                this.view.Inventory.Add(obj.Name);
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

            this.view.Message = new StringBuilder();
            this.view.Message.Append("Data saved");
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

            this.view.Message = new StringBuilder();
            this.view.Message.Append("Data loaded");
        }

        /// <summary>
        /// Northes this instance.
        /// </summary>
        public void North()
        {
            this.ProcessMovement(Direction.North);
        }

        /// <summary>
        /// Southes this instance.
        /// </summary>
        public void South()
        {
            this.ProcessMovement(Direction.South);
        }

        /// <summary>
        /// Easts this instance.
        /// </summary>
        public void East()
        {
            this.ProcessMovement(Direction.East);
        }

        /// <summary>
        /// Wests this instance.
        /// </summary>
        public void West()
        {
            this.ProcessMovement(Direction.West);
        }

        /// <summary>
        /// Ups this instance.
        /// </summary>
        public void Up()
        {
            this.ProcessMovement(Direction.Up);
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public void Down()
        {
            this.ProcessMovement(Direction.Down);
        }

        /// <summary>
        /// Processes the movement.
        /// </summary>
        /// <param name="direction">The direction.</param>
        private void ProcessMovement(Direction direction)
        {
            bool verticalMovement = direction == Direction.Up || direction == Direction.Down;
            if (this.Move(direction))
            {
                this.view.ClearScreen = true;
                this.view.Message = new StringBuilder();
                //// this.Look(verticalMovement);
            }
            else
            {
                this.view.ClearScreen = false;
                this.view.Message = new StringBuilder();
                this.view.Message.Append(TheHouseData.DisallowedDirectionValue);
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
            if (direction == Direction.North || direction == Direction.East || direction == Direction.West || direction == Direction.South)
            {
                if (onOffObjectFlashlight.State == Switch.On)
                {
                    consumableObjectBatteries.IncrementTimesUsed();
                    if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                    {
                        onOffObjectFlashlight.State = Switch.Off;
                    }
                }

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
            this.view.Message = new StringBuilder();
            Room room = this.house.Rooms[this.player.Location];
            Adversary adversaryLeopard = this.house.Adversaries[TheHouseAdversaryData.LeopardShortName];
            PortableObject portableObjectBrush = this.house.InanimateObjects[TheHouseObjectData.BrushShortName] as PortableObject;
            this.view.Message = new StringBuilder();

            // Trying to brush non adverasry?
            if (!this.house.Adversaries.Contains(this.view.Argument, false))
            {
                this.view.Message.Append("You can't brush that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to brush adversary that is not in the room?
                this.view.Message.Append("I see no ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" here");
            }
            else if (!this.house.Inventory.Contains(portableObjectBrush))
            {
                // Trying to brush adversary in the room but don't have a brush?
                this.view.Message.Append("You have nothing with which to brush the ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (!this.house.Adversaries[this.view.Argument].Equals(adversaryLeopard))
            {
                // Trying to brush adversary in room with your brush but it's not the leopard?
                this.view.Message.Append("The ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" will become angry if you persist!");
            }
            else
            {
                // Must be trying to brush the leopard in the room with the brush
                this.house.HideAdversary(adversaryLeopard, this.player.Location);
                this.view.Message.Append("Purrrrrrr!!!!!!!!  The leopard is very gratified for the grooming and leaves");
            }
        }

        /// <summary>
        /// Digs this instance.
        /// </summary>
        public void Dig()
        {
            this.view.Message = new StringBuilder();
            Room room = this.house.Rooms[this.player.Location];
#if DEBUG
            ////this._player.Inventory.Add(this.house.InanimateObjects[TheHouseData.ShovelShortName]);
#endif
            if (String.Compare(this.view.Argument, "dirt", true, CultureInfo.CurrentCulture) != 0 && String.Compare(this.view.Argument, "floor", true, CultureInfo.CurrentCulture) != 0)
            {
                this.view.Message.Append("You can't dig the ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(".");
            }
            else if (!(room is UnfinishedFlooredRoom))
            {
                this.view.Message.Append("I see no dirt to dig here.");
            }
            else if (!this.house.Inventory.Contains(TheHouseObjectData.ShovelShortName))
            {
                this.view.Message.Append("You don't have anything with which to dig.");
            }
            else
            {
                this.view.Message.Append("Digging... ");
                foreach (InanimateObject inanimateObjectCurrent in room.Items)
                {
                    PortableObject portableObjectCurrent = inanimateObjectCurrent as PortableObject;
                    if (portableObjectCurrent != null && portableObjectCurrent.Buried == true)
                    {
                        portableObjectCurrent.Buried = false;
                        this.view.Message.Append("I found something!");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Lights the specified state.
        /// </summary>
        public void Light()
        {
            this.view.Message = new StringBuilder();
            Switch state = 0;
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.house.InanimateObjects[TheHouseObjectData.BatteriesShortName] as ConsumableObject;
            if (String.IsNullOrEmpty(view.Argument))
            {
                state = Switch.On;
                if (onOffObjectFlashlight.State == Switch.On)
                {
                    state = Switch.Off;
                }
            }
            else
            {
                try
                {
                    state = (Switch)Enum.Parse(typeof(Switch), view.Argument, true);
                }
                catch (ArgumentException)
                {
                    state = Switch.Off;
                }
            }

            if (state == Switch.On)
            {
                if (!this.house.Inventory.Contains(onOffObjectFlashlight.Identity))
                {
                    this.view.Message.Append("You have no light to turn on!");
                }
                else if (!this.house.Inventory.Contains(consumableObjectBatteries.Identity))
                {
                    this.view.Message.Append("It doesn't work");
                }
                else if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    this.view.Message.Append("The batteries are exhausted");
                }
                else
                {
                    onOffObjectFlashlight.State = Switch.On;
                    this.view.Message.Append("Light on");
                    this.player.TimesLookedInDark = 0;
                }
            }
            else
            {
                if (!this.house.Inventory.Contains(onOffObjectFlashlight.Identity))
                {
                    this.view.Message.Append("You have no light to turn off!");
                }
                else if (!this.house.Inventory.Contains(consumableObjectBatteries.Identity))
                {
                    this.view.Message.Append("It doesn't work anyway -- so why turn it off!");
                }
                else if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    this.view.Message.Append("The batteries are already dead!");
                }
                else
                {
                    onOffObjectFlashlight.State = Switch.Off;
                    this.view.Message.Append("Light off");
                }
            }
        }

        /// <summary>
        /// Opens this instance.
        /// </summary>
        public void Open()
        {
            this.view.Message = new StringBuilder();
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
            if (String.Compare(this.view.Argument, lockableDoor.Identity, true, CultureInfo.CurrentCulture) != 0 && String.Compare(this.view.Argument, "drawer", true, CultureInfo.CurrentCulture) != 0)
            {
                this.view.Message.Append("I'm sorry, I only know how to unlock doors and drawers.");
            }
            else if (String.Compare(this.view.Argument, "drawer", true, CultureInfo.CurrentCulture) == 0)
            {
                this.view.Message.Append("Show me a drawer and I'll open it!!!");
            }
            else if (!this.house.Rooms[this.player.Location].Items.Contains(lockableDoor))
            {
                this.view.Message.Append("I see no door that needs opening!");
            }
            else if (!this.house.Inventory.Contains(portableObjectKey))
            {
                this.view.Message.Append("I need something first!");
            }
            else
            {
                this.house.Rooms[this.player.Location].Items.Remove(lockableDoor);
                this.house.Rooms[this.player.Location].Exits.Add(new RoomExit(lockableDoor.ExitWhenUnlocked.ExitDirection, lockableDoor.ExitWhenUnlocked.ExitDestination));
                this.view.Message.Append("<<<<C-L-I-C-K>>>>\r\nOK, it's open now");
            }
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            this.view.Message = new StringBuilder();
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
                this.view.Message.Append("You can't play that!");
            }
            else if (!this.house.Inventory.Contains(portableObjectBanjo))
            {
                this.view.Message.Append("You have no banjo to play");
            }
            else
            {
                // TODO: play sound
                if (this.house.Rooms[this.player.Location].Adversaries.Contains(adversaryBeast))
                {
                    this.house.HideAdversary(adversaryBeast, this.player.Location);
                    this.view.Message.Append("Music hath charm to soothe the savage beast.  The beast wandered off in a state of bliss.");
                }
            }
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        public void Read()
        {
            this.view.Message = new StringBuilder();
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
                this.view.Message.Append("You can't read that");
            }
            else if (!this.house.Inventory.Contains(inanimateObjectTarget))
            {
                this.view.Message.Append("You don't have a ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" to read.");
            }
            else if (inanimateObjectTarget.Equals(portableObjectSorcerersBook))
            {
                this.view.Message.Append("The writing is blurry -- it reads:\r\n");
                this.view.Message.Append("magic words to make objects . . . one of the following.\r\n");
                string[] stringArrayMagicWords = Enum.GetNames(typeof(MagicWord));
                int intMagicWordCount = stringArrayMagicWords.Length;
                for (int i = 1; i < intMagicWordCount; i++)
                {
                    this.view.Message.Append(stringArrayMagicWords[i]);
                    this.view.Message.Append(Environment.NewLine);
                }

                this.view.Message.Append("Note:  Be sure to use the right word in the . . .");
            }
            else if (inanimateObjectTarget.Equals(portableObjectParchment))
            {
                this.view.Message.Append("The parchment is torn -- it reads:\r\n");
                this.view.Message.Append(". . . is the place to use them:\r\n");
                foreach (Room room in this.house.Rooms.MagicRooms)
                {
                    this.view.Message.Append(room.Name);
                    this.view.Message.Append(Environment.NewLine);
                }

                // One non-magic decoy room to make things a little harder
                LocationType locationTypeDecoyRoom = new LocationType(0, Floor.ThirdFloor);
                this.view.Message.Append(this.house.Rooms[locationTypeDecoyRoom].Name);
            }
        }

        /// <summary>
        /// Says this instance.
        /// </summary>
        public void Say()
        {
            this.view.Message = new StringBuilder();
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
                this.view.Message.Append("Nothing happened");
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

                    this.view.Message.Append("The air shimmers");
                }
                else if (this.house.Rooms[this.player.Location].Magic && this.house.Rooms[this.player.Location].MagicWordForRoom != theword)
                {
                    this.view.Message.Append("You experience disortientation");
                    this.player.Location = new LocationType(this.random.Next(10), (Floor)this.random.Next(4));
                }
                else
                {
                    this.view.Message.Append("Nothing happened");
                }
            }
        }

        /// <summary>
        /// Sprays this instance.
        /// </summary>
        public void Spray()
        {
            this.view.Message = new StringBuilder();
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
                this.view.Message.Append("You have nothing with which to spray the ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (!this.house.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to brush non adverasry?
                this.view.Message.Append("You can't spray that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to spray adversary that is not in the room?
                this.view.Message.Append("I see no ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" here");
            }
            else if (consumableObjectBugSpray.TimesUsed >= consumableObjectBugSpray.UsageLimit)
            {
                this.view.Message.Append("The can is empty");
            }
            else if (!this.house.Adversaries[this.view.Argument].Equals(adversaryBlob))
            {
                // Trying to spray adversary in room with your spray but it's not the blob?
                consumableObjectBugSpray.IncrementTimesUsed();
                this.view.Message.Append("The ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" will become angry if you persist!");
            }
            else
            {
                // Must be trying to spray the blob in the room that has the blob
                consumableObjectBugSpray.IncrementTimesUsed();
                this.house.HideAdversary(adversaryBlob, this.player.Location);
                this.view.Message.Append("Blob runs away");
            }
        }

        /// <summary>
        /// Stabs this instance.
        /// </summary>
        public void Stab()
        {
            this.view.Message = new StringBuilder();
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
                this.view.Message.Append("You can't kill that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                this.view.Message.Append("I see no ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" here");
            }
            else if (!this.house.Inventory.Contains(portableObjectKnife))
            {
                this.view.Message.Append("You have nothing with which to kill the ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (!adversaryTarget.Equals(adversaryMonk))
            {
                this.view.Message.Append("The ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" will become angry if you persist!");
            }
            else
            {
                this.house.HideAdversary(adversaryMonk, this.player.Location);
                this.view.Message.Append("Monk has run away");
            }
        }

        /// <summary>
        /// Waves this instance.
        /// </summary>
        public void Wave()
        {
            this.view.Message = new StringBuilder();
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
                this.view.Message.Append("You can't wave that.");
            }
            else if (!this.house.Inventory.Contains(inanimateObjectTarget))
            {
                // is not in inventory?
                this.view.Message.Append("You don't have a ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" to wave.");
            }
            else if (!(inanimateObjectTarget.Equals(portableObjectGarlic) || inanimateObjectTarget.Equals(onOffObjectFlashlight)))
            {
                // is not light nor garlic?
                this.view.Message.Append("That was fun.");
            }
            else if (inanimateObjectTarget.Equals(onOffObjectFlashlight) && onOffObjectFlashlight.State == Switch.On && room.Adversaries.Contains(adversaryVampire))
            {
                // is light and vamp in room and light on?
                this.view.Message.Append("The vampire has fled.");
                this.house.HideAdversary(adversaryVampire, this.player.Location);
            }
            else if (inanimateObjectTarget.Equals(portableObjectGarlic) && room.Adversaries.Contains(adversaryWerewolf))
            {
                // is garlic and ware in room?
                this.view.Message.Append("The warewolf has fled.");
                this.house.HideAdversary(adversaryWerewolf, this.player.Location);
            }
            else
            {
                // otherwise "no effect"
                this.view.Message.Append("It had no effect");
            }
        }

        /// <summary>
        /// Quits this instance.
        /// </summary>
        public void Quit()
        {
            this.view.Message = new StringBuilder();
            this.view.Message.Append(String.Format(CultureInfo.CurrentCulture, "You got {0} items out of the house in {1} moves", this.player.ItemsRemovedFromHouse, this.player.NumberOfMoves));
            this.view.GameEnded = true;
        }

        /// <summary>
        /// Drops this instance.
        /// </summary>
        public void Drop()
        {
            this.view.Message = new StringBuilder();
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
                this.view.Message.Append("You can't drop that");
            }
            else if (!this.house.Inventory.Contains(inanimateObjectTarget.ToString()))
            {
                this.view.Message.Append("You don't have a ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (inanimateObjectTarget.Equals(this.house.InanimateObjects[TheHouseObjectData.BatteriesShortName]) || inanimateObjectTarget.Equals(this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName]))
            {
                string stringArgumentBackup = this.view.Argument;
                StringBuilder stringBuilderMessageBackup = this.view.Message;
                bool boolClearScreenBackup = this.view.ClearScreen;
                HousePresenter argumentActionPresenter = new HousePresenter(this.view);
                this.view.Argument = "off";
                argumentActionPresenter.Light();
                this.view.Argument = stringArgumentBackup;
                this.view.Message = stringBuilderMessageBackup;
                this.view.ClearScreen = boolClearScreenBackup;
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" dropped");
            }
            else if (inanimateObjectTarget is ContainerObject && this.house.Inventory.ContainsByType(typeof(MultiplePieceObject), multiplePieceObjectsInInventory))
            {
                this.view.Message.Append("Try dropping the following items first:  ");
                int intCount = 0;
                foreach (InanimateObject mpo in multiplePieceObjectsInInventory)
                {
                    this.view.Message.Append(mpo.Name);
                    intCount++;
                    if (intCount < multiplePieceObjectsInInventory.Count)
                    {
                        this.view.Message.Append(", ");
                    }
                }
            }
            else if (inanimateObjectTarget is ProtectiveObject && this.house.Inventory.ContainsByType(typeof(PainfulObject)))
            {
                this.view.Message.Append("You'll hurt yourself");
            }
            else if (inanimateObjectTarget is DelicateObject && !this.house.Rooms[this.player.Location].Items.ContainsByType(typeof(CushioningObject)))
            {
                this.view.Message.Append("It will break");
            }
            else
            {
                //PortableObject portableObject = inanimateObjectTarget as PortableObject;
                this.house.RemoveFromInventory(portableObjectTarget, this.player.Location);
                //                    this._player.Inventory.Remove(inanimateObjectTarget.ToString());
                //                    this.house.Rooms[this._player.Location].Items.Add(inanimateObjectTarget);
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" dropped");
                if (this.player.Location.Equals(TheHouseRoomData.LocationFirstFloorFrontPorch))
                {
                    this.player.ItemsRemovedFromHouse++;
                    if (this.player.ItemsRemovedFromHouse == this.house.PortableObjects.Count)
                    {
                        this.view.GameEnded = true;
                        this.view.Message = new StringBuilder();
                        this.view.Message.Append(String.Format(CultureInfo.CurrentCulture, "Congratulations--you have successfully completed House Adventure \r\nYou removed all 20 objects in {0} moves", player.NumberOfMoves));
                    }
                }
            }
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        public void Get()
        {
            this.view.Message = new StringBuilder();
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
                        this.view.Message.Append("Aughhhh . . .\r\n\r\nRemember?!");
                    }
                    else
                    {
                        // Nothing by that name is in the room
                        this.view.Message.Append("I see no ");
                        this.view.Message.Append(this.view.Argument);
                        this.view.Message.Append(" here");
                    }
                }
                else if (this.house.Rooms[this.player.Location].Adversaries.ContainsNonImpostor())
                {
                    // Room has an adversary that is not the imposter
                    this.view.Message.Append("This room's occupant seems to have grown very attached to the ");
                    this.view.Message.Append(this.view.Argument);
                    this.view.Message.Append(" and won't let you have it");
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
                            this.view.Message.Append("You can't pick up that many small items!");
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
                            this.view.Message.Append("Ouch! That hurts! You can't pick that up!");
                        }
                    }
                    else
                    {
                        this.house.AddToInventory(portableObjectTarget);
                        //                        this._player.Inventory.Add(portableObjectTarget);
                        //                      room.Items.Remove(portableObjectTarget);
                        this.view.Message.Append(this.view.Argument);
                        this.view.Message.Append(" taken");
                    }
                }
                else
                {
                    this.view.Message.Append("You can't carry that much.  You'll have to drop something.");
                }
            }
            else
            {
                this.view.Message.Append("You can't take the ");
                this.view.Message.Append(this.view.Argument);
            }
        }

        /// <summary>
        /// Looks in the current room.
        /// </summary>
        public void Look()
        {
            Room room = this.house.Rooms[this.player.Location];
            this.view.GameEnded = false;
            this.view.ClearScreen = true;
            this.view.ExitDirections.Clear();
            this.view.AdversariesInRoom.Clear();
            this.view.ItemsInRoom.Clear();
            this.view.RoomName = String.Empty;
            this.view.Message = new StringBuilder();
            TelephoneBooth telephoneBooth = room as TelephoneBooth;
            if (!this.view.AfterVerticalMovement && this.house.Inventory.Contains(TheHouseObjectData.DimeShortName) && telephoneBooth != null)
            {
                this.player.Location.Floor = (Floor)this.random.Next(4);
                room = this.house.Rooms[this.player.Location];
            }

            this.view.RoomName = room.Name;
            if (this.random.Next(50) < 10)
            {
                this.house.RemoveFrontPorchItems();
            }

            if (this.random.Next(50) < 40)
            {
                this.house.UpdateMonstersInHangout();
            }

            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[TheHouseObjectData.FlashlightShortName] as OnOffObject;
            if (this.player.Location.Floor == Floor.Basement && onOffObjectFlashlight.State == Switch.Off)
            {
                this.view.Message.Append("nothing--it's too dark!");
                this.player.TimesLookedInDark++;
                if (this.player.TimesLookedInDark > TheHouseData.MaximumLooksInDark)
                {
                    this.view.Message.Append("Aughhhh . . .\r\nBeware of things unseen !!");
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
                    }
                    else if (portableObject.Visible && !portableObject.Buried)
                    {
                        this.view.ItemsInRoom.Add(inanimateObject.Name);
                    }
                }

                foreach (RoomExit exit in room.Exits)
                {
                    this.view.ExitDirections.Add(exit.ExitDirection.ToString());
                }
            }
        }
    }
}
