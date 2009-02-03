using System;
using System.Collections.Generic;
using System.Text;

namespace HouseFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class MagicRoom:Room
    {
        private MagicWord magicWordForRoom;

        /// <summary>
        /// Gets or sets the magic word for the room.
        /// </summary>
        /// <value>The magic word for the room.</value>
        public MagicWord MagicWordForRoom
        {
            get { return magicWordForRoom; }
            set { magicWordForRoom = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagicRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="word">The word.</param>
        public MagicRoom(string name, int roomNumber, Floor floor, RoomExit[] exits, MagicWord word)
            : base(name, roomNumber, floor, exits)
        {
            magicWordForRoom = word;
        }

    }
}
