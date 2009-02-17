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
		#region Data Members (22) 

		// Fields (11) 

        private List<string> adversariesInRoom;
        private bool afterVerticalMovement;
        private string argument;
        private bool clearScreen;
        private List<string> exitDirections;
        private bool gameEnded;
        private HouseType house = new HouseType(true);
        private List<string> itemsInRoom;
        private StringBuilder message;
        private Player player = new Player();
        private string roomName;


		// Properties (11) 

        public IList<string> AdversariesInRoom
        {
            get { return this.adversariesInRoom; }
        }

        public bool AfterVerticalMovement
        {
            get { return this.afterVerticalMovement; }
        }

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

        public IList<string> ExitDirections
        {
            get { return this.exitDirections; }
        }

        public bool GameEnded
        {
            get
            {
                return this.gameEnded;
            }
            set
            {
                this.gameEnded = value;
            }
        }

        public HouseCore.HouseType House
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

        public IList<string> ItemsInRoom
        {
            get { return this.itemsInRoom; }
        }

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

        public HouseCore.Player Player
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

        public string RoomName
        {
            get
            {
                return this.roomName;
            }
            set
            {
                this.roomName = value;
            }
        }


		#endregion Data Members 

    }
}
