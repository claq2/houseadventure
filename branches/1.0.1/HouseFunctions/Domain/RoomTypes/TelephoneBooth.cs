using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class TelephoneBooth : Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneBooth"/> class.
        /// </summary>
        public TelephoneBooth() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneBooth"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public TelephoneBooth(string name) : base(name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneBooth"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public TelephoneBooth(string name, int roomNumber, Floor floor)
            : base(name, roomNumber, floor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneBooth"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public TelephoneBooth(string name, int roomNumber, Floor floor, RoomExit[] exits)
            : base(name, roomNumber, floor, exits) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneBooth"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">if set to <c>true</c> [magic].</param>
        public TelephoneBooth(string name, int roomNumber, Floor floor, RoomExit[] exits, bool magic, MagicWord word)
             : base(name, roomNumber, floor, exits, magic, word) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneBooth"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">The word.</param>
        public TelephoneBooth(string name, LocationType location, ReadOnlyExitSetCollection exits, bool magic, MagicWord word)
            : base(name, location, exits, magic, word)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneBooth"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        public TelephoneBooth(string name, LocationType location, ReadOnlyExitSetCollection exits)
            : base(name, location, exits) { }

    }
}
