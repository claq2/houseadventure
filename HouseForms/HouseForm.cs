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

        /// <summary>
        /// Brushes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        private void Brush(string item)
        {
            //labelMessage.Text = TheSingletonHouse.Instance.Player.Brush(item);
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
            {
                stringAction = this.listBoxActions.SelectedValue.ToString();
            }

            if (this.listBoxRoomContents.SelectedIndex != -1)
            {
                stringItem = this.listBoxRoomContents.SelectedValue.ToString();
            }

            this.PerformAction(stringAction, stringItem);
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

            MessageBox.Show((Control)sender, this.Message, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, optionsMessage);
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
            this.Argument = item;
            this.housePresenter.Get();
            this.labelMessage.Text = this.Message;
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
            {
                this.labelMessage.Text = this.Message;
                return;
            }

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

        /// <summary>
        /// Moves the player.
        /// </summary>
        /// <param name="direction">The direction.</param>
        private void MovePlayer(Direction direction)
        {
            bool afterVerticalMovement = false;
            if (direction == Direction.Down || direction == Direction.Up)
            {
                afterVerticalMovement = true;
            }

            //if (TheSingletonHouse.Instance.Player.Move(direction))
            //{
            //    this.Look(afterVerticalMovement);
            //}
            //else
            //{
            //    labelMessage.Text = TheHouseData.DisallowedDirectionValue;
            //}
        }

        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="item">The item.</param>
        private void PerformAction(string action, string item)
        {
            if (String.Compare(action, "quit", true, CultureInfo.CurrentCulture) == 0)
            {
            }
            else if (String.Compare(action, "brush", true, CultureInfo.CurrentCulture) == 0)
            {
                this.Brush(item);
            }
            else if (String.Compare(action, "get", true, CultureInfo.CurrentCulture) == 0)
            {
                this.Get(item);
            }
            else
            {
                labelMessage.Text = "I don't understand";
            }
        }

        #endregion Methods

        #region IHouseView Members

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            private get;
            set;
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