using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class StationaryObject : InanimateObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StationaryObject"/> class.
        /// </summary>
        public StationaryObject() 
            : base() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationaryObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public StationaryObject(string name) 
            : base(name) 
        { 
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="UnportableObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //public UnportableObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationaryObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        public StationaryObject(string name, Room room) 
            : base(name, room) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationaryObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        /// <param name="shortName">The short name.</param>
        public StationaryObject(string name, Room room, string shortName) 
            : base(name, room, shortName) 
        { 
        }

    }
}
