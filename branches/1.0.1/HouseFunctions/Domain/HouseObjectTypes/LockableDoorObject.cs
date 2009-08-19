//-----------------------------------------------------------------------
// <copyright file="LockableDoorObject.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents a locked door
    /// </summary>
    public class LockableDoorObject : StationaryObject
    {
        /// <summary>
        /// The exit that is added to the room when the door is unlocked
        /// </summary>
        private RoomExit exitWhenUnlocked;

        ///// <summary>
        ///// The item's short name
        ///// </summary>
        //private string shortName;

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObject"/> class.
        /// </summary>
        public LockableDoorObject() 
            : base() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        public LockableDoorObject(string name) 
            : base(name) 
        { 
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="LockableObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //// public LockableObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        public LockableDoorObject(string name, NormalRoom room) 
            : base(name, room) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="exit">The exit that is added to the room when the door is unlocked.</param>
        public LockableDoorObject(string name, NormalRoom room, RoomExit exit)
            : base(name, room)
        {
            this.exitWhenUnlocked = exit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The name of the room.</param>
        /// <param name="exit">The exit that is added to the room when the door is unlocked.</param>
        /// <param name="shortName">The short name.</param>
        public LockableDoorObject(string name, NormalRoom room, RoomExit exit, string shortName)
            : base(name, room, shortName)
        {
            this.exitWhenUnlocked = exit;
            ////this.shortName = shortName;
        }

        /// <summary>
        /// Gets or sets the exit when unlocked.
        /// </summary>
        /// <value>The exit when unlocked.</value>
        public RoomExit ExitWhenUnlocked
        {
            get { return this.exitWhenUnlocked; }
            set { this.exitWhenUnlocked = value; }
        }

        ///// <summary>
        ///// Gets the short name.
        ///// </summary>
        ///// <value>The short name.</value>
        //public string ShortName
        //{
        //    get { return this.shortName; }
        //}
    }
}
