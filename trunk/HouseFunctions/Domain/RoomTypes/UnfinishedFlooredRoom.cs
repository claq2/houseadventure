using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class UnfinishedFlooredRoom : Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom"/> class.
        /// </summary>
        public UnfinishedFlooredRoom() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public UnfinishedFlooredRoom(string name) : base(name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public UnfinishedFlooredRoom(string name, int roomNumber, Floor floor)
            : base(name, roomNumber, floor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public UnfinishedFlooredRoom(string name, int roomNumber, Floor floor, RoomExit[] exits)
            : base(name, roomNumber, floor, exits) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        public UnfinishedFlooredRoom(string name, LocationType location, ReadOnlyExitSetCollection exits)
            : base(name, location, exits) { }
    }
}
