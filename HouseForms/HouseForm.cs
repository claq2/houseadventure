//-----------------------------------------------------------------------
// <copyright file="HouseForm.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

[assembly: System.CLSCompliant(true)]
namespace HouseForms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Globalization;
    using HouseCore;
    using HouseCore.Interfaces;
    using HouseCore.Presenters;

    /// <summary>
    /// The Form
    /// </summary>
    public partial class FormHouse : Form, IHouseView
    {

        /// <summary>
        /// The presenter for actions
        /// </summary>
        private HousePresenter housePresenter;

        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="FormHouse"/> class.
        /// </summary>
        public FormHouse()
        {
            InitializeComponent();
            this.housePresenter = new HousePresenter(this);
        }

        #endregion Constructors

        #region Methods (17)

        // Private Methods (17) 

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

        /// <summary>
        /// Brushes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        private void Brush(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Brush();
        }

        /// <summary>
        /// Handles the Click event of the buttonDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonDown_Click(object sender, EventArgs e)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.ProcessLook(this.housePresenter.Down());
        }

        /// <summary>
        /// Handles the Click event of the buttonEast control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonEast_Click(object sender, EventArgs e)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.ProcessLook(this.housePresenter.East());
        }

        /// <summary>
        /// Handles the Click event of the buttonInventory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonInventory_Click(object sender, EventArgs e)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.housePresenter.PopulateInventory();
            this.listBoxInventory.DataSource = this.Inventory;
        }

        /// <summary>
        /// Handles the Click event of the buttonLook control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonLook_Click(object sender, EventArgs e)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.housePresenter.Look();
            this.ProcessLook(true);
        }

        /// <summary>
        /// Handles the Click event of the buttonNorth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonNorth_Click(object sender, EventArgs e)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.ProcessLook(this.housePresenter.North());
        }

        /// <summary>
        /// Handles the Click event of the buttonPerformAction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonPerformAction_Click(object sender, EventArgs e)
        {
            string stringAction = String.Empty;
            string stringItem = String.Empty;
            if (this.listBoxActions.SelectedIndex != -1)
                stringAction = this.listBoxActions.SelectedValue.ToString();
            else
                MessageBox.Show("Please select an action from the Actions list");

            this.PerformAction(stringAction);
        }

        /// <summary>
        /// Handles the Click event of the buttonQuit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.housePresenter.Quit();
            MessageBoxOptions optionsMessage = (MessageBoxOptions)0;
            if (IsRightToLeft((IWin32Window)sender))
            {
                optionsMessage |= MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
            }

            MessageBox.Show((Control)sender, this.labelMessage.Text, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, optionsMessage);
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the buttonSouth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonSouth_Click(object sender, EventArgs e)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.ProcessLook(this.housePresenter.South());
        }

        /// <summary>
        /// Handles the Click event of the buttonUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonUp_Click(object sender, EventArgs e)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.ProcessLook(this.housePresenter.Up());
        }

        /// <summary>
        /// Handles the Click event of the buttonWest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonWest_Click(object sender, EventArgs e)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.ProcessLook(this.housePresenter.West());
        }

        private void ClearBoxes()
        {
            this.listBoxInventory.DataSource = null;
            this.listBoxInventory.Items.Clear();
            this.listBoxRoomContents.DataSource = null;
            this.listBoxRoomContents.Items.Clear();
            this.listBoxExits.DataSource = null;
            this.listBoxExits.Items.Clear();
            this.labelMessage.Text = String.Empty;
        }

        /// <summary>
        /// Handles the Load event of the FormHouse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FormHouse_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            bool bDebugMode = false;
            MessageBoxOptions optionsImpostorMessage = (MessageBoxOptions)0;
            if (IsRightToLeft((IWin32Window)sender))
            {
                optionsImpostorMessage |= MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
            }
            //MessageBox.Show("last");
            MessageBox.Show((Control)sender, "House Adventure\r\n\r\nRemember the Impostor is last\r\n", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, optionsImpostorMessage);

            foreach (string arg in args)
            {
                if (String.Compare(arg, "debug", true, CultureInfo.CurrentCulture) == 0)
                {
                    bDebugMode = true;
                }
            }

            this.listBoxActions.DataSource = TheHouseData.Actions;
            this.housePresenter.IncrementNumberOfMoves();
            this.labelMessage.Text = String.Empty;
            this.housePresenter.Look();
            this.ProcessLook(true);
        }

        /// <summary>
        /// Gets the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        private void Get(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Get();
        }

        /// <summary>
        /// Determines whether [is right to left] [the specified owner].
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>
        /// 	<c>true</c> if [is right to left] [the specified owner]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsRightToLeft(IWin32Window owner)
        {
            Control control = owner as Control;
            //using (Control control = owner as Control)
            //{
            if (control != null)
                return control.RightToLeft == RightToLeft.Yes;
            //}

            // If no parent control is available, ask the CurrentUICulture
            // if we are running under right-to-left.
            return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
        }

        /// <summary>
        /// Looks this instance.
        /// </summary>
        /// <param name="successfulMovementOrManualLook">if set to <c>true</c> [successful movement].</param>
        private void ProcessLook(bool successfulMovementOrManualLook)
        {
            if (this.ClearScreen)
            {
                this.ClearBoxes();
            }

            if (!successfulMovementOrManualLook)
                return;

            List<string> itemsInRoom = new List<string>();
            foreach (string adversary in this.AdversariesInRoom)
            {
                itemsInRoom.Add(adversary);
            }

            foreach (string inanimateObject in this.ItemsInRoom)
            {
                itemsInRoom.Add(inanimateObject);
            }

            this.listBoxRoomContents.DataSource = itemsInRoom;
            this.listBoxExits.DataSource = this.ExitDirections;
        }

        private void Drop(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Drop();
        }

        private void Say(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Say();
        }

        private void Stab(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Stab();
        }

        private void Light()
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.housePresenter.Light();
        }

        private void Play(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Play();
        }

        private void Read(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Read();
        }

        private void Dig(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Dig();
        }

        private void On()
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = "on";
            this.housePresenter.Light();
        }

        private void Off()
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = "off";
            this.housePresenter.Light();
        }

        private void Wave(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Wave();
        }

        private void Open(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Open();
        }

        private void Spray(string item)
        {
            this.housePresenter.IncrementNumberOfMoves();
            this.Argument = item;
            this.housePresenter.Spray();
        }

        private void PerformRoomItemAction(string action)
        {
            if (this.listBoxRoomContents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item in the room.");
                return;
            }

            if (String.Compare(action, "brush", true, CultureInfo.CurrentCulture) == 0)
                this.Brush(this.ItemsInRoomShortNames[this.listBoxRoomContents.SelectedIndex]);
            else if (String.Compare(action, "get", true, CultureInfo.CurrentCulture) == 0)
                this.Get(this.ItemsInRoomShortNames[this.listBoxRoomContents.SelectedIndex]);
            else if (String.Compare(action, "kill", true, CultureInfo.CurrentCulture) == 0 || String.Compare(action, "stab", true, CultureInfo.CurrentCulture) == 0)
                this.Stab(this.ItemsInRoomShortNames[this.listBoxRoomContents.SelectedIndex]);
            else if (String.Compare(action, "spray", true, CultureInfo.CurrentCulture) == 0)
                this.Spray(this.ItemsInRoomShortNames[this.listBoxRoomContents.SelectedIndex]);
            else if (String.Compare(action, "unlock", true, CultureInfo.CurrentCulture) == 0 || String.Compare(action, "open", true, CultureInfo.CurrentCulture) == 0)
                this.Open(this.ItemsInRoomShortNames[this.listBoxRoomContents.SelectedIndex]);

        }

        private void PerformNonArgumentAction(string action)
        {
            if (String.Compare(action, "light", true, CultureInfo.CurrentCulture) == 0)
                this.Light();
            else if (String.Compare(action, "on", true, CultureInfo.CurrentCulture) == 0)
                this.On();
            else if (String.Compare(action, "off", true, CultureInfo.CurrentCulture) == 0)
                this.Off();

        }

        private void PerformInventoryAction(string action)
        {
            if (this.listBoxInventory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item in the inventory.");
                return;
            }

            if (String.Compare(action, "drop", true, CultureInfo.CurrentCulture) == 0)
                this.Drop(this.InventoryShortNames[this.listBoxInventory.SelectedIndex]);
            else if (String.Compare(action, "play", true, CultureInfo.CurrentCulture) == 0)
                this.Play(this.InventoryShortNames[this.listBoxInventory.SelectedIndex]);
            else if (String.Compare(action, "read", true, CultureInfo.CurrentCulture) == 0)
                this.Read(this.InventoryShortNames[this.listBoxInventory.SelectedIndex]);
            else if (String.Compare(action, "wave", true, CultureInfo.CurrentCulture) == 0)
                this.Wave(this.InventoryShortNames[this.listBoxRoomContents.SelectedIndex]);
        }

        private void PerformFreeFormArgumentAction(string action)
        {
            using (Input input = new Input(action))
            {
                DialogResult result = input.ShowDialog(this);
                if (result == DialogResult.OK)
                    if (String.Compare(action, "say", true, CultureInfo.CurrentCulture) == 0)
                        this.Say(input.Argument);
                    else
                        if (String.Compare(action, "dig", true, CultureInfo.CurrentCulture) == 0)
                            this.Dig(input.Argument);
            }
        }

        ///// <summary>
        ///// Moves the player.
        ///// </summary>
        ///// <param name="direction">The direction.</param>
        //private void MovePlayer(Direction direction)
        //{
        //    bool afterVerticalMovement = false;
        //    if (direction == Direction.Down || direction == Direction.Up)
        //    {
        //        afterVerticalMovement = true;
        //    }

        //    //if (TheSingletonHouse.Instance.Player.Move(direction))
        //    //{
        //    //    this.Look(afterVerticalMovement);
        //    //}
        //    //else
        //    //{
        //    //    labelMessage.Text = TheHouseData.DisallowedDirectionValue;
        //    //}
        //}

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="action">The action.</param>
        private void PerformAction(string action)
        {
            if (TheHouseData.RoomItemActions.Contains(action))
            {
                this.PerformRoomItemAction(action);
                return;
            }

            if (TheHouseData.NonArgumentActions.Contains(action))
            {
                this.PerformNonArgumentAction(action);
                return;
            }

            if (TheHouseData.InventoryActions.Contains(action))
            {
                this.PerformInventoryAction(action);
                return;
            }

            if (TheHouseData.FreeformArgumentActions.Contains(action))
            {
                this.PerformFreeFormArgumentAction(action);
                return;
            }

            labelMessage.Text = "I don't understand";
        }

        #endregion Methods

        #region IHouseView Members

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            set
            {
                this.labelMessage.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [clear screen].
        /// </summary>
        /// <value><c>true</c> if [clear screen]; otherwise, <c>false</c>.</value>
        public bool ClearScreen { private get; set; }

        ///// <summary>
        ///// Gets or sets the house.
        ///// </summary>
        ///// <value>The house.</value>
        //public HouseType House
        //{
        //    get
        //    {
        //        throw new NotImplementedException("The method or operation is not implemented.");
        //    }
        //    set
        //    {
        //        throw new NotImplementedException("The method or operation is not implemented.");
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the player.
        ///// </summary>
        ///// <value>The player.</value>
        //public Player Player
        //{
        //    get
        //    {
        //        throw new NotImplementedException("The method or operation is not implemented.");
        //    }
        //    set
        //    {
        //        throw new NotImplementedException("The method or operation is not implemented.");
        //    }
        //}

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        public string Argument { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether [game ended].
        /// </summary>
        /// <value><c>true</c> if [game ended]; otherwise, <c>false</c>.</value>
        public bool GameEnded { private get; set; }

        private IList<string> adversariesInRoom = new List<string>();

        /// <summary>
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public IList<string> AdversariesInRoom
        {
            get { return this.adversariesInRoom; }
        }

        private IList<string> itemsInRoom = new List<string>();

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

        private IList<string> exitDirections = new List<string>();

        /// <summary>
        /// Gets the exit directions.
        /// </summary>
        /// <value>The exit directions.</value>
        public IList<string> ExitDirections
        {
            get { return this.exitDirections; }
        }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        public string RoomName
        {
            set
            {
                this.labelLocation.Text = value;
            }
        }

        #endregion

    }
}