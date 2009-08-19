//-----------------------------------------------------------------------
// <copyright file="NormalRoom2.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System.Xml.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(UnfinishedFlooredRoom2))]
    [XmlInclude(typeof(TelephoneBooth2))]
    public class NormalRoom2 : Room2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom2"/> class.
        /// </summary>
        public NormalRoom2()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public NormalRoom2(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        public NormalRoom2(string name, int roomNumber)
            : base(name, roomNumber)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        public NormalRoom2(string name, int roomNumber, RoomExit[] exits)
            : base(name, roomNumber, exits)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        public NormalRoom2(string name, int roomNumber, ReadOnlyExitSetCollection exits)
            : base(name, roomNumber, exits)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> room is magic.</param>
        /// <param name="word">The word.</param>
        public NormalRoom2(string name, int roomNumber, RoomExit[] exits, bool magic, MagicWord word)
            : base(name, roomNumber, exits, magic, word)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">The word.</param>
        public NormalRoom2(string name, int roomNumber, ReadOnlyExitSetCollection exits, bool magic, MagicWord word)
            : base(name, roomNumber, exits, magic, word)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom2"/> class.
        /// </summary>
        /// <param name="roomInfo">The room info.</param>
        public NormalRoom2(NormalRoomInfo roomInfo)
            : base(roomInfo)
        {
        }
    }
}
