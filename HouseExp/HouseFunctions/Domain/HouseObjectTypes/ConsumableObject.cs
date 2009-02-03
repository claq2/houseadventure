//-----------------------------------------------------------------------
// <copyright file="ConsumableObject.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    /// <summary>
    /// Class that represents an item that can be used a limited number of time
    /// </summary>
    public class ConsumableObject : PortableObject
    {
        /// <summary>
        /// The usage limit
        /// </summary>
        private int usageLimit;

        /// <summary>
        /// The number of times the item has been used
        /// </summary>
        private int timesUsed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject"/> class.
        /// </summary>
        public ConsumableObject() 
            : base() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        public ConsumableObject(string name) 
            : base(name) 
        { 
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="ConsumableObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //// public ConsumableObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The initial room.</param>
        public ConsumableObject(string name, Room room) 
            : base(name, room) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject"/> class.
        /// </summary>
        /// <param name="name">The display name of the item.</param>
        /// <param name="room">The initial room.</param>
        /// <param name="usageLimit">The usage limit.</param>
        public ConsumableObject(string name, Room room, int usageLimit)
            : base(name, room)
        {
            this.usageLimit = usageLimit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="room">The initial room.</param>
        /// <param name="usageLimit">The usage limit.</param>
        /// <param name="shortName">The short name.</param>
        public ConsumableObject(string name, Room room, int usageLimit, string shortName)
            : base(name, room, shortName)
        {
            this.usageLimit = usageLimit;
        }

        /// <summary>
        /// Gets or sets the usage limit.
        /// </summary>
        /// <value>The usage limit.</value>
        public int UsageLimit
        {
            get { return this.usageLimit; }
            set { this.usageLimit = value; }
        }

        /// <summary>
        /// Gets or sets the times used.
        /// </summary>
        /// <value>The times used.</value>
        public int TimesUsed
        {
            get { return this.timesUsed; }
            set { this.timesUsed = value; }
        }

        /// <summary>
        /// Increments the times used.
        /// </summary>
        public void IncrementTimesUsed()
        {
            this.timesUsed++;
        }
    }
}
