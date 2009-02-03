//-----------------------------------------------------------------------
// <copyright file="GameEndingActionPresenter.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseFunctions.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using HouseFunctions.Interfaces;

    /// <summary>
    /// Presents the actions that can be performed on an <see cref="IGameEndingAction"/> view
    /// </summary>
    public class GameEndingActionPresenter
    {
        /// <summary>
        /// The view upon which to act.
        /// </summary>
        private IGameEndingAction view;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEndingActionPresenter"/> class.
        /// </summary>
        /// <param name="view">The view upon which to act.</param>
        public GameEndingActionPresenter(IGameEndingAction view)
        {
            this.view = view;
        }

        /// <summary>
        /// Quits this instance.
        /// </summary>
        public void Quit()
        {
            this.view.Message = new StringBuilder();
            this.view.Message.Append(String.Format(CultureInfo.CurrentCulture, "You got {0} items out of the house in {1} moves", this.view.Player.ItemsRemovedFromHouse, this.view.Player.NumberOfMoves));
            this.view.GameEnded = true;
        }
    }
}
