//-----------------------------------------------------------------------
// <copyright file="ILookAction.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseFunctions.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Members involved in performing a look action
    /// </summary>
    public interface ILookAction : IGameEndingAction
    {
        /// <summary>
        /// Gets a value indicating whether the look action preceeded a vertical movement
        /// </summary>
        bool AfterVerticalMovement { get; }

        /// <summary>
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        IList<string> Adversaries { get; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        IList<string> Items { get; }

        /// <summary>
        /// Gets the exit directions.
        /// </summary>
        /// <value>The exit directions.</value>
        IList<string> ExitDirections { get; }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        string RoomName { get; set; }
    }
}
