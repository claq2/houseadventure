//-----------------------------------------------------------------------
// <copyright file="HouseType.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Class that maintains the state of the house
    /// </summary>
    public class HouseType
    {
        #region Fields (6)

        /// <summary>
        /// The adversaries in the house
        /// </summary>
        private AdversaryCollection adversaries = new AdversaryCollection();

        /// <summary>
        /// The inanimate objects in the house
        /// </summary>
        private InanimateObjectKeyedCollection inanimateObjects = new InanimateObjectKeyedCollection();

        /// <summary>
        /// The rooms in the house
        /// </summary>
        private RoomKeyedCollection rooms = new RoomKeyedCollection();

        /// <summary>
        /// Number of items removes from the house
        /// </summary>
        private int itemsRemovedFromHouse;

        /// <summary>
        /// Number of attempted actions
        /// </summary>
        private int numberOfMoves;

        /// <summary>
        /// Number of times player has looked in the dark
        /// </summary>
        private int timesLookedInDark;
        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="HouseType"/> class.
        /// </summary>
        public HouseType()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HouseType"/> class.
        /// </summary>
        /// <param name="initializeHouse">if set to <c>true</c> [initialize house].</param>
        public HouseType(bool initializeHouse)
        {
            if (initializeHouse)
            {
                this.InitRooms();
                this.InitObjects();
                this.InitMonsters();
            }
        }

        #endregion Constructors

        #region Properties (6)

        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
        public InanimateObjectKeyedCollection Inventory
        {
            get 
            { 
                InanimateObjectKeyedCollection result = new InanimateObjectKeyedCollection();
                foreach (InanimateObject obj in this.Rooms[LocationType.Inventory].Items)
                {
                    result.Add(obj);
                }
                return result;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portableObject"></param>
        public void AddToInventory(PortableObject portableObject)
        {
            foreach (Room room in this.Rooms)
            {
                foreach (InanimateObject inanimateObject in room.Items)
                {
                    if (inanimateObject == portableObject)
                    {
                        room.Items.Remove(portableObject);
                        this.Rooms[LocationType.Inventory].Items.Add(portableObject);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portableObject"></param>
        /// <param name="location"></param>
        public void RemoveFromInventory(PortableObject portableObject, LocationType location)
        {
            this.Rooms[LocationType.Inventory].Items.Remove(portableObject);
            this.Rooms[location].Items.Add(portableObject);
        }

        /// <summary>
        /// Gets or sets the items removed from house.
        /// </summary>
        /// <value>The items removed from house.</value>
        public int ItemsRemovedFromHouse
        {
            get { return this.itemsRemovedFromHouse; }
            set { this.itemsRemovedFromHouse = value; }
        }

        /// <summary>
        /// Gets or sets the number of moves.
        /// </summary>
        /// <value>The number of moves.</value>
        public int NumberOfMoves
        {
            get { return this.numberOfMoves; }
            set { this.numberOfMoves = value; }
        }

        /// <summary>
        /// Gets or sets the times looked in dark.
        /// </summary>
        /// <value>The times looked in dark.</value>
        public int TimesLookedInDark
        {
            get { return this.timesLookedInDark; }
            set { this.timesLookedInDark = value; }
        }
        /// <summary>
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        [XmlIgnore()]
        public AdversaryCollection Adversaries
        {
            get { return this.adversaries; }
        }

        /// <summary>
        /// Gets the inanimate objects.
        /// </summary>
        /// <value>The inanimate objects.</value>
        [XmlIgnore()]
        public InanimateObjectKeyedCollection InanimateObjects
        {
            get { return this.inanimateObjects; }
        }

        /// <summary>
        /// Gets the portable objects.
        /// </summary>
        /// <value>The portable objects.</value>
        [XmlIgnore()]
        public InanimateObjectKeyedCollection PortableObjects
        {
            get
            {
                InanimateObjectKeyedCollection result = new InanimateObjectKeyedCollection();
                foreach (InanimateObject obj in this.inanimateObjects)
                {
                    PortableObject portableObject = obj as PortableObject;
                    if (portableObject != null)
                    {
                        result.Add(obj);
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <value>The rooms.</value>
        public RoomKeyedCollection Rooms
        {
            get { return this.rooms; }
        }

        #endregion Properties

        #region Methods (10)

        // Public Methods (3) 

        ///// <summary>
        ///// Loads this instance.
        ///// </summary>
        ///// <returns>Message indicating success or failure</returns>
        //public string Load()
        //{
        //    StringBuilder stringBuilderOutput = new StringBuilder();
        //    XmlSerializer serializer = new XmlSerializer(typeof(SaveData));

        //    // Reading the XML document requires a FileStream.
        //    using (Stream reader = new FileStream("housedata.txt", FileMode.Open))
        //    {
        //        // Call the Deserialize method to restore the object's state.
        //        SaveData saveData = new SaveData();
        //        saveData = (SaveData)serializer.Deserialize(reader);
        //        reader.Close();
        //        this.RestoreFromSaveData(saveData);
        //    }
        //    stringBuilderOutput.Append("Data loaded");
        //    return stringBuilderOutput.ToString();
        //}

        //    /// <summary>
        //    /// Restores from save data.
        //    /// </summary>
        //    /// <param name="data">The data object in which to store state.</param>
        //    public void RestoreFromSaveData(SaveData data)
        //    {
        //        int intCountRooms = data.Rooms.Count;
        //        for (int i = 0; i < intCountRooms; i++)
        //        {
        //            this.rooms.Remove(data.Rooms[i].Location);
        //            this.rooms.Add(data.Rooms[i]);
        //            int intCountAdversariesInRoom = data.Rooms[i].Adversaries.Count;
        //            for (int j = 0; j < intCountAdversariesInRoom; j++)
        //            {
        //                this.adversaries.Remove(data.Rooms[i].Adversaries[j].Name);
        //                this.adversaries.Add(data.Rooms[i].Adversaries[j]);
        //            }

        //            int intCountItemsInRoom = data.Rooms[i].Items.Count;
        //            for (int j = 0; j < intCountItemsInRoom; j++)
        //            {
        //                this.inanimateObjects.Remove(data.Rooms[i].Items[j].Name);
        //                this.inanimateObjects.Add(data.Rooms[i].Items[j]);
        //            }
        //        }

        //        this.InitPortableObjects();
        //    }
        //}

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>Message indicating success or failure</returns>
        public string Save()
        {
            SaveData saveData = new SaveData();
            this.PopulateSaveData(saveData);
            StringBuilder stringBuilderOutput = new StringBuilder();
            XmlSerializer serializerSaveData = new XmlSerializer(typeof(SaveData));
            using (TextWriter writer = new StreamWriter("housedata.txt"))
            {
                serializerSaveData.Serialize(writer, saveData);
            }

            stringBuilderOutput.Append("Data saved");
            return stringBuilderOutput.ToString();
        }

        // Private Methods (5) 

        /// <summary>
        /// Inits the monsters.
        /// </summary>
        private void InitMonsters()
        {
            Random random = new Random();
            this.adversaries.Add(new Adversary(TheHouseAdversaryData.BlobName, this.rooms[TheHouseRoomData.LocationBasementFreezer], TheHouseAdversaryData.BlobShortName));
            this.adversaries.Add(new Adversary(TheHouseAdversaryData.BeastName, this.rooms[TheHouseRoomData.LocationBasementPumpRoom], TheHouseAdversaryData.BeastShortName));
            this.adversaries.Add(new Adversary(TheHouseAdversaryData.LeopardName, this.rooms[TheHouseRoomData.LocationThirdFloorLibrary], TheHouseAdversaryData.LeopardShortName));
            this.adversaries.Add(new Adversary(TheHouseAdversaryData.MonkName, this.rooms[TheHouseRoomData.LocationSecondFloorGuestroom1], TheHouseAdversaryData.MonkShortName));
            this.adversaries.Add(new Adversary(TheHouseAdversaryData.VampireName, this.rooms[TheHouseRoomData.LocationFirstFloorKitchen], TheHouseAdversaryData.VampireShortName));
            this.adversaries.Add(new Adversary(TheHouseAdversaryData.WerewolfName, this.rooms[TheHouseRoomData.LocationThirdFloorArtHall], TheHouseAdversaryData.WerewolfShortName));
            int intImpostorItemNumber = random.Next(this.PortableObjects.Count);
            string stringImpostorDisplayName = this.PortableObjects[intImpostorItemNumber].Name;
            string stringImpostorShortName = this.PortableObjects[intImpostorItemNumber].ShortName;
            int intImpostorRoomNumber = random.Next(10);
            Floor floorImpostorFloor = (Floor)random.Next(4);
            LocationType locationImpostorLocation = new LocationType(intImpostorRoomNumber, floorImpostorFloor);
            this.adversaries.Add(new Impostor(stringImpostorDisplayName, this.rooms[locationImpostorLocation], stringImpostorShortName));
        }

        /// <summary>
        /// Inits the objects.
        /// </summary>
        private void InitObjects()
        {
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.BagOfGoldName, this.rooms[TheHouseRoomData.LocationBasementTortureChamber], TheHouseObjectData.BagOfGoldShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.BanjoName, this.rooms[TheHouseRoomData.LocationSecondFloorDen], TheHouseObjectData.BanjoShortName));
            this.inanimateObjects.Add(new ConsumableObject(TheHouseObjectData.BatteriesName, this.rooms[TheHouseRoomData.LocationThirdFloorTrophyRoom], 40, TheHouseObjectData.BatteriesShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.BrushName, this.rooms[TheHouseRoomData.LocationSecondFloorSittingRoom], TheHouseObjectData.BrushShortName));
            this.inanimateObjects.Add(new ConsumableObject(TheHouseObjectData.BugSprayName, this.rooms[TheHouseRoomData.LocationBasementPumpRoom], 3, TheHouseObjectData.BugSprayShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.DiamondName, this.rooms[TheHouseRoomData.LocationSecondFloorCloset], TheHouseObjectData.DiamondShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.DimeName, this.rooms[TheHouseRoomData.LocationFirstFloorDiningRoom], false, false, TheHouseObjectData.DimeShortName));
            this.inanimateObjects.Add(new PainfulObject(TheHouseObjectData.DryIceName, this.rooms[TheHouseRoomData.LocationThirdFloorBarroom], TheHouseObjectData.DryIceShortName));
            this.inanimateObjects.Add(new OnOffObject(TheHouseObjectData.FlashlightName, this.rooms[TheHouseRoomData.LocationFirstFloorCoatCloset], TheHouseObjectData.FlashlightShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.GarlicName, this.rooms[TheHouseRoomData.LocationBasementDirtFlooredRoom], true, true, TheHouseObjectData.GarlicShortName));
            this.inanimateObjects.Add(new ProtectiveObject(TheHouseObjectData.GloveName, this.rooms[TheHouseRoomData.LocationBasementTelephoneBooth], false, false, TheHouseObjectData.GloveShortName));
            this.inanimateObjects.Add(new MultiplePieceObject(TheHouseObjectData.CoinsName, this.rooms[TheHouseRoomData.LocationSecondFloorTelephoneBooth], TheHouseObjectData.CoinsShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.KnifeName, this.rooms[TheHouseRoomData.LocationFirstFloorKitchen], TheHouseObjectData.KnifeShortName));
            this.inanimateObjects.Add(new DelicateObject(TheHouseObjectData.VaseName, this.rooms[TheHouseRoomData.LocationSecondFloorGuestroom1], TheHouseObjectData.VaseShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.ParchmentName, this.rooms[TheHouseRoomData.LocationBasementFreezer], TheHouseObjectData.ParchmentShortName));
            this.inanimateObjects.Add(new CushioningObject(TheHouseObjectData.PillowName, this.rooms[TheHouseRoomData.LocationThirdFloorArtHall], TheHouseObjectData.PillowShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.RustedKeyName, this.rooms[TheHouseRoomData.LocationBasementDirtFlooredRoom], true, true, TheHouseObjectData.RustedKeyShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.ShovelName, this.rooms[TheHouseRoomData.LocationThirdFloorComputerRoom], TheHouseObjectData.ShovelShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseObjectData.BookName, this.rooms[TheHouseRoomData.LocationThirdFloorLibrary], TheHouseObjectData.BookShortName));
            this.inanimateObjects.Add(new ContainerObject(TheHouseObjectData.BoxName, this.rooms[TheHouseRoomData.LocationFirstFloorFoyer], TheHouseObjectData.BoxShortName));

            this.inanimateObjects.Add(new LockableDoorObject(TheHouseObjectData.LockedDoorName, this.rooms[TheHouseRoomData.LocationFirstFloorFoyer], new RoomExit(Direction.South, 0), TheHouseObjectData.LockedDoorShortName));
            this.inanimateObjects.Add(new StationaryObject(TheHouseObjectData.BathtubName, this.rooms[TheHouseRoomData.LocationSecondFloorBathroom]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseObjectData.FrontYardName, this.rooms[TheHouseRoomData.LocationFirstFloorFrontPorch]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseObjectData.BedName, this.rooms[TheHouseRoomData.LocationSecondFloorMasterBedroom]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseObjectData.MainframeName, this.rooms[TheHouseRoomData.LocationThirdFloorComputerRoom]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseObjectData.MooseHeadName, this.rooms[TheHouseRoomData.LocationSecondFloorDen]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseObjectData.StocksName, this.rooms[TheHouseRoomData.LocationBasementTortureChamber]));
        }

        /// <summary>
        /// Inits the basement rooms.
        /// </summary>
        /// <param name="random">The random.</param>
        private void InitBasementRooms(Random random)
        {
            this.rooms.Add(new Room(TheHouseRoomData.CoalBinName, TheHouseRoomData.LocationBasementCoalBin, TheHouseRoomData.ExitsBasementCoalBin));
            this.rooms.Add(new UnfinishedFlooredRoom(TheHouseRoomData.DirtFlooredRoomName, TheHouseRoomData.LocationBasementDirtFlooredRoom, TheHouseRoomData.ExitsBasementDirtFlooredRoom));
            this.rooms.Add(new Elevator(TheHouseRoomData.BasementElevatorName, TheHouseRoomData.LocationBasementElevator, TheHouseRoomData.ExitsBasementElevator));
            this.rooms.Add(new Room(TheHouseRoomData.FreezerName, TheHouseRoomData.LocationBasementFreezer, TheHouseRoomData.ExitsBasementFreezer));
            this.rooms.Add(new Room(TheHouseRoomData.FurnaceRoomName, TheHouseRoomData.LocationBasementFurnaceRoom, TheHouseRoomData.ExitsBasementFurnaceRoom));
            this.rooms.Add(new Room(TheHouseRoomData.LaboratoryName, TheHouseRoomData.LocationBasementLaboratory, TheHouseRoomData.ExitsBasementLaboratory));
            this.rooms.Add(new Room(TheHouseRoomData.PumpRoomName, TheHouseRoomData.LocationBasementPumpRoom, TheHouseRoomData.ExitsBasementPumpRoom));
            this.rooms.Add(new TelephoneBooth(TheHouseRoomData.TelephoneBoothName, TheHouseRoomData.LocationBasementTelephoneBooth, TheHouseRoomData.ExitsBasementTelephoneBooth, true, (MagicWord)random.Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1));
            this.rooms.Add(new Room(TheHouseRoomData.TortureChamberName, TheHouseRoomData.LocationBasementTortureChamber, TheHouseRoomData.ExitsBasementTortureChamber));
            this.rooms.Add(new Room(TheHouseRoomData.WorkshopName, TheHouseRoomData.LocationBasementWorkshop, TheHouseRoomData.ExitsBasementWorkshop));
        }

        /// <summary>
        /// Inits the first floor rooms.
        /// </summary>
        /// <param name="random">The random.</param>
        private void InitFirstFloorRooms(Random random)
        {
            this.rooms.Add(new Room(TheHouseRoomData.BedroomName, TheHouseRoomData.LocationFirstFloorBedroom, TheHouseRoomData.ExitsFirstFloorBedroom));
            this.rooms.Add(new Room(TheHouseRoomData.CoatClosetName, TheHouseRoomData.LocationFirstFloorCoatCloset, TheHouseRoomData.ExitsFirstFloorCoatCloset));
            this.rooms.Add(new Room(TheHouseRoomData.DiningRoomName, TheHouseRoomData.LocationFirstFloorDiningRoom, TheHouseRoomData.ExitsFirstFloorDiningRoom, true, (MagicWord)random.Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1));
            this.rooms.Add(new Elevator(TheHouseRoomData.FirstFloorElevatorName, TheHouseRoomData.LocationFirstFloorElevator, TheHouseRoomData.ExitsFirstFloorElevator));
            this.rooms.Add(new Room(TheHouseRoomData.FamilyRoomName, TheHouseRoomData.LocationFirstFloorFamilyRoom, TheHouseRoomData.ExitsFirstFloorFamilyRoom));
            this.rooms.Add(new Room(TheHouseRoomData.FoyerName, TheHouseRoomData.LocationFirstFloorFoyer, TheHouseRoomData.ExitsFirstFloorFoyer));
            this.rooms.Add(new Room(TheHouseRoomData.FrontPorchName, TheHouseRoomData.LocationFirstFloorFrontPorch, TheHouseRoomData.ExitsFirstFloorFrontPorch));
            this.rooms.Add(new Room(TheHouseRoomData.KitchenName, TheHouseRoomData.LocationFirstFloorKitchen, TheHouseRoomData.ExitsFirstFloorKitchen));
            this.rooms.Add(new Room(TheHouseRoomData.PantryName, TheHouseRoomData.LocationFirstFloorPantry, TheHouseRoomData.ExitsFirstFloorPantry));
            this.rooms.Add(new TelephoneBooth(TheHouseRoomData.TelephoneBoothName, TheHouseRoomData.LocationFirstFloorTelephoneBooth, TheHouseRoomData.ExitsFirstFloorTelephoneBooth));
        }

        /// <summary>
        /// Inits the second floor rooms.
        /// </summary>
        private void InitSecondFloorRooms()
        {
            this.rooms.Add(new Room(TheHouseRoomData.BathroomName, TheHouseRoomData.LocationSecondFloorBathroom, TheHouseRoomData.ExitsSecondFloorBathroom));
            this.rooms.Add(new Room(TheHouseRoomData.ClosetName, TheHouseRoomData.LocationSecondFloorCloset, TheHouseRoomData.ExitsSecondFloorCloset));
            this.rooms.Add(new Room(TheHouseRoomData.DenName, TheHouseRoomData.LocationSecondFloorDen, TheHouseRoomData.ExitsSecondFloorDen));
            this.rooms.Add(new Elevator(TheHouseRoomData.SecondFloorElevatorName, TheHouseRoomData.LocationSecondFloorElevator, TheHouseRoomData.ExitsSecondFloorElevator));
            this.rooms.Add(new Room(TheHouseRoomData.GuestroomName, TheHouseRoomData.LocationSecondFloorGuestroom1, TheHouseRoomData.ExitsSecondFloorGuestroom1));
            this.rooms.Add(new Room(TheHouseRoomData.GuestroomName, TheHouseRoomData.LocationSecondFloorGuestroom2, TheHouseRoomData.ExitsSecondFloorGuestroom2));
            this.rooms.Add(new Room(TheHouseRoomData.MasterBedroomName, TheHouseRoomData.LocationSecondFloorMasterBedroom, TheHouseRoomData.ExitsSecondFloorMasterBedroom));
            this.rooms.Add(new Room(TheHouseRoomData.SewingRoomName, TheHouseRoomData.LocationSecondFloorSewingRoom, TheHouseRoomData.ExitsSecondFloorSewingRoom));
            this.rooms.Add(new Room(TheHouseRoomData.SittingRoomName, TheHouseRoomData.LocationSecondFloorSittingRoom, TheHouseRoomData.ExitsSecondFloorSittingRoom));
            this.rooms.Add(new TelephoneBooth(TheHouseRoomData.TelephoneBoothName, TheHouseRoomData.LocationSecondFloorTelephoneBooth, TheHouseRoomData.ExitsSecondFloorTelephoneBooth));
        }

        /// <summary>
        /// Inits the third floor rooms.
        /// </summary>
        private void InitThirdFloorRooms()
        {
            this.rooms.Add(new Room(TheHouseRoomData.ArtHallName, TheHouseRoomData.LocationThirdFloorArtHall, TheHouseRoomData.ExitsThirdFloorArtHall));
            this.rooms.Add(new Room(TheHouseRoomData.BarroomName, TheHouseRoomData.LocationThirdFloorBarroom, TheHouseRoomData.ExitsThirdFloorBarroom));
            this.rooms.Add(new Room(TheHouseRoomData.BedroomName, TheHouseRoomData.LocationThirdFloorBedroom, TheHouseRoomData.ExitsThirdFloorBedroom));
            this.rooms.Add(new Room(TheHouseRoomData.ComputerRoomName, TheHouseRoomData.LocationThirdFloorComputerRoom, TheHouseRoomData.ExitsThirdFloorComputerRoom));
            this.rooms.Add(new Elevator(TheHouseRoomData.ThirdFloorElevatorName, TheHouseRoomData.LocationThirdFloorElevator, TheHouseRoomData.ExitsThirdFloorElevator));
            this.rooms.Add(new Room(TheHouseRoomData.GameRoomName, TheHouseRoomData.LocationThirdFloorGameRoom, TheHouseRoomData.ExitsThirdFloorGameRoom));
            this.rooms.Add(new Room(TheHouseRoomData.LibraryName, TheHouseRoomData.LocationThirdFloorLibrary, TheHouseRoomData.ExitsThirdFloorLibrary));
            this.rooms.Add(new Room(TheHouseRoomData.LivingRoomName, TheHouseRoomData.LocationThirdFloorLivingRoom, TheHouseRoomData.ExitsThirdFloorLivingRoom));
            this.rooms.Add(new TelephoneBooth(TheHouseRoomData.TelephoneBoothName, TheHouseRoomData.LocationThirdFloorTelephoneBooth, TheHouseRoomData.ExitsThirdFloorTelephoneBooth));
            this.rooms.Add(new Room(TheHouseRoomData.TrophyRoomName, TheHouseRoomData.LocationThirdFloorTrophyRoom, TheHouseRoomData.ExitsThirdFloorTrophyRoom));
        }

        /// <summary>
        /// Inits the monster hangout rooms.
        /// </summary>
        private void InitMonsterHangoutRooms()
        {
            this.rooms.Add(new MonsterHangout(TheHouseRoomData.MonsterHangoutName, TheHouseRoomData.LocationMonsterHangout, TheHouseRoomData.ExitsMonsterHangout));
        }

        /// <summary>
        /// Inits the rooms.
        /// </summary>
        private void InitRooms()
        {
            Random random = new Random();
            InitBasementRooms(random);

            InitFirstFloorRooms(random);

            InitSecondFloorRooms();

            InitThirdFloorRooms();

            InitMonsterHangoutRooms();
        }

        /// <summary>
        /// Populates the save data.
        /// </summary>
        /// <param name="data">The data in which to store state.</param>
        private void PopulateSaveData(SaveData data)
        {
            data.PopulateRooms(this.rooms);
        }

        // Internal Methods (2) 

        /// <summary>
        /// Removes the front porch items.
        /// </summary>
        internal void RemoveFrontPorchItems()
        {
            Room room = this.rooms[TheHouseRoomData.LocationFirstFloorFrontPorch];
            foreach (InanimateObject io in room.Items)
            {
                if (io is PortableObject)
                {
                    room.Items.Remove(io);
                }
            }
        }

        /// <summary>
        /// Updates the monsters in hangout.
        /// </summary>
        internal void UpdateMonstersInHangout()
        {
            // TODO: can't modify adversries in the foreach loop
            MonsterHangout monsterHangout = this.rooms[TheHouseRoomData.LocationMonsterHangout] as MonsterHangout;
            Random random = new Random();
            int intMonsterCount = monsterHangout.Adversaries.Count;
            List<int> listIntMonstersToBringBack = new List<int>();
            ////foreach (Adversary adversary in room.Adversaries)
            for (int i=0 ; i < intMonsterCount ; i++)
            {
                if (monsterHangout.Adversaries[i].MovesUntilUnhidden > 1)
                {
                    monsterHangout.Adversaries[i].MovesUntilUnhidden--;
                }
                else if (monsterHangout.Adversaries[i].MovesUntilUnhidden == 1)
                {
                    listIntMonstersToBringBack.Add(i);
                    monsterHangout.Adversaries[i].MovesUntilUnhidden--;
                }
            }

            foreach (int i in listIntMonstersToBringBack)
            {
                Adversary adversary = monsterHangout.Adversaries[i];
                monsterHangout.Adversaries.RemoveAt(i);
                int intRoom = random.Next(10);
                Floor floor = (Floor)random.Next(4);
                LocationType locationNew = new LocationType(intRoom, floor);
                this.rooms[locationNew].Adversaries.Add(adversary);
            }
        }

        /// <summary>
        /// Hides the adversary.
        /// </summary>
        /// <param name="adversary">The adversary.</param>
        /// <param name="location">The location.</param>
        public void HideAdversary(Adversary adversary, LocationType location)
        {
            this.Rooms[location].Adversaries.Remove(adversary);
            this.Rooms[TheHouseRoomData.LocationMonsterHangout].Adversaries.Add(adversary);
            adversary.MovesUntilUnhidden = 5;
        }

        #endregion Methods

        /// <summary>
        /// Restores the house.
        /// </summary>
        /// <param name="value">The value.</param>
        public void RestoreHouse(HouseType value)
        {
            int intCountRooms = value.Rooms.Count;
            for (int i = 0; i < intCountRooms; i++)
            {
                this.rooms.Remove(value.Rooms[i].Location);
                this.rooms.Add(value.Rooms[i]);
                int intCountAdversariesInRoom = value.Rooms[i].Adversaries.Count;
                for (int j = 0; j < intCountAdversariesInRoom; j++)
                {
                    this.adversaries.Remove(value.Rooms[i].Adversaries[j].Identity);
                    this.adversaries.Add(value.Rooms[i].Adversaries[j]);
                }

                int intCountItemsInRoom = value.Rooms[i].Items.Count;
                for (int j = 0; j < intCountItemsInRoom; j++)
                {
                    this.inanimateObjects.Remove(value.Rooms[i].Items[j].Identity);
                    this.inanimateObjects.Add(value.Rooms[i].Items[j]);
                }
            }
        }
    }
}
