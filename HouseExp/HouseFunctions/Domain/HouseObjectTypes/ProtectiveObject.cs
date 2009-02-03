//-----------------------------------------------------------------------
// <copyright file="ProtectiveObject.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents an item allows getting a painful object
    /// </summary>
    public class ProtectiveObject : PortableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtectiveObject"/> class.
        /// </summary>
        public ProtectiveObject() 
            : base() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtectiveObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        public ProtectiveObject(string name) 
            : base(name) 
        { 
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="ProtectiveObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //// public ProtectiveObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtectiveObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        public ProtectiveObject(string name, Room room) 
            : base(name, room) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtectiveObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="buried">if set to <c>true</c> item is buried.</param>
        /// <param name="visible">if set to <c>true</c> item is visible.</param>
        public ProtectiveObject(string name, Room room, bool buried, bool visible)
            : base(name, room, buried, visible) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtectiveObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="buried">if set to <c>true</c> item is buried.</param>
        /// <param name="visible">if set to <c>true</c> item is visible.</param>
        /// <param name="shortName">The short name.</param>
        public ProtectiveObject(string name, Room room, bool buried, bool visible, string shortName)
            : base(name, room, buried, visible, shortName)
        {
        }
    }
}
