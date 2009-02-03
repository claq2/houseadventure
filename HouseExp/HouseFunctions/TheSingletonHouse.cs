using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    using System.Xml.Serialization;
    using System.IO;
    /// <summary>
    /// 
    /// </summary>
    public class TheSingletonHouse
    {

		#region Fields (6) 

        private AdversaryCollection adversaries = new AdversaryCollection();
        private InanimateObjectKeyedCollection inanimateObjects = new InanimateObjectKeyedCollection();
        private static readonly TheSingletonHouse instance = new TheSingletonHouse();
        private PlayerEntity player;
        private InanimateObjectKeyedCollection portableObjects = new InanimateObjectKeyedCollection();
        private RoomKeyedCollection rooms = new RoomKeyedCollection();

		#endregion Fields 

		#region Constructors (1) 

        private TheSingletonHouse()
        {
            InitRooms();
            InitObjects();
            InitPortableObjects();
            InitMonsters();
            player = new PlayerEntity(this);
        }

		#endregion Constructors 

		#region Properties (6) 

        /// <summary>
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public AdversaryCollection Adversaries
        {
            get { return adversaries; }
        }

        /// <summary>
        /// Gets the inanimate objects.
        /// </summary>
        /// <value>The inanimate objects.</value>
        public InanimateObjectKeyedCollection InanimateObjects
        {
            get { return inanimateObjects; }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static TheSingletonHouse Instance
        {
            get { return TheSingletonHouse.instance; }
        }

        /// <summary>
        /// Gets or sets the player entity.
        /// </summary>
        /// <value>The player entity.</value>
        public PlayerEntity Player
        {
            get { return player; }
        }

        /// <summary>
        /// Gets the portable objects.
        /// </summary>
        /// <value>The portable objects.</value>
        public InanimateObjectKeyedCollection PortableObjects
        {
            get { return portableObjects; }
        }

        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <value>The rooms.</value>
        public RoomKeyedCollection Rooms
        {
            get { return rooms; }
        }

		#endregion Properties 

		#region Methods (10) 


		// Public Methods (3) 

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <returns></returns>
        public string Load()
        {
            StringBuilder sbOutput = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
            // Reading the XML document requires a FileStream.
            using (Stream reader = new FileStream("housedata.txt", FileMode.Open))
            {
                // Declare an object variable of the type to be deserialized.
                //OrderedItem i;
                // Call the Deserialize method to restore the object's state.
                SaveData saveData = new SaveData();
                saveData = (SaveData)serializer.Deserialize(reader);
                reader.Close();
                RestoreFromSaveData(saveData);
                player.RestoreFromSaveData(saveData);
            }
            sbOutput.Append("Data loaded");
            return sbOutput.ToString();
        }

        /// <summary>
        /// Restores from save data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void RestoreFromSaveData(SaveData data)
        {
            int iCountRooms = data.Rooms.Count;
            for (int i = 0; i < iCountRooms; i++)
            {
                this.rooms.Remove(data.Rooms[i].Location);
                this.rooms.Add(data.Rooms[i]);
                int iCountAdversariesInRoom = data.Rooms[i].Adversaries.Count;
                for (int j = 0; j < iCountAdversariesInRoom; j++)
                {
                    this.adversaries.Remove(data.Rooms[i].Adversaries[j].Name);
                    this.adversaries.Add(data.Rooms[i].Adversaries[j]);
                }
                int iCountItemsInRoom = data.Rooms[i].Items.Count;
                for (int j = 0; j < iCountItemsInRoom; j++)
                {
                    this.inanimateObjects.Remove(data.Rooms[i].Items[j].Name);
                    this.inanimateObjects.Add(data.Rooms[i].Items[j]);
                }
            }
            InitPortableObjects();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            SaveData saveData = new SaveData();
            player.PopulateSaveData(saveData);
            PopulateSaveData(saveData);
            StringBuilder sbOutput = new StringBuilder();
            XmlSerializer serializerSaveData = new XmlSerializer(typeof(SaveData));
            using (TextWriter writer = new StreamWriter("housedata.txt"))
            {
                serializerSaveData.Serialize(writer, saveData);
            }
            //writer.Close();
            sbOutput.Append("Data saved");
            return sbOutput.ToString();
        }



		// Private Methods (5) 

        private void InitMonsters()
        {
            adversaries.Add(new Adversary(TheHouseData.BlobName, rooms[TheHouseData.LocationBasementFreezer]));
            adversaries.Add(new Adversary(TheHouseData.BeastName, rooms[TheHouseData.LocationBasementPumpRoom]));
            adversaries.Add(new Adversary(TheHouseData.LeopardName, rooms[TheHouseData.LocationThirdFloorLibrary]));
            adversaries.Add(new Adversary(TheHouseData.MonkName, rooms[TheHouseData.LocationSecondFloorGuestroom1]));
            adversaries.Add(new Adversary(TheHouseData.VampireName, rooms[TheHouseData.LocationFirstFloorKitchen]));
            adversaries.Add(new Adversary(TheHouseData.WerewolfName, rooms[TheHouseData.LocationThirdFloorArtHall]));
            string stringImpostorName = portableObjects[new Random().Next(portableObjects.Count)].Name;
            int intImpostorRoomNumber = new Random().Next(10);
            Floor floorImpostorFloor = (Floor)new Random().Next(4);
            LocationType locationImpostorLocation = new LocationType(intImpostorRoomNumber, floorImpostorFloor);
            adversaries.Add(new Impostor(stringImpostorName, rooms[locationImpostorLocation]));
        }

        private void InitObjects()
        {
            inanimateObjects.Add(new PortableObject(TheHouseData.BagOfGoldName, rooms[TheHouseData.LocationBasementTortureChamber]));
            inanimateObjects.Add(new PortableObject(TheHouseData.BanjoName, rooms[TheHouseData.LocationSecondFloorDen]));
            inanimateObjects.Add(new ConsumableObject(TheHouseData.BatteriesName, rooms[TheHouseData.LocationThirdFloorTrophyRoom], 40));
            inanimateObjects.Add(new PortableObject(TheHouseData.BrushName, rooms[TheHouseData.LocationSecondFloorSittingRoom]));
            inanimateObjects.Add(new ConsumableObject(TheHouseData.BugSprayName, rooms[TheHouseData.LocationBasementPumpRoom], 3));
            inanimateObjects.Add(new PortableObject(TheHouseData.DiamondName, rooms[TheHouseData.LocationSecondFloorCloset]));
            inanimateObjects.Add(new PortableObject(TheHouseData.DimeName, rooms[TheHouseData.LocationFirstFloorDiningRoom], false, false));
            inanimateObjects.Add(new PainfulObject(TheHouseData.DryIceName, rooms[TheHouseData.LocationThirdFloorBarroom]));
            inanimateObjects.Add(new OnOffObject(TheHouseData.FlashlightName, rooms[TheHouseData.LocationFirstFloorCoatCloset]));
            inanimateObjects.Add(new PortableObject(TheHouseData.GarlicName, rooms[TheHouseData.LocationBasementDirtFlooredRoom], true, true));
            inanimateObjects.Add(new ProtectiveObject(TheHouseData.GloveName, rooms[TheHouseData.LocationBasementTelephoneBooth], false, false));
            inanimateObjects.Add(new MultiplePieceObject(TheHouseData.CoinsName, rooms[TheHouseData.LocationSecondFloorTelephoneBooth]));
            inanimateObjects.Add(new PortableObject(TheHouseData.KnifeName, rooms[TheHouseData.LocationFirstFloorKitchen]));
            inanimateObjects.Add(new DelicateObject(TheHouseData.VaseName, rooms[TheHouseData.LocationSecondFloorGuestroom1]));
            inanimateObjects.Add(new PortableObject(TheHouseData.ParchmentName, rooms[TheHouseData.LocationBasementFreezer]));
            inanimateObjects.Add(new CushioningObject(TheHouseData.PillowName, rooms[TheHouseData.LocationThirdFloorArtHall]));
            inanimateObjects.Add(new PortableObject(TheHouseData.RustedKeyName, rooms[TheHouseData.LocationBasementDirtFlooredRoom], true, true));
            inanimateObjects.Add(new PortableObject(TheHouseData.ShovelName, rooms[TheHouseData.LocationThirdFloorComputerRoom]));
            inanimateObjects.Add(new PortableObject(TheHouseData.BookName, rooms[TheHouseData.LocationThirdFloorLibrary]));
            inanimateObjects.Add(new ContainerObject(TheHouseData.BoxName, rooms[TheHouseData.LocationFirstFloorFoyer]));

            inanimateObjects.Add(new LockableDoorObject(TheHouseData.LockedDoorName, rooms[TheHouseData.LocationFirstFloorFoyer], new RoomExit(Direction.South, 0)));
            inanimateObjects.Add(new StationaryObject(TheHouseData.BathtubName, rooms[TheHouseData.LocationSecondFloorBathroom]));
            inanimateObjects.Add(new StationaryObject(TheHouseData.FrontYardName, rooms[TheHouseData.LocationFirstFloorFrontPorch]));
            inanimateObjects.Add(new StationaryObject(TheHouseData.BedName, rooms[TheHouseData.LocationSecondFloorMasterBedroom]));
            inanimateObjects.Add(new StationaryObject(TheHouseData.MainframeName, rooms[TheHouseData.LocationThirdFloorComputerRoom]));
            inanimateObjects.Add(new StationaryObject(TheHouseData.MooseHeadName, rooms[TheHouseData.LocationSecondFloorDen]));
            inanimateObjects.Add(new StationaryObject(TheHouseData.StocksName, rooms[TheHouseData.LocationBasementTortureChamber]));

        }

        private void InitPortableObjects()
        {
            int intCount = inanimateObjects.Count;
            portableObjects.Clear();
            for (int i = 0; i < intCount; i++)
            {
                PortableObject portable = inanimateObjects[i] as PortableObject;
                if (portable != null)
                {
                    portableObjects.Add(portable);
                }
            }
        }

        private void InitRooms()
        {
            rooms.Add(new Room(TheHouseData.CoalBinName, TheHouseData.LocationBasementCoalBin, TheHouseData.ExitsBasementCoalBin));
            rooms.Add(new UnfinishedFlooredRoom(TheHouseData.DirtFlooredRoomName, TheHouseData.LocationBasementDirtFlooredRoom, TheHouseData.ExitsBasementDirtFlooredRoom));
            rooms.Add(new Elevator(TheHouseData.BasementElevatorName, TheHouseData.LocationBasementElevator, TheHouseData.ExitsBasementElevator));
            rooms.Add(new Room(TheHouseData.FreezerName, TheHouseData.LocationBasementFreezer, TheHouseData.ExitsBasementFreezer));
            rooms.Add(new Room(TheHouseData.FurnaceRoomName, TheHouseData.LocationBasementFurnaceRoom, TheHouseData.ExitsBasementFurnaceRoom));
            rooms.Add(new Room(TheHouseData.LaboratoryName, TheHouseData.LocationBasementLaboratory, TheHouseData.ExitsBasementLaboratory));
            rooms.Add(new Room(TheHouseData.PumpRoomName, TheHouseData.LocationBasementPumpRoom, TheHouseData.ExitsBasementPumpRoom));
            rooms.Add(new TelephoneBooth(TheHouseData.TelephoneBoothName, TheHouseData.LocationBasementTelephoneBooth, TheHouseData.ExitsBasementTelephoneBooth, true, (MagicWord)new Random().Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1));
            rooms.Add(new Room(TheHouseData.TortureChamberName, TheHouseData.LocationBasementTortureChamber, TheHouseData.ExitsBasementTortureChamber));
            rooms.Add(new Room(TheHouseData.WorkshopName, TheHouseData.LocationBasementWorkshop, TheHouseData.ExitsBasementWorkshop));

            rooms.Add(new Room(TheHouseData.BedroomName, TheHouseData.LocationFirstFloorBedroom, TheHouseData.ExitsFirstFloorBedroom));
            rooms.Add(new Room(TheHouseData.CoatClosetName, TheHouseData.LocationFirstFloorCoatCloset, TheHouseData.ExitsFirstFloorCoatCloset));
            rooms.Add(new Room(TheHouseData.DiningRoomName, TheHouseData.LocationFirstFloorDiningRoom, TheHouseData.ExitsFirstFloorDiningRoom));
            rooms.Add(new Room(TheHouseData.FirstFloorElevatorName, TheHouseData.LocationFirstFloorElevator, TheHouseData.ExitsFirstFloorElevator));
            rooms.Add(new Room(TheHouseData.FamilyRoomName, TheHouseData.LocationFirstFloorFamilyRoom, TheHouseData.ExitsFirstFloorFamilyRoom));
            rooms.Add(new Room(TheHouseData.FoyerName, TheHouseData.LocationFirstFloorFoyer, TheHouseData.ExitsFirstFloorFoyer));
            rooms.Add(new Room(TheHouseData.FrontPorchName, TheHouseData.LocationFirstFloorFrontPorch, TheHouseData.ExitsFirstFloorFrontPorch));
            rooms.Add(new Room(TheHouseData.KitchenName, TheHouseData.LocationFirstFloorKitchen, TheHouseData.ExitsFirstFloorKitchen));
            rooms.Add(new Room(TheHouseData.PantryName, TheHouseData.LocationFirstFloorPantry, TheHouseData.ExitsFirstFloorPantry));
            rooms.Add(new Room(TheHouseData.TelephoneBoothName, TheHouseData.LocationFirstFloorTelephoneBooth, TheHouseData.ExitsFirstFloorTelephoneBooth));

            rooms.Add(new Room(TheHouseData.BathroomName, TheHouseData.LocationSecondFloorBathroom, TheHouseData.ExitsSecondFloorBathroom));
            rooms.Add(new Room(TheHouseData.ClosetName, TheHouseData.LocationSecondFloorCloset, TheHouseData.ExitsSecondFloorCloset));
            rooms.Add(new Room(TheHouseData.DenName, TheHouseData.LocationSecondFloorDen, TheHouseData.ExitsSecondFloorDen));
            rooms.Add(new Room(TheHouseData.SecondFloorElevatorName, TheHouseData.LocationSecondFloorElevator, TheHouseData.ExitsSecondFloorElevator));
            rooms.Add(new Room(TheHouseData.GuestroomName, TheHouseData.LocationSecondFloorGuestroom1, TheHouseData.ExitsSecondFloorGuestroom1));
            rooms.Add(new Room(TheHouseData.GuestroomName, TheHouseData.LocationSecondFloorGuestroom2, TheHouseData.ExitsSecondFloorGuestroom2));
            rooms.Add(new Room(TheHouseData.MasterBedroomName, TheHouseData.LocationSecondFloorMasterBedroom, TheHouseData.ExitsSecondFloorMasterBedroom));
            rooms.Add(new Room(TheHouseData.SewingRoomName, TheHouseData.LocationSecondFloorSewingRoom, TheHouseData.ExitsSecondFloorSewingRoom));
            rooms.Add(new Room(TheHouseData.SittingRoomName, TheHouseData.LocationSecondFloorSittingRoom, TheHouseData.ExitsSecondFloorSittingRoom));
            rooms.Add(new Room(TheHouseData.TelephoneBoothName, TheHouseData.LocationSecondFloorTelephoneBooth, TheHouseData.ExitsSecondFloorTelephoneBooth));

            rooms.Add(new Room(TheHouseData.ArtHallName, TheHouseData.LocationThirdFloorArtHall, TheHouseData.ExitsThirdFloorArtHall));
            rooms.Add(new Room(TheHouseData.BarroomName, TheHouseData.LocationThirdFloorBarroom, TheHouseData.ExitsThirdFloorBarroom));
            rooms.Add(new Room(TheHouseData.BedroomName, TheHouseData.LocationThirdFloorBedroom, TheHouseData.ExitsThirdFloorBedroom));
            rooms.Add(new Room(TheHouseData.ComputerRoomName, TheHouseData.LocationThirdFloorComputerRoom, TheHouseData.ExitsThirdFloorComputerRoom));
            rooms.Add(new Room(TheHouseData.ThirdFloorElevatorName, TheHouseData.LocationThirdFloorElevator, TheHouseData.ExitsThirdFloorElevator));
            rooms.Add(new Room(TheHouseData.GameRoomName, TheHouseData.LocationThirdFloorGameRoom, TheHouseData.ExitsThirdFloorGameRoom));
            rooms.Add(new Room(TheHouseData.LibraryName, TheHouseData.LocationThirdFloorLibrary, TheHouseData.ExitsThirdFloorLibrary));
            rooms.Add(new Room(TheHouseData.LivingRoomName, TheHouseData.LocationThirdFloorLivingRoom, TheHouseData.ExitsThirdFloorLivingRoom));
            rooms.Add(new Room(TheHouseData.TelephoneBoothName, TheHouseData.LocationThirdFloorTelephoneBooth, TheHouseData.ExitsThirdFloorTelephoneBooth));
            rooms.Add(new Room(TheHouseData.TrophyRoomName, TheHouseData.LocationThirdFloorTrophyRoom, TheHouseData.ExitsThirdFloorTrophyRoom));

            rooms.Add(new MonsterHangout(TheHouseData.MonsterHangoutName, TheHouseData.LocationMonsterHangout, TheHouseData.ExitsMonsterHangout));
        }

        /// <summary>
        /// Populates the save data.
        /// </summary>
        /// <param name="data">The data.</param>
        private void PopulateSaveData(SaveData data)
        {
            data.PopulateRooms(rooms);
        }



		// Internal Methods (2) 

        /// <summary>
        /// Removes the front porch items.
        /// </summary>
        internal void RemoveFrontPorchItems()
        {
            Room room = rooms[TheHouseData.LocationFirstFloorFrontPorch];
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
            MonsterHangout room = rooms[TheHouseData.LocationMonsterHangout] as MonsterHangout;
            foreach (Adversary adversary in room.Adversaries)
            {
                if (adversary.MovesUntilUnhidden > 1)
                {
                    adversary.MovesUntilUnhidden--;
                }
                else if (adversary.MovesUntilUnhidden == 1)
                {
                    adversary.MovesUntilUnhidden--;
                    room.Adversaries.Remove(adversary);
                    LocationType locationNew = new LocationType(new Random().Next(10), (Floor)new Random().Next(4));
                    rooms[locationNew].Adversaries.Add(adversary);
                }
            }
        }


		#endregion Methods 

    }
}
