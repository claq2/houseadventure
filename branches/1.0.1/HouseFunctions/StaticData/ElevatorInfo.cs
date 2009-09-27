using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ElevatorInfo : NormalRoomInfo
    {

        /// <summary>
        /// Gets or sets up.
        /// </summary>
        /// <value>Up.</value>
        public Floor Up { get; private set; }

        /// <summary>
        /// Gets or sets down.
        /// </summary>
        /// <value>Down.</value>
        public Floor Down { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElevatorInfo"/> class.
        /// </summary>
        public ElevatorInfo() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElevatorInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public ElevatorInfo(string name, int roomNumber, Floor floor, RoomExit[] exits, Floor up, Floor down)
            : base(name, roomNumber, floor, exits)
        {
            this.Up = up;
            this.Down = down;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElevatorInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="word">The word.</param>
        public ElevatorInfo(string name, int roomNumber, Floor floor, RoomExit[] exits, MagicWord word) : base(name, roomNumber, floor, exits, word) { }

        /// <summary>
        /// Creates the room.
        /// </summary>
        /// <returns></returns>
        public override Room2 CreateRoom()
        {
            return new Elevator2(this);
        }

    }
}
