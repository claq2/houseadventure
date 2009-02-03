using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

[assembly: CLSCompliant(true)]
namespace HouseFunctions
{
    using System.Collections.ObjectModel;
    /// <summary>
    /// 
    /// </summary>
    public static class TheHouse2
    {

		#region Fields (158) 

        //static string sObjectsShort = "GOLKEYCANGLOBOOKNIBOXDIMFLADIAPILPARHAICOIBANGARBATICESHOVAS";
        //static string sMonstersShort = "BLOVAMBEALEOMONWER";
        private static string[] actions = new string[] { "Get", "Drop", "Say", "Kill", "Stab", "Light", "Play", "Read", "Dig", "On", "Off", "Brush", "Wave", "Unlock", "Spray" };
        private static AdversaryCollection allAdversaries = InitializeAdversaryCollection();
        private static InanimateObjectsCollection allInanimateObjects = InitializeInanimateObjects();
        private static InanimateObjectKeyedCollection allInanimateObjects2 = InitializeInanimateObjects2();
        private static InanimateObjectsCollection allPortableObjects = InitializePortableObjects();
        private static RoomKeyedCollection allRooms = InitializeAllRooms();

        private static PortableObject bagOfGold = new PortableObject(m_BagOfGoldName, basementTortureChamber);
        private static PortableObject banjo = new PortableObject(m_BanjoName, secondFloorDen);
        private static Room basementCoalBin = new Room(m_CoalBinName, 4, Floor.Basement, new RoomExit[] { new RoomExit(Direction.East, 6), new RoomExit(Direction.West, 3) });
        private static UnfinishedFlooredRoom basementDirtFlooredRoom = new UnfinishedFlooredRoom(m_DirtFlooredRoomName, 0, Floor.Basement, new RoomExit[] { new RoomExit(Direction.West, 7), new RoomExit(Direction.South, 1) });
        private static Elevator basementElevator = new Elevator(m_BasementElevatorName, 9, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 3), new RoomExit(Direction.South, 8) });
        private static Room basementFreezer = new Room(m_FreezerName, 7, Floor.Basement, new RoomExit[] { new RoomExit(Direction.East, 0), new RoomExit(Direction.West, 6) });
        private static Room basementFurnaceRoom = new Room(m_FurnaceRoomName, 3, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.East, 4), new RoomExit(Direction.South, 9) });
        private static Room basementLabratory = new Room(m_LabratoryName, 1, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 0), new RoomExit(Direction.East, 2) });
        private static Room basementPumpRoom = new Room(m_PumpRoomName, 2, Floor.Basement, new RoomExit[] { new RoomExit(Direction.West, 1), new RoomExit(Direction.South, 3) });
        private static RoomKeyedCollection basementRooms = InitializeBasementRooms();
        private static TelephoneBooth basementTelephoneBooth = new TelephoneBooth(m_TelephoneBoothName, 8, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.South, 5) }, true, (MagicWord)new Random().Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1);
        private static Room basementTortureChamber = new Room(m_TortureChamberName, 5, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.South, 6) });
        private static Room basementWorkshop = new Room(m_WorkshopName, 6, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.East, 7), new RoomExit(Direction.West, 4) });
        private static StationaryObject bathtub = new StationaryObject(m_BathtubName, secondFloorBathroom);
        private static ConsumableObject batteries = new ConsumableObject(m_BatteriesName, thirdFloorTrophyRoom, 40);
        private static Adversary beast = new Adversary(m_BeastName, basementPumpRoom);
        private static Adversary blob = new Adversary(m_BlobName, basementFreezer);
        private static PortableObject brush = new PortableObject(m_BrushName, secondFloorSittingRoom);
        private static ConsumableObject bugSpray = new ConsumableObject(m_BugSprayName, basementPumpRoom, 3);
        private static ReadOnlyCollection<string> collectionActions = new ReadOnlyCollection<string>(actions);
        private static PortableObject diamond = new PortableObject(m_DiamondName, secondFloorCloset);
        private static PortableObject dime = new PortableObject(m_DimeName, firstFloorDiningRoom, false, false);
        /// <summary>
        /// String to display when a player tries to go in a direction that doesn't exist.
        /// </summary>
        public const string DisallowedDirectionValue = "You can't go that way";
        private static PainfulObject dryIce = new PainfulObject(m_DryIceName, thirdFloorBarRoom);
        private static Room firstFloorBedroom = new Room(m_BedroomName, 2, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.East, 5), new RoomExit(Direction.South, 7) });
        private static Room firstFloorCoatCloset = new Room(m_CoatClosetname, 3, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.East, 1), new RoomExit(Direction.West, 9) });
        private static Room firstFloorDiningRoom = new Room(m_DiningRoomName, 4, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 7), new RoomExit(Direction.East, 9) }, true, (MagicWord)new Random().Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1);
        private static Elevator firstFloorElevator = new Elevator(m_FirstFloorElevatorName, 9, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 6), new RoomExit(Direction.East, 3), new RoomExit(Direction.West, 4) });
        private static Room firstFloorFamilyRoom = new Room(m_FamilyRoomName, 7, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.West, 1), new RoomExit(Direction.South, 4) });
        private static Room firstFloorFoyer = new Room(m_FoyerName, 1, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.East, 7), new RoomExit(Direction.West, 3) });
        private static Room firstFloorFrontPorch = new Room(m_FrontPorchName, 0, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 1) });
        private static Room firstFloorKitchen = new Room(m_KitchenName, 6, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.South, 9) });
        private static Room firstFloorPantry = new Room(m_PantryName, 5, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.West, 2), new RoomExit(Direction.South, 6) });
        private static RoomKeyedCollection firstFloorRooms = InitializeFirstFloorRooms();
        private static TelephoneBooth firstFloorTelephoneBooth = new TelephoneBooth(m_TelephoneBoothName, 8, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.South, 5) });
        private static OnOffObject flashlight = new OnOffObject(m_FlashlightName, firstFloorCoatCloset);
        private static StationaryObject frontYard = new StationaryObject(m_FrontYardName, firstFloorFrontPorch);
        private static PortableObject garlic = new PortableObject(m_GarlicName, basementDirtFlooredRoom, true, true);
        private static ProtectiveObject glove = new ProtectiveObject(m_GloveName, basementTelephoneBooth, false, false);
        private static MultiplePieceObject goldCoins = new MultiplePieceObject(m_CoinsName, secondFloorTelephoneBooth);
        private static StationaryObject kingSizedBed = new StationaryObject(m_BedName, secondFloorMasterBedroom);
        private static PortableObject knife = new PortableObject(m_KnifeName, firstFloorKitchen);
        private static Adversary leopard = new Adversary(m_LeopardName, thirdFloorLibrary);
        private static LockableObject lockedDoor = new LockableObject(m_LockedDoorName, firstFloorFoyer, new RoomExit(Direction.South, 0));
        private const string m_ArtHallName = "in the art hall";
        private const string m_BagOfGoldName = "a bag of gold";
        private const string m_BanjoName = "a banjo";
        private const string m_BarRoomName = "in the barroom";
        private const string m_BasementElevatorName = "in the basement elevator";
        private const string m_BathroomName = "in a bathroom";
        private const string m_BathtubName = "a brass bathtub";
        private const string m_BatteriesName = "a set of batteries";
        private const string m_BeastName = "a savage beast";
        private const string m_BedName = "a king sized bed";
        private const string m_BedroomName = "in a bedroom";
        private const string m_BlobName = "a protoplasmic blob";
        private const string m_BookName = "a sorcerer's hand book";
        private const string m_BoxName = "a wooden box";
        private const string m_BrushName = "a hairbrush";
        private const string m_BugSprayName = "a can of bug spray";
        private const string m_ClosetName = "in a closet";
        private const string m_CoalBinName = "in a dusty coal bin";
        private const string m_CoatClosetname = "in a coat closet";
        private const string m_CoinsName = "100's of gold coins";
        private const string m_ComputerRoomName = "in the computer-room";
        private const string m_DenName = "in the den";
        private const string m_DiamondName = "a small diamond";
        private const string m_DimeName = "an aluminum dime";
        private const string m_DiningRoomName = "in the dining room";
        private const string m_DirtFlooredRoomName = "in a dirt-floored room";
        private const string m_DryIceName = "a block of dry ice";
        private const string m_FamilyRoomName = "in the family room";
        private const string m_FirstFloorElevatorName = "in the first floor elevator";
        private const string m_FlashlightName = "a flashlight";
        private const string m_FoyerName = "in the foyer";
        private const string m_FreezerName = "in a walk-in freezer";
        private const string m_FrontPorchName = "on the front porch";
        private const string m_FrontYardName = "the front yard";
        private const string m_FurnaceRoomName = "in the furnace room";
        private const string m_GameRoomName = "in the game room";
        private const string m_GarlicName = "a clove of garlic";
        private const string m_GloveName = "an old leather glove";
        private const string m_GuestRoomName = "in a guest room";
        private const string m_KitchenName = "in the kitchen";
        private const string m_KnifeName = "a carving knife";
        private const string m_LabratoryName = "in the laboratory";
        private const string m_LeopardName = "a leopard";
        private const string m_LibraryName = "in the library";
        private const string m_LivingRoomName = "in the living room";
        private const string m_LockedDoorName = "a locked door";
        private const string m_MainframeName = "a unitron 30/50 mainframe";
        private const string m_MasterBedroomName = "in the master bedroom";
        private const string m_MonkName = "an insane monk";
        private const string m_MonsterHangoutName = "in the monster hangout";
        private const string m_MooseHeadName = "a dusty moose head";
        private const string m_PantryName = "in the pantry";
        private const string m_ParchmentName = "a wrinkled parchment";
        private const string m_PillowName = "a silk pillow";
        private const string m_PumpRoomName = "in the pumproom";
        private const string m_RustedKeyName = "a rusted key";
        private const string m_SecondFloorElevatorName = "in the second floor elevator";
        private const string m_SewingRoomName = "in the sewing room";
        private const string m_ShovelName = "a shovel";
        private const string m_SittingRoomName = "in a sitting room";
        private const string m_StocksName = "a set of stocks";
        private const string m_TelephoneBoothName = "in a telephone booth";
        private const string m_ThirdFloorElevatorName = "in the third floor elevator";
        private const string m_TortureChamberName = "in the torture chamber";
        private const string m_TrophyRoomName = "in the trophy room";
        private const string m_VampireName = "a vampire";
        private const string m_VaseName = "a ming vase";
        private const string m_WerewolfName = "a werewolf";
        private const string m_WorkshopName = "in the workshop";
        private static StationaryObject mainframe = new StationaryObject(m_MainframeName, thirdFloorComputerRoom);
        private static DelicateObject mingVase = new DelicateObject(m_VaseName, secondFloorGuestRoom1);
        private static Adversary monk = new Adversary(m_MonkName, secondFloorGuestRoom1);
        private static MonsterHangout monsterHangout = new MonsterHangout(m_MonsterHangoutName, 0, Floor.MonsterHangout);
        private static RoomKeyedCollection monsterHangoutRooms = InitializeMonsterHangoutRooms();
        private static StationaryObject mooseHead = new StationaryObject(m_MooseHeadName, secondFloorDen);
        private static PortableObject parchment = new PortableObject(m_ParchmentName, basementFreezer);
        private static CushioningObject pillow = new CushioningObject(m_PillowName, thirdFloorArtHall);
        private static PlayerEntity player = new PlayerEntity();
        private static PortableObject rustedKey = new PortableObject(m_RustedKeyName, basementDirtFlooredRoom, true, true);
        private static Room secondFloorBathroom = new Room(m_BathroomName, 4, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.East, 5), new RoomExit(Direction.West, 3), new RoomExit(Direction.South, 6) });
        private static Room secondFloorCloset = new Room(m_ClosetName, 1, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 0), new RoomExit(Direction.South, 3) });
        private static Room secondFloorDen = new Room(m_DenName, 7, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 6), new RoomExit(Direction.West, 8) });
        private static Elevator secondFloorElevator = new Elevator(m_SecondFloorElevatorName, 9, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.West, 0), new RoomExit(Direction.South, 2) });
        private static Room secondFloorGuestRoom1 = new Room(m_GuestRoomName, 3, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 1), new RoomExit(Direction.East, 4), new RoomExit(Direction.West, 5) });
        private static Room secondFloorGuestRoom2 = new Room(m_GuestRoomName, 5, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.East, 3), new RoomExit(Direction.West, 4) });
        private static Room secondFloorMasterBedroom = new Room(m_MasterBedroomName, 2, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.South, 4) });
        private static RoomKeyedCollection secondFloorRooms = InitializeSecondFloorRooms();
        private static Room secondFloorSewingRoom = new Room(m_SewingRoomName, 0, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.East, 9), new RoomExit(Direction.South, 1) });
        private static Room secondFloorSittingRoom = new Room(m_SittingRoomName, 6, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.South, 7) });
        private static TelephoneBooth secondFloorTelephoneBooth = new TelephoneBooth(m_TelephoneBoothName, 8, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.East, 7) });
        private static PortableObject shovel = new PortableObject(m_ShovelName, thirdFloorComputerRoom);
        private static PortableObject sorcerersBook = new PortableObject(m_BookName, thirdFloorLibrary);
        private static StationaryObject stocks = new StationaryObject(m_StocksName, basementTortureChamber);
        private static Impostor theImpostor = new Impostor(AllPortableObjects[new Random().Next(AllPortableObjects.Count)].Name, GetRoom(new LocationType(new Random().Next(10), (Floor)new Random().Next(4))));
        private static Room thirdFloorArtHall = new Room(m_ArtHallName, 7, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.West, 6) });
        private static Room thirdFloorBarRoom = new Room(m_BarRoomName, 3, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.East, 5), new RoomExit(Direction.West, 8) });
        private static Room thirdFloorBedroom = new Room(m_BedroomName, 6, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.East, 7) });
        private static Room thirdFloorComputerRoom = new Room(m_ComputerRoomName, 4, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.South, 5) });
        private static Elevator thirdFloorElevator = new Elevator(m_ThirdFloorElevatorName, 9, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.East, 1), new RoomExit(Direction.South, 0) });
        private static Room thirdFloorGameRoom = new Room(m_GameRoomName, 5, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.West, 3), new RoomExit(Direction.South, 7) });
        private static Room thirdFloorLibrary = new Room(m_LibraryName, 1, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.West, 9), new RoomExit(Direction.South, 2) });
        private static Room thirdFloorLivingRoom = new Room(m_LivingRoomName, 0, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.East, 2) });
        private static RoomKeyedCollection thirdFloorRooms = InitializeThirdFloorRooms();
        private static TelephoneBooth thirdFloorTelephoneBooth = new TelephoneBooth(m_TelephoneBoothName, 8, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.East, 3), new RoomExit(Direction.South, 4) });
        private static Room thirdFloorTrophyRoom = new Room(m_TrophyRoomName, 2, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 1), new RoomExit(Direction.West, 0) });
        private static Adversary vampire = new Adversary(m_VampireName, firstFloorKitchen);
        private static Adversary werewolf = new Adversary(m_WerewolfName, thirdFloorArtHall);
        private static ContainerObject woodenBox = new ContainerObject(m_BoxName, firstFloorFoyer);

		#endregion Fields 

		#region Properties (11) 

        /// <summary>
        /// Gets the name of the beast.
        /// </summary>
        /// <value>The name of the beast.</value>
        public static string BeastName
        {
            get { return m_BeastName; }
        }

        /// <summary>
        /// Gets the name of the blob.
        /// </summary>
        /// <value>The name of the blob.</value>
        public static string BlobName
        {
            get { return m_BlobName; }
        }

        /// <summary>
        /// Gets the name of the brush.
        /// </summary>
        /// <value>The name of the brush.</value>
        public static string BrushName
        {
            get { return m_BrushName; }
        }

        /// <summary>
        /// Gets the name of the flash light.
        /// </summary>
        /// <value>The name of the flash light.</value>
        public static string FlashlightName
        {
            get { return m_FlashlightName; }
        }

        /// <summary>
        /// Gets the name of the garlic.
        /// </summary>
        /// <value>The name of the garlic.</value>
        public static string GarlicName
        {
            get { return m_GarlicName; }
        }

        /// <summary>
        /// Gets the name of the leopard.
        /// </summary>
        /// <value>The name of the leopard.</value>
        public static string LeopardName
        {
            get { return m_LeopardName; }
        }

        /// <summary>
        /// Gets the name of the monk.
        /// </summary>
        /// <value>The name of the monk.</value>
        public static string MonkName
        {
            get { return m_MonkName; }
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public static PlayerEntity Player
        {
            get { return TheHouse.player; }
        }

        /// <summary>
        /// Gets the impostor.
        /// </summary>
        /// <value>The impostor.</value>
        public static Impostor TheImpostor
        {
            get { return TheHouse.theImpostor; }
        }

        /// <summary>
        /// Gets the name of the vampire.
        /// </summary>
        /// <value>The name of the vampire.</value>
        public static string VampireName
        {
            get { return m_VampireName; }
        }

        /// <summary>
        /// Gets the name of the werewolf.
        /// </summary>
        /// <value>The name of the werewolf.</value>
        public static string WerewolfName
        {
            get { return m_WerewolfName; }
        }

		#endregion Properties 

		#region Methods (23) 


		// Public Methods (7) 

        /// <summary>
        /// Gets the room.
        /// </summary>
        /// <param name="floor">The floor.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <returns></returns>
        public static Room GetRoom(Floor floor, int roomNumber)
        {
            return GetRoom(new LocationType(roomNumber, floor));
        }

        /// <summary>
        /// Gets the room.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public static Room GetRoom(LocationType location)
        {
            return allRooms[location];
        }

        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <param name="floor">The floor.</param>
        /// <returns></returns>
        public static RoomKeyedCollection GetRooms(Floor floor)
        {
            RoomKeyedCollection colReturn;
            switch (floor)
            {
                case Floor.Basement:
                    colReturn = basementRooms;
                    break;
                case Floor.FirstFloor:
                    colReturn = firstFloorRooms;
                    break;
                case Floor.SecondFloor:
                    colReturn = secondFloorRooms;
                    break;
                case Floor.ThirdFloor:
                    colReturn = thirdFloorRooms;
                    break;
                case Floor.MonsterHangout:
                    colReturn = monsterHangoutRooms;
                    break;
                default:
                    colReturn = null;
                    break;
            }
            return colReturn;
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <returns></returns>
        public static string Load()
        {
            StringBuilder sbOutput = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
            // Reading the XML document requires a FileStream.
            Stream reader = new FileStream("housedata.txt", FileMode.Open);

            // Declare an object variable of the type to be deserialized.
            //OrderedItem i;

            // Call the Deserialize method to restore the object's state.
            SaveData saveData = new SaveData();
            saveData = (SaveData)serializer.Deserialize(reader);
            reader.Close();
            RestoreFromSaveData(saveData);
            player.RestoreFromSaveData(saveData);
            sbOutput.Append("Data loaded");
            return sbOutput.ToString();
        }

        /// <summary>
        /// Populates the save data.
        /// </summary>
        /// <param name="data">The data.</param>
        public static void PopulateSaveData(SaveData data)
        {
            data.PopulateRoomsOfOneFloor(basementRooms, Floor.Basement);
            data.PopulateRoomsOfOneFloor(firstFloorRooms, Floor.FirstFloor);
            data.PopulateRoomsOfOneFloor(secondFloorRooms, Floor.SecondFloor);
            data.PopulateRoomsOfOneFloor(thirdFloorRooms, Floor.ThirdFloor);
            data.PopulateRoomsOfOneFloor(monsterHangoutRooms, Floor.MonsterHangout);
        }

        /// <summary>
        /// Restores from save data.
        /// </summary>
        /// <param name="data">The data.</param>
        public static void RestoreFromSaveData(SaveData data)
        {
            RestoreRooms(data.BasementRooms);
            RestoreRooms(data.FirstFloorRooms);
            RestoreRooms(data.SecondFloorRooms);
            RestoreRooms(data.ThirdFloorRooms);
            RestoreRooms(data.MonsterHangoutRooms);
            allAdversaries = InitializeAdversaryCollection();
            allInanimateObjects = InitializeInanimateObjects();
            allInanimateObjects2 = InitializeInanimateObjects2();

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public static string Save()
        {
            SaveData saveData = new SaveData();
            player.PopulateSaveData(saveData);
            PopulateSaveData(saveData);
            StringBuilder sbOutput = new StringBuilder();
            XmlSerializer serializerSaveData = new XmlSerializer(typeof(SaveData));
            TextWriter writer = new StreamWriter("housedata.txt");

            serializerSaveData.Serialize(writer, saveData);
            writer.Close();
            sbOutput.Append("Data saved");
            return sbOutput.ToString();
        }



		// Private Methods (14) 

        private static AdversaryCollection InitializeAdversaryCollection()
        {
            AdversaryCollection coll = new AdversaryCollection();
            coll.Add(Blob);
            coll.Add(Vampire);
            coll.Add(Beast);
            coll.Add(Leopard);
            coll.Add(Monk);
            coll.Add(Werewolf);
            coll.Add(theImpostor);
            return coll;
        }

        private static RoomKeyedCollection InitializeAllRooms()
        {
            RoomKeyedCollection collReturn = new RoomKeyedCollection();
            foreach (Room room in basementRooms)
            {
                collReturn.Add(room);
            }
            foreach (Room room in firstFloorRooms)
            {
                collReturn.Add(room);
            }
            foreach (Room room in secondFloorRooms)
            {
                collReturn.Add(room);
            }
            foreach (Room room in thirdFloorRooms)
            {
                collReturn.Add(room);
            }
            foreach (Room room in monsterHangoutRooms)
            {
                collReturn.Add(room);
            }
            return collReturn;
        }

        private static RoomKeyedCollection InitializeBasementRooms()
        {
            RoomKeyedCollection collReturn = new RoomKeyedCollection();
            collReturn.Add(basementCoalBin);
            collReturn.Add(basementDirtFlooredRoom);
            collReturn.Add(basementElevator);
            collReturn.Add(basementFreezer);
            collReturn.Add(basementFurnaceRoom);
            collReturn.Add(basementLabratory);
            collReturn.Add(basementPumpRoom);
            collReturn.Add(basementTelephoneBooth);
            collReturn.Add(basementTortureChamber);
            collReturn.Add(basementWorkshop);
            return collReturn;
        }

        private static RoomKeyedCollection InitializeFirstFloorRooms()
        {
            RoomKeyedCollection collReturn = new RoomKeyedCollection();
            collReturn.Add(firstFloorBedroom);
            collReturn.Add(firstFloorCoatCloset);
            collReturn.Add(firstFloorDiningRoom);
            collReturn.Add(firstFloorElevator);
            collReturn.Add(firstFloorFamilyRoom);
            collReturn.Add(firstFloorFoyer);
            collReturn.Add(firstFloorFrontPorch);
            collReturn.Add(firstFloorKitchen);
            collReturn.Add(firstFloorPantry);
            collReturn.Add(firstFloorTelephoneBooth);
            return collReturn;
        }

        private static InanimateObjectsCollection InitializeInanimateObjects()
        {
            InanimateObjectsCollection coll = new InanimateObjectsCollection();
            coll.Add(BagOfGold);
            coll.Add(RustedKey);
            coll.Add(BugSpray);
            coll.Add(Glove);
            coll.Add(SorcerersBook);
            coll.Add(Knife);
            coll.Add(WoodenBox);
            coll.Add(Dime);
            coll.Add(Flashlight);
            coll.Add(Diamond);
            coll.Add(Pillow);
            coll.Add(Parchment);
            coll.Add(Brush);
            coll.Add(GoldCoins);
            coll.Add(Banjo);
            coll.Add(Garlic);
            coll.Add(Batteries);
            coll.Add(DryIce);
            coll.Add(Shovel);
            coll.Add(MingVase);
            coll.Add(LockedDoor);
            coll.Add(FrontYard);
            coll.Add(KingSizedBed);
            coll.Add(Bathtub);
            coll.Add(Stocks);
            coll.Add(MooseHead);
            coll.Add(Mainframe);
            return coll;
        }

        private static InanimateObjectKeyedCollection InitializeInanimateObjects2()
        {
            InanimateObjectKeyedCollection coll = new InanimateObjectKeyedCollection();
            coll.Add(BagOfGold);
            coll.Add(RustedKey);
            coll.Add(BugSpray);
            coll.Add(Glove);
            coll.Add(SorcerersBook);
            coll.Add(Knife);
            coll.Add(WoodenBox);
            coll.Add(Dime);
            coll.Add(Flashlight);
            coll.Add(Diamond);
            coll.Add(Pillow);
            coll.Add(Parchment);
            coll.Add(Brush);
            coll.Add(GoldCoins);
            coll.Add(Banjo);
            coll.Add(Garlic);
            coll.Add(Batteries);
            coll.Add(DryIce);
            coll.Add(Shovel);
            coll.Add(MingVase);
            coll.Add(LockedDoor);
            coll.Add(FrontYard);
            coll.Add(KingSizedBed);
            coll.Add(Stocks);
            coll.Add(MooseHead);
            coll.Add(Mainframe);
            return coll;
        }

        private static RoomKeyedCollection InitializeMonsterHangoutRooms()
        {
            RoomKeyedCollection collReturn = new RoomKeyedCollection();
            collReturn.Add(monsterHangout);
            return collReturn;
        }

        private static InanimateObjectsCollection InitializePortableObjects()
        {
            InanimateObjectsCollection coll = new InanimateObjectsCollection();
            coll.Add(BagOfGold);
            coll.Add(RustedKey);
            coll.Add(BugSpray);
            coll.Add(Glove);
            coll.Add(SorcerersBook);
            coll.Add(Knife);
            coll.Add(WoodenBox);
            coll.Add(Dime);
            coll.Add(Flashlight);
            coll.Add(Diamond);
            coll.Add(Pillow);
            coll.Add(Parchment);
            coll.Add(Brush);
            coll.Add(GoldCoins);
            coll.Add(Banjo);
            coll.Add(Garlic);
            coll.Add(Batteries);
            coll.Add(DryIce);
            coll.Add(Shovel);
            coll.Add(MingVase);
            return coll;
        }

        private static RoomKeyedCollection InitializeSecondFloorRooms()
        {
            RoomKeyedCollection collReturn = new RoomKeyedCollection();
            collReturn.Add(secondFloorBathroom);
            collReturn.Add(secondFloorCloset);
            collReturn.Add(secondFloorDen);
            collReturn.Add(secondFloorElevator);
            collReturn.Add(secondFloorGuestRoom1);
            collReturn.Add(secondFloorGuestRoom2);
            collReturn.Add(secondFloorMasterBedroom);
            collReturn.Add(secondFloorSewingRoom);
            collReturn.Add(secondFloorSittingRoom);
            collReturn.Add(secondFloorTelephoneBooth);
            return collReturn;
        }

        private static RoomKeyedCollection InitializeThirdFloorRooms()
        {
            RoomKeyedCollection collReturn = new RoomKeyedCollection();
            collReturn.Add(thirdFloorArtHall);
            collReturn.Add(thirdFloorBarRoom);
            collReturn.Add(thirdFloorBedroom);
            collReturn.Add(thirdFloorComputerRoom);
            collReturn.Add(thirdFloorElevator);
            collReturn.Add(thirdFloorGameRoom);
            collReturn.Add(thirdFloorLibrary);
            collReturn.Add(thirdFloorLivingRoom);
            collReturn.Add(thirdFloorTelephoneBooth);
            collReturn.Add(thirdFloorTrophyRoom);
            return collReturn;
        }

        private static void RepopulateAdversary(Adversary adversary)
        {
            switch (adversary.Name)
            {
                case m_BeastName:
                    beast = adversary;
                    break;
                case m_BlobName:
                    blob = adversary;
                    break;
                case m_LeopardName:
                    leopard = adversary;
                    break;
                case m_MonkName:
                    monk = adversary;
                    break;
                case m_VampireName:
                    vampire = adversary;
                    break;
                case m_WerewolfName:
                    werewolf = adversary;
                    break;
                default:
                    break;
                //private const string m_BlobName = "a protoplasmic blob";
                //private const string m_LeopardName = "a leopard";
                //private const string m_MonkName = "an insane monk";
                //private const string m_VampireName = "a vampire";
                //private const string m_WerewolfName = "a werewolf";

            }
            Impostor impostor = adversary as Impostor;
            if (impostor != null)
            {
                theImpostor = impostor;
            }
        }

        private static void RepopulateInanimateObject(InanimateObject item)
        {
            PortableObject portableItem = item as PortableObject;
            StationaryObject stationaryItem = item as StationaryObject;
            ConsumableObject consumableItem = item as ConsumableObject;
            switch (item.Name)
            {
                case m_BagOfGoldName:
                    bagOfGold = portableItem;
                    break;
                case m_BanjoName:
                    banjo = portableItem;
                    break;
                case m_BathtubName:
                    bathtub = stationaryItem;
                    break;
                case m_BatteriesName:
                    batteries = consumableItem;
                    break;
                case m_BedName:
                    kingSizedBed = stationaryItem;
                    break;
                case m_BookName:
                    sorcerersBook = portableItem;
                    break;
                case m_BoxName:
                    woodenBox = item as ContainerObject;
                    break;
                case m_BrushName:
                    brush = portableItem;
                    break;
                case m_BugSprayName:
                    bugSpray = consumableItem;
                    break;
                case m_CoinsName:
                    goldCoins = item as MultiplePieceObject;
                    break;
                case m_DiamondName:
                    diamond = portableItem;
                    break;
                case m_DimeName:
                    dime = portableItem;
                    break;
                case m_DryIceName:
                    dryIce = item as PainfulObject;
                    break;
                case m_FlashlightName:
                    flashlight = item as OnOffObject;
                    break;
                case m_FrontYardName:
                    frontYard = stationaryItem;
                    break;
                case m_GarlicName:
                    garlic = portableItem;
                    break;
                case m_GloveName:
                    glove = item as ProtectiveObject;
                    break;
                case m_KnifeName:
                    knife = portableItem;
                    break;
                case m_LockedDoorName:
                    lockedDoor = item as LockableObject;
                    break;
                case m_MainframeName:
                    mainframe = stationaryItem;
                    break;
                case m_MooseHeadName:
                    mooseHead = stationaryItem;
                    break;
                case m_ParchmentName:
                    parchment = portableItem;
                    break;
                case m_PillowName:
                    pillow = item as CushioningObject;
                    break;
                case m_RustedKeyName:
                    rustedKey = portableItem;
                    break;
                case m_ShovelName:
                    shovel = portableItem;
                    break;
                case m_StocksName:
                    stocks = stationaryItem;
                    break;
                case m_VaseName:
                    mingVase = item as DelicateObject;
                    break;

                default:
                    break;
            }
        }

        private static void RestoreRoom(Room room)
        {
            Elevator elevator = room as Elevator;
            switch (room.Name)
            {
                case m_BasementElevatorName:
                    basementElevator = elevator;
                    break;
                default:
                    break;
            }
        }

        private static void RestoreRooms(RoomKeyedCollection rooms)
        {
            int iCountRooms = rooms.Count;
            for (int i = 0; i < iCountRooms; i++)
            {
                int iCountAdversariesInRoom = rooms[i].Adversaries.Count;
                for (int j = 0; j < iCountAdversariesInRoom; j++)
                {
                    RepopulateAdversary(rooms[i].Adversaries[j]);
                }
                int iCountItemsInRoom = rooms[i].Items.Count;
                for (int j = 0; j < iCountItemsInRoom; j++)
                {
                    RepopulateInanimateObject(rooms[i].Items[j]);
                }
                RestoreRoom(rooms[i]);
            }
        }



		// Internal Methods (2) 

        /// <summary>
        /// Removes the front porch items.
        /// </summary>
        internal static void RemoveFrontPorchItems()
        {
            foreach (InanimateObject io in firstFloorFrontPorch.Items)
            {
                if (io is PortableObject)
                {
                    firstFloorFrontPorch.Items.Remove(io);
                }
            }
        }

        /// <summary>
        /// Updates the monsters in hangout.
        /// </summary>
        internal static void UpdateMonstersInHangout()
        {
            foreach (Adversary adversary in monsterHangout.Adversaries)
            {
                if (adversary.MovesUntilUnhidden > 1)
                {
                    adversary.MovesUntilUnhidden--;
                }
                else if (adversary.MovesUntilUnhidden == 1)
                {
                    adversary.MovesUntilUnhidden--;
                    monsterHangout.Adversaries.Remove(adversary);
                    GetRoom((Floor)new Random().Next(4), new Random().Next(10)).Adversaries.Add(adversary);
                }
            }
        }


		#endregion Methods 
        /// <summary>
        /// Gets the actions.
        /// </summary>
        /// <value>The actions.</value>
        public static ReadOnlyCollection<string> Actions
        {
            get { return TheHouse.collectionActions; }
            //set { TheHouse.actions = value; }
        }
        /// <summary>
        /// Gets the bag of gold.
        /// </summary>
        /// <value>The bag of gold.</value>
        public static PortableObject BagOfGold
        {
            get { return TheHouse.bagOfGold; }
            //set { TheHouse.bagOfGold = value; }
        }
        /// <summary>
        /// Gets the rusted key.
        /// </summary>
        /// <value>The rusted key.</value>
        public static PortableObject RustedKey
        {
            get { return TheHouse.rustedKey; }
            //set { TheHouse.rustedKey = value; }
        }
        /// <summary>
        /// Gets the bug spray.
        /// </summary>
        /// <value>The bug spray.</value>
        public static ConsumableObject BugSpray
        {
            get { return TheHouse.bugSpray; }
            //set { TheHouse.bugSpray = value; }
        }
        /// <summary>
        /// Gets the glove.
        /// </summary>
        /// <value>The glove.</value>
        public static ProtectiveObject Glove
        {
            get { return TheHouse.glove; }
            //set { TheHouse.glove = value; }
        }
        /// <summary>
        /// Gets the sorcerers book.
        /// </summary>
        /// <value>The sorcerers book.</value>
        public static PortableObject SorcerersBook
        {
            get { return TheHouse.sorcerersBook; }
            //set { TheHouse.sorcerersBook = value; }
        }
        /// <summary>
        /// Gets the knife.
        /// </summary>
        /// <value>The knife.</value>
        public static PortableObject Knife
        {
            get { return TheHouse.knife; }
            //set { TheHouse.knife = value; }
        }
        /// <summary>
        /// Gets the wooden box.
        /// </summary>
        /// <value>The wooden box.</value>
        public static ContainerObject WoodenBox
        {
            get { return TheHouse.woodenBox; }
            //set { TheHouse.woodenBox = value; }
        }
        /// <summary>
        /// Gets the dime.
        /// </summary>
        /// <value>The dime.</value>
        public static PortableObject Dime
        {
            get { return TheHouse.dime; }
            //set { TheHouse.dime = value; }
        }
        /// <summary>
        /// Gets the flashlight.
        /// </summary>
        /// <value>The flashlight.</value>
        public static OnOffObject Flashlight
        {
            get { return TheHouse.flashlight; }
            //set { TheHouse.flashlight = value; }
        }
        /// <summary>
        /// Gets the diamond.
        /// </summary>
        /// <value>The diamond.</value>
        public static PortableObject Diamond
        {
            get { return TheHouse.diamond; }
            //set { TheHouse.diamond = value; }
        }
        /// <summary>
        /// Gets the pillow.
        /// </summary>
        /// <value>The pillow.</value>
        public static CushioningObject Pillow
        {
            get { return TheHouse.pillow; }
            //set { TheHouse.pillow = value; }
        }
        /// <summary>
        /// Gets the parchment.
        /// </summary>
        /// <value>The parchment.</value>
        public static PortableObject Parchment
        {
            get { return TheHouse.parchment; }
            //set { TheHouse.parchment = value; }
        }
        /// <summary>
        /// Gets the brush.
        /// </summary>
        /// <value>The brush.</value>
        public static PortableObject Brush
        {
            get { return TheHouse.brush; }
            //set { TheHouse.brush = value; }
        }
        /// <summary>
        /// Gets the gold coins.
        /// </summary>
        /// <value>The gold coins.</value>
        public static MultiplePieceObject GoldCoins
        {
            get { return TheHouse.goldCoins; }
            //set { TheHouse.goldCoins = value; }
        }
        /// <summary>
        /// Gets the banjo.
        /// </summary>
        /// <value>The banjo.</value>
        public static PortableObject Banjo
        {
            get { return TheHouse.banjo; }
            //set { TheHouse.banjo = value; }
        }
        /// <summary>
        /// Gets the garlic.
        /// </summary>
        /// <value>The garlic.</value>
        public static PortableObject Garlic
        {
            get { return TheHouse.garlic; }
            //set { TheHouse.garlic = value; }
        }
        /// <summary>
        /// Gets the batteries.
        /// </summary>
        /// <value>The batteries.</value>
        public static ConsumableObject Batteries
        {
            get { return TheHouse.batteries; }
            //set { TheHouse.batteries = value; }
        }
        /// <summary>
        /// Gets the dry ice.
        /// </summary>
        /// <value>The dry ice.</value>
        public static PainfulObject DryIce
        {
            get { return TheHouse.dryIce; }
            //set { TheHouse.dryIce = value; }
        }
        /// <summary>
        /// Gets the shovel.
        /// </summary>
        /// <value>The shovel.</value>
        public static PortableObject Shovel
        {
            get { return TheHouse.shovel; }
            //set { TheHouse.shovel = value; }
        }
        /// <summary>
        /// Gets the ming vase.
        /// </summary>
        /// <value>The ming vase.</value>
        public static DelicateObject MingVase
        {
            get { return TheHouse.mingVase; }
            //set { TheHouse.mingVase = value; }
        }
        /// <summary>
        /// Gets the locked door.
        /// </summary>
        /// <value>The locked door.</value>
        public static LockableObject LockedDoor
        {
            get { return TheHouse.lockedDoor; }
            //set { TheHouse.lockedDoor = value; }
        }
        /// <summary>
        /// Gets the front yard.
        /// </summary>
        /// <value>The front yard.</value>
        public static StationaryObject FrontYard
        {
            get { return TheHouse.frontYard; }
            //set { TheHouse.frontYard = value; }
        }
        /// <summary>
        /// Gets the king sized bed.
        /// </summary>
        /// <value>The king sized bed.</value>
        public static StationaryObject KingSizedBed
        {
            get { return TheHouse.kingSizedBed; }
            //set { TheHouse.kingSizedBed = value; }
        }
        /// <summary>
        /// Gets the bathtub.
        /// </summary>
        /// <value>The bathtub.</value>
        public static StationaryObject Bathtub
        {
            get { return TheHouse.bathtub; }
            //set { TheHouse.bathtub = value; }
        }
        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public static StationaryObject Stocks
        {
            get { return TheHouse.stocks; }
            //set { TheHouse.stocks = value; }
        }
        /// <summary>
        /// Gets the moose head.
        /// </summary>
        /// <value>The moose head.</value>
        public static StationaryObject MooseHead
        {
            get { return TheHouse.mooseHead; }
            //set { TheHouse.mooseHead = value; }
        }
        /// <summary>
        /// Gets the mainframe.
        /// </summary>
        /// <value>The mainframe.</value>
        public static StationaryObject Mainframe
        {
            get { return TheHouse.mainframe; }
            //set { TheHouse.mainframe = value; }
        }
        /// <summary>
        /// Gets all inanimate objects.
        /// </summary>
        /// <value>All inanimate objects.</value>
        public static InanimateObjectsCollection AllInanimateObjects
        {
            get { return TheHouse.allInanimateObjects; }
            //set { TheHouse.allInanimateObjects = value; }
        }
        /// <summary>
        /// All of the portable objects in the game
        /// </summary>
        public static InanimateObjectsCollection AllPortableObjects
        {
            get { return TheHouse.allPortableObjects; }
            //set { TheHouse.allPortableObjects = value; }
        }
        /// <summary>
        /// Gets all inanimate objects in a keyed collection.
        /// </summary>
        /// <value>All inanimate objects in a keyed collection.</value>
        public static InanimateObjectKeyedCollection AllInanimateObjects2
        {
            get { return TheHouse.allInanimateObjects2; }
            //set { TheHouse.allInanimateObjects2 = value; }
        }
        /// <summary>
        /// Gets the blob.
        /// </summary>
        /// <value>The blob.</value>
        public static Adversary Blob
        {
            get { return TheHouse.blob; }
            //set { TheHouse.blob = value; }
        }
        /// <summary>
        /// Gets the vampire.
        /// </summary>
        /// <value>The vampire.</value>
        public static Adversary Vampire
        {
            get { return TheHouse.vampire; }
            //set { TheHouse.vampire = value; }
        }
        /// <summary>
        /// Gets the beast.
        /// </summary>
        /// <value>The beast.</value>
        public static Adversary Beast
        {
            get { return TheHouse.beast; }
            //set { TheHouse.beast = value; }
        }
        /// <summary>
        /// Gets the leopard.
        /// </summary>
        /// <value>The leopard.</value>
        public static Adversary Leopard
        {
            get { return TheHouse.leopard; }
            //set { TheHouse.leopard = value; }
        }
        /// <summary>
        /// Gets the monk.
        /// </summary>
        /// <value>The monk.</value>
        public static Adversary Monk
        {
            get { return TheHouse.monk; }
            //set { TheHouse.monk = value; }
        }
        /// <summary>
        /// Gets the werewolf.
        /// </summary>
        /// <value>The werewolf.</value>
        public static Adversary Werewolf
        {
            get { return TheHouse.werewolf; }
            //set { TheHouse.werewolf = value; }
        }
        /// <summary>
        /// Gets all rooms.
        /// </summary>
        /// <value>All rooms.</value>
        public static RoomKeyedCollection AllRooms
        {
            get { return TheHouse.allRooms; }
            // set { TheHouse.allRooms = value; }
        }
        /// <summary>
        /// Gets all adversaries.
        /// </summary>
        /// <value>All adversaries.</value>
        public static AdversaryCollection AllAdversaries
        {
            get { return TheHouse.allAdversaries; }
            //set { TheHouse.allAdversaries = value; }
        }
        //public static void Initialize(HouseFunctions.PlayerEntity Player, int[, ,] Exits, int[,] Monsters, double[,] Objects, int[,] MagicRooms)
        //{
        //    Player.Location.Floor = Floor.FirstFloor;
        //    Player.Location.Room = 1;
        //    //#region load rooms
        //    ////house.Rooms = new Collection<Collection<Room>>();
        //    //for (int i = 0; i < 4; i++)
        //    //{
        //    //    string[] saRoomNames;
        //    //    int[] daFloor;

        //    //    if (i == 0)
        //    //    {
        //    //        saRoomNames = saBasementRooms;
        //    //        daFloor = daBasementExits;
        //    //    }
        //    //    else if (i == 1)
        //    //    {
        //    //        saRoomNames = saMainFloorRooms;
        //    //        daFloor = daMainFloorExits;
        //    //    }
        //    //    else if (i == 2)
        //    //    {
        //    //        saRoomNames = saSecondFloorRooms;
        //    //        daFloor = daSecondFloorExits;
        //    //    }
        //    //    else
        //    //    {
        //    //        saRoomNames = saThirdFloorRooms;
        //    //        daFloor = daThirdFloorExits;
        //    //    }

        //    //    //Add new floor to the house
        //    //    house.Rooms.Add(new System.Collections.ObjectModel.Collection<Room>());

        //    //    for (int j = 0; j < 10; j++)
        //    //    {

        //    //        //Add a new room to the house
        //    //        if (j == 0 && i == 0)
        //    //        {
        //    //            house.Rooms[i].Add(new UnfinishedFlooredRoom());
        //    //        }
        //    //        else if (j < 8)
        //    //        {
        //    //            house.Rooms[i].Add(new Room());
        //    //        }
        //    //        else if (j == 8)
        //    //        {
        //    //            house.Rooms[i].Add(new TelephoneBooth());
        //    //        }
        //    //        else if (j == 9)
        //    //        {
        //    //            house.Rooms[i].Add(new Elevator());
        //    //        }
        //    //        rooms.Add(house.Rooms[i][j]);
        //    //        house.Rooms[i][j].Location.Floor = (Floor)i;
        //    //        house.Rooms[i][j].Location.Room = j;
        //    //        house.Rooms[i][j].Name = saRoomNames[j];
        //    //        //house.Rooms[i][j].Exits = new ExitSet();
        //    //        for (int k = 0; k < 4; k++)
        //    //        {
        //    //            Exits[i, j, k] = daFloor[j * 4 + k] - 1;
        //    //            if (daFloor[j * 4 + k] - 1 > -1)
        //    //            {
        //    //                house.Rooms[i][j].Exits.Add(new RoomExit((Direction)k, daFloor[j * 4 + k] - 1));
        //    //            }

        //    //        }
        //    //    }
        //    //}
        //    //#endregion

        //    //#region load monsters
        //    //for (int i = 0; i < 6; i++)
        //    //{
        //    //    int iMonsterLevel = iaMonsterLocations[i * 2 + 0] - 1;
        //    //    int iMonsterRoom = iaMonsterLocations[i * 2 + 1] - 1;
        //    //    Adversary adversary = new Adversary();
        //    //    adversary.Name = saMonsters[i];
        //    //    house.Rooms[iMonsterLevel][iMonsterRoom].Adversaries.Add(adversary);
        //    //    //allAdversaries.Add(adversary);
        //    //    for (int j = 0; j < 2; j++)
        //    //    {
        //    //        Monsters[i, j] = iaMonsterLocations[i * 2 + j] - 1;
        //    //    }
        //    //}
        //    //#endregion

        //    //#region load objects
        //    //foreach (InanimateObject o in LoadObjects(Objects, house))
        //    //{
        //        //allInanimateObjects.Add(o);
        //    //}
        //    //#endregion

        //    /*
        //            static int[] iaConsumableObjects = new int[] { 2 ,16 };
        //static int[] iaConsumableDependentObjects = new int[] { 16 };
        //static int[] iaConsumableObjectLimits = new int[] { 1, 40 };
        //static int[] iaConsumableDependentObjectDependency = new int[] { 8 };
        //static int[] iaLockableObjects = new int[] { 20 };
        //static int[] iaLockableObjectsDestinations = new int[] { 0 };
        //static House.Direction[] daLockableObjectsDirections = new Direction[] { Direction.South };
        //    */

        //    #region load magic word rooms
        //    //for (int i = 0; i < 2; i++)
        //    //{
        //    //    int magicRoomFloor = iaMagicWordRooms[i * 2 + 0];
        //    //    int magicRoomRoom = iaMagicWordRooms[i * 2 + 1];
        //    //    int magicRoomIndex = magicRoomFloor * 10 + magicRoomRoom;
        //    //    int iObjCount = rooms[magicRoomIndex].Items.Count;
        //    //    for (int io = 0; io < iObjCount; io++)
        //    //    //foreach (InanimateObject obj in rooms[magicRoomIndex].InanimateObjects)

        //    //    //                foreach (InanimateObject obj in rooms[magicRoomIndex].Items)
        //    //    {
        //    //        InanimateObject obj = rooms[magicRoomIndex].Items[io];
        //    //        HiddenObject hoItem = new HiddenObject();

        //    //        //rooms[magicRoomIndex].InanimateObjects.
        //    //        hoItem.Location = obj.Location;
        //    //        hoItem.Name = obj.Name;
        //    //        hoItem.Hidden = true;

        //    //        house.Rooms[magicRoomFloor][magicRoomRoom].Items[io] = hoItem;
        //    //        rooms[magicRoomIndex].Items[io] = hoItem;

        //    //        //iObjCount++;


        //    //    }
        //    //    //rooms[magicRoomIndex]=new M
        //    //    for (int j = 0; j < 2; j++)
        //    //    {
        //    //        //rooms[
        //    //        MagicRooms[i, j] = iaMagicWordRooms[i * 2 + j];
        //    //    }
        //    //}
        //    #endregion
        //}
        /*
        private static InanimateObjectsCollection LoadObjects(double[,] Objects, HouseEntity house)
        {
            InanimateObjectsCollection collReturn = new InanimateObjectsCollection();
            for (int i = 0; i < saObjects.Length; i++)
            {
                int iObjectLevel = daObjectLocations[i * 2 + 0] - 1;
                int iObjectRoom = daObjectLocations[i * 2 + 1] - 1;
                InanimateObject inObj;
                if (i < 20)
                {
                    inObj = new PortableObject();
                }
                else
                {
                    inObj = new UnportableObject();
                }
                inObj.Name = saObjects[i];
                inObj.Location.Floor = (Floor)iObjectLevel;
                inObj.Location.Room = iObjectRoom;
                //house.Rooms[iObjectLevel][iObjectRoom].InanimateObjects.Add(inObj);
                house.Rooms[iObjectLevel][iObjectRoom].Items.Add(inObj);
                collReturn.Add(inObj);
                for (int j = 0; j < 2; j++)
                {
                    Objects[i, j] = daObjectLocations[i * 2 + j] - 1;
                }
            }

            foreach (int objNum in iaBuriedObjects)
            {
                InanimateObject obj = collReturn[objNum];
                BuriedObject boObj = new BuriedObject();
                boObj.Buried = true;
                boObj.Location = obj.Location;
                boObj.Name = obj.Name;
                collReturn[objNum] = boObj;
                int indexinroom = house.Rooms[(int)boObj.Location.Floor][boObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)boObj.Location.Floor][boObj.Location.Room].Items[indexinroom] = boObj;
            }

            foreach (int objNum in iaMultiplePieceObjects)
            {
                InanimateObject obj = collReturn[objNum];
                MultiplePieceObject mpObj = new MultiplePieceObject();
                mpObj.Location = obj.Location;
                mpObj.Name = obj.Name;
                collReturn[objNum] = mpObj;
                int indexinroom = house.Rooms[(int)mpObj.Location.Floor][mpObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)mpObj.Location.Floor][mpObj.Location.Room].Items[indexinroom] = mpObj;
            }

            foreach (int objNum in iaContainerObjects)
            {
                InanimateObject obj = collReturn[objNum];
                ContainerObject cObj = new ContainerObject();
                cObj.Location = obj.Location;
                cObj.Name = obj.Name;
                collReturn[objNum] = cObj;
                int indexinroom = house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items[indexinroom] = cObj;
            }

            foreach (int objNum in iaProtectiveObjects)
            {
                InanimateObject obj = collReturn[objNum];
                ProtectiveObject pObj = new ProtectiveObject();
                pObj.Location = obj.Location;
                pObj.Name = obj.Name;
                collReturn[objNum] = pObj;
                int indexinroom = house.Rooms[(int)pObj.Location.Floor][pObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)pObj.Location.Floor][pObj.Location.Room].Items[indexinroom] = pObj;
            }

            foreach (int objNum in iaPainfulObjects)
            {
                InanimateObject obj = collReturn[objNum];
                PainfulObject pObj = new PainfulObject();
                pObj.Location = obj.Location;
                pObj.Name = obj.Name;
                collReturn[objNum] = pObj;
                int indexinroom = house.Rooms[(int)pObj.Location.Floor][pObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)pObj.Location.Floor][pObj.Location.Room].Items[indexinroom] = pObj;
            }

            foreach (int objNum in iaOnOffObjects)
            {
                InanimateObject obj = collReturn[objNum];
                OnOffObject ooObj = new OnOffObject();
                ooObj.Location = obj.Location;
                ooObj.Name = obj.Name;
                collReturn[objNum] = ooObj;
                int indexinroom = house.Rooms[(int)ooObj.Location.Floor][ooObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)ooObj.Location.Floor][ooObj.Location.Room].Items[indexinroom] = ooObj;
            }

            foreach (int objNum in iaDelicateObjects)
            {
                InanimateObject obj = collReturn[objNum];
                DelicateObject dObj = new DelicateObject();
                dObj.Location = obj.Location;
                dObj.Name = obj.Name;
                collReturn[objNum] = dObj;
                int indexinroom = house.Rooms[(int)dObj.Location.Floor][dObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)dObj.Location.Floor][dObj.Location.Room].Items[indexinroom] = dObj;
            }

            foreach (int objNum in iaCushioningObjects)
            {
                InanimateObject obj = collReturn[objNum];
                CushioningObject cObj = new CushioningObject();
                cObj.Location = obj.Location;
                cObj.Name = obj.Name;
                collReturn[objNum] = cObj;
                int indexinroom = house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items[indexinroom] = cObj;
            }

            int iConsumableObjectIndex = 0;
            foreach (int objNum in iaConsumableObjects)
            {
                InanimateObject obj = collReturn[objNum];
                ConsumableObject cObj = new ConsumableObject();
                cObj.Location = obj.Location;
                cObj.Name = obj.Name;
                cObj.UsageLimit = iaConsumableObjectLimits[iConsumableObjectIndex];
                collReturn[objNum] = cObj;
                int indexinroom = house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items[indexinroom] = cObj;
                iConsumableObjectIndex++;
            }
            return collReturn;
        }
        */

    }
}
