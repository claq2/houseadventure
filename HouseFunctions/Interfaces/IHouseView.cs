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
        StringBuilder Message { get; set;}

        /// <summary>
        /// Gets or sets a value indicating whether [clear screen].
        /// </summary>
        /// <value><c>true</c> if [clear screen]; otherwise, <c>false</c>.</value>
        Boolean ClearScreen { get; set;}

        /// <summary>
        /// Gets or sets the house.
        /// </summary>
        /// <value>The house.</value>
        HouseType House { get;}// set;}

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>The player.</value>
        //Player Player { get; set;}

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        String Argument { get; set;}

        /// <summary>
        /// Gets or sets a value indicating whether [game ended].
        /// </summary>
        /// <value><c>true</c> if [game ended]; otherwise, <c>false</c>.</value>
        Boolean GameEnded { get;set;}

        /// <summary>
        /// Gets a value indicating whether the look action preceeded a vertical movement
        /// </summary>
        Boolean AfterVerticalMovement { get; }

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
        String RoomName { get; set; }
    }
}
