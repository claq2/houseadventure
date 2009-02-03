namespace HouseCore.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    using HouseCore;
    using HouseCore.Interfaces;

    /// <summary>
    /// The functions that can be done in the house
    /// </summary>
    public class HousePresenter
    {
        private IHouseView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="HousePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public HousePresenter(IHouseView view)
        {
            this.view = view;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            SaveData saveData = new SaveData(this.view);
            StringBuilder stringBuilderOutput = new StringBuilder();
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
            StringBuilder stringBuilderOutput = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));

            // Reading the XML document requires a FileStream.
            using (Stream reader = new FileStream("housedata.txt", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                SaveData saveData = new SaveData();
                saveData = (SaveData)serializer.Deserialize(reader);
                reader.Close();
                this.view.Player = saveData.Player;
                this.view.House = saveData.House;
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
            Room roomCurrent = this.view.House.Rooms[this.view.Player.Location];
            Elevator elevatorCurrent = roomCurrent as Elevator;
            OnOffObject onOffObjectFlashlight = this.view.House.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.view.House.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
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
                    this.view.Player.Location.RoomNumber = roomCurrent.Exits[direction].ExitDestination;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == Direction.Up)
            {
                if (elevatorCurrent != null && this.view.Player.Location.Floor != Floor.ThirdFloor)
                {
                    this.view.Player.Location.Floor++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == Direction.Down)
            {
                if (elevatorCurrent != null && this.view.Player.Location.Floor != Floor.Basement)
                {
                    this.view.Player.Location.Floor--;
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
            Room room = this.view.House.Rooms[this.view.Player.Location];
            Adversary adversaryLeopard = this.view.House.Adversaries[TheHouseData.LeopardShortName];
            PortableObject portableObjectBrush = this.view.House.InanimateObjects[TheHouseData.BrushShortName] as PortableObject;
            this.view.Message = new StringBuilder();

            // Trying to brush non adverasry?
            if (!this.view.House.Adversaries.Contains(this.view.Argument, false))
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
            else if (!this.view.Player.Inventory.Contains(portableObjectBrush))
            {
                // Trying to brush adversary in the room but don't have a brush?
                this.view.Message.Append("You have nothing with which to brush the ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (!this.view.House.Adversaries[this.view.Argument].Equals(adversaryLeopard))
            {
                // Trying to brush adversary in room with your brush but it's not the leopard?
                this.view.Message.Append("The ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" will become angry if you persist!");
            }
            else
            {
                // Must be trying to brush the leopard in the room with the brush
                this.view.House.HideAdversary(adversaryLeopard, this.view.Player.Location);
                this.view.Message.Append("Purrrrrrr!!!!!!!!  The leopard is very gratified for the grooming and leaves");
            }
        }

        /// <summary>
        /// Digs this instance.
        /// </summary>
        public void Dig()
        {
            this.view.Message = new StringBuilder();
            Room room = this.view.House.Rooms[this.view.Player.Location];
#if DEBUG
            ////this.view.Player.Inventory.Add(this.view.House.InanimateObjects[TheHouseData.ShovelShortName]);
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
            else if (!this.view.Player.Inventory.Contains(TheHouseData.ShovelShortName))
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
            OnOffObject onOffObjectFlashlight = this.view.House.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.view.House.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
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
                if (!this.view.Player.Inventory.Contains(onOffObjectFlashlight.Identity))
                {
                    this.view.Message.Append("You have no light to turn on!");
                }
                else if (!this.view.Player.Inventory.Contains(consumableObjectBatteries.Identity))
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
                    this.view.Player.TimesLookedInDark = 0;
                }
            }
            else
            {
                if (!this.view.Player.Inventory.Contains(onOffObjectFlashlight.Identity))
                {
                    this.view.Message.Append("You have no light to turn off!");
                }
                else if (!this.view.Player.Inventory.Contains(consumableObjectBatteries.Identity))
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
            LockableDoorObject lockableDoor = this.view.House.InanimateObjects[TheHouseData.LockedDoorShortName] as LockableDoorObject;
            PortableObject portableObjectKey = this.view.House.PortableObjects[TheHouseData.RustedKeyShortName] as PortableObject;
#if DEBUG
            /*
            if (!this.view.Player.Inventory.Contains(portableObjectKey))
            {
                this.view.Player.Inventory.Add(portableObjectKey);
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
            else if (!this.view.House.Rooms[this.view.Player.Location].Items.Contains(lockableDoor))
            {
                this.view.Message.Append("I see no door that needs opening!");
            }
            else if (!this.view.Player.Inventory.Contains(portableObjectKey))
            {
                this.view.Message.Append("I need something first!");
            }
            else
            {
                this.view.House.Rooms[this.view.Player.Location].Items.Remove(lockableDoor);
                this.view.House.Rooms[this.view.Player.Location].Exits.Add(new RoomExit(lockableDoor.ExitWhenUnlocked.ExitDirection, lockableDoor.ExitWhenUnlocked.ExitDestination));
                this.view.Message.Append("<<<<C-L-I-C-K>>>>\r\nOK, it's open now");
            }
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            this.view.Message = new StringBuilder();
            PortableObject portableObjectBanjo = this.view.House.PortableObjects[TheHouseData.BanjoShortName] as PortableObject;
            Adversary adversaryBeast = this.view.House.Adversaries[TheHouseData.BeastShortName];
#if DEBUG
            ////this.view.Player.Inventory.Add(portableObjectBanjo);
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.view.House.PortableObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
                inanimateObjectTarget = null;
            }

            if (inanimateObjectTarget == null || !inanimateObjectTarget.Equals(portableObjectBanjo))
            {
                this.view.Message.Append("You can't play that!");
            }
            else if (!this.view.Player.Inventory.Contains(portableObjectBanjo))
            {
                this.view.Message.Append("You have no banjo to play");
            }
            else
            {
                // TODO: play sound
                if (this.view.House.Rooms[this.view.Player.Location].Adversaries.Contains(adversaryBeast))
                {
                    this.view.House.HideAdversary(adversaryBeast, this.view.Player.Location);
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
            PortableObject portableObjectSorcerersBook = this.view.House.InanimateObjects[TheHouseData.BookShortName] as PortableObject;
            PortableObject portableObjectParchment = this.view.House.InanimateObjects[TheHouseData.ParchmentShortName] as PortableObject;
#if DEBUG
            /*
            if (!this.view.Player.Inventory.Contains(portableObjectSorcerersBook))
            {
                this.view.Player.Inventory.Add(portableObjectSorcerersBook);
            }

            if (!this.view.Player.Inventory.Contains(portableObjectParchment))
            {
                this.view.Player.Inventory.Add(portableObjectParchment);
            }
            */
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.view.House.InanimateObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

                if (inanimateObjectTarget == null || !(inanimateObjectTarget is PortableObject))
                {
                    this.view.Message.Append("You can't read that");
                }
                else if (!this.view.Player.Inventory.Contains(inanimateObjectTarget))
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
                    foreach (Room room in this.view.House.Rooms.MagicRooms)
                    {
                        this.view.Message.Append(room.Name);
                        this.view.Message.Append(Environment.NewLine);
                    }

                    // One non-magic decoy room to make things a little harder
                    LocationType locationTypeDecoyRoom = new LocationType(0, Floor.ThirdFloor);
                    this.view.Message.Append(this.view.House.Rooms[locationTypeDecoyRoom].Name);
                }
        }

        /// <summary>
        /// Says this instance.
        /// </summary>
        public void Say()
        {
            this.view.Message = new StringBuilder();
            bool boolWordIsMagic = false;
            Random random = new Random();
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
                if (this.view.House.Rooms[this.view.Player.Location].Magic && this.view.House.Rooms[this.view.Player.Location].MagicWordForRoom == theword)
                {
                    foreach (InanimateObject inanimateObjectCurrent in this.view.House.Rooms[this.view.Player.Location].Items)
                    {
                        PortableObject portableObjectCurrent = inanimateObjectCurrent as PortableObject;
                        if (portableObjectCurrent != null && !portableObjectCurrent.Visible)
                        {
                            portableObjectCurrent.Visible = true;
                        }
                    }

                    this.view.Message.Append("The air shimmers");
                }
                else if (this.view.House.Rooms[this.view.Player.Location].Magic && this.view.House.Rooms[this.view.Player.Location].MagicWordForRoom != theword)
                {
                    this.view.Message.Append("You experience disortientation");
                    this.view.Player.Location = new LocationType(random.Next(10), (Floor)random.Next(4));
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
            ConsumableObject consumableObjectBugSpray = this.view.House.InanimateObjects[TheHouseData.BugSprayShortName] as ConsumableObject;
            Adversary adversaryBlob = this.view.House.Adversaries[TheHouseData.BlobShortName];
#if DEBUG
            /*
            if (!this.view.Player.Inventory.Contains(consumableObjectBugSpray))
            {
                this.view.Player.Inventory.Add(consumableObjectBugSpray);
            }
            */
#endif
            Room room = this.view.House.Rooms[this.view.Player.Location];

            // Trying to spray adversary in the room but don't have the spray?
            if (!this.view.Player.Inventory.Contains(consumableObjectBugSpray))
            {
                this.view.Message.Append("You have nothing with which to spray the ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (!this.view.House.Adversaries.Contains(this.view.Argument, false))
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
            else if (!this.view.House.Adversaries[this.view.Argument].Equals(adversaryBlob))
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
                this.view.House.HideAdversary(adversaryBlob, this.view.Player.Location);
                this.view.Message.Append("Blob runs away");
            }
        }

        /// <summary>
        /// Stabs this instance.
        /// </summary>
        public void Stab()
        {
            this.view.Message = new StringBuilder();
            Room room = this.view.House.Rooms[this.view.Player.Location];
            PortableObject portableObjectKnife = this.view.House.PortableObjects[TheHouseData.KnifeShortName] as PortableObject;
            Adversary adversaryMonk = this.view.House.Adversaries[TheHouseData.MonkShortName];
            Adversary adversaryTarget = null;
            try
            {
                adversaryTarget = this.view.House.Adversaries[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            if (!this.view.House.Adversaries.Contains(this.view.Argument, false))
            {
                this.view.Message.Append("You can't kill that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                this.view.Message.Append("I see no ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" here");
            }
            else if (!this.view.Player.Inventory.Contains(portableObjectKnife))
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
                this.view.House.HideAdversary(adversaryMonk, this.view.Player.Location);
                this.view.Message.Append("Monk has run away");
            }
        }

        /// <summary>
        /// Waves this instance.
        /// </summary>
        public void Wave()
        {
            this.view.Message = new StringBuilder();
            Room room = this.view.House.Rooms[this.view.Player.Location];
            PortableObject portableObjectGarlic = this.view.House.InanimateObjects[TheHouseData.GarlicShortName] as PortableObject;
            OnOffObject onOffObjectFlashlight = this.view.House.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            Adversary adversaryVampire = this.view.House.Adversaries[TheHouseData.VampireShortName];
            Adversary adversaryWerewolf = this.view.House.Adversaries[TheHouseData.WerewolfShortName];

#if DEBUG
            /*
            ConsumableObject consumableObjectBatteries = this.view.House.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
            if (!this.view.Player.Inventory.Contains(portableObjectGarlic))
            {
                this.view.Player.Inventory.Add(portableObjectGarlic);
            }

            if (!this.view.Player.Inventory.Contains(onOffObjectFlashlight))
            {
                this.view.Player.Inventory.Add(onOffObjectFlashlight);
            }

            if (!this.view.Player.Inventory.Contains(consumableObjectBatteries))
            {
                this.view.Player.Inventory.Add(consumableObjectBatteries);
            }
            */
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.view.House.InanimateObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            if (inanimateObjectTarget == null || !(inanimateObjectTarget is PortableObject))
            {
                // is not portable?
                this.view.Message.Append("You can't wave that.");
            }
            else if (!this.view.Player.Inventory.Contains(inanimateObjectTarget))
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
                this.view.House.HideAdversary(adversaryVampire, this.view.Player.Location);
            }
            else if (inanimateObjectTarget.Equals(portableObjectGarlic) && room.Adversaries.Contains(adversaryWerewolf))
            {
                // is garlic and ware in room?
                this.view.Message.Append("The warewolf has fled.");
                this.view.House.HideAdversary(adversaryWerewolf, this.view.Player.Location);
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
            this.view.Message.Append(String.Format(CultureInfo.CurrentCulture, "You got {0} items out of the house in {1} moves", this.view.Player.ItemsRemovedFromHouse, this.view.Player.NumberOfMoves));
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
                inanimateObjectTarget = this.view.House.InanimateObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

                if (inanimateObjectTarget == null || !(inanimateObjectTarget is PortableObject))
                {
                    this.view.Message.Append("You can't drop that");
                }
                else if (!this.view.Player.Inventory.Contains(inanimateObjectTarget.ToString()))
                {
                    this.view.Message.Append("You don't have a ");
                    this.view.Message.Append(this.view.Argument);
                }
                else if (inanimateObjectTarget.Equals(this.view.House.InanimateObjects[TheHouseData.BatteriesShortName]) || inanimateObjectTarget.Equals(this.view.House.InanimateObjects[TheHouseData.FlashlightShortName]))
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
                else if (inanimateObjectTarget is ContainerObject && this.view.Player.Inventory.ContainsByType(typeof(MultiplePieceObject), multiplePieceObjectsInInventory))
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
                else if (inanimateObjectTarget is ProtectiveObject && this.view.Player.Inventory.ContainsByType(typeof(PainfulObject)))
                {
                    this.view.Message.Append("You'll hurt yourself");
                }
                else if (inanimateObjectTarget is DelicateObject && !this.view.House.Rooms[this.view.Player.Location].Items.ContainsByType(typeof(CushioningObject)))
                {
                    this.view.Message.Append("It will break");
                }
                else
                {
                    this.view.Player.Inventory.Remove(inanimateObjectTarget.ToString());
                    this.view.House.Rooms[this.view.Player.Location].Items.Add(inanimateObjectTarget);
                    this.view.Message.Append(this.view.Argument);
                    this.view.Message.Append(" dropped");
                    if (this.view.Player.Location.Equals(TheHouseData.LocationFirstFloorFrontPorch))
                    {
                        this.view.Player.ItemsRemovedFromHouse++;
                        if (this.view.Player.ItemsRemovedFromHouse == this.view.House.PortableObjects.Count)
                        {
                            this.view.GameEnded = true;
                            this.view.Message = new StringBuilder();
                            this.view.Message.Append(String.Format(CultureInfo.CurrentCulture, "Congratulations--you have successfully completed House Adventure \r\nYou removed all 20 objects in {0} moves", view.Player.NumberOfMoves));
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
            Room room = this.view.House.Rooms[this.view.Player.Location];
            this.view.GameEnded = false;

            // Trying to pick up known object?
            try
            {
                portableObjectTarget = this.view.House.InanimateObjects[this.view.Argument] as PortableObject;
            }
            catch (KeyNotFoundException)
            {
                portableObjectTarget = null;
            }

            // Is a known portable item
            if (portableObjectTarget != null)
            {
                // Item not in room or item in room but buried or invisible
                if (!this.view.House.Rooms[this.view.Player.Location].Items.Contains(portableObjectTarget) || (this.view.House.Rooms[this.view.Player.Location].Items.Contains(portableObjectTarget) && (portableObjectTarget.Buried || !portableObjectTarget.Visible)))
                {
                    // Impostor in room and its name is the same as the target item
                    if (portableObjectTarget.Equals(this.view.House.Adversaries.TheImpostor) && this.view.House.Rooms[this.view.Player.Location].Adversaries.Contains(this.view.House.Adversaries.TheImpostor))
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
                else if (this.view.House.Rooms[this.view.Player.Location].Adversaries.ContainsNonImpostor())
                {
                    // Room has an adversary that is not the imposter
                    this.view.Message.Append("This room's occupant seems to have grown very attached to the ");
                    this.view.Message.Append(this.view.Argument);
                    this.view.Message.Append(" and won't let you have it");
                }
                else if (this.view.Player.Inventory.Count < TheHouseData.MaximumInventoryItems)
                {
                    if (portableObjectTarget is MultiplePieceObject)
                    {
                        if (this.view.Player.Inventory.ContainsByType(typeof(ContainerObject)))
                        {
                            this.view.Player.Inventory.Add(portableObjectTarget);
                            room.Items.Remove(portableObjectTarget);
                        }
                        else
                        {
                            this.view.Message.Append("You can't pick up that many small items!");
                        }
                    }
                    else if (portableObjectTarget is PainfulObject)
                    {
                        bool boolHasProtectiveItem = false;
                        foreach (InanimateObject inanimateObject in this.view.Player.Inventory)
                        {
                            if (inanimateObject is ProtectiveObject)
                            {
                                boolHasProtectiveItem = true;
                            }
                        }

                        if (boolHasProtectiveItem)
                        {
                            this.view.Player.Inventory.Add(portableObjectTarget);
                            room.Items.Remove(portableObjectTarget);
                        }
                        else
                        {
                            this.view.Message.Append("Ouch! That hurts! You can't pick that up!");
                        }
                    }
                    else
                    {
                        this.view.Player.Inventory.Add(portableObjectTarget);
                        room.Items.Remove(portableObjectTarget);
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
            Room room = this.view.House.Rooms[this.view.Player.Location];
            Random random = new Random();
            this.view.GameEnded = false;
            this.view.ClearScreen = true;
            this.view.ExitDirections.Clear();
            this.view.Adversaries.Clear();
            this.view.Items.Clear();
            this.view.RoomName = String.Empty;
            this.view.Message = new StringBuilder();
            TelephoneBooth telephoneBooth = room as TelephoneBooth;
            if (!this.view.AfterVerticalMovement && this.view.Player.Inventory.Contains(TheHouseData.DimeShortName) && telephoneBooth != null)
            {
                this.view.Player.Location.Floor = (Floor)random.Next(4);
                room = this.view.House.Rooms[this.view.Player.Location];
            }

            this.view.RoomName = room.Name;
            if (random.Next(50) < 10)
            {
                this.view.House.RemoveFrontPorchItems();
            }

            if (random.Next(50) < 40)
            {
                this.view.House.UpdateMonstersInHangout();
            }

            OnOffObject onOffObjectFlashlight = this.view.House.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            if (this.view.Player.Location.Floor == Floor.Basement && onOffObjectFlashlight.State == Switch.Off)
            {
                this.view.Message.Append("nothing--it's too dark!");
                this.view.Player.TimesLookedInDark++;
                if (this.view.Player.TimesLookedInDark > TheHouseData.MaximumLooksInDark)
                {
                    this.view.Message.Append("Aughhhh . . .\r\nBeware of things unseen !!");
                    this.view.GameEnded = true;
                }
            }
            else
            {
                foreach (Adversary adversary in room.Adversaries)
                {
                    this.view.Adversaries.Add(adversary.Name);
                }

                foreach (InanimateObject inanimateObject in room.Items)
                {
                    PortableObject portableObject = inanimateObject as PortableObject;
                    if (portableObject == null)
                    {
                        // If it's a stationary object
                        this.view.Items.Add(inanimateObject.Name);
                    }
                    else if (portableObject.Visible && !portableObject.Buried)
                    {
                        this.view.Items.Add(inanimateObject.Name);
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
