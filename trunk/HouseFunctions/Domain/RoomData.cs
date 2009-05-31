using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    using System.Collections.ObjectModel;
    /// <summary>
    /// All data relating to rooms
    /// </summary>
    public static class RoomData
    {
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
        private readonly static ExitSetKeyedCollection exitsInventory = new ExitSetKeyedCollection(new RoomExit[0]);
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
        private readonly static LocationType locationInventory = new LocationType(-1, Floor.InHand);
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
        private const string m_BarroomName = "in the barroom";
        private const string m_BasementElevatorName = "in the basement elevator";
        private const string m_BathroomName = "in a bathroom";
        private const string m_BedroomName = "in a bedroom";
        private const string m_ClosetName = "in a closet";
        private const string m_CoalBinName = "in a dusty coal bin";
        private const string m_CoatClosetName = "in a coat closet";
        private const string m_ComputerRoomName = "in the computer-room";
        private const string m_DenName = "in the den";
        private const string m_DiningRoomName = "in the dining room";
        private const string m_DirtFlooredRoomName = "in a dirt-floored room";
        private const string m_FamilyRoomName = "in the family room";
        private const string m_FirstFloorElevatorName = "in the first floor elevator";
        private const string m_FoyerName = "in the foyer";
        private const string m_FreezerName = "in a walk-in freezer";
        private const string m_FrontPorchName = "on the front porch";
        private const string m_FurnaceRoomName = "in the furnace room";
        private const string m_GameRoomName = "in the game room";
        private const string m_GuestroomName = "in a guest room";
        private const string m_KitchenName = "in the kitchen";
        private const string m_LaboratoryName = "in the laboratory";
        private const string m_LibraryName = "in the library";
        private const string m_LivingRoomName = "in the living room";
        private const string m_MasterBedroomName = "in the master bedroom";
        private const string m_MonsterHangoutName = "in the monster hangout";
        private const string m_PantryName = "in the pantry";
        private const string m_PumpRoomName = "in the pumproom";
        private const string m_SecondFloorElevatorName = "in the second floor elevator";
        private const string m_SewingRoomName = "in the sewing room";
        private const string m_SittingRoomName = "in a sitting room";
        private const string m_TelephoneBoothName = "in a telephone booth";
        private const string m_ThirdFloorElevatorName = "in the third floor elevator";
        private const string m_TortureChamberName = "in the torture chamber";
        private const string m_TrophyRoomName = "in the trophy room";
        private const string m_WorkshopName = "in the workshop";
        private const string m_InventoryName = "in your inventory";

        /// <summary>
        /// Gets the exits for the basement coal bin.
        /// </summary>
        /// <value>The exits for the basement coal bin.</value>
        public static ExitSetKeyedCollection ExitsBasementCoalBin
        {
            get { return RoomData.exitsBasementCoalBin; }
        }

        /// <summary>
        /// Gets the exits for the basement dirt floored room.
        /// </summary>
        /// <value>The exits for the basement dirt floored room.</value>
        public static ExitSetKeyedCollection ExitsBasementDirtFlooredRoom
        {
            get { return RoomData.exitsBasementDirtFlooredRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement elevator.
        /// </summary>
        /// <value>The exits for the basement elevator.</value>
        public static ExitSetKeyedCollection ExitsBasementElevator
        {
            get { return RoomData.exitsBasementElevator; }
        }

        /// <summary>
        /// Gets the exits for the basement freezer.
        /// </summary>
        /// <value>The exits for the basement freezer.</value>
        public static ExitSetKeyedCollection ExitsBasementFreezer
        {
            get { return RoomData.exitsBasementFreezer; }
        }

        /// <summary>
        /// Gets the exits for the basement furnace room.
        /// </summary>
        /// <value>The exits for the basement furnace room.</value>
        public static ExitSetKeyedCollection ExitsBasementFurnaceRoom
        {
            get { return RoomData.exitsBasementFurnaceRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement laboratory.
        /// </summary>
        /// <value>The exits for the basement laboratory.</value>
        public static ExitSetKeyedCollection ExitsBasementLaboratory
        {
            get { return RoomData.exitsBasementLaboratory; }
        }

        /// <summary>
        /// Gets the exits for the basement pump room.
        /// </summary>
        /// <value>The exits for the basement pump room.</value>
        public static ExitSetKeyedCollection ExitsBasementPumpRoom
        {
            get { return RoomData.exitsBasementPumpRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement telephone booth.
        /// </summary>
        /// <value>The exits for the basement telephone booth.</value>
        public static ExitSetKeyedCollection ExitsBasementTelephoneBooth
        {
            get { return RoomData.exitsBasementTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the basement torture chamber.
        /// </summary>
        /// <value>The exits for the basement torture chamber.</value>
        public static ExitSetKeyedCollection ExitsBasementTortureChamber
        {
            get { return RoomData.exitsBasementTortureChamber; }
        }

        /// <summary>
        /// Gets the exits for the basement workshop.
        /// </summary>
        /// <value>The exits for the basement workshop.</value>
        public static ExitSetKeyedCollection ExitsBasementWorkshop
        {
            get { return RoomData.exitsBasementWorkshop; }
        }

        /// <summary>
        /// Gets the exits for the first floor bedroom.
        /// </summary>
        /// <value>The exits for the first floor bedroom.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorBedroom
        {
            get { return RoomData.exitsFirstFloorBedroom; }
        }

        /// <summary>
        /// Gets the exits for the first floor coat closet.
        /// </summary>
        /// <value>The exits for the first floor coat closet.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorCoatCloset
        {
            get { return RoomData.exitsFirstFloorCoatCloset; }
        }

        /// <summary>
        /// Gets the exits for the first floor dining room.
        /// </summary>
        /// <value>The exits for the first floor dining room.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorDiningRoom
        {
            get { return RoomData.exitsFirstFloorDiningRoom; }
        }

        /// <summary>
        /// Gets the exits for the first floor elevator.
        /// </summary>
        /// <value>The exits for the first floor elevator.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorElevator
        {
            get { return RoomData.exitsFirstFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the first floor family room.
        /// </summary>
        /// <value>The exits for the first floor family room.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorFamilyRoom
        {
            get { return RoomData.exitsFirstFloorFamilyRoom; }
        }

        /// <summary>
        /// Gets the exits for the first floor foyer.
        /// </summary>
        /// <value>The exits for the first floor foyer.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorFoyer
        {
            get { return RoomData.exitsFirstFloorFoyer; }
        }

        /// <summary>
        /// Gets the exits for the first floor front porch.
        /// </summary>
        /// <value>The exits for the first floor front porch.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorFrontPorch
        {
            get { return RoomData.exitsFirstFloorFrontPorch; }
        }

        /// <summary>
        /// Gets the exits for the first floor kitchen.
        /// </summary>
        /// <value>The exits for the first floor kitchen.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorKitchen
        {
            get { return RoomData.exitsFirstFloorKitchen; }
        }

        /// <summary>
        /// Gets the exits for the first floor pantry.
        /// </summary>
        /// <value>The exits for the first floor pantry.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorPantry
        {
            get { return RoomData.exitsFirstFloorPantry; }
        }

        /// <summary>
        /// Gets the exits for the first floor telephone booth.
        /// </summary>
        /// <value>The exits for the first floor telephone booth.</value>
        public static ExitSetKeyedCollection ExitsFirstFloorTelephoneBooth
        {
            get { return RoomData.exitsFirstFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits of the monster hangout.
        /// </summary>
        /// <value>The exits of the monster hangout.</value>
        public static ExitSetKeyedCollection ExitsMonsterHangout
        {
            get { return RoomData.exitsMonsterHangout; }
        }

        /// <summary>
        /// Gets the exits of the inventory room.
        /// </summary>
        /// <value>The exits of the inventory room.</value>
        public static ExitSetKeyedCollection ExitsInventory
        {
            get { return RoomData.exitsInventory; }
        }

        /// <summary>
        /// Gets the exits for the second floor bathroom.
        /// </summary>
        /// <value>The exits for the second floor bathroom.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorBathroom
        {
            get { return RoomData.exitsSecondFloorBathroom; }
        }

        /// <summary>
        /// Gets the exits for the second floor closet.
        /// </summary>
        /// <value>The exits for the second floor closet.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorCloset
        {
            get { return RoomData.exitsSecondFloorCloset; }
        }

        /// <summary>
        /// Gets the exits for the second floor den.
        /// </summary>
        /// <value>The exits for the second floor den.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorDen
        {
            get { return RoomData.exitsSecondFloorDen; }
        }

        /// <summary>
        /// Gets the exits for the second floor elevator.
        /// </summary>
        /// <value>The exits for the second floor elevator.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorElevator
        {
            get { return RoomData.exitsSecondFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the second floor guest room1.
        /// </summary>
        /// <value>The exits for the second floor guest room1.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorGuestroom1
        {
            get { return RoomData.exitsSecondFloorGuestroom1; }
        }

        /// <summary>
        /// Gets the exits for the second floor guest room2.
        /// </summary>
        /// <value>The exits for the second floor guest room2.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorGuestroom2
        {
            get { return RoomData.exitsSecondFloorGuestroom2; }
        }

        /// <summary>
        /// Gets the exits for the second floor master bedroom.
        /// </summary>
        /// <value>The exits for the second floor master bedroom.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorMasterBedroom
        {
            get { return RoomData.exitsSecondFloorMasterBedroom; }
        }

        /// <summary>
        /// Gets the exits for the second floor sewing room.
        /// </summary>
        /// <value>The exits for the second floor sewing room.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorSewingRoom
        {
            get { return RoomData.exitsSecondFloorSewingRoom; }
        }

        /// <summary>
        /// Gets the exits for the second floor sitting room.
        /// </summary>
        /// <value>The exits for the second floor sitting room.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorSittingRoom
        {
            get { return RoomData.exitsSecondFloorSittingRoom; }
        }

        /// <summary>
        /// Gets the exits for the second floor telephone booth.
        /// </summary>
        /// <value>The exits for the second floor telephone booth.</value>
        public static ExitSetKeyedCollection ExitsSecondFloorTelephoneBooth
        {
            get { return RoomData.exitsSecondFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the third floor art hall.
        /// </summary>
        /// <value>The exits for the third floor art hall.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorArtHall
        {
            get { return RoomData.exitsThirdFloorArtHall; }
        }

        /// <summary>
        /// Gets the exits for the third floor bar room.
        /// </summary>
        /// <value>The exits for the third floor bar room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorBarroom
        {
            get { return RoomData.exitsThirdFloorBarroom; }
        }

        /// <summary>
        /// Gets the exits for the third floor bedroom.
        /// </summary>
        /// <value>The exits for the third floor bedroom.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorBedroom
        {
            get { return RoomData.exitsThirdFloorBedroom; }
        }

        /// <summary>
        /// Gets the exits for the third floor computer room.
        /// </summary>
        /// <value>The exits for the third floor computer room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorComputerRoom
        {
            get { return RoomData.exitsThirdFloorComputerRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor elevator.
        /// </summary>
        /// <value>The exits for the third floor elevator.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorElevator
        {
            get { return RoomData.exitsThirdFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the third floor game room.
        /// </summary>
        /// <value>The exits for the third floor game room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorGameRoom
        {
            get { return RoomData.exitsThirdFloorGameRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor library.
        /// </summary>
        /// <value>The exits for the third floor library.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorLibrary
        {
            get { return RoomData.exitsThirdFloorLibrary; }
        }

        /// <summary>
        /// Gets the exits for the third floor living room.
        /// </summary>
        /// <value>The exits for the third floor living room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorLivingRoom
        {
            get { return RoomData.exitsThirdFloorLivingRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor telephone booth.
        /// </summary>
        /// <value>The exits for the third floor telephone booth.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorTelephoneBooth
        {
            get { return RoomData.exitsThirdFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the third floor trophy room.
        /// </summary>
        /// <value>The exits for the third floor trophy room.</value>
        public static ExitSetKeyedCollection ExitsThirdFloorTrophyRoom
        {
            get { return RoomData.exitsThirdFloorTrophyRoom; }
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
        /// Gets the name of the bedroom.
        /// </summary>
        /// <value>The name of the bedroom.</value>
        public static string BedroomName
        {
            get { return m_BedroomName; }
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
        /// Gets the name of the laboratory.
        /// </summary>
        /// <value>The name of the laboratory.</value>
        public static string LaboratoryName
        {
            get { return m_LaboratoryName; }
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
            get { return RoomData.locationBasementCoalBin; }
        }

        /// <summary>
        /// Gets the location of the basement dirt floored room.
        /// </summary>
        /// <value>The location of the basement dirt floored room.</value>
        public static LocationType LocationBasementDirtFlooredRoom
        {
            get { return RoomData.locationBasementDirtFlooredRoom; }
        }

        /// <summary>
        /// Gets the location of the basement elevator.
        /// </summary>
        /// <value>The location of the basement elevator.</value>
        public static LocationType LocationBasementElevator
        {
            get { return RoomData.locationBasementElevator; }
        }

        /// <summary>
        /// Gets the location of the basement freezer.
        /// </summary>
        /// <value>The location of the basement freezer.</value>
        public static LocationType LocationBasementFreezer
        {
            get { return RoomData.locationBasementFreezer; }
        }

        /// <summary>
        /// Gets the location of the basement furnace room.
        /// </summary>
        /// <value>The location of the basement furnace room.</value>
        public static LocationType LocationBasementFurnaceRoom
        {
            get { return RoomData.locationBasementFurnaceRoom; }
        }

        /// <summary>
        /// Gets the location of the basement laboratory.
        /// </summary>
        /// <value>The location of the basement laboratory.</value>
        public static LocationType LocationBasementLaboratory
        {
            get { return RoomData.locationBasementLaboratory; }
        }

        /// <summary>
        /// Gets the location of the basement pump room.
        /// </summary>
        /// <value>The location of the basement pump room.</value>
        public static LocationType LocationBasementPumpRoom
        {
            get { return RoomData.locationBasementPumpRoom; }
        }

        /// <summary>
        /// Gets the location of the basement telephone booth.
        /// </summary>
        /// <value>The location of the basement telephone booth.</value>
        public static LocationType LocationBasementTelephoneBooth
        {
            get { return RoomData.locationBasementTelephoneBooth; }
        }

        /// <summary>
        /// Gets the location of the basement torture chamber.
        /// </summary>
        /// <value>The location of the basement torture chamber.</value>
        public static LocationType LocationBasementTortureChamber
        {
            get { return RoomData.locationBasementTortureChamber; }
        }

        /// <summary>
        /// Gets the location of the basement workshop.
        /// </summary>
        /// <value>The location of the basement workshop.</value>
        public static LocationType LocationBasementWorkshop
        {
            get { return RoomData.locationBasementWorkshop; }
        }

        /// <summary>
        /// Gets the location of the first floor bedroom.
        /// </summary>
        /// <value>The location of the first floor bedroom.</value>
        public static LocationType LocationFirstFloorBedroom
        {
            get { return RoomData.locationFirstFloorBedroom; }
        }

        /// <summary>
        /// Gets the location of the first floor coat closet.
        /// </summary>
        /// <value>The location of the first floor coat closet.</value>
        public static LocationType LocationFirstFloorCoatCloset
        {
            get { return RoomData.locationFirstFloorCoatCloset; }
        }

        /// <summary>
        /// Gets the location of the first floor dining room.
        /// </summary>
        /// <value>The location of the first floor dining room.</value>
        public static LocationType LocationFirstFloorDiningRoom
        {
            get { return RoomData.locationFirstFloorDiningRoom; }
        }

        /// <summary>
        /// Gets the location of the first floor elevator.
        /// </summary>
        /// <value>The location of the first floor elevator.</value>
        public static LocationType LocationFirstFloorElevator
        {
            get { return RoomData.locationFirstFloorElevator; }
        }

        /// <summary>
        /// Gets the location of the first floor family room.
        /// </summary>
        /// <value>The location of the first floor family room.</value>
        public static LocationType LocationFirstFloorFamilyRoom
        {
            get { return RoomData.locationFirstFloorFamilyRoom; }
        }

        /// <summary>
        /// Gets the location of the first floor foyer.
        /// </summary>
        /// <value>The location of the first floor foyer.</value>
        public static LocationType LocationFirstFloorFoyer
        {
            get { return RoomData.locationFirstFloorFoyer; }
        }

        /// <summary>
        /// Gets the location of the first floor front porch.
        /// </summary>
        /// <value>The location of the first floor front porch.</value>
        public static LocationType LocationFirstFloorFrontPorch
        {
            get { return RoomData.locationFirstFloorFrontPorch; }
        }

        /// <summary>
        /// Gets the location of the first floor kitchen.
        /// </summary>
        /// <value>The location of the first floor kitchen.</value>
        public static LocationType LocationFirstFloorKitchen
        {
            get { return RoomData.locationFirstFloorKitchen; }
        }

        /// <summary>
        /// Gets the location of the first floor pantry.
        /// </summary>
        /// <value>The location of the first floor pantry.</value>
        public static LocationType LocationFirstFloorPantry
        {
            get { return RoomData.locationFirstFloorPantry; }
        }

        /// <summary>
        /// Gets the location of the first floor telephone booth.
        /// </summary>
        /// <value>The location of the first floor telephone booth.</value>
        public static LocationType LocationFirstFloorTelephoneBooth
        {
            get { return RoomData.locationFirstFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the location of the monster hangout.
        /// </summary>
        /// <value>The location of the monster hangout.</value>
        public static LocationType LocationMonsterHangout
        {
            get { return RoomData.locationMonsterHangout; }
        }

        /// <summary>
        /// Gets the location of the inventory.
        /// </summary>
        /// <value>The location of the inventory.</value>
        public static LocationType LocationInventory
        {
            get { return RoomData.locationInventory; }
        }

        /// <summary>
        /// Gets the location of the second floor bathroom.
        /// </summary>
        /// <value>The location of the second floor bathroom.</value>
        public static LocationType LocationSecondFloorBathroom
        {
            get { return RoomData.locationSecondFloorBathroom; }
        }

        /// <summary>
        /// Gets the location of the second floor closet.
        /// </summary>
        /// <value>The location of the second floor closet.</value>
        public static LocationType LocationSecondFloorCloset
        {
            get { return RoomData.locationSecondFloorCloset; }
        }

        /// <summary>
        /// Gets the location of the second floor den.
        /// </summary>
        /// <value>The location of the second floor den.</value>
        public static LocationType LocationSecondFloorDen
        {
            get { return RoomData.locationSecondFloorDen; }
        }

        /// <summary>
        /// Gets the location of the second floor elevator.
        /// </summary>
        /// <value>The location of the second floor elevator.</value>
        public static LocationType LocationSecondFloorElevator
        {
            get { return RoomData.locationSecondFloorElevator; }
        }

        /// <summary>
        /// Gets the location of the second floor guest room1.
        /// </summary>
        /// <value>The location of the second floor guest room1.</value>
        public static LocationType LocationSecondFloorGuestroom1
        {
            get { return RoomData.locationSecondFloorGuestroom1; }
        }

        /// <summary>
        /// Gets the location of the second floor guest room2.
        /// </summary>
        /// <value>The location of the second floor guest room2.</value>
        public static LocationType LocationSecondFloorGuestroom2
        {
            get { return RoomData.locationSecondFloorGuestroom2; }
        }

        /// <summary>
        /// Gets the location of the second floor master bedroom.
        /// </summary>
        /// <value>The location of the second floor master bedroom.</value>
        public static LocationType LocationSecondFloorMasterBedroom
        {
            get { return RoomData.locationSecondFloorMasterBedroom; }
        }

        /// <summary>
        /// Gets the location of the second floor sewing room.
        /// </summary>
        /// <value>The location of the second floor sewing room.</value>
        public static LocationType LocationSecondFloorSewingRoom
        {
            get { return RoomData.locationSecondFloorSewingRoom; }
        }

        /// <summary>
        /// Gets the location of the second floor sitting room.
        /// </summary>
        /// <value>The location of the second floor sitting room.</value>
        public static LocationType LocationSecondFloorSittingRoom
        {
            get { return RoomData.locationSecondFloorSittingRoom; }
        }

        /// <summary>
        /// Gets the location of the second floor telephone booth.
        /// </summary>
        /// <value>The location of the second floor telephone booth.</value>
        public static LocationType LocationSecondFloorTelephoneBooth
        {
            get { return RoomData.locationSecondFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the location of the third floor art hall.
        /// </summary>
        /// <value>The location of the third floor art hall.</value>
        public static LocationType LocationThirdFloorArtHall
        {
            get { return RoomData.locationThirdFloorArtHall; }
        }

        /// <summary>
        /// Gets the location of the third floor bar room.
        /// </summary>
        /// <value>The location of the third floor bar room.</value>
        public static LocationType LocationThirdFloorBarroom
        {
            get { return RoomData.locationThirdFloorBarroom; }
        }

        /// <summary>
        /// Gets the location of the third floor bedroom.
        /// </summary>
        /// <value>The location of the third floor bedroom.</value>
        public static LocationType LocationThirdFloorBedroom
        {
            get { return RoomData.locationThirdFloorBedroom; }
        }

        /// <summary>
        /// Gets the location of the third floor computer room.
        /// </summary>
        /// <value>The location of the third floor computer room.</value>
        public static LocationType LocationThirdFloorComputerRoom
        {
            get { return RoomData.locationThirdFloorComputerRoom; }
        }

        /// <summary>
        /// Gets the location of the third floor elevator.
        /// </summary>
        /// <value>The location of the third floor elevator.</value>
        public static LocationType LocationThirdFloorElevator
        {
            get { return RoomData.locationThirdFloorElevator; }
        }

        /// <summary>
        /// Gets the location of the third floor game room.
        /// </summary>
        /// <value>The location of the third floor game room.</value>
        public static LocationType LocationThirdFloorGameRoom
        {
            get { return RoomData.locationThirdFloorGameRoom; }
        }

        /// <summary>
        /// Gets the location of the third floor library.
        /// </summary>
        /// <value>The location of the third floor library.</value>
        public static LocationType LocationThirdFloorLibrary
        {
            get { return RoomData.locationThirdFloorLibrary; }
        }

        /// <summary>
        /// Gets the location of the third floor living room.
        /// </summary>
        /// <value>The location of the third floor living room.</value>
        public static LocationType LocationThirdFloorLivingRoom
        {
            get { return RoomData.locationThirdFloorLivingRoom; }
        }

        /// <summary>
        /// Gets the location of the third floor telephone booth.
        /// </summary>
        /// <value>The location of the third floor telephone booth.</value>
        public static LocationType LocationThirdFloorTelephoneBooth
        {
            get { return RoomData.locationThirdFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the location of the third floor trophy room.
        /// </summary>
        /// <value>The location of the third floor trophy room.</value>
        public static LocationType LocationThirdFloorTrophyRoom
        {
            get { return RoomData.locationThirdFloorTrophyRoom; }
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
        /// Gets the name of the monster hangout.
        /// </summary>
        /// <value>The name of the monster hangout.</value>
        public static string MonsterHangoutName
        {
            get { return m_MonsterHangoutName; }
        }

        /// <summary>
        /// Gets the name of the inventory.
        /// </summary>
        /// <value>The name of the inventory.</value>
        public static string InventoryName
        {
            get { return m_InventoryName; }
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
        /// Gets the name of the pump room.
        /// </summary>
        /// <value>The name of the pump room.</value>
        public static string PumpRoomName
        {
            get { return m_PumpRoomName; }
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
        /// Gets the name of the sitting room.
        /// </summary>
        /// <value>The name of the sitting room.</value>
        public static string SittingRoomName
        {
            get { return m_SittingRoomName; }
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
        /// Gets the name of the workshop.
        /// </summary>
        /// <value>The name of the workshop.</value>
        public static string WorkshopName
        {
            get { return m_WorkshopName; }
        }
    }
}
