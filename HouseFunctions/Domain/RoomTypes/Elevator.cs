using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Elevator : Room
    {
                /// <summary>
        /// Initializes a new instance of the <see cref="Elevator"/> class.
        /// </summary>
        public Elevator() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Elevator(string name) : base(name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public Elevator(string name, int roomNumber, Floor floor)
            : base(name, roomNumber, floor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public Elevator(string name, int roomNumber, Floor floor, RoomExit[] exits)
            : base(name, roomNumber, floor, exits) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        public Elevator(string name, LocationType location, ReadOnlyExitSet exits)
            : base(name, location, exits) { }
    }
}
