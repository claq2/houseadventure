//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

[assembly: System.CLSCompliant(true)]
namespace House
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    using HouseCore;
    using HouseCore.Interfaces;
    using HouseCore.Presenters;

    /// <summary>
    /// The Program class
    /// </summary>
    public sealed class Program
    {
        #region initial game data
        /*
        static string[] saObjects = new string[] { "a bag of gold", "a rusted key", "a can of bug spray", "an old leather glove", "a sorcerer's hand book", "a carving knife", "a wooden box", "an aluminum dime", "a flashlight", "a small diamond", "a silk pillow", "a wrinkled parchment", "a hairbrush", "100's of gold coins", "a banjo", "a clove of garlic", "a set of batteries", "a block of dry ice", "a shovel", "a ming vase", "a locked door ", "the front yard", "a king sized bed", "a brass bathtub", "a set of stocks", "a dusty moose head", "a unitron 30/50 mainframe" };
        static string[] saMonsters = new string[] { "a protoplasmic blob", "a vampire", "a savage beast", "a leopard", "an insane monk", "a werewolf", "" };
        static string[] saBasementRooms = new string[] { "in a dirt-floored room", "in the laboratory", "in the pumproom", "in the furnace room", "in a dusty coal bin", "in the torture chamber", "in the workshop", "in a walk-in freezer", "in a telephone booth", "in the basement elevator" };
        static string[] saMainFloorRooms = new string[] { "on the front porch", "in the foyer", "in a bedroom", "in a coat closet", "in the dining room", "in the pantry", "in the kitchen", "in the family room", "in a telephone booth", "in the first floor elevator" };
        static string[] saSecondFloorRooms = new string[] { "in the sewing room", "in a closet", "in the master bedroom", "in a guest room", "in a bathroom", "in a guest room", "in a sitting room", "in the den", "in a telephone booth", "in the second floor elevator" };
        static string[] saThirdFloorRooms = new string[] { "in the living room", "in the library", "in the trophy room", "in the barroom", "in the computer-room", "in the game room", "in a bedroom", "in the art hall", "in a telephone booth", "in the third floor elevator" };
        //static string[] saMagicWords = new string[] { "ABRACADABRA", "SHAZAAM", "SEERSUCKER", "UGABOOM" };
        static string[] saDirections = new string[] { "NORTH", "EAST", "WEST", "SOUTH" };
        //static string sObjectsShort = "GOLKEYCANGLOBOOKNIBOXDIMFLADIAPILPARHAICOIBANGARBATICESHOVAS";
        //static string sMonstersShort = "BLOVAMBEALEOMONWER";
        //static string sActionsShort = "GETTAKDROSAYKILSTALIGPLAREADIGINVQUION OFFBRUWAVUNLOPESPRSAVLOAUDNEWS";
        static int[] daBasementExits = new int[] { 0, 0, 8, 2, 1, 3, 0, 0, 0, 0, 2, 4, 3, 5, 0, 10, 0, 7, 4, 0, 9, 0, 0, 7, 6, 8, 5, 0, 0, 1, 7, 0, 10, 0, 0, 6, 4, 0, 0, 9 };
        static int[] daMainFloorExits = new int[] { 2, 0, 0, 0, 0, 8, 4, 0, 0, 6, 0, 8, 0, 2, 10, 0, 8, 10, 0, 0, 9, 0, 3, 7, 6, 0, 0, 10, 3, 0, 2, 5, 0, 0, 0, 6, 7, 4, 5, 0 };
        static int[] daSecondFloorExits = new int[] { 0, 10, 0, 2, 1, 0, 0, 4, 10, 0, 0, 5, 2, 5, 6, 0, 3, 6, 4, 7, 0, 4, 5, 0, 5, 0, 0, 8, 7, 0, 9, 0, 0, 8, 0, 0, 0, 0, 1, 3 };
        static int[] daThirdFloorExits = new int[] { 10, 3, 0, 0, 0, 0, 10, 3, 2, 0, 1, 0, 0, 6, 9, 0, 9, 0, 0, 6, 5, 0, 4, 8, 0, 8, 0, 0, 6, 0, 7, 0, 0, 4, 0, 5, 0, 2, 0, 1 };
        static int[] iaMonsterLocations = new int[] { 1, 8, 2, 7, 1, 3, 4, 2, 3, 4, 4, 8 };
        //static double[] daObjectLocations = new double[] { 1, 6, 1, 1.5, 1, 3, 1, 9.5, 4, 2, 2, 7, 2, 2, 2, 5.5, 2, 4, 3, 2, 4, 8, 1, 8, 3, 7, 3, 9, 3, 8, 1, 1.5, 4, 3, 4, 4, 4, 5, 3, 4, 2, 2, 2, 1, 3, 3, 3, 5, 1, 6, 3, 8, 4, 5 };
        static int[] daObjectLocations = new int[] { 1, 6, 1, 1, 1, 3, 1, 9, 4, 2, 2, 7, 2, 2, 2, 5, 2, 4, 3, 2, 4, 8, 1, 8, 3, 7, 3, 9, 3, 8, 1, 1, 4, 3, 4, 4, 4, 5, 3, 4, 2, 2, 2, 1, 3, 3, 3, 5, 1, 6, 3, 8, 4, 5 };
        static int[] iaMagicWordRooms = new int[] { 0, 8, 1, 4 }; //All items in these rooms are hidden until the right magic word is spoken
        static int[] iaConsumableObjects = new int[] { 2, 16 };
        static int[] iaConsumableDependentObjects = new int[] { 16 };
        static int[] iaConsumableObjectLimits = new int[] { 1, 40 };
        static int[] iaConsumableDependentObjectDependency = new int[] { 8 };
        static int[] iaBuriedObjects = new int[] { 1, 15 };
        static int[] iaMultiplePieceObjects = new int[] { 13 };
        static int[] iaContainerObjects = new int[] { 6 };
        static int[] iaDelicateObjects = new int[] { 19 };
        static int[] iaCushioningObjects = new int[] { 10 };
        static int[] iaOnOffObjects = new int[] { 8 };
        static int[] iaLockableObjects = new int[] { 20 };
        static int[] iaLockableObjectsDestinations = new int[] { 0 };
        static HouseFunctions.Direction[] daLockableObjectsDirections = new Direction[] { Direction.South };
        static int[] iaElevators = new int[] { 0, 9, 1, 9, 2, 9, 3, 9 };
        static int[] iaTelephoneBooths = new int[] { 0, 8, 1, 8, 2, 8, 3, 8 };
        static int[] iaUnfinishedFloorRooms = new int[] { 0, 0 };
        static int[] iaPainfulObjects = new int[] { 17 };
        static int[] iaProtectiveObjects = new int[] { 3 };

        static int[] iaAdversaryDislikedObjects = new int[] { 2,8,14,12,5,15};
        */

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        private Program()
        {
        }

        /// <summary>
        /// Entry point for the program
        /// </summary>
        /// <param name="args">Command line arguments entered by the user</param>
        public static void Main(string[] args)
        {
            PlayGame game = new PlayGame();
            game.TheLoop();

            /*
            bool boolDebugMode = false;
            bool wonGame = false;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Write("House Adventure\r\n\r\nRemember the Impostor is last\r\n");
            ////Thread.Sleep(5000);

            foreach (string arg in args)
            {
                if (String.Compare(arg, "debug", true, CultureInfo.CurrentCulture) == 0)
                {
                    boolDebugMode = true;
                }
            }

            if (boolDebugMode)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("Basement:\r\n");
                    }
                    else if (i == 1)
                    {
                        Console.Write("Main floor:\r\n");
                    }
                    else if (i == 2)
                    {
                        Console.Write("Second floor:\r\n");
                    }
                    else
                    {
                        Console.Write("Third floor:\r\n");
                    }

                    foreach (Room room in TheSingletonHouse.Instance.Rooms)
                    {
                        Console.Write("\tRoom: " + room.Name + "\r\n");
                        Console.Write("\t\tExits: ");
                        foreach (RoomExit exit in room.Exits)
                        {
                            Console.Write(exit.ExitDirection.ToString() + " to " + exit.ExitDestination.ToString() + ", ");
                        }

                        Console.Write("\r\n");
                        Console.Write("\t\tMonsters: ");
                        foreach (Adversary adversary in room.Adversaries)
                        {
                            Console.Write(adversary.Name + ", ");
                        }

                        Console.Write("\r\n");
                        Console.Write("\t\tItems: ");
                        foreach (InanimateObject io in room.Items)
                        {
                            Console.Write(io.Name + ", ");
                        }

                        Console.Write("\r\n");
                    }
                }
            }

            ////Console.Beep(100, 1000);
            string[] stringArrayCommand;
            char[] charArraySplitChars = new char[] { ' ' };
            bool boolQuitting = false;
            Console.WriteLine(ProcessLookHelper(TheSingletonHouse.Instance.Player.Look(false)));
            do
            {
                ////Console.Clear();
                ////Console.Write(TheHouse.Player.Look(heHouse.Rooms[(int)TheHouse.Player.Location.Floor][TheHouse.Player.Location.Room]));
                TheSingletonHouse.Instance.Player.IncrementNumberOfMoves();
                Console.Write("What to do \r\n");
                stringArrayCommand = Console.ReadLine().Split(charArraySplitChars, 2);

                if (stringArrayCommand[0].Length > 0)
                {
                    string stringFormattedCommand = FormatCommand(stringArrayCommand[0]);
                    if (String.Compare(stringArrayCommand[0], "quit", true, CultureInfo.CurrentCulture) == 0)
                    {
                        boolQuitting = true;
                    }
                    else if (String.Compare(stringArrayCommand[0], "brush", true, CultureInfo.CurrentCulture) == 0)
                    {
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        Console.WriteLine(TheSingletonHouse.Instance.Player.Brush(stringItem));
                    }
                    else if (String.Compare(stringArrayCommand[0], "say", true, CultureInfo.CurrentCulture) == 0)
                    {
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        Console.WriteLine(TheSingletonHouse.Instance.Player.Say(stringItem));
                    }
                    else if (String.Compare(stringArrayCommand[0], "open", true, CultureInfo.CurrentCulture) == 0)
                    {
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        Console.WriteLine(TheSingletonHouse.Instance.Player.Open(stringItem));
                    }
                    else if (String.Compare(stringArrayCommand[0], "unlock", true, CultureInfo.CurrentCulture) == 0)
                    {
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        Console.WriteLine(TheSingletonHouse.Instance.Player.Open(stringItem));
                    }
                    else if (String.Compare(stringArrayCommand[0], "play", true, CultureInfo.CurrentCulture) == 0)
                    {
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        Console.WriteLine(TheSingletonHouse.Instance.Player.Play(stringItem));
                    }
                    else if (String.Compare(stringArrayCommand[0], "light", true, CultureInfo.CurrentCulture) == 0)
                    {
                        OnOffObject onOffFlashlight = TheSingletonHouse.Instance.InanimateObjects[TheHouseData.FlashlightName] as OnOffObject;
                        Switch switchState = onOffFlashlight.State;
                        switch (switchState)
                        {
                            case Switch.Off:
                                Console.WriteLine(TheSingletonHouse.Instance.Player.Light(Switch.On));
                                break;
                            case Switch.On:
                                Console.WriteLine(TheSingletonHouse.Instance.Player.Light(Switch.Off));
                                break;
                            default:
                                break;
                        }
                    }
                    else if (String.Compare(stringArrayCommand[0], "on", true, CultureInfo.CurrentCulture) == 0)
                    {
                        Console.WriteLine(TheSingletonHouse.Instance.Player.Light(Switch.On));
                    }
                    else if (String.Compare(stringArrayCommand[0], "off", true, CultureInfo.CurrentCulture) == 0)
                    {
                        Console.WriteLine(TheSingletonHouse.Instance.Player.Light(Switch.Off));
                    }
                    else if (String.Compare(stringArrayCommand[0], "wave", true, CultureInfo.CurrentCulture) == 0)
                    {
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        Console.WriteLine(TheSingletonHouse.Instance.Player.Wave(stringItem));
                    }
                    else if (String.Compare(stringArrayCommand[0], "get", true, CultureInfo.CurrentCulture) == 0 || String.Compare(stringArrayCommand[0], "take", true, CultureInfo.CurrentCulture) == 0)
                    {
                        GetHelper getHelper;
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        getHelper = TheSingletonHouse.Instance.Player.Get(stringItem);
                        Console.WriteLine(getHelper.Output);
                        boolQuitting = getHelper.Died;
                    }
                    else if (String.Compare(stringArrayCommand[0], "dig", true, CultureInfo.CurrentCulture) == 0)
                    {
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        Console.WriteLine(TheSingletonHouse.Instance.Player.Dig(stringItem));
                    }
                    else if (String.Compare(stringArrayCommand[0], "read", true, CultureInfo.CurrentCulture) == 0)
                    {
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        Console.WriteLine(TheSingletonHouse.Instance.Player.Read(stringItem));
                    }
                    else if (String.Compare(stringArrayCommand[0], "drop", true, CultureInfo.CurrentCulture) == 0)
                    {
                        DropHelper dropHelper;
                        string stringItem;
                        if (stringArrayCommand.Length > 1)
                        {
                            stringItem = stringArrayCommand[1];
                        }
                        else
                        {
                            Console.Write(stringFormattedCommand + " what? ");
                            stringItem = Console.ReadLine();
                        }

                        dropHelper = TheSingletonHouse.Instance.Player.Drop(stringItem);
                        Console.WriteLine(dropHelper.Output);
                        boolQuitting = dropHelper.WonGame;
                    }
                    else if (String.Compare(stringArrayCommand[0], "inventory", true, CultureInfo.CurrentCulture) == 0)
                    {
                        StringBuilder stringBuilderOutput = new StringBuilder();

                        stringBuilderOutput.Append("You are presently carrying\r\n");
                        if (TheSingletonHouse.Instance.Player.Inventory.Count == 0)
                        {
                            stringBuilderOutput.Append("nothing");
                        }
                        else
                        {
                            foreach (InanimateObject inanimateObject in TheSingletonHouse.Instance.Player.Inventory)
                            {
                                stringBuilderOutput.Append(inanimateObject.Name);
                                stringBuilderOutput.Append("\r\n");
                            }
                        }

                        Console.WriteLine(stringBuilderOutput.ToString());
                    }
                    else if (String.Compare(stringArrayCommand[0], "look", true, CultureInfo.CurrentCulture) == 0)
                    {
                        LookHelper lookHelper = TheSingletonHouse.Instance.Player.Look(false);
                        Console.Clear();
                        Console.WriteLine(ProcessLookHelper(lookHelper));
                        boolQuitting = lookHelper.Died;
                    }
                    else if (String.Compare(stringArrayCommand[0], "save", true, CultureInfo.CurrentCulture) == 0)
                    {
                        Console.Clear();
                        Console.WriteLine(TheSingletonHouse.Instance.Save());
                    }
                    else if (String.Compare(stringArrayCommand[0], "load", true, CultureInfo.CurrentCulture) == 0)
                    {
                        Console.Clear();
                        Console.WriteLine(TheSingletonHouse.Instance.Load());
                    }
                    else if (String.Compare(stringArrayCommand[0], "up", true, CultureInfo.CurrentCulture) == 0)
                    {
                        boolQuitting = ProcessMovement(Direction.Up);
                    }
                    else if (String.Compare(stringArrayCommand[0], "down", true, CultureInfo.CurrentCulture) == 0)
                    {
                        boolQuitting = ProcessMovement(Direction.Down);
                    }
                    else if (String.Compare(stringArrayCommand[0], "north", true, CultureInfo.CurrentCulture) == 0)
                    {
                        boolQuitting = ProcessMovement(Direction.North);
                    }
                    else if (String.Compare(stringArrayCommand[0], "south", true, CultureInfo.CurrentCulture) == 0)
                    {
                        boolQuitting = ProcessMovement(Direction.South);
                    }
                    else if (String.Compare(stringArrayCommand[0], "east", true, CultureInfo.CurrentCulture) == 0)
                    {
                        boolQuitting = ProcessMovement(Direction.East);
                    }
                    else if (String.Compare(stringArrayCommand[0], "west", true, CultureInfo.CurrentCulture) == 0)
                    {
                        boolQuitting = ProcessMovement(Direction.West);
                    }
                    else
                    {
                        Console.Write("I don't understand\r\n");
                    }
                }
            }
            while (!boolQuitting && !wonGame);
            if (boolQuitting)
            {
                Console.Write(String.Format(CultureInfo.CurrentCulture, "You got {0} items out of the house in {1} moves", TheSingletonHouse.Instance.Player.ItemsRemovedFromHouse, TheSingletonHouse.Instance.Player.NumberOfMoves));
            }
            else
            {
                Console.Clear();
                Console.Write(String.Format(CultureInfo.CurrentCulture, "Congratulations--you have successfully completed House Adventure \r\nYou removed all 20 objects in {0} moves", TheSingletonHouse.Instance.Player.NumberOfMoves));
            }
            */
        }

        ///// <summary>
        ///// Formats the command.
        ///// </summary>
        ///// <param name="input">The input.</param>
        ///// <returns>The input string with the first letter in upper case and the reset in lower case</returns>
        //private static string FormatCommand(string input)
        //{
        //    return input[0].ToString().ToUpper(CultureInfo.CurrentCulture) + input.Substring(1).ToLower(CultureInfo.CurrentCulture);
        //}

        ///// <summary>
        ///// Processes the look helper.
        ///// </summary>
        ///// <param name="lookHelper">The look helper.</param>
        ///// <returns>String to show the user</returns>
        //private static string ProcessLookHelper(LookHelper lookHelper)
        //{
        //    StringBuilder stringBuilderOutput = new StringBuilder();
        //    stringBuilderOutput.Append("\r\n\r\n");
        //    stringBuilderOutput.Append("You are ");
        //    stringBuilderOutput.Append(lookHelper.RoomName);
        //    stringBuilderOutput.Append("\r\n");
        //    stringBuilderOutput.Append("I see:\r\n");
        //    if (!String.IsNullOrEmpty(lookHelper.Output))
        //    {
        //        stringBuilderOutput.Append(lookHelper.Output);
        //    }
        //    else
        //    {
        //        foreach (Adversary adversary in lookHelper.Adversaries)
        //        {
        //            stringBuilderOutput.Append(adversary.Name);
        //            stringBuilderOutput.Append("\r\n");
        //        }

        //        foreach (InanimateObject inanimateObject in lookHelper.Items)
        //        {
        //            stringBuilderOutput.Append(inanimateObject.Name);
        //            stringBuilderOutput.Append("\r\n");
        //        }

        //        stringBuilderOutput.Append("Obvious exits are:\r\n");
        //        int intCount = 0;
        //        foreach (Direction direction in lookHelper.ExitDirections)
        //        {
        //            stringBuilderOutput.Append(direction.ToString());
        //            intCount++;
        //            if (intCount < lookHelper.ExitDirections.Count)
        //            {
        //                stringBuilderOutput.Append("\r\n");
        //            }
        //        }
        //    }

        //    return stringBuilderOutput.ToString();
        //}

        ///// <summary>
        ///// Processes the movement.
        ///// </summary>
        ///// <param name="direction">The direction.</param>
        ///// <returns>Success or fail</returns>
        //private static bool ProcessMovement(Direction direction)
        //{
        //    LookHelper lookHelper = new LookHelper();
        //    bool verticalMovement = direction == Direction.Up || direction == Direction.Down;
        //    if (TheSingletonHouse.Instance.Player.Move(direction))
        //    {
        //        Console.Clear();
        //        lookHelper = TheSingletonHouse.Instance.Player.Look(verticalMovement);
        //        Console.WriteLine(ProcessLookHelper(lookHelper));
        //    }
        //    else
        //    {
        //        Console.WriteLine(TheHouseData.DisallowedDirectionValue);
        //    }

        //    return lookHelper.Died;
        //}

        /*
        public static void Initialize(HouseFunctions.PlayerEntity Player, int[, ,] Exits, int[,] Monsters, double[,] Objects, int[,] MagicRooms, HouseEntity house, List<Room> rooms, List<Adversary> adversries, List<InanimateObject> items)
        {

            TheHouse.Player.Location.Floor = Floor.FirstFloor;
            TheHouse.Player.Location.Room = 1;

            #region load rooms
            //house.Rooms = new Collection<Collection<Room>>();
            for (int i = 0; i < 4; i++)
            {
                string[] saRoomNames;
                int[] daFloor;

                if (i == 0)
                {
                    saRoomNames = saBasementRooms;
                    daFloor = daBasementExits;
                }
                else if (i == 1)
                {
                    saRoomNames = saMainFloorRooms;
                    daFloor = daMainFloorExits;
                }
                else if (i == 2)
                {
                    saRoomNames = saSecondFloorRooms;
                    daFloor = daSecondFloorExits;
                }
                else
                {
                    saRoomNames = saThirdFloorRooms;
                    daFloor = daThirdFloorExits;
                }

                //Add new floor to the house
                house.Rooms.Add(new System.Collections.ObjectModel.Collection<Room>());

                for (int j = 0; j < 10; j++)
                {

                    //Add a new room to the house
                    if (j == 0 && i == 0)
                    {
                        house.Rooms[i].Add(new UnfinishedFlooredRoom());
                    }
                    else if (j < 8)
                    {
                        house.Rooms[i].Add(new Room());
                    }
                    else if (j == 8)
                    {
                        house.Rooms[i].Add(new TelephoneBooth());
                    }
                    else if (j == 9)
                    {
                        house.Rooms[i].Add(new Elevator());
                    }
                    rooms.Add(house.Rooms[i][j]);
                    house.Rooms[i][j].Location.Floor = (Floor)i;
                    house.Rooms[i][j].Location.Room = j;
                    house.Rooms[i][j].Name = saRoomNames[j];
                    //house.Rooms[i][j].Exits = new ExitSet();
                    for (int k = 0; k < 4; k++)
                    {
                        Exits[i, j, k] = daFloor[j * 4 + k] - 1;
                        if (daFloor[j * 4 + k] - 1 > -1)
                        {
                            house.Rooms[i][j].Exits.Add(new RoomExit((Direction)k, daFloor[j * 4 + k] - 1));
                        }

                    }
                }
            }
            #endregion

            #region load monsters
            for (int i = 0; i < 6; i++)
            {
                int iMonsterLevel = iaMonsterLocations[i * 2 + 0] - 1;
                int iMonsterRoom = iaMonsterLocations[i * 2 + 1] - 1;
                Adversary adversary = new Adversary();
                adversary.Name = saMonsters[i];
                house.Rooms[iMonsterLevel][iMonsterRoom].Adversaries.Add(adversary);
                adversries.Add(adversary);

                for (int j = 0; j < 2; j++)
                {
                    Monsters[i, j] = iaMonsterLocations[i * 2 + j] - 1;
                }
            }
            #endregion

            #region load objects
            for (int i = 0; i < 27; i++)
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
                inObj.Location.Floor=(Floor)iObjectLevel;
                inObj.Location.Room=iObjectRoom;
                //house.Rooms[iObjectLevel][iObjectRoom].InanimateObjects.Add(inObj);
                house.Rooms[iObjectLevel][iObjectRoom].Items.Add(inObj);
                items.Add(inObj);
                for (int j = 0; j < 2; j++)
                {
                    Objects[i, j] = daObjectLocations[i * 2 + j] - 1;
                }
            }
            #endregion

            foreach (int objNum in iaBuriedObjects)
            {
                InanimateObject obj = items[objNum];
                BuriedObject boObj = new BuriedObject();
                boObj.Buried = true;
                boObj.Location=obj.Location;
                boObj.Name = obj.Name;
                items[objNum] = boObj;
                int indexinroom = house.Rooms[(int)boObj.Location.Floor][boObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)boObj.Location.Floor][boObj.Location.Room].Items[indexinroom] = boObj;
            }

            foreach (int objNum in iaMultiplePieceObjects)
            {
                InanimateObject obj = items[objNum];
                MultiplePieceObject mpObj = new MultiplePieceObject();
                mpObj.Location = obj.Location;
                mpObj.Name = obj.Name;
                items[objNum] = mpObj;
                int indexinroom = house.Rooms[(int)mpObj.Location.Floor][mpObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)mpObj.Location.Floor][mpObj.Location.Room].Items[indexinroom] = mpObj;
            }

            foreach (int objNum in iaContainerObjects)
            {
                InanimateObject obj = items[objNum];
                ContainerObject cObj = new ContainerObject();
                cObj.Location = obj.Location;
                cObj.Name = obj.Name;
                items[objNum] = cObj;
                int indexinroom = house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items[indexinroom] = cObj;
            }

            foreach (int objNum in iaProtectiveObjects)
            {
                InanimateObject obj = items[objNum];
                ProtectiveObject pObj = new ProtectiveObject();
                pObj.Location = obj.Location;
                pObj.Name = obj.Name;
                items[objNum] = pObj;
                int indexinroom = house.Rooms[(int)pObj.Location.Floor][pObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)pObj.Location.Floor][pObj.Location.Room].Items[indexinroom] = pObj;
            }

            foreach (int objNum in iaPainfulObjects)
            {
                InanimateObject obj = items[objNum];
                PainfulObject pObj = new PainfulObject();
                pObj.Location = obj.Location;
                pObj.Name = obj.Name;
                items[objNum] = pObj;
                int indexinroom = house.Rooms[(int)pObj.Location.Floor][pObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)pObj.Location.Floor][pObj.Location.Room].Items[indexinroom] = pObj;
            }

            foreach (int objNum in iaOnOffObjects)
            {
                InanimateObject obj = items[objNum];
                OnOffObject ooObj = new OnOffObject();
                ooObj.Location = obj.Location;
                ooObj.Name = obj.Name;
                items[objNum] = ooObj;
                int indexinroom = house.Rooms[(int)ooObj.Location.Floor][ooObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)ooObj.Location.Floor][ooObj.Location.Room].Items[indexinroom] = ooObj;
            }

            foreach (int objNum in iaDelicateObjects)
            {
                InanimateObject obj = items[objNum];
                DelicateObject dObj = new DelicateObject();
                dObj.Location = obj.Location;
                dObj.Name = obj.Name;
                items[objNum] = dObj;
                int indexinroom = house.Rooms[(int)dObj.Location.Floor][dObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)dObj.Location.Floor][dObj.Location.Room].Items[indexinroom] = dObj;
            }

            foreach (int objNum in iaCushioningObjects)
            {
                InanimateObject obj = items[objNum];
                CushioningObject cObj = new CushioningObject();
                cObj.Location = obj.Location;
                cObj.Name = obj.Name;
                items[objNum] = cObj;
                int indexinroom = house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items[indexinroom] = cObj;
            }

            int iConsumableObjectIndex = 0;
            foreach (int objNum in iaConsumableObjects)
            {
                InanimateObject obj = items[objNum];
                ConsumableObject cObj = new ConsumableObject();
                cObj.Location = obj.Location;
                cObj.Name = obj.Name;
                cObj.UsageLimit = iaConsumableObjectLimits[iConsumableObjectIndex];
                items[objNum] = cObj;
                int indexinroom = house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items.IndexOf(obj);
                house.Rooms[(int)cObj.Location.Floor][cObj.Location.Room].Items[indexinroom] = cObj;
                iConsumableObjectIndex++;
            }

            /*
                    static int[] iaConsumableObjects = new int[] { 2 ,16 };
        static int[] iaConsumableDependentObjects = new int[] { 16 };
        static int[] iaConsumableObjectLimits = new int[] { 1, 40 };
        static int[] iaConsumableDependentObjectDependency = new int[] { 8 };
        static int[] iaLockableObjects = new int[] { 20 };
        static int[] iaLockableObjectsDestinations = new int[] { 0 };
        static House.Direction[] daLockableObjectsDirections = new Direction[] { Direction.South };
            */

        /*
            #region load magic word rooms
            for (int i = 0; i < 2; i++)
            {
                int magicRoomFloor = iaMagicWordRooms[i * 2 + 0];
                int magicRoomRoom = iaMagicWordRooms[i * 2 + 1];
                int magicRoomIndex = magicRoomFloor * 10 + magicRoomRoom;
                int iObjCount = rooms[magicRoomIndex].Items.Count;
                for (int io = 0; io < iObjCount; io++)
                //foreach (InanimateObject obj in rooms[magicRoomIndex].InanimateObjects)

                //                foreach (InanimateObject obj in rooms[magicRoomIndex].Items)
                {
                    InanimateObject obj = rooms[magicRoomIndex].Items[io];
                    HiddenObject hoItem = new HiddenObject();

                    //rooms[magicRoomIndex].InanimateObjects.
                    hoItem.Location = obj.Location;
                    hoItem.Name = obj.Name;
                    hoItem.Hidden = true;

                    house.Rooms[magicRoomFloor][magicRoomRoom].Items[io] = hoItem;
                    rooms[magicRoomIndex].Items[io] = hoItem;

                    //iObjCount++;


                }
                //rooms[magicRoomIndex]=new M
                for (int j = 0; j < 2; j++)
                {
                    //rooms[
                    MagicRooms[i, j] = iaMagicWordRooms[i * 2 + j];
                }
            }
            #endregion
        }

        */
    }
}
