//-----------------------------------------------------------------------
// <copyright file="Tests.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
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

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<string> ItemsInRoomShortNames
        {
            get { return this.itemsInRoomShortNames; }
        }

        private List<string> adversariesInRoom = new List<string>();

        public IList<string> AdversariesInRoom
        {
            get { return this.adversariesInRoom; }
        }

        public string Argument { get; set; }

        public bool ClearScreen { get; set; }

        private List<string> exitDirections = new List<string>();

        public IList<string> ExitDirections
        {
            get { return this.exitDirections; }
        }

        public bool GameEnded { get; set; }

        //public HouseType House
        //{
        //    get
        //    {
        //        return this.house;
        //    }
        //    set
        //    {
        //        this.house = value;
        //    }
        //}

        private IList<string> inventory = new List<string>();

        public IList<string> Inventory
        {
            get
            {
                return inventory;
            }
        }

        private IList<string> itemsInRoom = new List<string>();
        public IList<string> ItemsInRoom
        {
            get { return this.itemsInRoom; }
        }

        public string Message { get; set; }

        //public Player Player
        //{
        //    get
        //    {
        //        return this.player;
        //    }
        //}

        public string RoomName { get; set; }

        #endregion Data Members

    }
}
