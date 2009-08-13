namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class UnfinishedFlooredRoom2 : Room2 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom2"/> class.
        /// </summary>
        public UnfinishedFlooredRoom2() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        public UnfinishedFlooredRoom2(string name, int roomNumber, ReadOnlyExitSetCollection exits) : base(name, roomNumber, exits) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">The word.</param>
        public UnfinishedFlooredRoom2(string name, int roomNumber, ReadOnlyExitSetCollection exits, bool magic, MagicWord word)
            : base(name, roomNumber, exits, magic, word)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom2"/> class.
        /// </summary>
        /// <param name="roomInfo">The room info.</param>
        public UnfinishedFlooredRoom2(RoomInfo roomInfo)
            : base(roomInfo)
        {
        }

}
}
