//-----------------------------------------------------------------------
// <copyright file="Room2KeyedCollection.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class Room2KeyedCollection : KeyedCollection<int, Room2>
    {
        /// <summary>
        /// Gets or sets the room floor.
        /// </summary>
        /// <value>The room floor.</value>
        public Floor RoomFloor { get; set; }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override int GetKeyForItem(Room2 item)
        {
            return item.RoomNumber;
        }
    }
}
