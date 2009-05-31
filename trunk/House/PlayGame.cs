//-----------------------------------------------------------------------
// <copyright file="PlayGame.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace House
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using HouseCore;
    using HouseCore.Interfaces;
    using HouseCore.Presenters;

    /// <summary>
    /// Class that maintains state and determines actions that the user is attempting to execute
    /// </summary>
    public class PlayGame : IHouseView
    {
        #region Data Members (25)

        // Fields (15) 

        /// <summary>
        /// The presenter for actions
        /// </summary>
        private HousePresenter housePresenter;

        /// <summary>
        /// The adversaries in the room
        /// </summary>
        private List<string> adversariesInRoom = new List<string>();

        /// <summary>
        /// The exits in the room
        /// </summary>
        private List<string> exitDirections = new List<string>();

        ///// <summary>
        ///// The house in which the game is taking place
        ///// </summary>
        //private HouseType house = new HouseType(true);

        /// <summary>
        /// The items in the room
        /// </summary>
        private List<string> itemsInRoom = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGame"/> class.
        /// </summary>
        public PlayGame()
        {
            //this.housePresenter = new housePresenter(this);
            //this.housePresenter = new housePresenter(this);
            //this.housePresenter = new housePresenter(this);
            //this.housePresenter = new housePresenter(this);
            //this.housePresenter = new housePresenter(this);
            this.housePresenter = new HousePresenter(this);
        }

        // Properties (10) 

        /// <summary>
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public IList<string> AdversariesInRoom
        {
            get { return this.adversariesInRoom; }
        }

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        public string Argument { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether [clear screen].
        /// </summary>
        /// <value><c>true</c> if [clear screen]; otherwise, <c>false</c>.</value>
        public bool ClearScreen { get; set; }

        /// <summary>
        /// Gets the exit directions.
        /// </summary>
        /// <value>The exit directions.</value>
        public IList<string> ExitDirections
        {
            get { return this.exitDirections; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [game ended].
        /// </summary>
        /// <value><c>true</c> if [game ended]; otherwise, <c>false</c>.</value>
        public bool GameEnded { private get; set; }

        /// <summary>
        /// Private backing store for the inventory
        /// </summary>
        private IList<string> inventory = new List<string>();

        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
        public IList<string> Inventory
        {
            get
            {
                return inventory;
            }
        }

        private IList<string> inventoryShortNames = new List<string>();

        /// <summary>
        /// Gets the inventory items short names.
        /// </summary>
        /// <value>The inventory items short names.</value>
        public IList<string> InventoryShortNames
        {
            get
            {
                return inventoryShortNames;
            }
        }
        
        ///// <summary>
        ///// Gets or sets the house.
        ///// </summary>
        ///// <value>The house.</value>
        //public HouseType House
        //{
        //    get
        //    {
        //        return this.house;
        //    }

        //    //set
        //    //{
        //    //    ////this.house = value;
        //    //    this.house.RestoreHouse(value);
        //    //}
        //}

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<string> ItemsInRoom
        {
            get { return this.itemsInRoom; }
        }

        private IList<string> itemsInRoomShortNames = new List<string>();

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<string> ItemsInRoomShortNames
        {
            get { return this.itemsInRoomShortNames; }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { private get; set; }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        public string RoomName { private get; set; }

        #endregion Data Members

        #region Plumbing Code (3)

        /// <summary>
        /// Thes the loop.
        /// </summary>
        public void TheLoop()
        {
            string[] stringArrayCommand;
            char[] charArraySplitChars = new char[] { ' ' };

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Write("House Adventure" + Environment.NewLine + Environment.NewLine + "Remember the Impostor is last" + Environment.NewLine);
            ////Thread.Sleep(5000);
            this.housePresenter.Look();
            Console.WriteLine(this.ProcessLookReturn(true));

            while (!this.GameEnded)
            {
                this.housePresenter.IncrementNumberOfMoves();
                //Player.NumberOfMoves++;
                Console.Write("What to do \r\n");
                stringArrayCommand = new string[] { };
                string stringLine = Console.ReadLine();
                if (stringLine != null)
                {
                    stringArrayCommand = stringLine.Split(charArraySplitChars, 2);
                }

                if (stringArrayCommand.Length > 0 && stringArrayCommand[0].Length > 0)
                {
                    string stringShortenedCommand = stringArrayCommand[0].PadRight(3, ' ').Substring(0, 3).Trim();
                    if (String.Compare(stringShortenedCommand, "qui", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.Quit();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "bru", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Brush();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "spr", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Spray();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "say", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Say();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "ope", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Open();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "unl", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Open();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "pla", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Play();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "wav", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Wave();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "dig", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Dig();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "rea", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Read();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "loo", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.Look();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.ProcessLookReturn(true));
                    }
                    else if (String.Compare(stringShortenedCommand, "sav", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.Save();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "loa", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.Load();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "lig", true, CultureInfo.CurrentCulture) == 0)
                    {
                        if (stringArrayCommand.Length > 1)
                        {
                            this.Argument = stringArrayCommand[1];
                        }
                        else
                        {
                            this.Argument = String.Empty;
                        }

                        this.housePresenter.Light();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "on", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = "on";
                        this.housePresenter.Light();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "off", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = "off";
                        this.housePresenter.Light();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "get", true, CultureInfo.CurrentCulture) == 0 || String.Compare(stringShortenedCommand, "tak", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Get();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "sta", true, CultureInfo.CurrentCulture) == 0 || String.Compare(stringShortenedCommand, "kil", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Stab();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "dro", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.Argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Drop();
                        if (this.ClearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "inv", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.PopulateInventory();
                        StringBuilder stringBuilderOutput = new StringBuilder();

                        stringBuilderOutput.Append("You are presently carrying\r\n");
                        //                        if (this.player.Inventory.Count == 0)
                        foreach (string item in this.Inventory)
                        {
                            stringBuilderOutput.Append(item);
                            stringBuilderOutput.Append(Environment.NewLine);
                        }

                        /*
                        if (this.House.Rooms[TheHouseRoomData.LocationInventory].Items.Count == 0)
                        {
                            stringBuilderOutput.Append("nothing");
                        }
                        else
                        {
//                            foreach (InanimateObject inanimateObject in this.player.Inventory)
                            foreach (InanimateObject inanimateObject in this.House.Rooms[TheHouseRoomData.LocationInventory].Items)
                            {
                                stringBuilderOutput.Append(inanimateObject.Name);
                                stringBuilderOutput.Append(Environment.NewLine);
                            }
                        }
                         */

                        Console.WriteLine(stringBuilderOutput.ToString());
                    }
                    else
                    {
                        // Perhaps user entered something that starts with one of the direction values: U, D, N, E, W, S
                        stringShortenedCommand = stringShortenedCommand.Substring(0, 1);
                        if (String.Compare(stringShortenedCommand, "n", true, CultureInfo.CurrentCulture) == 0)
                        {
                            Console.WriteLine(this.ProcessLookReturn(this.housePresenter.North()));
                        }
                        else if (String.Compare(stringShortenedCommand, "s", true, CultureInfo.CurrentCulture) == 0)
                        {
                            Console.WriteLine(this.ProcessLookReturn(this.housePresenter.South()));
                        }
                        else if (String.Compare(stringShortenedCommand, "e", true, CultureInfo.CurrentCulture) == 0)
                        {
                            Console.WriteLine(this.ProcessLookReturn(this.housePresenter.East()));
                        }
                        else if (String.Compare(stringShortenedCommand, "w", true, CultureInfo.CurrentCulture) == 0)
                        {
                            Console.WriteLine(this.ProcessLookReturn(this.housePresenter.West()));
                        }
                        else if (String.Compare(stringShortenedCommand, "u", true, CultureInfo.CurrentCulture) == 0)
                        {
                            Console.WriteLine(this.ProcessLookReturn(this.housePresenter.Up()));
                        }
                        else if (String.Compare(stringShortenedCommand, "d", true, CultureInfo.CurrentCulture) == 0)
                        {
                            Console.WriteLine(this.ProcessLookReturn(this.housePresenter.Down()));
                        }
                        else
                        {
                            Console.WriteLine("I don't understand");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Formats the command.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The command with first character in upper case, rest in lower case</returns>
        private static string FormatCommand(string input)
        {
            return input[0].ToString().ToUpper(CultureInfo.CurrentCulture) + input.Substring(1).ToLower(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Collects the argument.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The argument for the command.</returns>
        private static string CollectArgument(string[] command)
        {
            string stringReturn = String.Empty;
            string stringFormattedCommand = FormatCommand(command[0]);
            if (command.Length > 1)
            {
                stringReturn = command[1];
            }
            else
            {
                Console.Write(String.Format(CultureInfo.CurrentCulture, "{0} what? ", stringFormattedCommand));
                stringReturn = Console.ReadLine();
            }

            return stringReturn;
        }

        /// <summary>
        /// Processes the look helper.
        /// </summary>
        /// <returns>String to show the user</returns>
        private string ProcessLookReturn(bool successfulMovementOrManualLook)
        {
            if (this.ClearScreen)
                Console.Clear();

            if (!successfulMovementOrManualLook)
                return this.Message;

            StringBuilder stringBuilderOutput = new StringBuilder();
            stringBuilderOutput.Append("\r\n\r\n");
            stringBuilderOutput.Append("You are ");
            stringBuilderOutput.Append(this.RoomName);
            stringBuilderOutput.Append(Environment.NewLine);
            stringBuilderOutput.Append("I see:\r\n");
            if (!String.IsNullOrEmpty(this.Message.ToString()))
            {
                stringBuilderOutput.Append(this.Message);
            }
            else
            {
                foreach (string adversary in this.AdversariesInRoom)
                {
                    stringBuilderOutput.Append(adversary);
                    stringBuilderOutput.Append(Environment.NewLine);
                }

                foreach (string inanimateObject in this.ItemsInRoom)
                {
                    stringBuilderOutput.Append(inanimateObject);
                    stringBuilderOutput.Append(Environment.NewLine);
                }

                stringBuilderOutput.Append("Obvious exits are:\r\n");
                int intCount = 0;
                foreach (string direction in this.ExitDirections)
                {
                    stringBuilderOutput.Append(direction);
                    intCount++;
                    if (intCount < this.ExitDirections.Count)
                    {
                        stringBuilderOutput.Append(Environment.NewLine);
                    }
                }
            }

            return stringBuilderOutput.ToString();
        }

        #endregion Plumbing Code
    }
}
