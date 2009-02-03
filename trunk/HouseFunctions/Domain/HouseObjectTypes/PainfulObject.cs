//-----------------------------------------------------------------------
// <copyright file="PainfulObject.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents an item that can cannot be handled without a protective object
    /// </summary>
    public class PainfulObject : PortableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PainfulObject"/> class.
        /// </summary>
        public PainfulObject() 
            : base() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PainfulObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        public PainfulObject(string name) 
            : base(name) 
        { 
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="PainfulObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //// public PainfulObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PainfulObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        public PainfulObject(string name, Room room)
            : base(name, room) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PainfulObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="shortName">The short name.</param>
        public PainfulObject(string name, Room room, string shortName) 
            : base(name, room, shortName) 
        { 
        }
    }
}
