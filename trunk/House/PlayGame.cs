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
        /// Indicates that the look action preceeded a vertical movement
        /// </summary>
        private bool afterVerticalMovement;

        /// <summary>
        /// The presenter for actions
        /// </summary>
        private HousePresenter housePresenter;

        /// <summary>
        /// The adversaries in the room
        /// </summary>
        private List<string> adversariesInRoom = new List<string>();

        /// <summary>
        /// The action argument
        /// </summary>
        private string argument = String.Empty;

        /// <summary>
        /// Indicator for whether to clear the screen before outputting the action results
        /// </summary>
        private bool clearScreen;

        /// <summary>
        /// The exits in the room
        /// </summary>
        private List<string> exitDirections = new List<string>();

        /// <summary>
        /// Indicator for whether the action ended the game
        /// </summary>
        private bool gameEnded;

        /// <summary>
        /// The house in which the game is taking place
        /// </summary>
        private HouseCore.HouseType house = new HouseCore.HouseType(true);

        /// <summary>
        /// The items in the room
        /// </summary>
        private List<string> itemsInRoom = new List<string>();

        /// <summary>
        /// The output from the action
        /// </summary>
        private StringBuilder message = new StringBuilder();

        /// <summary>
        /// The player object
        /// </summary>
        private Player player = new Player();

        /// <summary>
        /// The name of the current room
        /// </summary>
        private string roomName = String.Empty;

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
        /// Gets a value indicating whether a vertical movement was just performed
        /// </summary>
        /// <value>true if done after a vertical movement, false otherwise</value>
        public bool AfterVerticalMovement
        {
            get { return this.afterVerticalMovement; }
        }

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        public string Argument
        {
            get
            {
                return this.argument;
            }

            set
            {
                this.argument = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [clear screen].
        /// </summary>
        /// <value><c>true</c> if [clear screen]; otherwise, <c>false</c>.</value>
        public bool ClearScreen
        {
            get
            {
                return this.clearScreen;
            }

            set
            {
                this.clearScreen = value;
            }
        }

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
        public bool GameEnded
        {
            get { return this.gameEnded; }
            set { this.gameEnded = value; }
        }

        /// <summary>
        /// Gets or sets the house.
        /// </summary>
        /// <value>The house.</value>
        public HouseCore.HouseType House
        {
            get
            {
                return this.house;
            }

            set
            {
                ////this.house = value;
                this.house.RestoreHouse(value);
            }
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<string> ItemsInRoom
        {
            get { return this.itemsInRoom; }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public StringBuilder Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player
        {
            get
            {
                return this.player;
            }

            set
            {
                this.player = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        public string RoomName
        {
            get { return this.roomName; }
            set { this.roomName = value; }
        }

        #endregion Data Members 

        #region Plumbing Code (3) 

        /// <summary>
        /// Thes the loop.
        /// </summary>
        public void TheLoop()
        {
            string command = String.Empty;
            string[] stringArrayCommand;
            char[] charArraySplitChars = new char[] { ' ' };

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Write("House Adventure" + Environment.NewLine + Environment.NewLine + "Remember the Impostor is last" + Environment.NewLine);
            ////Thread.Sleep(5000);
            this.housePresenter.Look();
            Console.WriteLine(this.ProcessLookReturn());

            while (!this.gameEnded)
            {
                Player.NumberOfMoves++;
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
                    string stringFormattedCommand = FormatCommand(stringArrayCommand[0]);
                    if (String.Compare(stringShortenedCommand, "qui", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.Quit();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "bru", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Brush();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "spr", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Spray();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "say", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Say();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "ope", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Open();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "unl", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Open();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "pla", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Play();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "wav", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Wave();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "dig", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Dig();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "rea", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Read();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "loo", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.Look();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.ProcessLookReturn());
                    }
                    else if (String.Compare(stringShortenedCommand, "sav", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.Save();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "loa", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.housePresenter.Load();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "lig", true, CultureInfo.CurrentCulture) == 0)
                    {
                        if (stringArrayCommand.Length > 1)
                        {
                            this.argument = stringArrayCommand[1];
                        }
                        else
                        {
                            this.argument = String.Empty;
                        }

                        this.housePresenter.Light();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "on", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = "on";
                        this.housePresenter.Light();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "off", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = "off";
                        this.housePresenter.Light();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.Message);
                    }
                    else if (String.Compare(stringShortenedCommand, "get", true, CultureInfo.CurrentCulture) == 0 || String.Compare(stringArrayCommand[0], "take", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Get();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "dro", true, CultureInfo.CurrentCulture) == 0)
                    {
                        this.argument = CollectArgument(stringArrayCommand);
                        this.housePresenter.Drop();
                        if (this.clearScreen)
                        {
                            Console.Clear();
                        }

                        Console.WriteLine(this.message);
                    }
                    else if (String.Compare(stringShortenedCommand, "inv", true, CultureInfo.CurrentCulture) == 0)
                    {
                        StringBuilder stringBuilderOutput = new StringBuilder();

                        stringBuilderOutput.Append("You are presently carrying\r\n");
//                        if (this.player.Inventory.Count == 0)
                        if (this.house.Rooms[LocationType.Inventory].Items.Count == 0)
                        {
                            stringBuilderOutput.Append("nothing");
                        }
                        else
                        {
//                            foreach (InanimateObject inanimateObject in this.player.Inventory)
                            foreach (InanimateObject inanimateObject in this.house.Rooms[LocationType.Inventory].Items)
                            {
                                stringBuilderOutput.Append(inanimateObject.Name);
                                stringBuilderOutput.Append(Environment.NewLine);
                            }
                        }

                        Console.WriteLine(stringBuilderOutput.ToString());
                    }
                    else
                    {
                        // Perhaps user entered something that starts with one of the direction values: U, D, N, E, W, S
                        stringShortenedCommand = stringShortenedCommand.Substring(0, 1);
                        if (String.Compare(stringShortenedCommand, "n", true, CultureInfo.CurrentCulture) == 0)
                        {
                            this.housePresenter.North();
                            if (this.clearScreen)
                            {
                                Console.Clear();
                            }

                            if (String.IsNullOrEmpty(this.Message.ToString()))
                            {
                                this.afterVerticalMovement = false;
                                this.housePresenter.Look();
                                Console.WriteLine(this.ProcessLookReturn());
                            }
                            else
                            {
                                Console.WriteLine(this.Message);
                            }
                        }
                        else if (String.Compare(stringShortenedCommand, "s", true, CultureInfo.CurrentCulture) == 0)
                        {
                            this.housePresenter.South();
                            if (this.clearScreen)
                            {
                                Console.Clear();
                            }

                            if (String.IsNullOrEmpty(this.Message.ToString()))
                            {
                                this.afterVerticalMovement = false;
                                this.housePresenter.Look();
                                Console.WriteLine(this.ProcessLookReturn());
                            }
                            else
                            {
                                Console.WriteLine(this.Message);
                            }
                        }
                        else if (String.Compare(stringShortenedCommand, "e", true, CultureInfo.CurrentCulture) == 0)
                        {
                            this.housePresenter.East();
                            if (this.clearScreen)
                            {
                                Console.Clear();
                            }

                            if (String.IsNullOrEmpty(this.Message.ToString()))
                            {
                                this.afterVerticalMovement = false;
                                this.housePresenter.Look();
                                Console.WriteLine(this.ProcessLookReturn());
                            }
                            else
                            {
                                Console.WriteLine(this.Message);
                            }
                        }
                        else if (String.Compare(stringShortenedCommand, "w", true, CultureInfo.CurrentCulture) == 0)
                        {
                            this.housePresenter.West();
                            if (this.clearScreen)
                            {
                                Console.Clear();
                            }

                            if (String.IsNullOrEmpty(this.Message.ToString()))
                            {
                                this.afterVerticalMovement = false;
                                this.housePresenter.Look();
                                Console.WriteLine(this.ProcessLookReturn());
                            }
                            else
                            {
                                Console.WriteLine(this.Message);
                            }
                        }
                        else if (String.Compare(stringShortenedCommand, "u", true, CultureInfo.CurrentCulture) == 0)
                        {
                            this.housePresenter.Up();
                            if (this.clearScreen)
                            {
                                Console.Clear();
                            }

                            if (String.IsNullOrEmpty(this.Message.ToString()))
                            {
                                this.afterVerticalMovement = true;
                                this.housePresenter.Look();
                                Console.WriteLine(this.ProcessLookReturn());
                            }
                            else
                            {
                                Console.WriteLine(this.Message);
                            }
                        }
                        else if (String.Compare(stringShortenedCommand, "d", true, CultureInfo.CurrentCulture) == 0)
                        {
                            this.housePresenter.Down();
                            if (this.clearScreen)
                            {
                                Console.Clear();
                            }

                            if (String.IsNullOrEmpty(this.Message.ToString()))
                            {
                                this.afterVerticalMovement = true;
                                this.housePresenter.Look();
                                Console.WriteLine(this.ProcessLookReturn());
                            }
                            else
                            {
                                Console.WriteLine(this.Message);
                            }
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
        private string ProcessLookReturn()
        {
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
