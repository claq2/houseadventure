//-----------------------------------------------------------------------
// <copyright file="PortableObject.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents an item that can be picked up
    /// </summary>
    public class PortableObject : InanimateObject
    {
        #region Fields (2) 

        /// <summary>
        /// Indicates whether the item is buried
        /// </summary>
        private bool buried;

        /// <summary>
        /// Indicates whether the item is visible
        /// </summary>
        private bool visible = true;

        ///// <summary>
        ///// The item's short name
        ///// </summary>
        //private string shortName;

        #endregion Fields 

        #region Constructors (5) 

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="buried">if set to <c>true</c> item is buried.</param>
        /// <param name="visible">if set to <c>true</c> item is visible.</param>
        public PortableObject(string name, Room room, bool buried, bool visible)
            : base(name, room)
        {
            this.buried = buried;
            this.visible = visible;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="buried">if set to <c>true</c> item is buried.</param>
        /// <param name="visible">if set to <c>true</c> item is visible.</param>
        /// <param name="shortName">The short name.</param>
        public PortableObject(string name, Room room, bool buried, bool visible, string shortName)
            : base(name, room, shortName)
        {
            this.buried = buried;
            this.visible = visible;
            ////this.shortName = shortName;
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="PortableObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        ////public PortableObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject"/> class and adds the item to the items collection of the given room.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        public PortableObject(string name, Room room) : base(name, room)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject"/> class and adds the item to the items collection of the given room.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="shortName">The short name.</param>
        public PortableObject(string name, Room room, string shortName)
            : base(name, room, shortName)
        {
            ////this.shortName = shortName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        public PortableObject(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject"/> class.
        /// </summary>
        public PortableObject()
            : base()
        {
        }

        #endregion Constructors 

        #region Properties (2) 

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PortableObject"/> is buried.
        /// </summary>
        /// <value><c>true</c> if buried; otherwise, <c>false</c>.</value>
        public bool Buried
        {
            get { return this.buried; }
            set { this.buried = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PortableObject"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }

        ///// <summary>
        ///// Gets the short name.
        ///// </summary>
        ///// <value>The short name.</value>
        //public string ShortName
        //{
        //    get { return this.shortName; }
        //}
        #endregion Properties 
    }
}
