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
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void SetMessage(String message);

        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
        IList<string> Inventory { get; }

        /// <summary>
        /// Gets the inventory items short names.
        /// </summary>
        /// <value>The inventory items short names.</value>
        IList<string> InventoryShortNames { get; }

        //TODO: Turn this into a method
        /// <summary>
        /// Sets a value indicating whether the screen should be cleared of information.
        /// </summary>
        /// <value><c>true</c> if the screen should be cleared; otherwise, <c>false</c>.</value>
        Boolean ClearScreen { set;}

        /// <summary>
        /// Gets the argument.
        /// </summary>
        /// <value>The argument.</value>
        String Argument { get; }

        //TODO: Turn this into a method
        /// <summary>
        /// Sets a value indicating whether the game has ended.
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
        /// Gets the items in room short names.
        /// </summary>
        /// <value>The items in room short names.</value>
        IList<string> ItemsInRoomShortNames { get; }

        /// <summary>
        /// Gets the exit directions.
        /// </summary>
        /// <value>The exit directions.</value>
        IList<string> ExitDirections { get; }

        //TODO: Turn this into a method
        /// <summary>
        /// Sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        String RoomName { set; }
    }
}
