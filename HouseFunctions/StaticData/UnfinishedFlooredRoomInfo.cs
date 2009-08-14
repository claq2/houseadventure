namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Contains readonly information for creating UnfinishedFlooredRoom objects
    /// </summary>
    public class UnfinishedFlooredRoomInfo : RoomInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoomInfo"/> class.
        /// </summary>
        public UnfinishedFlooredRoomInfo() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoomInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public UnfinishedFlooredRoomInfo(string name, int roomNumber, Floor floor, RoomExit[] exits)
            : base(name, roomNumber, floor, exits)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoomInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="word">The word.</param>
        public UnfinishedFlooredRoomInfo(string name, int roomNumber, Floor floor, RoomExit[] exits, MagicWord word) : base(name, roomNumber, floor, exits, word) { }
    }
}
