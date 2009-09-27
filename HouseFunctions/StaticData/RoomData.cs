//-----------------------------------------------------------------------
// <copyright file="RoomData.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// All data relating to rooms
    /// </summary>
    public sealed class RoomData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomData"/> class.
        /// </summary>
        private RoomData()
        {
        }

        private static Random random = new Random();
        private readonly static ReadOnlyRoomInfoCollection rooms2 = new ReadOnlyRoomInfoCollection(InitializeRooms());

        /// <summary>
        /// Gets the magic rooms.
        /// </summary>
        /// <value>The magic rooms.</value>
        public static ReadOnlyRoomInfoCollection MagicRooms
        {
            get
            {
                List<RoomInfo> result = new List<RoomInfo>();
                foreach (RoomInfo roomInfo in rooms2)
                    if (roomInfo.Magic)
                        result.Add(roomInfo);

                return new ReadOnlyRoomInfoCollection(result);
            }
        }

        private static List<RoomInfo> InitializeRooms()
        {
            List<RoomInfo> result = new List<RoomInfo>();
            result.Add(new UnfinishedFlooredRoomInfo("in a dirt-floored room", 0, Floor.Basement, new RoomExit[] { new RoomExit(Direction.West, 7), new RoomExit(Direction.South, 1) }));
            result.Add(new NormalRoomInfo("in the laboratory", 1, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 0), new RoomExit(Direction.East, 2) }));
            result.Add(new NormalRoomInfo("in the pumproom", 2, Floor.Basement, new RoomExit[] { new RoomExit(Direction.West, 1), new RoomExit(Direction.South, 3) }));
            result.Add(new NormalRoomInfo("in the furnace room", 3, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.East, 4), new RoomExit(Direction.South, 9) }));
            result.Add(new NormalRoomInfo("in a dusty coal bin", 4, Floor.Basement, new RoomExit[] { new RoomExit(Direction.East, 6), new RoomExit(Direction.West, 3) }));
            result.Add(new NormalRoomInfo("in the torture chamber", 5, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.South, 6) }));
            result.Add(new NormalRoomInfo("in the workshop", 6, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.East, 7), new RoomExit(Direction.West, 4) }));
            result.Add(new NormalRoomInfo("in a walk-in freezer", 7, Floor.Basement, new RoomExit[] { new RoomExit(Direction.East, 0), new RoomExit(Direction.West, 6) }));
#if (DEBUG)
            MagicWord word = MagicWord.Seersucker;
#else
            MagicWord word = (MagicWord)RoomData.random.Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1;
#endif
            result.Add(new TelephoneBoothInfo("in a telephone booth", 8, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.South, 5) }, word));
            result.Add(new ElevatorInfo("in the basement elevator", 9, Floor.Basement, new RoomExit[] { new RoomExit(Direction.North, 3), new RoomExit(Direction.South, 8) }, Floor.FirstFloor, Floor.Undefined));

            result.Add(new NormalRoomInfo("on the front porch", 0, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 1) }));
            result.Add(new NormalRoomInfo("in the foyer", 1, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.East, 7), new RoomExit(Direction.West, 3) }));
            result.Add(new NormalRoomInfo("in a bedroom", 2, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.East, 5), new RoomExit(Direction.South, 7) }));
            result.Add(new NormalRoomInfo("in a coat closet", 3, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.East, 1), new RoomExit(Direction.West, 9) }));
#if (DEBUG)
            word = MagicWord.Seersucker;
#else
            word = (MagicWord)RoomData.random.Next(Enum.GetNames(typeof(MagicWord)).Length - 1) + 1;
#endif
            result.Add(new NormalRoomInfo("in the dining room", 4, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 7), new RoomExit(Direction.East, 9) }, word));
            result.Add(new NormalRoomInfo("in the pantry", 5, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.West, 2), new RoomExit(Direction.South, 6) }));
            result.Add(new NormalRoomInfo("in the kitchen", 6, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.South, 9) }));
            result.Add(new NormalRoomInfo("in the family room", 7, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.West, 1), new RoomExit(Direction.South, 4) }));
            result.Add(new TelephoneBoothInfo("in a telephone booth", 8, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.South, 5) }));
            result.Add(new ElevatorInfo("in the first floor elevator", 9, Floor.FirstFloor, new RoomExit[] { new RoomExit(Direction.North, 6), new RoomExit(Direction.East, 3), new RoomExit(Direction.West, 4)}, Floor.SecondFloor, Floor.Basement));

            result.Add(new NormalRoomInfo("in the sewing room", 0, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.East, 9), new RoomExit(Direction.South, 1) }));
            result.Add(new NormalRoomInfo("in a closet", 1, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 0), new RoomExit(Direction.South, 3) }));
            result.Add(new NormalRoomInfo("in the master bedroom", 2, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.South, 4) }));
            result.Add(new NormalRoomInfo("in a guest room", 3, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 1), new RoomExit(Direction.East, 4), new RoomExit(Direction.West, 5) }));
            result.Add(new NormalRoomInfo("in a bathroom", 4, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.East, 5), new RoomExit(Direction.West, 3), new RoomExit(Direction.South, 6) }));
            result.Add(new NormalRoomInfo("in a guest room", 5, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.East, 3), new RoomExit(Direction.West, 4) }));
            result.Add(new NormalRoomInfo("in a sitting room", 6, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.South, 7) }));
            result.Add(new NormalRoomInfo("in the den", 7, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 6), new RoomExit(Direction.West, 8) }));
            result.Add(new TelephoneBoothInfo("in a telephone booth", 8, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.South, 7) }));
            result.Add(new ElevatorInfo("in the second floor elevator", 9, Floor.SecondFloor, new RoomExit[] { new RoomExit(Direction.West, 0), new RoomExit(Direction.South, 2)}, Floor.ThirdFloor, Floor.FirstFloor));

            result.Add(new NormalRoomInfo("in the living room", 0, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.East, 2) }));
            result.Add(new NormalRoomInfo("in the library", 1, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.West, 9), new RoomExit(Direction.South, 2) }));
            result.Add(new NormalRoomInfo("in the trophy room", 2, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 1), new RoomExit(Direction.West, 0) }));
            result.Add(new NormalRoomInfo("in the barroom", 3, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.East, 5), new RoomExit(Direction.West, 8) }));
            result.Add(new NormalRoomInfo("in the computer-room", 4, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.South, 5) }));
            result.Add(new NormalRoomInfo("in the game room", 5, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.West, 3), new RoomExit(Direction.South, 7) }));
            result.Add(new NormalRoomInfo("in a bedroom", 6, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.East, 7) }));
            result.Add(new NormalRoomInfo("in the art hall", 7, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.West, 6) }));
            result.Add(new TelephoneBoothInfo("in a telephone booth", 8, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.East, 3), new RoomExit(Direction.South, 4) }));
            result.Add(new ElevatorInfo("in the third floor elevator", 9, Floor.ThirdFloor, new RoomExit[] { new RoomExit(Direction.East, 1), new RoomExit(Direction.South, 0)}, Floor.Undefined, Floor.SecondFloor));

            result.Add(new NormalRoomInfo("in the monster hangout", 0, Floor.MonsterHangout, new RoomExit[0]));

            result.Add(new NormalRoomInfo("in your inventory", 0, Floor.InHand, new RoomExit[0]));

            return result;
        }

        //TODO:  Split this class into a few classes
        private static ReadOnlyExitSetCollection exitsBasementCoalBin = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 6), new RoomExit(Direction.West, 3) });
        private static ReadOnlyExitSetCollection exitsBasementDirtFlooredRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.West, 7), new RoomExit(Direction.South, 1) });
        private static ReadOnlyExitSetCollection exitsBasementElevator = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 3), new RoomExit(Direction.South, 8) });
        private static ReadOnlyExitSetCollection exitsBasementFreezer = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 0), new RoomExit(Direction.West, 6) });
        private static ReadOnlyExitSetCollection exitsBasementFurnaceRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.East, 4), new RoomExit(Direction.South, 9) });
        private static ReadOnlyExitSetCollection exitsBasementLaboratory = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 0), new RoomExit(Direction.East, 2) });
        private static ReadOnlyExitSetCollection exitsBasementPumpRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.West, 1), new RoomExit(Direction.South, 3) });
        private static ReadOnlyExitSetCollection exitsBasementTelephoneBooth = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.South, 5) });
        private static ReadOnlyExitSetCollection exitsBasementTortureChamber = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.South, 6) });
        private static ReadOnlyExitSetCollection exitsBasementWorkshop = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.East, 7), new RoomExit(Direction.West, 4) });
        private static ReadOnlyExitSetCollection exitsFirstFloorBedroom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 5), new RoomExit(Direction.South, 7) });
        private static ReadOnlyExitSetCollection exitsFirstFloorCoatCloset = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 1), new RoomExit(Direction.West, 9) });
        private static ReadOnlyExitSetCollection exitsFirstFloorDiningRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 7), new RoomExit(Direction.East, 9) });
        private static ReadOnlyExitSetCollection exitsFirstFloorElevator = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 6), new RoomExit(Direction.East, 3), new RoomExit(Direction.West, 4) });
        private static ReadOnlyExitSetCollection exitsFirstFloorFamilyRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.West, 1), new RoomExit(Direction.South, 4) });
        private static ReadOnlyExitSetCollection exitsFirstFloorFoyer = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 7), new RoomExit(Direction.West, 3) });
        private static ReadOnlyExitSetCollection exitsFirstFloorFrontPorch = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 1) });
        private static ReadOnlyExitSetCollection exitsFirstFloorKitchen = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.South, 9) });
        private static ReadOnlyExitSetCollection exitsFirstFloorPantry = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.West, 2), new RoomExit(Direction.South, 6) });
        private static ReadOnlyExitSetCollection exitsFirstFloorTelephoneBooth = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.South, 5) });
        private static ReadOnlyExitSetCollection exitsMonsterHangout = new ReadOnlyExitSetCollection(new RoomExit[0]);
        private static ReadOnlyExitSetCollection exitsInventory = new ReadOnlyExitSetCollection(new RoomExit[0]);
        private static ReadOnlyExitSetCollection exitsSecondFloorBathroom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 2), new RoomExit(Direction.East, 5), new RoomExit(Direction.West, 3), new RoomExit(Direction.South, 6) });
        private static ReadOnlyExitSetCollection exitsSecondFloorCloset = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 0), new RoomExit(Direction.South, 3) });
        private static ReadOnlyExitSetCollection exitsSecondFloorDen = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 6), new RoomExit(Direction.West, 8) });
        private static ReadOnlyExitSetCollection exitsSecondFloorElevator = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.West, 0), new RoomExit(Direction.South, 2) });
        private static ReadOnlyExitSetCollection exitsSecondFloorGuestroom1 = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 1), new RoomExit(Direction.East, 4), new RoomExit(Direction.West, 5) });
        private static ReadOnlyExitSetCollection exitsSecondFloorGuestroom2 = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 3), new RoomExit(Direction.West, 4) });
        private static ReadOnlyExitSetCollection exitsSecondFloorMasterBedroom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.South, 4) });
        private static ReadOnlyExitSetCollection exitsSecondFloorSewingRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 9), new RoomExit(Direction.South, 1) });
        private static ReadOnlyExitSetCollection exitsSecondFloorSittingRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.South, 7) });
        private static ReadOnlyExitSetCollection exitsSecondFloorTelephoneBooth = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 7) });
        private static ReadOnlyExitSetCollection exitsThirdFloorArtHall = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 5), new RoomExit(Direction.West, 6) });
        private static ReadOnlyExitSetCollection exitsThirdFloorBarroom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 5), new RoomExit(Direction.West, 8) });
        private static ReadOnlyExitSetCollection exitsThirdFloorBedroom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 7) });
        private static ReadOnlyExitSetCollection exitsThirdFloorComputerRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 8), new RoomExit(Direction.South, 5) });
        private static ReadOnlyExitSetCollection exitsThirdFloorElevator = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 1), new RoomExit(Direction.South, 0) });
        private static ReadOnlyExitSetCollection exitsThirdFloorGameRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 4), new RoomExit(Direction.West, 3), new RoomExit(Direction.South, 7) });
        private static ReadOnlyExitSetCollection exitsThirdFloorLibrary = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.West, 9), new RoomExit(Direction.South, 2) });
        private static ReadOnlyExitSetCollection exitsThirdFloorLivingRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 9), new RoomExit(Direction.East, 2) });
        private static ReadOnlyExitSetCollection exitsThirdFloorTelephoneBooth = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.East, 3), new RoomExit(Direction.South, 4) });
        private static ReadOnlyExitSetCollection exitsThirdFloorTrophyRoom = new ReadOnlyExitSetCollection(new RoomExit[] { new RoomExit(Direction.North, 1), new RoomExit(Direction.West, 0) });

        private readonly static LocationType locationBasementDirtFlooredRoom = new LocationType(0, Floor.Basement);
        private readonly static LocationType locationBasementLaboratory = new LocationType(1, Floor.Basement);
        private readonly static LocationType locationBasementPumpRoom = new LocationType(2, Floor.Basement);
        private readonly static LocationType locationBasementFurnaceRoom = new LocationType(3, Floor.Basement);
        private readonly static LocationType locationBasementCoalBin = new LocationType(4, Floor.Basement);
        private readonly static LocationType locationBasementTortureChamber = new LocationType(5, Floor.Basement);
        private readonly static LocationType locationBasementWorkshop = new LocationType(6, Floor.Basement);
        private readonly static LocationType locationBasementFreezer = new LocationType(7, Floor.Basement);
        private readonly static LocationType locationBasementTelephoneBooth = new LocationType(8, Floor.Basement);
        private readonly static LocationType locationBasementElevator = new LocationType(9, Floor.Basement);

        private readonly static LocationType locationFirstFloorFrontPorch = new LocationType(0, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorFoyer = new LocationType(1, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorBedroom = new LocationType(2, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorCoatCloset = new LocationType(3, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorDiningRoom = new LocationType(4, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorPantry = new LocationType(5, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorKitchen = new LocationType(6, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorFamilyRoom = new LocationType(7, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorTelephoneBooth = new LocationType(8, Floor.FirstFloor);
        private readonly static LocationType locationFirstFloorElevator = new LocationType(9, Floor.FirstFloor);

        private readonly static LocationType locationMonsterHangout = new LocationType(0, Floor.MonsterHangout);

        private readonly static LocationType locationInventory = new LocationType(0, Floor.InHand);

        private readonly static LocationType locationSecondFloorSewingRoom = new LocationType(0, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorCloset = new LocationType(1, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorMasterBedroom = new LocationType(2, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorGuestroom1 = new LocationType(3, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorBathroom = new LocationType(4, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorGuestroom2 = new LocationType(5, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorSittingRoom = new LocationType(6, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorDen = new LocationType(7, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorTelephoneBooth = new LocationType(8, Floor.SecondFloor);
        private readonly static LocationType locationSecondFloorElevator = new LocationType(9, Floor.SecondFloor);

        private readonly static LocationType locationThirdFloorLivingRoom = new LocationType(0, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorLibrary = new LocationType(1, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorTrophyRoom = new LocationType(2, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorBarroom = new LocationType(3, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorComputerRoom = new LocationType(4, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorGameRoom = new LocationType(5, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorBedroom = new LocationType(6, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorArtHall = new LocationType(7, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorTelephoneBooth = new LocationType(8, Floor.ThirdFloor);
        private readonly static LocationType locationThirdFloorElevator = new LocationType(9, Floor.ThirdFloor);

        private const string artHallName = "in the art hall";
        private const string barroomName = "in the barroom";
        private const string basementElevatorName = "in the basement elevator";
        private const string bathroomName = "in a bathroom";
        private const string bedroomName = "in a bedroom";
        private const string closetName = "in a closet";
        private const string coalBinName = "in a dusty coal bin";
        private const string coatClosetName = "in a coat closet";
        private const string computerRoomName = "in the computer-room";
        private const string denName = "in the den";
        private const string diningRoomName = "in the dining room";
        private const string dirtFlooredRoomName = "in a dirt-floored room";
        private const string familyRoomName = "in the family room";
        private const string firstFloorElevatorName = "in the first floor elevator";
        private const string foyerName = "in the foyer";
        private const string freezerName = "in a walk-in freezer";
        private const string frontPorchName = "on the front porch";
        private const string furnaceRoomName = "in the furnace room";
        private const string gameRoomName = "in the game room";
        private const string guestroomName = "in a guest room";
        private const string kitchenName = "in the kitchen";
        private const string laboratoryName = "in the laboratory";
        private const string libraryName = "in the library";
        private const string livingRoomName = "in the living room";
        private const string masterBedroomName = "in the master bedroom";
        private const string monsterHangoutName = "in the monster hangout";
        private const string pantryName = "in the pantry";
        private const string pumpRoomName = "in the pumproom";
        private const string secondFloorElevatorName = "in the second floor elevator";
        private const string sewingRoomName = "in the sewing room";
        private const string sittingRoomName = "in a sitting room";
        private const string telephoneBoothName = "in a telephone booth";
        private const string thirdFloorElevatorName = "in the third floor elevator";
        private const string tortureChamberName = "in the torture chamber";
        private const string trophyRoomName = "in the trophy room";
        private const string workshopName = "in the workshop";
        private const string inventoryName = "in your inventory";

        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <value>The rooms.</value>
        public static ReadOnlyRoomInfoCollection Rooms
        {
            get { return RoomData.rooms2; }
        }

        /// <summary>
        /// Gets the exits for the basement coal bin.
        /// </summary>
        /// <value>The exits for the basement coal bin.</value>
        public static ReadOnlyExitSetCollection ExitsBasementCoalBin
        {
            get { return RoomData.exitsBasementCoalBin; }
        }

        /// <summary>
        /// Gets the exits for the basement dirt floored room.
        /// </summary>
        /// <value>The exits for the basement dirt floored room.</value>
        public static ReadOnlyExitSetCollection ExitsBasementDirtFlooredRoom
        {
            get { return RoomData.exitsBasementDirtFlooredRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement elevator.
        /// </summary>
        /// <value>The exits for the basement elevator.</value>
        public static ReadOnlyExitSetCollection ExitsBasementElevator
        {
            get { return RoomData.exitsBasementElevator; }
        }

        /// <summary>
        /// Gets the exits for the basement freezer.
        /// </summary>
        /// <value>The exits for the basement freezer.</value>
        public static ReadOnlyExitSetCollection ExitsBasementFreezer
        {
            get { return RoomData.exitsBasementFreezer; }
        }

        /// <summary>
        /// Gets the exits for the basement furnace room.
        /// </summary>
        /// <value>The exits for the basement furnace room.</value>
        public static ReadOnlyExitSetCollection ExitsBasementFurnaceRoom
        {
            get { return RoomData.exitsBasementFurnaceRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement laboratory.
        /// </summary>
        /// <value>The exits for the basement laboratory.</value>
        public static ReadOnlyExitSetCollection ExitsBasementLaboratory
        {
            get { return RoomData.exitsBasementLaboratory; }
        }

        /// <summary>
        /// Gets the exits for the basement pump room.
        /// </summary>
        /// <value>The exits for the basement pump room.</value>
        public static ReadOnlyExitSetCollection ExitsBasementPumpRoom
        {
            get { return RoomData.exitsBasementPumpRoom; }
        }

        /// <summary>
        /// Gets the exits for the basement telephone booth.
        /// </summary>
        /// <value>The exits for the basement telephone booth.</value>
        public static ReadOnlyExitSetCollection ExitsBasementTelephoneBooth
        {
            get { return RoomData.exitsBasementTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the basement torture chamber.
        /// </summary>
        /// <value>The exits for the basement torture chamber.</value>
        public static ReadOnlyExitSetCollection ExitsBasementTortureChamber
        {
            get { return RoomData.exitsBasementTortureChamber; }
        }

        /// <summary>
        /// Gets the exits for the basement workshop.
        /// </summary>
        /// <value>The exits for the basement workshop.</value>
        public static ReadOnlyExitSetCollection ExitsBasementWorkshop
        {
            get { return RoomData.exitsBasementWorkshop; }
        }

        /// <summary>
        /// Gets the exits for the first floor bedroom.
        /// </summary>
        /// <value>The exits for the first floor bedroom.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorBedroom
        {
            get { return RoomData.exitsFirstFloorBedroom; }
        }

        /// <summary>
        /// Gets the exits for the first floor coat closet.
        /// </summary>
        /// <value>The exits for the first floor coat closet.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorCoatCloset
        {
            get { return RoomData.exitsFirstFloorCoatCloset; }
        }

        /// <summary>
        /// Gets the exits for the first floor dining room.
        /// </summary>
        /// <value>The exits for the first floor dining room.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorDiningRoom
        {
            get { return RoomData.exitsFirstFloorDiningRoom; }
        }

        /// <summary>
        /// Gets the exits for the first floor elevator.
        /// </summary>
        /// <value>The exits for the first floor elevator.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorElevator
        {
            get { return RoomData.exitsFirstFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the first floor family room.
        /// </summary>
        /// <value>The exits for the first floor family room.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorFamilyRoom
        {
            get { return RoomData.exitsFirstFloorFamilyRoom; }
        }

        /// <summary>
        /// Gets the exits for the first floor foyer.
        /// </summary>
        /// <value>The exits for the first floor foyer.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorFoyer
        {
            get { return RoomData.exitsFirstFloorFoyer; }
        }

        /// <summary>
        /// Gets the exits for the first floor front porch.
        /// </summary>
        /// <value>The exits for the first floor front porch.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorFrontPorch
        {
            get { return RoomData.exitsFirstFloorFrontPorch; }
        }

        /// <summary>
        /// Gets the exits for the first floor kitchen.
        /// </summary>
        /// <value>The exits for the first floor kitchen.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorKitchen
        {
            get { return RoomData.exitsFirstFloorKitchen; }
        }

        /// <summary>
        /// Gets the exits for the first floor pantry.
        /// </summary>
        /// <value>The exits for the first floor pantry.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorPantry
        {
            get { return RoomData.exitsFirstFloorPantry; }
        }

        /// <summary>
        /// Gets the exits for the first floor telephone booth.
        /// </summary>
        /// <value>The exits for the first floor telephone booth.</value>
        public static ReadOnlyExitSetCollection ExitsFirstFloorTelephoneBooth
        {
            get { return RoomData.exitsFirstFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits of the monster hangout.
        /// </summary>
        /// <value>The exits of the monster hangout.</value>
        public static ReadOnlyExitSetCollection ExitsMonsterHangout
        {
            get { return RoomData.exitsMonsterHangout; }
        }

        /// <summary>
        /// Gets the exits of the inventory room.
        /// </summary>
        /// <value>The exits of the inventory room.</value>
        public static ReadOnlyExitSetCollection ExitsInventory
        {
            get { return RoomData.exitsInventory; }
        }

        /// <summary>
        /// Gets the exits for the second floor bathroom.
        /// </summary>
        /// <value>The exits for the second floor bathroom.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorBathroom
        {
            get { return RoomData.exitsSecondFloorBathroom; }
        }

        /// <summary>
        /// Gets the exits for the second floor closet.
        /// </summary>
        /// <value>The exits for the second floor closet.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorCloset
        {
            get { return RoomData.exitsSecondFloorCloset; }
        }

        /// <summary>
        /// Gets the exits for the second floor den.
        /// </summary>
        /// <value>The exits for the second floor den.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorDen
        {
            get { return RoomData.exitsSecondFloorDen; }
        }

        /// <summary>
        /// Gets the exits for the second floor elevator.
        /// </summary>
        /// <value>The exits for the second floor elevator.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorElevator
        {
            get { return RoomData.exitsSecondFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the second floor guest room1.
        /// </summary>
        /// <value>The exits for the second floor guest room1.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorGuestroom1
        {
            get { return RoomData.exitsSecondFloorGuestroom1; }
        }

        /// <summary>
        /// Gets the exits for the second floor guest room2.
        /// </summary>
        /// <value>The exits for the second floor guest room2.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorGuestroom2
        {
            get { return RoomData.exitsSecondFloorGuestroom2; }
        }

        /// <summary>
        /// Gets the exits for the second floor master bedroom.
        /// </summary>
        /// <value>The exits for the second floor master bedroom.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorMasterBedroom
        {
            get { return RoomData.exitsSecondFloorMasterBedroom; }
        }

        /// <summary>
        /// Gets the exits for the second floor sewing room.
        /// </summary>
        /// <value>The exits for the second floor sewing room.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorSewingRoom
        {
            get { return RoomData.exitsSecondFloorSewingRoom; }
        }

        /// <summary>
        /// Gets the exits for the second floor sitting room.
        /// </summary>
        /// <value>The exits for the second floor sitting room.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorSittingRoom
        {
            get { return RoomData.exitsSecondFloorSittingRoom; }
        }

        /// <summary>
        /// Gets the exits for the second floor telephone booth.
        /// </summary>
        /// <value>The exits for the second floor telephone booth.</value>
        public static ReadOnlyExitSetCollection ExitsSecondFloorTelephoneBooth
        {
            get { return RoomData.exitsSecondFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the third floor art hall.
        /// </summary>
        /// <value>The exits for the third floor art hall.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorArtHall
        {
            get { return RoomData.exitsThirdFloorArtHall; }
        }

        /// <summary>
        /// Gets the exits for the third floor bar room.
        /// </summary>
        /// <value>The exits for the third floor bar room.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorBarroom
        {
            get { return RoomData.exitsThirdFloorBarroom; }
        }

        /// <summary>
        /// Gets the exits for the third floor bedroom.
        /// </summary>
        /// <value>The exits for the third floor bedroom.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorBedroom
        {
            get { return RoomData.exitsThirdFloorBedroom; }
        }

        /// <summary>
        /// Gets the exits for the third floor computer room.
        /// </summary>
        /// <value>The exits for the third floor computer room.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorComputerRoom
        {
            get { return RoomData.exitsThirdFloorComputerRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor elevator.
        /// </summary>
        /// <value>The exits for the third floor elevator.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorElevator
        {
            get { return RoomData.exitsThirdFloorElevator; }
        }

        /// <summary>
        /// Gets the exits for the third floor game room.
        /// </summary>
        /// <value>The exits for the third floor game room.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorGameRoom
        {
            get { return RoomData.exitsThirdFloorGameRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor library.
        /// </summary>
        /// <value>The exits for the third floor library.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorLibrary
        {
            get { return RoomData.exitsThirdFloorLibrary; }
        }

        /// <summary>
        /// Gets the exits for the third floor living room.
        /// </summary>
        /// <value>The exits for the third floor living room.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorLivingRoom
        {
            get { return RoomData.exitsThirdFloorLivingRoom; }
        }

        /// <summary>
        /// Gets the exits for the third floor telephone booth.
        /// </summary>
        /// <value>The exits for the third floor telephone booth.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorTelephoneBooth
        {
            get { return RoomData.exitsThirdFloorTelephoneBooth; }
        }

        /// <summary>
        /// Gets the exits for the third floor trophy room.
        /// </summary>
        /// <value>The exits for the third floor trophy room.</value>
        public static ReadOnlyExitSetCollection ExitsThirdFloorTrophyRoom
        {
            get { return RoomData.exitsThirdFloorTrophyRoom; }
        }

        /// <summary>
        /// Gets the name of the art hall.
        /// </summary>
        /// <value>The name of the art hall.</value>
        public static string ArtHallName
        {
            get { return artHallName; }
        }

        /// <summary>
        /// Gets the name of the bar room.
        /// </summary>
        /// <value>The name of the bar room.</value>
        public static string BarroomName
        {
            get { return barroomName; }
        }

        /// <summary>
        /// Gets the name of the basement elevator.
        /// </summary>
        /// <value>The name of the basement elevator.</value>
        public static string BasementElevatorName
        {
            get { return basementElevatorName; }
        }

        /// <summary>
        /// Gets the name of the bathroom.
        /// </summary>
        /// <value>The name of the bathroom.</value>
        public static string BathroomName
        {
            get { return bathroomName; }
        }

        /// <summary>
        /// Gets the name of the bedroom.
        /// </summary>
        /// <value>The name of the bedroom.</value>
        public static string BedroomName
        {
            get { return bedroomName; }
        }

        /// <summary>
        /// Gets the name of the closet.
        /// </summary>
        /// <value>The name of the closet.</value>
        public static string ClosetName
        {
            get { return closetName; }
        }

        /// <summary>
        /// Gets the name of the coal bin.
        /// </summary>
        /// <value>The name of the coal bin.</value>
        public static string CoalBinName
        {
            get { return coalBinName; }
        }

        /// <summary>
        /// Gets the coat closet name.
        /// </summary>
        /// <value>The coat closet name.</value>
        public static string CoatClosetName
        {
            get { return coatClosetName; }
        }

        /// <summary>
        /// Gets the name of the computer room.
        /// </summary>
        /// <value>The name of the computer room.</value>
        public static string ComputerRoomName
        {
            get { return computerRoomName; }
        }

        /// <summary>
        /// Gets the name of the den.
        /// </summary>
        /// <value>The name of the den.</value>
        public static string DenName
        {
            get { return denName; }
        }

        /// <summary>
        /// Gets the name of the dining room.
        /// </summary>
        /// <value>The name of the dining room.</value>
        public static string DiningRoomName
        {
            get { return diningRoomName; }
        }

        /// <summary>
        /// Gets the name of the dirt floored room.
        /// </summary>
        /// <value>The name of the dirt floored room.</value>
        public static string DirtFlooredRoomName
        {
            get { return dirtFlooredRoomName; }
        }

        /// <summary>
        /// Gets the name of the family room.
        /// </summary>
        /// <value>The name of the family room.</value>
        public static string FamilyRoomName
        {
            get { return familyRoomName; }
        }

        /// <summary>
        /// Gets the first name of the floor elevator.
        /// </summary>
        /// <value>The first name of the floor elevator.</value>
        public static string FirstFloorElevatorName
        {
            get { return firstFloorElevatorName; }
        }

        /// <summary>
        /// Gets the name of the foyer.
        /// </summary>
        /// <value>The name of the foyer.</value>
        public static string FoyerName
        {
            get { return foyerName; }
        }

        /// <summary>
        /// Gets the name of the freezer.
        /// </summary>
        /// <value>The name of the freezer.</value>
        public static string FreezerName
        {
            get { return freezerName; }
        }

        /// <summary>
        /// Gets the name of the front porch.
        /// </summary>
        /// <value>The name of the front porch.</value>
        public static string FrontPorchName
        {
            get { return frontPorchName; }
        }

        /// <summary>
        /// Gets the name of the furnace room.
        /// </summary>
        /// <value>The name of the furnace room.</value>
        public static string FurnaceRoomName
        {
            get { return furnaceRoomName; }
        }

        /// <summary>
        /// Gets the name of the game room.
        /// </summary>
        /// <value>The name of the game room.</value>
        public static string GameRoomName
        {
            get { return gameRoomName; }
        }

        /// <summary>
        /// Gets the name of the guest room.
        /// </summary>
        /// <value>The name of the guest room.</value>
        public static string GuestroomName
        {
            get { return guestroomName; }
        }

        /// <summary>
        /// Gets the name of the kitchen.
        /// </summary>
        /// <value>The name of the kitchen.</value>
        public static string KitchenName
        {
            get { return kitchenName; }
        }

        /// <summary>
        /// Gets the name of the laboratory.
        /// </summary>
        /// <value>The name of the laboratory.</value>
        public static string LaboratoryName
        {
            get { return laboratoryName; }
        }

        /// <summary>
        /// Gets the name of the library.
        /// </summary>
        /// <value>The name of the library.</value>
        public static string LibraryName
        {
            get { return libraryName; }
        }

        /// <summary>
        /// Gets the name of the living room.
        /// </summary>
        /// <value>The name of the living room.</value>
        public static string LivingRoomName
        {
            get { return livingRoomName; }
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
            get { return masterBedroomName; }
        }

        /// <summary>
        /// Gets the name of the monster hangout.
        /// </summary>
        /// <value>The name of the monster hangout.</value>
        public static string MonsterHangoutName
        {
            get { return monsterHangoutName; }
        }

        /// <summary>
        /// Gets the name of the inventory.
        /// </summary>
        /// <value>The name of the inventory.</value>
        public static string InventoryName
        {
            get { return inventoryName; }
        }

        /// <summary>
        /// Gets the name of the pantry.
        /// </summary>
        /// <value>The name of the pantry.</value>
        public static string PantryName
        {
            get { return pantryName; }
        }

        /// <summary>
        /// Gets the name of the pump room.
        /// </summary>
        /// <value>The name of the pump room.</value>
        public static string PumpRoomName
        {
            get { return pumpRoomName; }
        }

        /// <summary>
        /// Gets the name of the second floor elevator.
        /// </summary>
        /// <value>The name of the second floor elevator.</value>
        public static string SecondFloorElevatorName
        {
            get { return secondFloorElevatorName; }
        }

        /// <summary>
        /// Gets the name of the sewing room.
        /// </summary>
        /// <value>The name of the sewing room.</value>
        public static string SewingRoomName
        {
            get { return sewingRoomName; }
        }

        /// <summary>
        /// Gets the name of the sitting room.
        /// </summary>
        /// <value>The name of the sitting room.</value>
        public static string SittingRoomName
        {
            get { return sittingRoomName; }
        }

        /// <summary>
        /// Gets the name of the telephone booth.
        /// </summary>
        /// <value>The name of the telephone booth.</value>
        public static string TelephoneBoothName
        {
            get { return telephoneBoothName; }
        }

        /// <summary>
        /// Gets the name of the third floor elevator.
        /// </summary>
        /// <value>The name of the third floor elevator.</value>
        public static string ThirdFloorElevatorName
        {
            get { return thirdFloorElevatorName; }
        }

        /// <summary>
        /// Gets the name of the torture chamber.
        /// </summary>
        /// <value>The name of the torture chamber.</value>
        public static string TortureChamberName
        {
            get { return tortureChamberName; }
        }

        /// <summary>
        /// Gets the name of the trophy room.
        /// </summary>
        /// <value>The name of the trophy room.</value>
        public static string TrophyRoomName
        {
            get { return trophyRoomName; }
        }

        /// <summary>
        /// Gets the name of the workshop.
        /// </summary>
        /// <value>The name of the workshop.</value>
        public static string WorkshopName
        {
            get { return workshopName; }
        }
    }
}
