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

    /// <summary>
    /// The Form
    /// </summary>
    public partial class FormHouse : Form, IHouseView
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="FormHouse"/> class.
        /// </summary>
        public FormHouse()
        {
            InitializeComponent();
        }

        #endregion Constructors 

        #region Methods (17) 

        // Private Methods (17) 

        public InanimateObjectKeyedCollection Inventory { get; private set; }

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
            this.MovePlayer(Direction.Down);
        }

        /// <summary>
        /// Handles the Click event of the buttonEast control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonEast_Click(object sender, EventArgs e)
        {
            this.MovePlayer(Direction.East);
        }

        /// <summary>
        /// Handles the Click event of the buttonInventory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonInventory_Click(object sender, EventArgs e)
        {
            //this.listBoxInventory.DataSource = TheSingletonHouse.Instance.Player.Inventory;
            this.listBoxInventory.Items.Add("1");
            this.listBoxInventory.Items.Add("2");
        }

        /// <summary>
        /// Handles the Click event of the buttonLook control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonLook_Click(object sender, EventArgs e)
        {
            this.PerformAction("look", String.Empty);
        }

        /// <summary>
        /// Handles the Click event of the buttonNorth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonNorth_Click(object sender, EventArgs e)
        {
            this.MovePlayer(Direction.North);
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
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the buttonSouth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonSouth_Click(object sender, EventArgs e)
        {
            this.MovePlayer(Direction.South);
        }

        /// <summary>
        /// Handles the Click event of the buttonUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonUp_Click(object sender, EventArgs e)
        {
            this.MovePlayer(Direction.Up);
        }

        /// <summary>
        /// Handles the Click event of the buttonWest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonWest_Click(object sender, EventArgs e)
        {
            this.MovePlayer(Direction.West);
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

            listBoxActions.DataSource = TheHouseData.Actions;

            labelMessage.Text = String.Empty;
            this.Look(false);
        }

        /// <summary>
        /// Gets the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        private void Get(string item)
        {
            //GetHelper getHelper = TheSingletonHouse.Instance.Player.Get(item);
            //labelMessage.Text = getHelper.Output;
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
        /// <param name="afterVerticalMovement">if set to <c>true</c> [after vertical movement].</param>
        private void Look(bool afterVerticalMovement)
        {
            //LookHelper lookHelper = TheSingletonHouse.Instance.Player.Look(afterVerticalMovement);

            //labelLocation.Text = lookHelper.RoomName;
            //listBoxRoomContents.DataSource = lookHelper.Items;
            //listBoxExits.DataSource = lookHelper.ExitDirections;
            //labelMessage.Text = lookHelper.Output;
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
            else if (String.Compare(action, "look", true, CultureInfo.CurrentCulture) == 0)
            {
                this.Look(false);
            }
            else
            {
                labelMessage.Text = "I don't understand";
            }
        }

		#endregion Methods 
    
        #region IHouseView Members

        public StringBuilder Message
        {
            get
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
            set
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
        }

        public bool ClearScreen
        {
            get
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
            set
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
        }

        public HouseType House
        {
            get
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
            set
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
        }

        public Player Player
        {
            get
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
            set
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
        }

        public string Argument
        {
            get
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
            set
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
        }

        public bool GameEnded
        {
            get
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
            set
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
        }

        public bool AfterVerticalMovement
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public IList<string> AdversariesInRoom
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public IList<string> ItemsInRoom
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public IList<string> ExitDirections
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        public string RoomName
        {
            get
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
            set
            {
                throw new NotImplementedException("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}