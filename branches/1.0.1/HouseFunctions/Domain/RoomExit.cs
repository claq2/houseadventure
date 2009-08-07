//-----------------------------------------------------------------------
// <copyright file="RoomExit.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{

    /// <summary>
    /// Represents an exit from a room
    /// </summary>
    public class RoomExit
    {

        /// <summary>
        /// Creates a default Exit object
        /// </summary>
        public RoomExit()
        {
        }

        /// <summary>
        /// Creates an Exit object with the indicated Direction and Destination values
        /// </summary>
        /// <param name="direction">The direction the exit leads</param>
        /// <param name="destination">The ID of the room to which the exti leads</param>
        public RoomExit(Direction direction, int destination)
        {
            this.ExitDirection = direction;
            this.ExitDestination = destination;
        }

        /// <summary>
        /// Gets or sets the direction the exit leads
        /// </summary>
        public Direction ExitDirection { get; set; }

        /// <summary>
        /// Gets or sets the ID of the room to which the exit leads
        /// </summary>
        public int ExitDestination { get; set; }

        /// <summary>
        /// String representation of the Exit
        /// </summary>
        /// <returns>Direction enum in string format</returns>
        public override string ToString()
        {
            return this.ExitDirection.ToString();
        }
    }
}
