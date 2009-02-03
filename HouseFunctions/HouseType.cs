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
        /// The portable objects in the house
        /// </summary>
        private InanimateObjectKeyedCollection portableObjects = new InanimateObjectKeyedCollection();

        /// <summary>
        /// The rooms in the house
        /// </summary>
        private RoomKeyedCollection rooms = new RoomKeyedCollection();

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
                this.InitPortableObjects();
                this.InitMonsters();
            }
        }

        #endregion Constructors

        #region Properties (6)

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
            get { return this.portableObjects; }
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
            this.adversaries.Add(new Adversary(TheHouseData.BlobName, this.rooms[TheHouseData.LocationBasementFreezer], TheHouseData.BlobShortName));
            this.adversaries.Add(new Adversary(TheHouseData.BeastName, this.rooms[TheHouseData.LocationBasementPumpRoom], TheHouseData.BeastShortName));
            this.adversaries.Add(new Adversary(TheHouseData.LeopardName, this.rooms[TheHouseData.LocationThirdFloorLibrary], TheHouseData.LeopardShortName));
            this.adversaries.Add(new Adversary(TheHouseData.MonkName, this.rooms[TheHouseData.LocationSecondFloorGuestroom1], TheHouseData.MonkShortName));
            this.adversaries.Add(new Adversary(TheHouseData.VampireName, this.rooms[TheHouseData.LocationFirstFloorKitchen], TheHouseData.VampireShortName));
            this.adversaries.Add(new Adversary(TheHouseData.WerewolfName, this.rooms[TheHouseData.LocationThirdFloorArtHall], TheHouseData.WerewolfShortName));
            int intImpostorItemNumber = random.Next(portableObjects.Count);
            string stringImpostorDisplayName = this.portableObjects[intImpostorItemNumber].Name;
            string stringImpostorShortName = this.portableObjects[intImpostorItemNumber].ShortName;
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
            this.inanimateObjects.Add(new PortableObject(TheHouseData.BagOfGoldName, this.rooms[TheHouseData.LocationBasementTortureChamber], TheHouseData.BagOfGoldShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.BanjoName, this.rooms[TheHouseData.LocationSecondFloorDen], TheHouseData.BanjoShortName));
            this.inanimateObjects.Add(new ConsumableObject(TheHouseData.BatteriesName, this.rooms[TheHouseData.LocationThirdFloorTrophyRoom], 40, TheHouseData.BatteriesShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.BrushName, this.rooms[TheHouseData.LocationSecondFloorSittingRoom], TheHouseData.BrushShortName));
            this.inanimateObjects.Add(new ConsumableObject(TheHouseData.BugSprayName, this.rooms[TheHouseData.LocationBasementPumpRoom], 3, TheHouseData.BugSprayShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.DiamondName, this.rooms[TheHouseData.LocationSecondFloorCloset], TheHouseData.DiamondShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.DimeName, this.rooms[TheHouseData.LocationFirstFloorDiningRoom], false, false, TheHouseData.DimeShortName));
            this.inanimateObjects.Add(new PainfulObject(TheHouseData.DryIceName, this.rooms[TheHouseData.LocationThirdFloorBarroom], TheHouseData.DryIceShortName));
            this.inanimateObjects.Add(new OnOffObject(TheHouseData.FlashlightName, this.rooms[TheHouseData.LocationFirstFloorCoatCloset], TheHouseData.FlashlightShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.GarlicName, this.rooms[TheHouseData.LocationBasementDirtFlooredRoom], true, true, TheHouseData.GarlicShortName));
            this.inanimateObjects.Add(new ProtectiveObject(TheHouseData.GloveName, this.rooms[TheHouseData.LocationBasementTelephoneBooth], false, false, TheHouseData.GloveShortName));
            this.inanimateObjects.Add(new MultiplePieceObject(TheHouseData.CoinsName, this.rooms[TheHouseData.LocationSecondFloorTelephoneBooth], TheHouseData.CoinsShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.KnifeName, this.rooms[TheHouseData.LocationFirstFloorKitchen], TheHouseData.KnifeShortName));
            this.inanimateObjects.Add(new DelicateObject(TheHouseData.VaseName, this.rooms[TheHouseData.LocationSecondFloorGuestroom1], TheHouseData.VaseShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.ParchmentName, this.rooms[TheHouseData.LocationBasementFreezer], TheHouseData.ParchmentShortName));
            this.inanimateObjects.Add(new CushioningObject(TheHouseData.PillowName, this.rooms[TheHouseData.LocationThirdFloorArtHall], TheHouseData.PillowShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.RustedKeyName, this.rooms[TheHouseData.LocationBasementDirtFlooredRoom], true, true, TheHouseData.RustedKeyShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.ShovelName, this.rooms[TheHouseData.LocationThirdFloorComputerRoom], TheHouseData.ShovelShortName));
            this.inanimateObjects.Add(new PortableObject(TheHouseData.BookName, this.rooms[TheHouseData.LocationThirdFloorLibrary], TheHouseData.BookShortName));
            this.inanimateObjects.Add(new ContainerObject(TheHouseData.BoxName, this.rooms[TheHouseData.LocationFirstFloorFoyer], TheHouseData.BoxShortName));

            this.inanimateObjects.Add(new LockableDoorObject(TheHouseData.LockedDoorName, this.rooms[TheHouseData.LocationFirstFloorFoyer], new RoomExit(Direction.South, 0), TheHouseData.LockedDoorShortName));
            this.inanimateObjects.Add(new StationaryObject(TheHouseData.BathtubName, this.rooms[TheHouseData.LocationSecondFloorBathroom]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseData.FrontYardName, this.rooms[TheHouseData.LocationFirstFloorFrontPorch]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseData.BedName, this.rooms[TheHouseData.LocationSecondFloorMasterBedroom]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseData.MainframeName, this.rooms[TheHouseData.LocationThirdFloorComputerRoom]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseData.MooseHeadName, this.rooms[TheHouseData.LocationSecondFloorDen]));
            this.inanimateObjects.Add(new StationaryObject(TheHouseData.StocksName, this.rooms[TheHouseData.LocationBasementTortureChamber]));
        }

        /// <summary>
        /// Inits the portable objects.
        /// </summary>
        private void InitPortableObjects()
        {
            int intCount = this.inanimateObjects.Count;
            this.portableObjects.Clear();
            for (int i = 0; i < intCount; i++)
            {
                PortableObject portable = this.inanimateObjects[i] as PortableObject;
                if (portable != null)
                {
                    this.portableObjects.Add(portable);
                }
            }
        }

        /// <summary>
        /// Inits the basement rooms.
        /// </summary>
        /// <param name="random">The random.</param>
        private void InitBasementRooms(Random random)
        {
            this.rooms.Add(new Room(TheHouseData.CoalBinName, TheHouseData.LocationBasementCoalBin, TheHouseData.ExitsBasementCoalBin));
            this.rooms.Add(new UnfinishedFlooredRoom(TheHouseData.DirtFlooredRoomName, TheHouseData.LocationBasementDirtFlooredRoom, TheHouseData.ExitsBasementDirtFlooredRoom));
            this.rooms.Add(new Elevator(TheHouseData.BasementElevatorName, TheHouseData.LocationBasementElevator, TheHouseData.ExitsBasementElevator));
            this.rooms.Add(new Room(TheHouseData.FreezerName, TheHouseData.LocationBasementFreezer, TheHouseData.ExitsBasementFreezer));
            this.rooms.Add(new Room(TheHouseData.FurnaceRoomName, TheHouseData.LocationBasementFurnaceRoom, TheHouseData.ExitsBasementFurnaceRoom));
            this.rooms.Add(new Room(TheHouseData.LaboratoryName, TheHouseData.LocationBasementLaboratory, TheHouseData.ExitsBasementLaboratory));
            this.rooms.Add(new Room(TheHouseData.PumpRoomName, TheHouseData.LocationBasementPumpRoom, TheHouseData.ExitsBasementPumpRoom));
            this.rooms.Add(new TelephoneBooth(TheHouseData.TelephoneBoothName, TheHouseData.LocationBasementTelephoneBooth, TheHouseData.ExitsBasementTelephoneBooth, true, (MagicWord)random.Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1));
            this.rooms.Add(new Room(TheHouseData.TortureChamberName, TheHouseData.LocationBasementTortureChamber, TheHouseData.ExitsBasementTortureChamber));
            this.rooms.Add(new Room(TheHouseData.WorkshopName, TheHouseData.LocationBasementWorkshop, TheHouseData.ExitsBasementWorkshop));
        }

        /// <summary>
        /// Inits the first floor rooms.
        /// </summary>
        /// <param name="random">The random.</param>
        private void InitFirstFloorRooms(Random random)
        {
            this.rooms.Add(new Room(TheHouseData.BedroomName, TheHouseData.LocationFirstFloorBedroom, TheHouseData.ExitsFirstFloorBedroom));
            this.rooms.Add(new Room(TheHouseData.CoatClosetName, TheHouseData.LocationFirstFloorCoatCloset, TheHouseData.ExitsFirstFloorCoatCloset));
            this.rooms.Add(new Room(TheHouseData.DiningRoomName, TheHouseData.LocationFirstFloorDiningRoom, TheHouseData.ExitsFirstFloorDiningRoom, true, (MagicWord)random.Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1));
            this.rooms.Add(new Elevator(TheHouseData.FirstFloorElevatorName, TheHouseData.LocationFirstFloorElevator, TheHouseData.ExitsFirstFloorElevator));
            this.rooms.Add(new Room(TheHouseData.FamilyRoomName, TheHouseData.LocationFirstFloorFamilyRoom, TheHouseData.ExitsFirstFloorFamilyRoom));
            this.rooms.Add(new Room(TheHouseData.FoyerName, TheHouseData.LocationFirstFloorFoyer, TheHouseData.ExitsFirstFloorFoyer));
            this.rooms.Add(new Room(TheHouseData.FrontPorchName, TheHouseData.LocationFirstFloorFrontPorch, TheHouseData.ExitsFirstFloorFrontPorch));
            this.rooms.Add(new Room(TheHouseData.KitchenName, TheHouseData.LocationFirstFloorKitchen, TheHouseData.ExitsFirstFloorKitchen));
            this.rooms.Add(new Room(TheHouseData.PantryName, TheHouseData.LocationFirstFloorPantry, TheHouseData.ExitsFirstFloorPantry));
            this.rooms.Add(new TelephoneBooth(TheHouseData.TelephoneBoothName, TheHouseData.LocationFirstFloorTelephoneBooth, TheHouseData.ExitsFirstFloorTelephoneBooth));
        }

        /// <summary>
        /// Inits the second floor rooms.
        /// </summary>
        private void InitSecondFloorRooms()
        {
            this.rooms.Add(new Room(TheHouseData.BathroomName, TheHouseData.LocationSecondFloorBathroom, TheHouseData.ExitsSecondFloorBathroom));
            this.rooms.Add(new Room(TheHouseData.ClosetName, TheHouseData.LocationSecondFloorCloset, TheHouseData.ExitsSecondFloorCloset));
            this.rooms.Add(new Room(TheHouseData.DenName, TheHouseData.LocationSecondFloorDen, TheHouseData.ExitsSecondFloorDen));
            this.rooms.Add(new Elevator(TheHouseData.SecondFloorElevatorName, TheHouseData.LocationSecondFloorElevator, TheHouseData.ExitsSecondFloorElevator));
            this.rooms.Add(new Room(TheHouseData.GuestroomName, TheHouseData.LocationSecondFloorGuestroom1, TheHouseData.ExitsSecondFloorGuestroom1));
            this.rooms.Add(new Room(TheHouseData.GuestroomName, TheHouseData.LocationSecondFloorGuestroom2, TheHouseData.ExitsSecondFloorGuestroom2));
            this.rooms.Add(new Room(TheHouseData.MasterBedroomName, TheHouseData.LocationSecondFloorMasterBedroom, TheHouseData.ExitsSecondFloorMasterBedroom));
            this.rooms.Add(new Room(TheHouseData.SewingRoomName, TheHouseData.LocationSecondFloorSewingRoom, TheHouseData.ExitsSecondFloorSewingRoom));
            this.rooms.Add(new Room(TheHouseData.SittingRoomName, TheHouseData.LocationSecondFloorSittingRoom, TheHouseData.ExitsSecondFloorSittingRoom));
            this.rooms.Add(new TelephoneBooth(TheHouseData.TelephoneBoothName, TheHouseData.LocationSecondFloorTelephoneBooth, TheHouseData.ExitsSecondFloorTelephoneBooth));
        }

        /// <summary>
        /// Inits the third floor rooms.
        /// </summary>
        private void InitThirdFloorRooms()
        {
            this.rooms.Add(new Room(TheHouseData.ArtHallName, TheHouseData.LocationThirdFloorArtHall, TheHouseData.ExitsThirdFloorArtHall));
            this.rooms.Add(new Room(TheHouseData.BarroomName, TheHouseData.LocationThirdFloorBarroom, TheHouseData.ExitsThirdFloorBarroom));
            this.rooms.Add(new Room(TheHouseData.BedroomName, TheHouseData.LocationThirdFloorBedroom, TheHouseData.ExitsThirdFloorBedroom));
            this.rooms.Add(new Room(TheHouseData.ComputerRoomName, TheHouseData.LocationThirdFloorComputerRoom, TheHouseData.ExitsThirdFloorComputerRoom));
            this.rooms.Add(new Elevator(TheHouseData.ThirdFloorElevatorName, TheHouseData.LocationThirdFloorElevator, TheHouseData.ExitsThirdFloorElevator));
            this.rooms.Add(new Room(TheHouseData.GameRoomName, TheHouseData.LocationThirdFloorGameRoom, TheHouseData.ExitsThirdFloorGameRoom));
            this.rooms.Add(new Room(TheHouseData.LibraryName, TheHouseData.LocationThirdFloorLibrary, TheHouseData.ExitsThirdFloorLibrary));
            this.rooms.Add(new Room(TheHouseData.LivingRoomName, TheHouseData.LocationThirdFloorLivingRoom, TheHouseData.ExitsThirdFloorLivingRoom));
            this.rooms.Add(new TelephoneBooth(TheHouseData.TelephoneBoothName, TheHouseData.LocationThirdFloorTelephoneBooth, TheHouseData.ExitsThirdFloorTelephoneBooth));
            this.rooms.Add(new Room(TheHouseData.TrophyRoomName, TheHouseData.LocationThirdFloorTrophyRoom, TheHouseData.ExitsThirdFloorTrophyRoom));
        }

        /// <summary>
        /// Inits the monster hangout rooms.
        /// </summary>
        private void InitMonsterHangoutRooms()
        {
            this.rooms.Add(new MonsterHangout(TheHouseData.MonsterHangoutName, TheHouseData.LocationMonsterHangout, TheHouseData.ExitsMonsterHangout));
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
            Room room = this.rooms[TheHouseData.LocationFirstFloorFrontPorch];
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
            MonsterHangout monsterHangout = this.rooms[TheHouseData.LocationMonsterHangout] as MonsterHangout;
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
            this.Rooms[TheHouseData.LocationMonsterHangout].Adversaries.Add(adversary);
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

            this.InitPortableObjects();
        }
    }
}
