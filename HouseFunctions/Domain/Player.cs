//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Object in which to store the player's state
    /// </summary>
    public class Player : PositionedEntity
    {
        #region Fields (4) 

        /// <summary>
        /// Private instance of the inventory
        /// </summary>
        //private InanimateObjectKeyedCollection inventory;

        /// <summary>
        /// Number of items removes from the house
        /// </summary>
        private int itemsRemovedFromHouse;

        /// <summary>
        /// Number of attempted actions
        /// </summary>
        private int numberOfMoves;

        /// <summary>
        /// Number of times player has looked in the dark
        /// </summary>
        private int timesLookedInDark;

        #endregion Fields

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player()
        {
            //this.inventory = new InanimateObjectKeyedCollection();
            Location.Floor = Floor.FirstFloor;
            Location.RoomNumber = 1;
        }

        #endregion Constructors 

        #region Properties (4) 

        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
     //   public InanimateObjectKeyedCollection Inventory
      //  {
       //     get { return this.inventory; }
       // }

        /// <summary>
        /// Gets or sets the items removed from house.
        /// </summary>
        /// <value>The items removed from house.</value>
        public int ItemsRemovedFromHouse
        {
            get { return this.itemsRemovedFromHouse; }
            set { this.itemsRemovedFromHouse = value; }
        }

        /// <summary>
        /// Gets or sets the number of moves.
        /// </summary>
        /// <value>The number of moves.</value>
        public int NumberOfMoves
        {
            get { return this.numberOfMoves; }
            set { this.numberOfMoves = value; }
        }

        /// <summary>
        /// Gets or sets the times looked in dark.
        /// </summary>
        /// <value>The times looked in dark.</value>
        public int TimesLookedInDark
        {
            get { return this.timesLookedInDark; }
            set { this.timesLookedInDark = value; }
        }

        #endregion Properties 
    }
}
