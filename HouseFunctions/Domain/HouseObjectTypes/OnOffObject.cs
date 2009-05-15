//-----------------------------------------------------------------------
// <copyright file="OnOffObject.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents an item that can be switched on and off
    /// </summary>
    public class OnOffObject : PortableObject
    {
        /// <summary>
        /// The state of the object
        /// </summary>
        private Switch state = Switch.Off;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnOffObject"/> class.
        /// </summary>
        public OnOffObject()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnOffObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        public OnOffObject(string name)
            : base(name)
        {
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="OnOffObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //// public OnOffObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnOffObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        public OnOffObject(string name, Room room) 
            : base(name, room) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnOffObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="shortName">The short name.</param>
        public OnOffObject(string name, Room room, string shortName) 
            : base(name, room, shortName) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject"></see> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="buried">if set to <c>true</c> item is buried.</param>
        /// <param name="visible">if set to <c>true</c> item is visible.</param>
        public OnOffObject(string name, Room room, bool buried, bool visible)
            : base(name, room, buried, visible)
        {
            
        }

        ////this.shortName = shortName;
        public OnOffObject(string name, Room room, bool buried, bool visible, string shortName)
            : base(name, room, buried, visible, shortName)
        {
            
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public Switch State
        {
            get { return this.state; }
            set { this.state = value; }
        }
    }
}
