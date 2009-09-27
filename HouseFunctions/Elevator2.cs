using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Elevator2 : Room2
    {
        private Floor _Up;
        /// <summary>
        /// Gets or sets room above.
        /// </summary>
        /// <value>Up.</value>
        public Floor Up
        {
            get { return _Up; }
            set
            {
                _Up = value;
                this.connectingFloors[DirectionConstants.Up] = this._Up;
            }
        }

        private Floor _Down;
        /// <summary>
        /// Gets or sets room below.
        /// </summary>
        /// <value>Down.</value>
        public Floor Down
        {
            get { return _Down; }
            set
            {
                _Down = value;
                this.connectingFloors[DirectionConstants.Down] = this._Down;
            }
        }

        private Dictionary<DirectionConstants, Floor> connectingFloors = new Dictionary<DirectionConstants, Floor>();

        private void InitializeFloors()
        {
            this._Up = Floor.Undefined;
            this.connectingFloors.Add(DirectionConstants.Up, this._Up);
            this._Down = Floor.Undefined;
            this.connectingFloors.Add(DirectionConstants.Down, this._Down);
        }

        /// <summary>
        /// Gets the floor in the given direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>Floor that is in the given direction</returns>
        public Floor GetFloorInDirection(DirectionConstants direction)
        {
            return this.connectingFloors[direction];
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator2"/> class.
        /// </summary>
        public Elevator2() : base() { this.InitializeFloors(); }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        public Elevator2(string name, int roomNumber, ReadOnlyExitSetCollection exits) : base(name, roomNumber, exits) { this.InitializeFloors(); }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">The word.</param>
        public Elevator2(string name, int roomNumber, ReadOnlyExitSetCollection exits, bool magic, MagicWord word)
            : base(name, roomNumber, exits, magic, word)
        {
            this.InitializeFloors();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator2"/> class.
        /// </summary>
        /// <param name="roomInfo">The room info.</param>
        public Elevator2(ElevatorInfo roomInfo)
            : base(roomInfo)
        {
            this.InitializeFloors();
            this.Up = roomInfo.Up;
            this.Down = roomInfo.Down;
        }

    }
}
