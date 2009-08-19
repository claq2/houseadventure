//-----------------------------------------------------------------------
// <copyright file="MultiplePieceObject.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents an item that cannot be picked up without a container object in hand
    /// </summary>
    public class MultiplePieceObject : PortableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplePieceObject"/> class.
        /// </summary>
        public MultiplePieceObject() 
            : base() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplePieceObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        public MultiplePieceObject(string name) 
            : base(name) 
        { 
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="MultiplePieceObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //// public MultiplePieceObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplePieceObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        public MultiplePieceObject(string name, NormalRoom room) 
            : base(name, room) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplePieceObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="shortName">The short name.</param>
        public MultiplePieceObject(string name, NormalRoom room, string shortName)
            : base(name, room, shortName)
        {
        }
    }
}
