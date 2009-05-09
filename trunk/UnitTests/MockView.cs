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

        private HouseType house = new HouseType(true);
        private Player player = new Player();


		// Properties (12) 

        public IList<string> AdversariesInRoom { get; private set; }

        public bool AfterVerticalMovement { get; private set; }

        public string Argument { get; set; }

        public bool ClearScreen { get; set; }

        public IList<string> ExitDirections { get; private set; }

        public bool GameEnded { get; set; }

        public HouseType House
        {
            get
            {
                return this.house;
            }
            set
            {
                this.house = value;
            }
        }

        public InanimateObjectKeyedCollection Inventory { get; set; }

        public IList<string> ItemsInRoom { get; private set; }

        public StringBuilder Message { get; set; }

        public Player Player
        {
            get
            {
                return this.player;
            }
        }

        public string RoomName { get; set; }


		#endregion Data Members 

    }
}
