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

        /// <summary>
        /// Inserts an element into the <see cref="T:System.Collections.ObjectModel.KeyedCollection`2"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index"/> is less than 0.-or-<paramref name="index"/> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
        protected override void InsertItem(int index, Room2 item)
        {
            base.InsertItem(index, item);
            foreach (RoomExit exit in item.Exits)
            {
                Room2 room2Destination;
                try
                {
                    room2Destination = this[exit.ExitDestination];
                }
                catch (KeyNotFoundException)
                {
                    room2Destination = null;
                }

                switch (exit.ExitDirection)
                {
                    case Direction.North:
                        if (room2Destination != null)
                        {
                            item.North = room2Destination;
                            room2Destination.South = item;
                        }
                        break;
                    case Direction.East:
                        if (room2Destination != null)
                        {
                            item.East = room2Destination;
                            room2Destination.West = item;
                        }
                        break;
                    case Direction.West:
                        if (room2Destination != null)
                        {
                            item.West = room2Destination;
                            room2Destination.East = item;
                        }
                        break;
                    case Direction.South:
                        if (room2Destination != null)
                        {
                            item.South = room2Destination;
                            room2Destination.North = item;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2KeyedCollection"/> class.
        /// </summary>
        public Room2KeyedCollection()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2KeyedCollection"/> class.
        /// </summary>
        /// <param name="floor">The floor.</param>
        public Room2KeyedCollection(Floor floor):base()
        {
            this.RoomFloor = floor;
        }
    }
}
