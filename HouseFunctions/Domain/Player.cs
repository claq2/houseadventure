//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;

    /// <summary>
    /// Object in which to store the player's state
    /// </summary>
    public class Player : PositionedEntity
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player()
        {
            //this.inventory = new InanimateObjectKeyedCollection();
            this.Location = new LocationType(1, Floor.FirstFloor);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionedEntity"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected Player(string name)
            : base(name)
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionedEntity"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        protected Player(string name, int roomNumber, Floor floor)
            : base(name, roomNumber, floor)
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionedEntity"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        protected Player(string name, LocationType location)
            : base(name, location)
        {
            
        }
         

        #endregion Constructors 

        #region Properties (4) 

        /// <summary>
        /// Gets or sets the items removed from house.
        /// </summary>
        /// <value>The items removed from house.</value>
        public int ItemsRemovedFromHouse { get; set; }

        /// <summary>
        /// Gets or sets the number of moves.
        /// </summary>
        /// <value>The number of moves.</value>
        public int NumberOfMoves { get; set; }

        /// <summary>
        /// Gets or sets the times looked in dark.
        /// </summary>
        /// <value>The times looked in dark.</value>
        public int TimesLookedInDark { get; set; }

        #endregion Properties 
    }
}
