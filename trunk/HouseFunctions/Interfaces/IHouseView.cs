namespace HouseCore.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections.ObjectModel;

    /// <summary>
    /// IHouseView stuff
    /// </summary>
    public interface IHouseView
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        String Message { set;}

        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
        IList<string> Inventory { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the screen should be cleared of information.
        /// </summary>
        /// <value><c>true</c> if the screen should be cleared; otherwise, <c>false</c>.</value>
        Boolean ClearScreen { set;}

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        String Argument { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the game has ended.
        /// </summary>
        /// <value><c>true</c> if the game has ended; otherwise, <c>false</c>.</value>
        Boolean GameEnded { set;}

        /// <summary>
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        IList<string> AdversariesInRoom { get; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        IList<string> ItemsInRoom { get; }

        /// <summary>
        /// Gets the exit directions.
        /// </summary>
        /// <value>The exit directions.</value>
        IList<string> ExitDirections { get; }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        String RoomName { set; }
    }
}
