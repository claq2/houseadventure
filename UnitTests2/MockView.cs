//-----------------------------------------------------------------------
// <copyright file="Tests.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests2
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HouseCore;
    using HouseCore.Interfaces;

    /// <summary>
    /// A mock version of the view
    /// </summary>
    public class MockView : IHouseView
    {

        #region Data Members (14)


        // Fields (2) 

        //private HouseType house = new HouseType(true);
        //private Player player = new Player();


        // Properties (12) 

        private IList<string> itemsInRoomShortNames = new List<string>();

        private string message;

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<string> ItemsInRoomShortNames
        {
            get { return this.itemsInRoomShortNames; }
        }

        private List<string> adversariesInRoom = new List<string>();

        /// <summary>
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public IList<string> AdversariesInRoom
        {
            get { return this.adversariesInRoom; }
        }

        /// <summary>
        /// Gets the argument.
        /// </summary>
        /// <value>The argument.</value>
        public string Argument { get; set; }

        /// <summary>
        /// Sets a value indicating whether the screen should be cleared of information.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the screen should be cleared; otherwise, <c>false</c>.
        /// </value>
        public bool ClearScreen { set; get; }

        private List<string> exitDirections = new List<string>();

        /// <summary>
        /// Gets the exit directions.
        /// </summary>
        /// <value>The exit directions.</value>
        public IList<string> ExitDirections
        {
            get { return this.exitDirections; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the game has ended.
        /// </summary>
        /// <value><c>true</c> if the game has ended; otherwise, <c>false</c>.</value>
        public bool GameEnded { set; get; }

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

        private IList<string> itemsInRoom = new List<string>();

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<string> ItemsInRoom
        {
            get { return this.itemsInRoom; }
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get { return this.message; }
        }

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SetMessage(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        public string RoomName { set; get; }

        #endregion Data Members

    }
}
