using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    using System.Collections.ObjectModel;
    /// <summary>
    /// 
    /// </summary>
    public static class TheHouseData
    {

		#region Fields (182) 

        private static string[] actions = new string[] { "Get", "Drop", "Say", "Kill", "Stab", "Light", "Play", "Read", "Dig", "On", "Off", "Brush", "Wave", "Unlock", "Spray" };
        private static ReadOnlyCollection<string> collectionActions = new ReadOnlyCollection<string>(actions);
        /// <summary>
        /// String to display when a player tries to go in a direction that doesn't exist.
        /// </summary>
        public const string DisallowedDirectionValue = "You can't go that way";
        private readonly static ExitSetKeyedCollection exitsBasementCoalBin = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 6), new RoomExit(Direction.West, 3) });
        private readonly static ExitSetKeyedCollection exitsBasementDirtFlooredRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.West, 7), new RoomExit(Direction.South, 1) });
        private readonly static ExitSetKeyedCollection exitsBasementElevator = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 3), new RoomExit(Direction.South, 8) });
        private readonly static ExitSetKeyedCollection exitsBasementFreezer = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 0), new RoomExit(Direction.West, 6) });
        private readonly static ExitSetKeyedCollection exitsBasementFurnaceRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.East, 4), new RoomExit(Direction.South, 9) });
        private readonly static ExitSetKeyedCollection exitsBasementLaboratory = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 0), new RoomExit(Direction.East, 2) });
        private readonly static ExitSetKeyedCollection exitsBasementPumpRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.West, 1), new RoomExit(Direction.South, 3) });
        private readonly static ExitSetKeyedCollection exitsBasementTelephoneBooth = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.South, 5) });
        private readonly static ExitSetKeyedCollection exitsBasementTortureChamber = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.South, 6) });
        private readonly static ExitSetKeyedCollection exitsBasementWorkshop = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.East, 7), new RoomExit(Direction.West, 4) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorBedroom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 5), new RoomExit(Direction.South, 7) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorCoatCloset = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 1), new RoomExit(Direction.West, 9) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorDiningRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 7), new RoomExit(Direction.East, 9) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorElevator = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 6), new RoomExit(Direction.East, 3), new RoomExit(Direction.West, 4) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorFamilyRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.West, 1), new RoomExit(Direction.South, 4) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorFoyer = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 7), new RoomExit(Direction.West, 3) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorFrontPorch = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 1) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorKitchen = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.South, 9) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorPantry = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.West, 2), new RoomExit(Direction.South, 6) });
        private readonly static ExitSetKeyedCollection exitsFirstFloorTelephoneBooth = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.South, 5) });
        private readonly static ExitSetKeyedCollection exitsMonsterHangout = new ExitSetKeyedCollection(new RoomExit[0]);
        private readonly static ExitSetKeyedCollection exitsSecondFloorBathroom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.East, 5), new RoomExit(Direction.West, 3), new RoomExit(Direction.South, 6) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorCloset = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 0), new RoomExit(Direction.South, 3) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorDen = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 6), new RoomExit(Direction.West, 8) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorElevator = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.West, 0), new RoomExit(Direction.South, 2) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorGuestroom1 = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 1), new RoomExit(Direction.East, 4), new RoomExit(Direction.West, 5) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorGuestroom2 = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 3), new RoomExit(Direction.West, 4) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorMasterBedroom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.South, 4) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorSewingRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 9), new RoomExit(Direction.South, 1) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorSittingRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.South, 7) });
        private readonly static ExitSetKeyedCollection exitsSecondFloorTelephoneBooth = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 7) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorArtHall = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.West, 6) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorBarroom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 5), new RoomExit(Direction.West, 8) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorBedroom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 7) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorComputerRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.South, 5) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorElevator = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 1), new RoomExit(Direction.South, 0) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorGameRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.West, 3), new RoomExit(Direction.South, 7) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorLibrary = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.West, 9), new RoomExit(Direction.South, 2) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorLivingRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.East, 2) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorTelephoneBooth = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.East, 3), new RoomExit(Direction.South, 4) });
        private readonly static ExitSetKeyedCollection exitsThirdFloorTrophyRoom = new ExitSetKeyedCollection(new RoomExit[] { new RoomExit(Direction.North, 1), new RoomExit(Direction.West, 0) });
        private readonly static LocationType locationBasementCoalBin = new LocationType(4, Floor.Basement);
        private readonly static LocationType locationBasementDirtFlooredRoom = new LocationType(0, Floor.Basement);
        private readonly static LocationType locationBasementElevator = new LocationType(9, Floor.Basement);
        private readonly static LocationType locationBasementFreezer = new LocationType(7, Floor.Basement);
        private readonly static LocationType locationBasementFurnaceRoom = new LocationType(3, Floor.Basement);
        private readonly static LocationType locationBasementLaboratory = new LocationType(1, Floor.Basement);
        private readonly static LocationType locationBasementPumpRoom = new LocationType(2, Floor.Basement);
        private readonly static LocationType locationBasementTelephoneBooth = new LocationType(8, Floor.Basement);
        private readonly static LocationType locationBasementTortureChamber = new LocationType(5, Floor.Basement);
        private readonly static LocationType locationBasementWorkshop = new LocationType(6, Floor.Basement);
        private readonly static LocationType locationFirstFloorBedroom = new LocationType(2, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorCoatCloset = new LocationType(3, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorDiningRoom = new LocationType(4, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorElevator = new LocationType(9, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorFamilyRoom = new LocationType(7, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorFoyer = new LocationType(1, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorFrontPorch = new LocationType(0, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorKitchen = new LocationType(6, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorPantry = new LocationType(5, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorTelephoneBooth = new LocationType(8, Floor.FirstFloor);
        private readonly static LocationType locationMonsterHangout = new LocationType(0, Floor.MonsterHangout);
        private readonly static LocationType locationSecondFloorBathroom = new LocationType(4, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorCloset = new LocationType(1, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorDen = new LocationType(7, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorElevator = new LocationType(9, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorGuestroom1 = new LocationType(3, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorGuestroom2 = new LocationType(5, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorMasterBedroom = new LocationType(2, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorSewingRoom = new LocationType(0, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorSittingRoom = new LocationType(6, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorTelephoneBooth = new LocationType(8, Floor.SecondFloor);
        private readonly static LocationType locationThirdFloorArtHall = new LocationType(7, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorBarroom = new LocationType(3, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorBedroom = new LocationType(6, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorComputerRoom = new LocationType(4, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorElevator = new LocationType(9, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorGameRoom = new LocationType(5, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorLibrary = new LocationType(1, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorLivingRoom = new LocationType(0, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorTelephoneBooth = new LocationType(8, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorTrophyRoom = new LocationType(2, Floor.ThirdFloor);
        private const string m_ArtHallName = "in the art hall";
        private const string m_BagOfGoldName = "a bag of gold";
        private const string m_BagOfGoldShortName = "gol";
         private const string m_BanjoName = "a banjo";
        private const string m_BanjoShortName = "ban";
         private const string m_BarroomName = "in the barroom";
        private const string m_BasementElevatorName = "in the basement elevator";
        private const string m_BathroomName = "in a bathroom";
        private const string m_BathtubName = "a brass bathtub";
        private const string m_BatteriesName = "a set of batteries";
        private const string m_BatteriesShortName = "bat";
         private const string m_BeastName = "a savage beast";
        private const string m_BeastShortName = "bea";
         private const string m_BedName = "a king sized bed";
        private const string m_BedroomName = "in a bedroom";
        private const string m_BlobName = "a protoplasmic blob";
        private const string m_BlobShortName = "blo";
         private const string m_BookName = "a sorcerer's hand book";
        private const string m_BookShortName = "boo";
         private const string m_BoxName = "a wooden box";
        private const string m_BoxShortName = "box";
         private const string m_BrushName = "a hairbrush";
        private const string m_BrushShortName = "hai";
         private const string m_BugSprayName = "a can of bug spray";
        private const string m_BugSprayShortName = "can";
         private const string m_ClosetName = "in a closet";
        private const string m_CoalBinName = "in a dusty coal bin";
        private const string m_CoatClosetName = "in a coat closet";
        private const string m_CoinsName = "100's of gold coins";
        private const string m_CoinsShortName = "coi";
         private const string m_ComputerRoomName = "in the computer-room";
        private const string m_DenName = "in the den";
        private const string m_DiamondName = "a small diamond";
        private const string m_DiamondShortName = "dia";
         private const string m_DimeName = "an aluminum dime";
         private const string m_DimeShortName = "dim";
         private const string m_DiningRoomName = "in the dining room";
        private const string m_DirtFlooredRoomName = "in a dirt-floored room";
        private const string m_DryIceName = "a block of dry ice";
        private const string m_DryIceShortName = "ice";
         private const string m_FamilyRoomName = "in the family room";
        private const string m_FirstFloorElevatorName = "in the first floor elevator";
        private const string m_FlashlightName = "a flashlight";
        private const string m_FlashlightShortName = "fla";
         private const string m_FoyerName = "in the foyer";
        private const string m_FreezerName = "in a walk-in freezer";
        private const string m_FrontPorchName = "on the front porch";
        private const string m_FrontYardName = "the front yard";
        private const string m_FurnaceRoomName = "in the furnace room";
        private const string m_GameRoomName = "in the game room";
        private const string m_GarlicName = "a clove of garlic";
        private const string m_GarlicShortName = "gar";
         private const string m_GloveName = "an old leather glove";
        private const string m_GloveShortName = "glo";
         private const string m_GuestroomName = "in a guest room";
        private const string m_KitchenName = "in the kitchen";
        private const string m_KnifeName = "a carving knife";
        private const string m_KnifeShortName = "kni";
         private const string m_LaboratoryName = "in the laboratory";
        private const string m_LeopardName = "a leopard";
        private const string m_LeopardShortName = "leo";
         private const string m_LibraryName = "in the library";
        private const string m_LivingRoomName = "in the living room";
        private const string m_LockedDoorName = "a locked door";
        private const string m_LockedDoorShortName = "doo";
         private const string m_MainframeName = "a unitron 30/50 mainframe";
        private const string m_MasterBedroomName = "in the master bedroom";
        private const string m_MonkName = "an insane monk";
        private const string m_MonkShortName = "mon";
         private const string m_MonsterHangoutName = "in the monster hangout";
        private const string m_MooseHeadName = "a dusty moose head";
        private const string m_PantryName = "in the pantry";
        private const string m_ParchmentName = "a wrinkled parchment";
        private const string m_ParchmentShortName = "par";
         private const string m_PillowName = "a silk pillow";
        private const string m_PillowShortName = "pil";
         private const string m_PumpRoomName = "in the pumproom";
        private const string m_RustedKeyName = "a rusted key";
        private const string m_RustedKeyShortName = "key";
         private const string m_SecondFloorElevatorName = "in the second floor elevator";
        private const string m_SewingRoomName = "in the sewing room";
        private const string m_ShovelName = "a shovel";
        private const string m_ShovelShortName = "sho";
         private const string m_SittingRoomName = "in a sitting room";
        private const string m_StocksName = "a set of stocks";
        private const string m_TelephoneBoothName = "in a telephone booth";
        private const string m_ThirdFloorElevatorName = "in the third floor elevator";
        private const string m_TortureChamberName = "in the torture chamber";
        private const string m_TrophyRoomName = "in the trophy room";
        private const string m_VampireName = "a vampire";
        private const string m_VampireShortName = "vam";
         private const string m_VaseName = "a ming vase";
        private const string m_VaseShortName = "vas";
         private const string m_WerewolfName = "a werewolf";
        private const string m_WerewolfShortName = "wer";
         private const string m_WorkshopName = "in the workshop";
        /// <summary>
        /// 
        /// </summary>
        public const int MaximumInventoryItems = 4;
        /// <summary>
        /// 
        /// </summary>
        public const int MaximumLooksInDark = 3;

		#endregion Fields 

		#region Properties (178) 

        /// <summary>
        /// Gets the actions.
        /// </summary>
        /// <value>The actions.</value>
        public static ReadOnlyCollection<string> Actions
        {
            get { return collectionActions; }
        }

        /// <summary>
        /// Gets the name of the art hall.
        /// </summary>
        /// <value>The name of the art hall.</value>
        public static string ArtHallName
        {
            get { return m_ArtHallName; }
        }

        /// <summary>
        /// Gets the name of the bag of gold.
        /// </summary>
        /// <value>The name of the bag of gold.</value>
        public static string BagOfGoldName
        {
            get { return m_BagOfGoldName; }
        }

        /// <summary>
        /// Gets the short name of the bag of gold.
        /// </summary>
        /// <value>The short name of the bag of gold.</value>
        public static string BagOfGoldShortName
        {
            get { return m_BagOfGoldShortName; }
        }

        /// <summary>
        /// Gets the name of the banjo.
        /// </summary>
        /// <value>The name of the banjo.</value>
        public static string BanjoName
        {
            get { return m_BanjoName; }
        }

        /// <summary>
        /// Gets the short name of the banjo.
        /// </summary>
        /// <value>The short name of the banjo.</value>
        public static string BanjoShortName
        {
            get { return m_BanjoShortName; }
        }

        /// <summary>
        /// Gets the name of the bar room.
        /// </summary>
        /// <value>The name of the bar room.</value>
        public static string BarroomName
        {
            get { return m_BarroomName; }
        }

        /// <summary>
        /// Gets the name of the basement elevator.
        /// </summary>
        /// <value>The name of the basement elevator.</value>
        public static string BasementElevatorName
        {
            get { return m_BasementElevatorName; }
        }

        /// <summary>
        /// Gets the name of the bathroom.
        /// </summary>
        /// <value>The name of the bathroom.</value>
        public static string BathroomName
        {
            get { return m_BathroomName; }
        }

        /// <summary>
        /// Gets the name of the bathtub.
        /// </summary>
        /// <value>The name of the bathtub.</value>
        public static string BathtubName
        {
            get { return m_BathtubName; }
        }

        /// <summary>
        /// Gets the name of the batteries.
        /// </summary>
        /// <value>The name of the batteries.</value>
        public static string BatteriesName
        {
            get { return m_BatteriesName; }
        }

        /// <summary>
        /// Gets the short name of the batteries.
        /// </summary>
        /// <value>The short name of the batteries.</value>
        public static string BatteriesShortName
        {
            get { return m_BatteriesShortName; }
        }

        /// <summary>
        /// Gets the name of the beast.
        /// </summary>
        /// <value>The name of the beast.</value>
        public static string BeastName
        {
            get { return m_BeastName; }
        }

        /// <summary>
        /// Gets the short name of the beast.
        /// </summary>
        /// <value>The short name of the beast.</value>
        public static string BeastShortName
        {
            get { return m_BeastShortName; }
        }

        /// <summary>
        /// Gets the name of the bed.
        /// </summary>
        /// <value>The name of the bed.</value>
        public static string BedName
        {
            get { return m_BedName; }
        }

        /// <summary>
        /// Gets the name of the bedroom.
        /// </summary>
        /// <value>The name of the bedroom.</value>
        public static string BedroomName
        {
            get { return m_BedroomName; }
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
        /// Gets the short name of the BLOB.
        /// </summary>
        /// <value>The short name of the BLOB.</value>
        public static string BlobShortName
        {
            get { return m_BlobShortName; }
        }

        /// <summary>
        /// Gets the name of the book.
        /// </summary>
        /// <value>The name of the book.</value>
        public static string BookName
        {
            get { return m_BookName; }
        }

        /// <summary>
        /// Gets the short name of the book.
        /// </summary>
        /// <value>The short name of the book.</value>
        public static string BookShortName
        {
            get { return m_BookShortName; }
        }

        /// <summary>
        /// Gets the name of the box.
        /// </summary>
        /// <value>The name of the box.</value>
        public static string BoxName
        {
            get { return m_BoxName; }
        }

        /// <summary>
        /// Gets the short name of the box.
        /// </summary>
        /// <value>The short name of the box.</value>
        public static string BoxShortName
        {
            get { return m_BoxShortName; }
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
        /// Gets the short name of the brush.
        /// </summary>
        /// <value>The short name of the brush.</value>
        public static string BrushShortName
        {
            get { return m_BrushShortName; }
        }

        /// <summary>
        /// Gets the name of the bug spray.
        /// </summary>
        /// <value>The name of the bug spray.</value>
        public static string BugSprayName
        {
            get { return m_BugSprayName; }
        }

        /// <summary>
        /// Gets the short name of the bug spray.
        /// </summary>
        /// <value>The short name of the bug spray.</value>
        public static string BugSprayShortName
        {
            get { return m_BugSprayShortName; }
        }

        /// <summary>
        /// Gets the name of the closet.
        /// </summary>
        /// <value>The name of the closet.</value>
        public static string ClosetName
        {
            get { return m_ClosetName; }
        }

        /// <summary>
        /// Gets the name of the coal bin.
        /// </summary>
        /// <value>The name of the coal bin.</value>
        public static string CoalBinName
        {
            get { return m_CoalBinName; }
        }

        /// <summary>
        /// Gets the coat closet name.
        /// </summary>
        /// <value>The coat closet name.</value>
        public static string CoatClosetName
        {
            get { return m_CoatClosetName; }
        }

        /// <summary>
        /// Gets the name of the coins.
        /// </summary>
        /// <value>The name of the coins.</value>
        public static string CoinsName
        {
            get { return m_CoinsName; }
        }

        /// <summary>
        /// Gets the short name of the coins.
        /// </summary>
        /// <value>The short name of the coins.</value>
        public static string CoinsShortName
        {
            get { return m_CoinsShortName; }
        }

        /// <summary>
        /// Gets the name of the computer room.
        /// </summary>
        /// <value>The name of the computer room.</value>
        public static string ComputerRoomName
        {
            get { return m_ComputerRoomName; }
        }

        /// <summary>
        /// Gets the name of the den.
        /// </summary>
        /// <value>The name of the den.</value>
        public static string DenName
        {
            get { return m_DenName; }
        }

        /// <summary>
        /// Gets the name of the diamond.
        /// </summary>
        /// <value>The name of the diamond.</value>
        public static string DiamondName
        {
            get { return m_DiamondName; }
        }

        /// <summary>
        /// Gets the short name of the diamond.
        /// </summary>
        /// <value>The short name of the diamond.</value>
        public static string DiamondShortName
        {
            get { return m_DiamondShortName; }
        }

        /// <summary>
        /// Gets the name of the dime.
        /// </summary>
        /// <value>The name of the dime.</value>
        public static string DimeName
        {
            get { return m_DimeName; }
        }

        /// <summary>
        /// Gets the short name of the dime.
        /// </summary>
        /// <value>The short name of the dime.</value>
        public static string DimeShortName
        {
            get { return m_DimeShortName; }
        }

        /// <summary>
        /// Gets the name of the dining room.
        /// </summary>
        /// <value>The name of the dining room.</value>
        public static string DiningRoomName
        {
            get { return m_DiningRoomName; }
        }

        /// <summary>
        /// Gets the name of the dirt floored room.
        /// </summary>
        /// <value>The name of the dirt floored room.</value>
        public static string DirtFlooredRoomName
        {
            get { return m_DirtFlooredRoomName; }
        }

        /// <summary>
        /// Gets the name of the dry ice.
        /// </summary>
        /// <value>The name of the dry ice.</value>
        public static string DryIceName
        {
            get { return m_DryIceName; }
        }

        /// <summary>
        /// Gets the short name of the dry ice.
        /// </summary>
        /// <value>The short name of the dry ice.</value>
        public static string DryIceShortName
        {
            get { return m_DryIceShortName; }
        }

        /// <summary>
        /// Gets the exits for the basement coal bin.
        /// </summary>
        /// <value>The exits for the basement coal bin.</value>
        public static ExitSetKeyedCollection ExitsBasementCoalBin
        {
            get { return TheHouseData.exitsBasementCoalBin; }
        }

        /// <summary>
        /// Gets the exits for the basement dirt floored room.
        /// </summary>
        /// <value>The exits for the basement dirt floored room.</value>
        public static ExitSetKeyedCollection ExitsBasementDirtFlooredRoom
        {
            get { return TheHouseData.exitsBasementDirtFlooredRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement elevator.
        /// </summary>
        /// <value>The exits for the basement elevator.</value>
        public static ExitSetKeyedCollection ExitsBasementElevator
        {
            get { return TheHouseData.exitsBasementElevator; }
        }

        /// <summary>
        /// Gets the exits for the basement freezer.
        /// </summary>
        /// <value>The exits for the basement freezer.</value>
        public static ExitSetKeyedCollection ExitsBasementFreezer
        {
            get { return TheHouseData.exitsBasementFreezer; }
        }

        /// <summary>
        /// Gets the exits for the basement furnace room.
        /// </summary>
        /// <value>The exits for the basement furnace room.</value>
        public static ExitSetKeyedCollection ExitsBasementFurnaceRoom
        {
            get { return TheHouseData.exitsBasementFurnaceRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement laboratory.
        /// </summary>
        /// <value>The exits for the basement laboratory.</value>
        public static ExitSetKeyedCollection ExitsBasementLaboratory
        {
            get { return TheHouseData.exitsBasementLaboratory; }
        }

        /// <summary>
        /// Gets the exits for the basement pump room.
        /// </summary>
        /// <value>The exits for the basement pump room.</value>
        public static ExitSetKeyedCollection ExitsBasementPumpRoom
        {
            get { return TheHouseData.exitsBasementPumpRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement telephone booth.
        /// </summary>
        /// <value>The exits for the basement telephone booth.</value>
        public static ExitSetKeyedCollection ExitsBasementTelephoneBooth
        {
            get { return TheHouseData.exitsBasementTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the basement torture chamber.
        /// </summary>
        /// <value>The exits for the basement torture chamber.</value>
        public static ExitSetKeyedCollection ExitsBasementTortureChamber
        {
            get { return TheHouseData.exitsBasementTortureChamber; }
        }

        /// <summary>
        /// Gets the exits for the basement workshop.
        /// </summary>
        /// <value>The exits for the basement workshop.</value>
        public static ExitSetKeyedCollection ExitsBasementWorkshop
        {
            get { return TheHouseData.exitsBasementWorkshop; }
        }

        /// <summary>
        /// Gets the exits for the first floor bedroom.
        /// </summary>
        /// <value>The exits for the first floor bedroom.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorBedroom
        {
            get { return TheHouseData.exitsFirstFloorBedroom; }
        }

        /// <summary>
        /// Gets the exits for the first floor coat closet.
        /// </summary>
        /// <value>The exits for the first floor coat closet.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorCoatCloset
        {
            get { return TheHouseData.exitsFirstFloorCoatCloset; }
        }

        /// <summary>
        /// Gets the exits for the first floor dining room.
        /// </summary>
        /// <value>The exits for the first floor dining room.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorDiningRoom
        {
            get { return TheHouseData.exitsFirstFloorDiningRoom; }
        }

        /// <summary>
        /// Gets the exits for the first floor elevator.
        /// </summary>
        /// <value>The exits for the first floor elevator.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorElevator
        {
            get { return TheHouseData.exitsFirstFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the first floor family room.
        /// </summary>
        /// <value>The exits for the first floor family room.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorFamilyRoom
        {
            get { return TheHouseData.exitsFirstFloorFamilyRoom; }
        }

        /// <summary>
        /// Gets the exits for the first floor foyer.
        /// </summary>
        /// <value>The exits for the first floor foyer.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorFoyer
        {
            get { return TheHouseData.exitsFirstFloorFoyer; }
        }

        /// <summary>
        /// Gets the exits for the first floor front porch.
        /// </summary>
        /// <value>The exits for the first floor front porch.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorFrontPorch
        {
            get { return TheHouseData.exitsFirstFloorFrontPorch; }
        }

        /// <summary>
        /// Gets the exits for the first floor kitchen.
        /// </summary>
        /// <value>The exits for the first floor kitchen.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorKitchen
        {
            get { return TheHouseData.exitsFirstFloorKitchen; }
        }

        /// <summary>
        /// Gets the exits for the first floor pantry.
        /// </summary>
        /// <value>The exits for the first floor pantry.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorPantry
        {
            get { return TheHouseData.exitsFirstFloorPantry; }
        }

        /// <summary>
        /// Gets the exits for the first floor telephone booth.
        /// </summary>
        /// <value>The exits for the first floor telephone booth.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorTelephoneBooth
        {
            get { return TheHouseData.exitsFirstFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits of the monster hangout.
        /// </summary>
        /// <value>The exits of the monster hangout.</value>
        public static ExitSetKeyedCollection ExitsMonsterHangout
        {
            get { return TheHouseData.exitsMonsterHangout; }
        }

        /// <summary>
        /// Gets the exits for the second floor bathroom.
        /// </summary>
        /// <value>The exits for the second floor bathroom.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorBathroom
        {
            get { return TheHouseData.exitsSecondFloorBathroom; }
        }

        /// <summary>
        /// Gets the exits for the second floor closet.
        /// </summary>
        /// <value>The exits for the second floor closet.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorCloset
        {
            get { return TheHouseData.exitsSecondFloorCloset; }
        }

        /// <summary>
        /// Gets the exits for the second floor den.
        /// </summary>
        /// <value>The exits for the second floor den.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorDen
        {
            get { return TheHouseData.exitsSecondFloorDen; }
        }

        /// <summary>
        /// Gets the exits for the second floor elevator.
        /// </summary>
        /// <value>The exits for the second floor elevator.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorElevator
        {
            get { return TheHouseData.exitsSecondFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the second floor guest room1.
        /// </summary>
        /// <value>The exits for the second floor guest room1.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorGuestroom1
        {
            get { return TheHouseData.exitsSecondFloorGuestroom1; }
        }

        /// <summary>
        /// Gets the exits for the second floor guest room2.
        /// </summary>
        /// <value>The exits for the second floor guest room2.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorGuestroom2
        {
            get { return TheHouseData.exitsSecondFloorGuestroom2; }
        }

        /// <summary>
        /// Gets the exits for the second floor master bedroom.
        /// </summary>
        /// <value>The exits for the second floor master bedroom.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorMasterBedroom
        {
            get { return TheHouseData.exitsSecondFloorMasterBedroom; }
        }

        /// <summary>
        /// Gets the exits for the second floor sewing room.
        /// </summary>
        /// <value>The exits for the second floor sewing room.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorSewingRoom
        {
            get { return TheHouseData.exitsSecondFloorSewingRoom; }
        }

        /// <summary>
        /// Gets the exits for the second floor sitting room.
        /// </summary>
        /// <value>The exits for the second floor sitting room.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorSittingRoom
        {
            get { return TheHouseData.exitsSecondFloorSittingRoom; }
        }

        /// <summary>
        /// Gets the exits for the second floor telephone booth.
        /// </summary>
        /// <value>The exits for the second floor telephone booth.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorTelephoneBooth
        {
            get { return TheHouseData.exitsSecondFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the third floor art hall.
        /// </summary>
        /// <value>The exits for the third floor art hall.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorArtHall
        {
            get { return TheHouseData.exitsThirdFloorArtHall; }
        }

        /// <summary>
        /// Gets the exits for the third floor bar room.
        /// </summary>
        /// <value>The exits for the third floor bar room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorBarroom
        {
            get { return TheHouseData.exitsThirdFloorBarroom; }
        }

        /// <summary>
        /// Gets the exits for the third floor bedroom.
        /// </summary>
        /// <value>The exits for the third floor bedroom.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorBedroom
        {
            get { return TheHouseData.exitsThirdFloorBedroom; }
        }

        /// <summary>
        /// Gets the exits for the third floor computer room.
        /// </summary>
        /// <value>The exits for the third floor computer room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorComputerRoom
        {
            get { return TheHouseData.exitsThirdFloorComputerRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor elevator.
        /// </summary>
        /// <value>The exits for the third floor elevator.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorElevator
        {
            get { return TheHouseData.exitsThirdFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the third floor game room.
        /// </summary>
        /// <value>The exits for the third floor game room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorGameRoom
        {
            get { return TheHouseData.exitsThirdFloorGameRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor library.
        /// </summary>
        /// <value>The exits for the third floor library.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorLibrary
        {
            get { return TheHouseData.exitsThirdFloorLibrary; }
        }

        /// <summary>
        /// Gets the exits for the third floor living room.
        /// </summary>
        /// <value>The exits for the third floor living room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorLivingRoom
        {
            get { return TheHouseData.exitsThirdFloorLivingRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor telephone booth.
        /// </summary>
        /// <value>The exits for the third floor telephone booth.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorTelephoneBooth
        {
            get { return TheHouseData.exitsThirdFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the third floor trophy room.
        /// </summary>
        /// <value>The exits for the third floor trophy room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorTrophyRoom
        {
            get { return TheHouseData.exitsThirdFloorTrophyRoom; }
        }

        /// <summary>
        /// Gets the name of the family room.
        /// </summary>
        /// <value>The name of the family room.</value>
        public static string FamilyRoomName
        {
            get { return m_FamilyRoomName; }
        }

        /// <summary>
        /// Gets the first name of the floor elevator.
        /// </summary>
        /// <value>The first name of the floor elevator.</value>
        public static string FirstFloorElevatorName
        {
            get { return m_FirstFloorElevatorName; }
        }

        /// <summary>
        /// Gets the name of the flashlight.
        /// </summary>
        /// <value>The name of the flashlight.</value>
        public static string FlashlightName
        {
            get { return m_FlashlightName; }
        }

        /// <summary>
        /// Gets the short name of the flashlight.
        /// </summary>
        /// <value>The short name of the flashlight.</value>
        public static string FlashlightShortName
        {
            get { return m_FlashlightShortName; }
        }

        /// <summary>
        /// Gets the name of the foyer.
        /// </summary>
        /// <value>The name of the foyer.</value>
        public static string FoyerName
        {
            get { return m_FoyerName; }
        }

        /// <summary>
        /// Gets the name of the freezer.
        /// </summary>
        /// <value>The name of the freezer.</value>
        public static string FreezerName
        {
            get { return m_FreezerName; }
        }

        /// <summary>
        /// Gets the name of the front porch.
        /// </summary>
        /// <value>The name of the front porch.</value>
        public static string FrontPorchName
        {
            get { return m_FrontPorchName; }
        }

        /// <summary>
        /// Gets the name of the front yard.
        /// </summary>
        /// <value>The name of the front yard.</value>
        public static string FrontYardName
        {
            get { return m_FrontYardName; }
        }

        /// <summary>
        /// Gets the name of the furnace room.
        /// </summary>
        /// <value>The name of the furnace room.</value>
        public static string FurnaceRoomName
        {
            get { return m_FurnaceRoomName; }
        }

        /// <summary>
        /// Gets the name of the game room.
        /// </summary>
        /// <value>The name of the game room.</value>
        public static string GameRoomName
        {
            get { return m_GameRoomName; }
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
        /// Gets the short name of the garlic.
        /// </summary>
        /// <value>The short name of the garlic.</value>
        public static string GarlicShortName
        {
            get { return m_GarlicShortName; }
        }

        /// <summary>
        /// Gets the name of the glove.
        /// </summary>
        /// <value>The name of the glove.</value>
        public static string GloveName
        {
            get { return m_GloveName; }
        }

        /// <summary>
        /// Gets the short name of the glove.
        /// </summary>
        /// <value>The short name of the glove.</value>
        public static string GloveShortName
        {
            get { return m_GloveShortName; }
        }

        /// <summary>
        /// Gets the name of the guest room.
        /// </summary>
        /// <value>The name of the guest room.</value>
        public static string GuestroomName
        {
            get { return m_GuestroomName; }
        }

        /// <summary>
        /// Gets the name of the kitchen.
        /// </summary>
        /// <value>The name of the kitchen.</value>
        public static string KitchenName
        {
            get { return m_KitchenName; }
        }

        /// <summary>
        /// Gets the name of the knife.
        /// </summary>
        /// <value>The name of the knife.</value>
        public static string KnifeName
        {
            get { return m_KnifeName; }
        }

        /// <summary>
        /// Gets the short name of the knife.
        /// </summary>
        /// <value>The short name of the knife.</value>
        public static string KnifeShortName
        {
            get { return m_KnifeShortName; }
        }

        /// <summary>
        /// Gets the name of the laboratory.
        /// </summary>
        /// <value>The name of the laboratory.</value>
        public static string LaboratoryName
        {
            get { return m_LaboratoryName; }
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
        /// Gets the short name of the leopard.
        /// </summary>
        /// <value>The short name of the leopard.</value>
        public static string LeopardShortName
        {
            get { return m_LeopardShortName; }
        }

        /// <summary>
        /// Gets the name of the library.
        /// </summary>
        /// <value>The name of the library.</value>
        public static string LibraryName
        {
            get { return m_LibraryName; }
        }

        /// <summary>
        /// Gets the name of the living room.
        /// </summary>
        /// <value>The name of the living room.</value>
        public static string LivingRoomName
        {
            get { return m_LivingRoomName; }
        }

        /// <summary>
        /// Gets the location of the basement coal bin.
        /// </summary>
        /// <value>The location of the basement coal bin.</value>
        public static LocationType LocationBasementCoalBin
        {
            get { return TheHouseData.locationBasementCoalBin; }
        }

        /// <summary>
        /// Gets the location of the basement dirt floored room.
        /// </summary>
        /// <value>The location of the basement dirt floored room.</value>
        public static LocationType LocationBasementDirtFlooredRoom
        {
            get { return TheHouseData.locationBasementDirtFlooredRoom; }
        }

        /// <summary>
        /// Gets the location of the basement elevator.
        /// </summary>
        /// <value>The location of the basement elevator.</value>
        public static LocationType LocationBasementElevator
        {
            get { return TheHouseData.locationBasementElevator; }
        }

        /// <summary>
        /// Gets the location of the basement freezer.
        /// </summary>
        /// <value>The location of the basement freezer.</value>
        public static LocationType LocationBasementFreezer
        {
            get { return TheHouseData.locationBasementFreezer; }
        }

        /// <summary>
        /// Gets the location of the basement furnace room.
        /// </summary>
        /// <value>The location of the basement furnace room.</value>
        public static LocationType LocationBasementFurnaceRoom
        {
            get { return TheHouseData.locationBasementFurnaceRoom; }
        }

        /// <summary>
        /// Gets the location of the basement laboratory.
        /// </summary>
        /// <value>The location of the basement laboratory.</value>
        public static LocationType LocationBasementLaboratory
        {
            get { return TheHouseData.locationBasementLaboratory; }
        }

        /// <summary>
        /// Gets the location of the basement pump room.
        /// </summary>
        /// <value>The location of the basement pump room.</value>
        public static LocationType LocationBasementPumpRoom
        {
            get { return TheHouseData.locationBasementPumpRoom; }
        }

        /// <summary>
        /// Gets the location of the basement telephone booth.
        /// </summary>
        /// <value>The location of the basement telephone booth.</value>
        public static LocationType LocationBasementTelephoneBooth
        {
            get { return TheHouseData.locationBasementTelephoneBooth; }
        }

        /// <summary>
        /// Gets the location of the basement torture chamber.
        /// </summary>
        /// <value>The location of the basement torture chamber.</value>
        public static LocationType LocationBasementTortureChamber
        {
            get { return TheHouseData.locationBasementTortureChamber; }
        }

        /// <summary>
        /// Gets the location of the basement workshop.
        /// </summary>
        /// <value>The location of the basement workshop.</value>
        public static LocationType LocationBasementWorkshop
        {
            get { return TheHouseData.locationBasementWorkshop; }
        }

        /// <summary>
        /// Gets the location of the first floor bedroom.
        /// </summary>
        /// <value>The location of the first floor bedroom.</value>
        public static LocationType LocationFirstFloorBedroom
        {
            get { return TheHouseData.locationFirstFloorBedroom; }
        }

        /// <summary>
        /// Gets the location of the first floor coat closet.
        /// </summary>
        /// <value>The location of the first floor coat closet.</value>
        public static LocationType LocationFirstFloorCoatCloset
        {
            get { return TheHouseData.locationFirstFloorCoatCloset; }
        }

        /// <summary>
        /// Gets the location of the first floor dining room.
        /// </summary>
        /// <value>The location of the first floor dining room.</value>
        public static LocationType LocationFirstFloorDiningRoom
        {
            get { return TheHouseData.locationFirstFloorDiningRoom; }
        }

        /// <summary>
        /// Gets the location of the first floor elevator.
        /// </summary>
        /// <value>The location of the first floor elevator.</value>
        public static LocationType LocationFirstFloorElevator
        {
            get { return TheHouseData.locationFirstFloorElevator; }
        }

        /// <summary>
        /// Gets the location of the first floor family room.
        /// </summary>
        /// <value>The location of the first floor family room.</value>
        public static LocationType LocationFirstFloorFamilyRoom
        {
            get { return TheHouseData.locationFirstFloorFamilyRoom; }
        }

        /// <summary>
        /// Gets the location of the first floor foyer.
        /// </summary>
        /// <value>The location of the first floor foyer.</value>
        public static LocationType LocationFirstFloorFoyer
        {
            get { return TheHouseData.locationFirstFloorFoyer; }
        }

        /// <summary>
        /// Gets the location of the first floor front porch.
        /// </summary>
        /// <value>The location of the first floor front porch.</value>
        public static LocationType LocationFirstFloorFrontPorch
        {
            get { return TheHouseData.locationFirstFloorFrontPorch; }
        }

        /// <summary>
        /// Gets the location of the first floor kitchen.
        /// </summary>
        /// <value>The location of the first floor kitchen.</value>
        public static LocationType LocationFirstFloorKitchen
        {
            get { return TheHouseData.locationFirstFloorKitchen; }
        }

        /// <summary>
        /// Gets the location of the first floor pantry.
        /// </summary>
        /// <value>The location of the first floor pantry.</value>
        public static LocationType LocationFirstFloorPantry
        {
            get { return TheHouseData.locationFirstFloorPantry; }
        }

        /// <summary>
        /// Gets the location of the first floor telephone booth.
        /// </summary>
        /// <value>The location of the first floor telephone booth.</value>
        public static LocationType LocationFirstFloorTelephoneBooth
        {
            get { return TheHouseData.locationFirstFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the location of the monster hangout.
        /// </summary>
        /// <value>The location of the monster hangout.</value>
        public static LocationType LocationMonsterHangout
        {
            get { return TheHouseData.locationMonsterHangout; }
        }

        /// <summary>
        /// Gets the location of the second floor bathroom.
        /// </summary>
        /// <value>The location of the second floor bathroom.</value>
        public static LocationType LocationSecondFloorBathroom
        {
            get { return TheHouseData.locationSecondFloorBathroom; }
        }

        /// <summary>
        /// Gets the location of the second floor closet.
        /// </summary>
        /// <value>The location of the second floor closet.</value>
        public static LocationType LocationSecondFloorCloset
        {
            get { return TheHouseData.locationSecondFloorCloset; }
        }

        /// <summary>
        /// Gets the location of the second floor den.
        /// </summary>
        /// <value>The location of the second floor den.</value>
        public static LocationType LocationSecondFloorDen
        {
            get { return TheHouseData.locationSecondFloorDen; }
        }

        /// <summary>
        /// Gets the location of the second floor elevator.
        /// </summary>
        /// <value>The location of the second floor elevator.</value>
        public static LocationType LocationSecondFloorElevator
        {
            get { return TheHouseData.locationSecondFloorElevator; }
        }

        /// <summary>
        /// Gets the location of the second floor guest room1.
        /// </summary>
        /// <value>The location of the second floor guest room1.</value>
        public static LocationType LocationSecondFloorGuestroom1
        {
            get { return TheHouseData.locationSecondFloorGuestroom1; }
        }

        /// <summary>
        /// Gets the location of the second floor guest room2.
        /// </summary>
        /// <value>The location of the second floor guest room2.</value>
        public static LocationType LocationSecondFloorGuestroom2
        {
            get { return TheHouseData.locationSecondFloorGuestroom2; }
        }

        /// <summary>
        /// Gets the location of the second floor master bedroom.
        /// </summary>
        /// <value>The location of the second floor master bedroom.</value>
        public static LocationType LocationSecondFloorMasterBedroom
        {
            get { return TheHouseData.locationSecondFloorMasterBedroom; }
        }

        /// <summary>
        /// Gets the location of the second floor sewing room.
        /// </summary>
        /// <value>The location of the second floor sewing room.</value>
        public static LocationType LocationSecondFloorSewingRoom
        {
            get { return TheHouseData.locationSecondFloorSewingRoom; }
        }

        /// <summary>
        /// Gets the location of the second floor sitting room.
        /// </summary>
        /// <value>The location of the second floor sitting room.</value>
        public static LocationType LocationSecondFloorSittingRoom
        {
            get { return TheHouseData.locationSecondFloorSittingRoom; }
        }

        /// <summary>
        /// Gets the location of the second floor telephone booth.
        /// </summary>
        /// <value>The location of the second floor telephone booth.</value>
        public static LocationType LocationSecondFloorTelephoneBooth
        {
            get { return TheHouseData.locationSecondFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the location of the third floor art hall.
        /// </summary>
        /// <value>The location of the third floor art hall.</value>
        public static LocationType LocationThirdFloorArtHall
        {
            get { return TheHouseData.locationThirdFloorArtHall; }
        }

        /// <summary>
        /// Gets the location of the third floor bar room.
        /// </summary>
        /// <value>The location of the third floor bar room.</value>
        public static LocationType LocationThirdFloorBarroom
        {
            get { return TheHouseData.locationThirdFloorBarroom; }
        }

        /// <summary>
        /// Gets the location of the third floor bedroom.
        /// </summary>
        /// <value>The location of the third floor bedroom.</value>
        public static LocationType LocationThirdFloorBedroom
        {
            get { return TheHouseData.locationThirdFloorBedroom; }
        }

        /// <summary>
        /// Gets the location of the third floor computer room.
        /// </summary>
        /// <value>The location of the third floor computer room.</value>
        public static LocationType LocationThirdFloorComputerRoom
        {
            get { return TheHouseData.locationThirdFloorComputerRoom; }
        }

        /// <summary>
        /// Gets the location of the third floor elevator.
        /// </summary>
        /// <value>The location of the third floor elevator.</value>
        public static LocationType LocationThirdFloorElevator
        {
            get { return TheHouseData.locationThirdFloorElevator; }
        }

        /// <summary>
        /// Gets the location of the third floor game room.
        /// </summary>
        /// <value>The location of the third floor game room.</value>
        public static LocationType LocationThirdFloorGameRoom
        {
            get { return TheHouseData.locationThirdFloorGameRoom; }
        }

        /// <summary>
        /// Gets the location of the third floor library.
        /// </summary>
        /// <value>The location of the third floor library.</value>
        public static LocationType LocationThirdFloorLibrary
        {
            get { return TheHouseData.locationThirdFloorLibrary; }
        }

        /// <summary>
        /// Gets the location of the third floor living room.
        /// </summary>
        /// <value>The location of the third floor living room.</value>
        public static LocationType LocationThirdFloorLivingRoom
        {
            get { return TheHouseData.locationThirdFloorLivingRoom; }
        }

        /// <summary>
        /// Gets the location of the third floor telephone booth.
        /// </summary>
        /// <value>The location of the third floor telephone booth.</value>
        public static LocationType LocationThirdFloorTelephoneBooth
        {
            get { return TheHouseData.locationThirdFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the location of the third floor trophy room.
        /// </summary>
        /// <value>The location of the third floor trophy room.</value>
        public static LocationType LocationThirdFloorTrophyRoom
        {
            get { return TheHouseData.locationThirdFloorTrophyRoom; }
        }

        /// <summary>
        /// Gets the name of the locked door.
        /// </summary>
        /// <value>The name of the locked door.</value>
        public static string LockedDoorName
        {
            get { return m_LockedDoorName; }
        }

        /// <summary>
        /// Gets the short name of the locked door.
        /// </summary>
        /// <value>The short name of the locked door.</value>
        public static string LockedDoorShortName
        {
            get { return m_LockedDoorShortName; }
        }

        /// <summary>
        /// Gets the name of the mainframe.
        /// </summary>
        /// <value>The name of the mainframe.</value>
        public static string MainframeName
        {
            get { return m_MainframeName; }
        }

        /// <summary>
        /// Gets the name of the master bedroom.
        /// </summary>
        /// <value>The name of the master bedroom.</value>
        public static string MasterBedroomName
        {
            get { return m_MasterBedroomName; }
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
        /// Gets the short name of the monk.
        /// </summary>
        /// <value>The short name of the monk.</value>
        public static string MonkShortName
        {
            get { return m_MonkShortName; }
        }

        /// <summary>
        /// Gets the name of the monster hangout.
        /// </summary>
        /// <value>The name of the monster hangout.</value>
        public static string MonsterHangoutName
        {
            get { return m_MonsterHangoutName; }
        }

        /// <summary>
        /// Gets the name of the moose head.
        /// </summary>
        /// <value>The name of the moose head.</value>
        public static string MooseHeadName
        {
            get { return m_MooseHeadName; }
        }

        /// <summary>
        /// Gets the name of the pantry.
        /// </summary>
        /// <value>The name of the pantry.</value>
        public static string PantryName
        {
            get { return m_PantryName; }
        }

        /// <summary>
        /// Gets the name of the parchment.
        /// </summary>
        /// <value>The name of the parchment.</value>
        public static string ParchmentName
        {
            get { return m_ParchmentName; }
        }

        /// <summary>
        /// Gets the short name of the parchment.
        /// </summary>
        /// <value>The short name of the parchment.</value>
        public static string ParchmentShortName
        {
            get { return m_ParchmentShortName; }
        }

        /// <summary>
        /// Gets the name of the pillow.
        /// </summary>
        /// <value>The name of the pillow.</value>
        public static string PillowName
        {
            get { return m_PillowName; }
        }

        /// <summary>
        /// Gets the short name of the pillow.
        /// </summary>
        /// <value>The short name of the pillow.</value>
        public static string PillowShortName
        {
            get { return m_PillowShortName; }
        }

        /// <summary>
        /// Gets the name of the pump room.
        /// </summary>
        /// <value>The name of the pump room.</value>
        public static string PumpRoomName
        {
            get { return m_PumpRoomName; }
        }

        /// <summary>
        /// Gets the name of the rusted key.
        /// </summary>
        /// <value>The name of the rusted key.</value>
        public static string RustedKeyName
        {
            get { return m_RustedKeyName; }
        }

        /// <summary>
        /// Gets the short name of the rusted key.
        /// </summary>
        /// <value>The short name of the rusted key.</value>
        public static string RustedKeyShortName
        {
            get { return m_RustedKeyShortName; }
        }

        /// <summary>
        /// Gets the name of the second floor elevator.
        /// </summary>
        /// <value>The name of the second floor elevator.</value>
        public static string SecondFloorElevatorName
        {
            get { return m_SecondFloorElevatorName; }
        }

        /// <summary>
        /// Gets the name of the sewing room.
        /// </summary>
        /// <value>The name of the sewing room.</value>
        public static string SewingRoomName
        {
            get { return m_SewingRoomName; }
        }

        /// <summary>
        /// Gets the name of the shovel.
        /// </summary>
        /// <value>The name of the shovel.</value>
        public static string ShovelName
        {
            get { return m_ShovelName; }
        }

        /// <summary>
        /// Gets the short name of the shovel.
        /// </summary>
        /// <value>The short name of the shovel.</value>
        public static string ShovelShortName
        {
            get { return m_ShovelShortName; }
        }

        /// <summary>
        /// Gets the name of the sitting room.
        /// </summary>
        /// <value>The name of the sitting room.</value>
        public static string SittingRoomName
        {
            get { return m_SittingRoomName; }
        }

        /// <summary>
        /// Gets the name of the stocks.
        /// </summary>
        /// <value>The name of the stocks.</value>
        public static string StocksName
        {
            get { return m_StocksName; }
        }

        /// <summary>
        /// Gets the name of the telephone booth.
        /// </summary>
        /// <value>The name of the telephone booth.</value>
        public static string TelephoneBoothName
        {
            get { return m_TelephoneBoothName; }
        }

        /// <summary>
        /// Gets the name of the third floor elevator.
        /// </summary>
        /// <value>The name of the third floor elevator.</value>
        public static string ThirdFloorElevatorName
        {
            get { return m_ThirdFloorElevatorName; }
        }

        /// <summary>
        /// Gets the name of the torture chamber.
        /// </summary>
        /// <value>The name of the torture chamber.</value>
        public static string TortureChamberName
        {
            get { return m_TortureChamberName; }
        }

        /// <summary>
        /// Gets the name of the trophy room.
        /// </summary>
        /// <value>The name of the trophy room.</value>
        public static string TrophyRoomName
        {
            get { return m_TrophyRoomName; }
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
        /// Gets the short name of the vampire.
        /// </summary>
        /// <value>The short name of the vampire.</value>
        public static string VampireShortName
        {
            get { return m_VampireShortName; }
        }

        /// <summary>
        /// Gets the name of the vase.
        /// </summary>
        /// <value>The name of the vase.</value>
        public static string VaseName
        {
            get { return m_VaseName; }
        }

        /// <summary>
        /// Gets the short name of the vase.
        /// </summary>
        /// <value>The short name of the vase.</value>
        public static string VaseShortName
        {
            get { return m_VaseShortName; }
        }

        /// <summary>
        /// Gets the name of the werewolf.
        /// </summary>
        /// <value>The name of the werewolf.</value>
        public static string WerewolfName
        {
            get { return m_WerewolfName; }
        }

        /// <summary>
        /// Gets the short name of the werewolf.
        /// </summary>
        /// <value>The short name of the werewolf.</value>
        public static string WerewolfShortName
        {
            get { return m_WerewolfShortName; }
        }

        /// <summary>
        /// Gets the name of the workshop.
        /// </summary>
        /// <value>The name of the workshop.</value>
        public static string WorkshopName
        {
            get { return m_WorkshopName; }
        }

		#endregion Properties 

    }
}
