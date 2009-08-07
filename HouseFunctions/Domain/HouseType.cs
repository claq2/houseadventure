//-----------------------------------------------------------------------
// <copyright file="HouseType.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.Collections.ObjectModel;

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

#if !(DEBUG)
        private Random random = new Random();
#endif
        #endregion Fields

        #region Constructors (2)

        /// <summary>
        /// Initializes a new instance of the <see cref="HouseType"/> class.
        /// </summary>
        /// <param name="initializeHouse">if set to <c>true</c> [initialize house].</param>
        public HouseType(bool initializeHouse)
        {
            if (!initializeHouse)
                return;

            this.InitRooms();
            this.InitObjects();
            this.InitMonsters();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HouseType"/> class.
        /// </summary>
        public HouseType()
        {
        }

        #endregion Constructors

        #region Properties (8)

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

        private FloorKeyedCollection floors = new FloorKeyedCollection();

        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
        public InanimateObjectKeyedCollection Inventory
        {
            get
            {
                InanimateObjectKeyedCollection result = new InanimateObjectKeyedCollection();
                foreach (InanimateObject obj in this.Rooms[RoomData.LocationInventory].Items)
                {
                    result.Add(obj);
                }

                return result;
            }
        }

        /// <summary>
        /// Gets or sets the items removed from house.
        /// </summary>
        /// <value>The items removed from house.</value>
        public int ItemsRemovedFromHouse { get; set; }

        /// <summary>
        /// Gets or sets the number of moves.
        /// </summary>
        /// <value>The number of moves.</value>
        public int NumberOfMoves { get; set; }

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

        /// <summary>
        /// Gets or sets the times looked in dark.
        /// </summary>
        /// <value>The times looked in dark.</value>
        public int TimesLookedInDark { get; set; }

        #endregion Properties

        #region Methods (2)

        // Public Methods (2) 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portableObject"></param>
        public void AddToInventory(PortableObject portableObject)
        {
            if (this.Rooms[RoomData.LocationInventory].Items.Count == 1 && this.Rooms[RoomData.LocationInventory].Items[0] is NullObject)
            {
                this.Rooms[RoomData.LocationInventory].Items.RemoveAt(0);
            }

            foreach (Room room in this.Rooms)
            {
                int intItemNumber = -1;
                int intCounter = 0;
                bool boolItemFound = false;
                foreach (InanimateObject inanimateObject in room.Items)
                {
                    if (inanimateObject != portableObject)
                    {
                        intCounter++;
                        continue;
                    }

                    boolItemFound = true;
                    intItemNumber = intCounter;
                }

                if (!boolItemFound)
                    continue;

                room.Items.RemoveAt(intItemNumber);
                this.Rooms[RoomData.LocationInventory].Items.Add(portableObject);
                break;
            }
        }

        /// <summary>
        /// Transfers an item from the inventory to the room
        /// </summary>
        /// <param name="portableObject">The object to remove from the inventory</param>
        /// <param name="location">The room in which to put the object down</param>
        public void RemoveFromInventory(PortableObject portableObject, LocationType location)
        {
            this.Rooms[RoomData.LocationInventory].Items.Remove(portableObject);
            this.Rooms[location].Items.Add(portableObject);
            if (this.Rooms[RoomData.LocationInventory].Items.Count == 0)
            {
                this.Rooms[RoomData.LocationInventory].Items.Add(new NullObject());
            }

        }

        #endregion Methods

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

        // Private Methods (5) 

        /// <summary>
        /// Inits the monsters.
        /// </summary>
        private void InitMonsters()
        {
            this.adversaries.Add(new Adversary(AdversaryData.BlobName, this.rooms[RoomData.LocationBasementFreezer], AdversaryData.BlobShortName));
            this.adversaries.Add(new Adversary(AdversaryData.BeastName, this.rooms[RoomData.LocationBasementPumpRoom], AdversaryData.BeastShortName));
            this.adversaries.Add(new Adversary(AdversaryData.LeopardName, this.rooms[RoomData.LocationThirdFloorLibrary], AdversaryData.LeopardShortName));
            this.adversaries.Add(new Adversary(AdversaryData.MonkName, this.rooms[RoomData.LocationSecondFloorGuestroom1], AdversaryData.MonkShortName));
            this.adversaries.Add(new Adversary(AdversaryData.VampireName, this.rooms[RoomData.LocationFirstFloorKitchen], AdversaryData.VampireShortName));
            this.adversaries.Add(new Adversary(AdversaryData.WerewolfName, this.rooms[RoomData.LocationThirdFloorArtHall], AdversaryData.WerewolfShortName));
#if (DEBUG)
            int intImpostorItemNumber = 0;
            int intImpostorRoomNumber = 0;
            Floor floorImpostorFloor = Floor.SecondFloor;
#else
            int intImpostorItemNumber = this.random.Next(this.PortableObjects.Count);
            int intImpostorRoomNumber = this.random.Next(10);
            Floor floorImpostorFloor = (Floor)this.random.Next(4);
#endif
            string stringImpostorDisplayName = this.PortableObjects[intImpostorItemNumber].Name;
            string stringImpostorShortName = this.PortableObjects[intImpostorItemNumber].ShortName;
            LocationType locationImpostorLocation = new LocationType(intImpostorRoomNumber, floorImpostorFloor);
            this.adversaries.Add(new Impostor(stringImpostorDisplayName, this.rooms[locationImpostorLocation], stringImpostorShortName));
        }

        /// <summary>
        /// Inits the objects.
        /// </summary>
        private void InitObjects()
        {
            this.inanimateObjects.Add(new PortableObject(ObjectData.BagOfGoldName, this.rooms[RoomData.LocationBasementTortureChamber], ObjectData.BagOfGoldShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.BanjoName, this.rooms[RoomData.LocationSecondFloorDen], ObjectData.BanjoShortName));
            this.inanimateObjects.Add(new ConsumableObject(ObjectData.BatteriesName, this.rooms[RoomData.LocationThirdFloorTrophyRoom], 40, ObjectData.BatteriesShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.BrushName, this.rooms[RoomData.LocationSecondFloorSittingRoom], ObjectData.BrushShortName));
            this.inanimateObjects.Add(new ConsumableObject(ObjectData.BugSprayName, this.rooms[RoomData.LocationBasementPumpRoom], 3, ObjectData.BugSprayShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.DiamondName, this.rooms[RoomData.LocationSecondFloorCloset], ObjectData.DiamondShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.DimeName, this.rooms[RoomData.LocationFirstFloorDiningRoom], false, false, ObjectData.DimeShortName));
            this.inanimateObjects.Add(new PainfulObject(ObjectData.DryIceName, this.rooms[RoomData.LocationThirdFloorBarroom], ObjectData.DryIceShortName));
            this.inanimateObjects.Add(new OnOffObject(ObjectData.FlashlightName, this.rooms[RoomData.LocationFirstFloorCoatCloset], ObjectData.FlashlightShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.GarlicName, this.rooms[RoomData.LocationBasementDirtFlooredRoom], true, true, ObjectData.GarlicShortName));
            this.inanimateObjects.Add(new ProtectiveObject(ObjectData.GloveName, this.rooms[RoomData.LocationBasementTelephoneBooth], false, false, ObjectData.GloveShortName));
            this.inanimateObjects.Add(new MultiplePieceObject(ObjectData.CoinsName, this.rooms[RoomData.LocationSecondFloorTelephoneBooth], ObjectData.CoinsShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.KnifeName, this.rooms[RoomData.LocationFirstFloorKitchen], ObjectData.KnifeShortName));
            this.inanimateObjects.Add(new DelicateObject(ObjectData.VaseName, this.rooms[RoomData.LocationSecondFloorGuestroom1], ObjectData.VaseShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.ParchmentName, this.rooms[RoomData.LocationBasementFreezer], ObjectData.ParchmentShortName));
            this.inanimateObjects.Add(new CushioningObject(ObjectData.PillowName, this.rooms[RoomData.LocationThirdFloorArtHall], ObjectData.PillowShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.RustedKeyName, this.rooms[RoomData.LocationBasementDirtFlooredRoom], true, true, ObjectData.RustedKeyShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.ShovelName, this.rooms[RoomData.LocationThirdFloorComputerRoom], ObjectData.ShovelShortName));
            this.inanimateObjects.Add(new PortableObject(ObjectData.BookName, this.rooms[RoomData.LocationThirdFloorLibrary], ObjectData.BookShortName));
            this.inanimateObjects.Add(new ContainerObject(ObjectData.BoxName, this.rooms[RoomData.LocationFirstFloorFoyer], ObjectData.BoxShortName));

            this.inanimateObjects.Add(new LockableDoorObject(ObjectData.LockedDoorName, this.rooms[RoomData.LocationFirstFloorFoyer], new RoomExit(Direction.South, 0), ObjectData.LockedDoorShortName));
            this.inanimateObjects.Add(new StationaryObject(ObjectData.BathtubName, this.rooms[RoomData.LocationSecondFloorBathroom]));
            this.inanimateObjects.Add(new StationaryObject(ObjectData.FrontYardName, this.rooms[RoomData.LocationFirstFloorFrontPorch]));
            this.inanimateObjects.Add(new StationaryObject(ObjectData.BedName, this.rooms[RoomData.LocationSecondFloorMasterBedroom]));
            this.inanimateObjects.Add(new StationaryObject(ObjectData.MainframeName, this.rooms[RoomData.LocationThirdFloorComputerRoom]));
            this.inanimateObjects.Add(new StationaryObject(ObjectData.MooseHeadName, this.rooms[RoomData.LocationSecondFloorDen]));
            this.inanimateObjects.Add(new StationaryObject(ObjectData.StocksName, this.rooms[RoomData.LocationBasementTortureChamber]));
        }

        /// <summary>
        /// Inits the basement rooms.
        /// </summary>
        private void InitBasementRooms()
        {
            Room2KeyedCollection room2Collection = new Room2KeyedCollection();
            room2Collection.RoomFloor = Floor.Basement;
            this.floors.Add(room2Collection);
            this.rooms.Add(new Room(RoomData.CoalBinName, RoomData.LocationBasementCoalBin, RoomData.ExitsBasementCoalBin));
            this.floors[Floor.Basement].Add(new Room2(RoomData.CoalBinName, RoomData.LocationBasementCoalBin.RoomNumber, RoomData.ExitsBasementCoalBin));
            this.rooms.Add(new UnfinishedFlooredRoom(RoomData.DirtFlooredRoomName, RoomData.LocationBasementDirtFlooredRoom, RoomData.ExitsBasementDirtFlooredRoom));
            this.floors[Floor.Basement].Add(new UnfinishedFlooredRoom2(RoomData.DirtFlooredRoomName, RoomData.LocationBasementDirtFlooredRoom.RoomNumber, RoomData.ExitsBasementDirtFlooredRoom));
            this.rooms.Add(new Elevator(RoomData.BasementElevatorName, RoomData.LocationBasementElevator, RoomData.ExitsBasementElevator));
            this.floors[Floor.Basement].Add(new Elevator2(RoomData.BasementElevatorName, RoomData.LocationBasementElevator.RoomNumber, RoomData.ExitsBasementElevator));
            this.rooms.Add(new Room(RoomData.FreezerName, RoomData.LocationBasementFreezer, RoomData.ExitsBasementFreezer));
            this.floors[Floor.Basement].Add(new Room2(RoomData.FreezerName, RoomData.LocationBasementFreezer.RoomNumber, RoomData.ExitsBasementFreezer));
            this.rooms.Add(new Room(RoomData.FurnaceRoomName, RoomData.LocationBasementFurnaceRoom, RoomData.ExitsBasementFurnaceRoom));
            this.floors[Floor.Basement].Add(new Room2(RoomData.FurnaceRoomName, RoomData.LocationBasementFurnaceRoom.RoomNumber, RoomData.ExitsBasementFurnaceRoom));
            this.rooms.Add(new Room(RoomData.LaboratoryName, RoomData.LocationBasementLaboratory, RoomData.ExitsBasementLaboratory));
            this.rooms.Add(new Room(RoomData.PumpRoomName, RoomData.LocationBasementPumpRoom, RoomData.ExitsBasementPumpRoom));
#if (DEBUG)
            MagicWord word = MagicWord.Seersucker;
#else
            MagicWord word = (MagicWord)this.random.Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1;
#endif
            this.rooms.Add(new TelephoneBooth(RoomData.TelephoneBoothName, RoomData.LocationBasementTelephoneBooth, RoomData.ExitsBasementTelephoneBooth, true, word));
            this.rooms.Add(new Room(RoomData.TortureChamberName, RoomData.LocationBasementTortureChamber, RoomData.ExitsBasementTortureChamber));
            this.rooms.Add(new Room(RoomData.WorkshopName, RoomData.LocationBasementWorkshop, RoomData.ExitsBasementWorkshop));
        }

        /// <summary>
        /// Inits the first floor rooms.
        /// </summary>
        private void InitFirstFloorRooms()
        {
            this.rooms.Add(new Room(RoomData.BedroomName, RoomData.LocationFirstFloorBedroom, RoomData.ExitsFirstFloorBedroom));
            this.rooms.Add(new Room(RoomData.CoatClosetName, RoomData.LocationFirstFloorCoatCloset, RoomData.ExitsFirstFloorCoatCloset));
#if (DEBUG)
            MagicWord word = MagicWord.Seersucker;
#else
            MagicWord word = (MagicWord)this.random.Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1;
#endif
            this.rooms.Add(new Room(RoomData.DiningRoomName, RoomData.LocationFirstFloorDiningRoom, RoomData.ExitsFirstFloorDiningRoom, true, word));
            this.rooms.Add(new Elevator(RoomData.FirstFloorElevatorName, RoomData.LocationFirstFloorElevator, RoomData.ExitsFirstFloorElevator));
            this.rooms.Add(new Room(RoomData.FamilyRoomName, RoomData.LocationFirstFloorFamilyRoom, RoomData.ExitsFirstFloorFamilyRoom));
            this.rooms.Add(new Room(RoomData.FoyerName, RoomData.LocationFirstFloorFoyer, RoomData.ExitsFirstFloorFoyer));
            this.rooms.Add(new Room(RoomData.FrontPorchName, RoomData.LocationFirstFloorFrontPorch, RoomData.ExitsFirstFloorFrontPorch));
            this.rooms.Add(new Room(RoomData.KitchenName, RoomData.LocationFirstFloorKitchen, RoomData.ExitsFirstFloorKitchen));
            this.rooms.Add(new Room(RoomData.PantryName, RoomData.LocationFirstFloorPantry, RoomData.ExitsFirstFloorPantry));
            this.rooms.Add(new TelephoneBooth(RoomData.TelephoneBoothName, RoomData.LocationFirstFloorTelephoneBooth, RoomData.ExitsFirstFloorTelephoneBooth));
        }

        /// <summary>
        /// Inits the second floor rooms.
        /// </summary>
        private void InitSecondFloorRooms()
        {
            this.rooms.Add(new Room(RoomData.BathroomName, RoomData.LocationSecondFloorBathroom, RoomData.ExitsSecondFloorBathroom));
            this.rooms.Add(new Room(RoomData.ClosetName, RoomData.LocationSecondFloorCloset, RoomData.ExitsSecondFloorCloset));
            this.rooms.Add(new Room(RoomData.DenName, RoomData.LocationSecondFloorDen, RoomData.ExitsSecondFloorDen));
            this.rooms.Add(new Elevator(RoomData.SecondFloorElevatorName, RoomData.LocationSecondFloorElevator, RoomData.ExitsSecondFloorElevator));
            this.rooms.Add(new Room(RoomData.GuestroomName, RoomData.LocationSecondFloorGuestroom1, RoomData.ExitsSecondFloorGuestroom1));
            this.rooms.Add(new Room(RoomData.GuestroomName, RoomData.LocationSecondFloorGuestroom2, RoomData.ExitsSecondFloorGuestroom2));
            this.rooms.Add(new Room(RoomData.MasterBedroomName, RoomData.LocationSecondFloorMasterBedroom, RoomData.ExitsSecondFloorMasterBedroom));
            this.rooms.Add(new Room(RoomData.SewingRoomName, RoomData.LocationSecondFloorSewingRoom, RoomData.ExitsSecondFloorSewingRoom));
            this.rooms.Add(new Room(RoomData.SittingRoomName, RoomData.LocationSecondFloorSittingRoom, RoomData.ExitsSecondFloorSittingRoom));
            this.rooms.Add(new TelephoneBooth(RoomData.TelephoneBoothName, RoomData.LocationSecondFloorTelephoneBooth, RoomData.ExitsSecondFloorTelephoneBooth));
        }

        /// <summary>
        /// Inits the third floor rooms.
        /// </summary>
        private void InitThirdFloorRooms()
        {
            this.rooms.Add(new Room(RoomData.ArtHallName, RoomData.LocationThirdFloorArtHall, RoomData.ExitsThirdFloorArtHall));
            this.rooms.Add(new Room(RoomData.BarroomName, RoomData.LocationThirdFloorBarroom, RoomData.ExitsThirdFloorBarroom));
            this.rooms.Add(new Room(RoomData.BedroomName, RoomData.LocationThirdFloorBedroom, RoomData.ExitsThirdFloorBedroom));
            this.rooms.Add(new Room(RoomData.ComputerRoomName, RoomData.LocationThirdFloorComputerRoom, RoomData.ExitsThirdFloorComputerRoom));
            this.rooms.Add(new Elevator(RoomData.ThirdFloorElevatorName, RoomData.LocationThirdFloorElevator, RoomData.ExitsThirdFloorElevator));
            this.rooms.Add(new Room(RoomData.GameRoomName, RoomData.LocationThirdFloorGameRoom, RoomData.ExitsThirdFloorGameRoom));
            this.rooms.Add(new Room(RoomData.LibraryName, RoomData.LocationThirdFloorLibrary, RoomData.ExitsThirdFloorLibrary));
            this.rooms.Add(new Room(RoomData.LivingRoomName, RoomData.LocationThirdFloorLivingRoom, RoomData.ExitsThirdFloorLivingRoom));
            this.rooms.Add(new TelephoneBooth(RoomData.TelephoneBoothName, RoomData.LocationThirdFloorTelephoneBooth, RoomData.ExitsThirdFloorTelephoneBooth));
            this.rooms.Add(new Room(RoomData.TrophyRoomName, RoomData.LocationThirdFloorTrophyRoom, RoomData.ExitsThirdFloorTrophyRoom));
        }

        /// <summary>
        /// Inits the monster hangout room.
        /// </summary>
        private void InitMonsterHangoutRooms()
        {
            this.rooms.Add(new Room(RoomData.MonsterHangoutName, RoomData.LocationMonsterHangout, RoomData.ExitsMonsterHangout));
        }

        /// <summary>
        /// Inits the rooms.
        /// </summary>
        private void InitRooms()
        {
            this.InitBasementRooms();
            this.InitFirstFloorRooms();
            this.InitSecondFloorRooms();
            this.InitThirdFloorRooms();
            this.InitMonsterHangoutRooms();
            this.InitInventoryRoom();
        }

        /// <summary>
        /// Inits the inventory room.
        /// </summary>
        private void InitInventoryRoom()
        {
            this.rooms.Add(new Room(RoomData.InventoryName, RoomData.LocationInventory, RoomData.ExitsInventory));
            this.rooms[RoomData.LocationInventory].Items.Add(new NullObject());
        }

        // Internal Methods (2) 

        /// <summary>
        /// Removes the front porch items.
        /// </summary>
        internal void RemoveFrontPorchItems()
        {
            Room roomPorch = this.rooms[RoomData.LocationFirstFloorFrontPorch];
            List<InanimateObject> listItemsToRemove = new List<InanimateObject>();
            foreach (InanimateObject io in roomPorch.Items)
            {
                if (io is PortableObject)
                {
                    listItemsToRemove.Add(io);
                }
            }

            foreach (InanimateObject io in listItemsToRemove)
            {
                roomPorch.Items.Remove(io);
            }
        }

        /// <summary>
        /// Updates the monsters in hangout.
        /// </summary>
        internal void UpdateMonstersInHangout()
        {
            Room roomMonsterHangout = this.rooms[RoomData.LocationMonsterHangout];
            List<Adversary> listAdversariesToBringBack = new List<Adversary>();
            //TODO: decrement randomly, not every time
            foreach (Adversary adversary in roomMonsterHangout.Adversaries)
            {
                if (adversary.MovesUntilUnhidden > 1)
                {
                    adversary.MovesUntilUnhidden--;
                }
                else if (adversary.MovesUntilUnhidden == 1)
                {
                    listAdversariesToBringBack.Add(adversary);
                    adversary.MovesUntilUnhidden--;
                }
            }

            foreach (Adversary adversary in listAdversariesToBringBack)
            {
                roomMonsterHangout.Adversaries.Remove(adversary);
#if (DEBUG)
                int intRoom = 2;
                Floor floor = Floor.FirstFloor;
#else
                int intRoom = this.random.Next(10);
                Floor floor = (Floor)this.random.Next(4);
#endif
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
            this.Rooms[RoomData.LocationMonsterHangout].Adversaries.Add(adversary);
            adversary.MovesUntilUnhidden = 5;
        }

        /// <summary>
        /// Restores the house.
        /// </summary>
        /// <param name="value">The value.</param>
        public void RestoreHouse(RoomKeyedCollection value)
        {
            this.rooms.Clear();
            this.adversaries.Clear();
            this.inanimateObjects.Clear();
            int intCountRooms = value.Count;
            for (int i = 0; i < intCountRooms; i++)
            {
                //                this.rooms.Remove(value.Rooms[i].Location);
                this.rooms.Add(value[i]);
                int intCountAdversariesInRoom = value[i].Adversaries.Count;
                for (int j = 0; j < intCountAdversariesInRoom; j++)
                {
                    //                    this.adversaries.Remove(value.Rooms[i].Adversaries[j].Identity);
                    this.adversaries.Add(value[i].Adversaries[j]);
                }

                int intCountItemsInRoom = value[i].Items.Count;
                for (int j = 0; j < intCountItemsInRoom; j++)
                {
                    //this.inanimateObjects.Remove(value.Rooms[i].Items[j].Identity);
                    this.inanimateObjects.Add(value[i].Items[j]);
                }
            }
        }
    }
}
