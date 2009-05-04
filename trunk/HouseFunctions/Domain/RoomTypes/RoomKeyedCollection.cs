using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class RoomKeyedCollection : KeyedCollection<LocationType, Room>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomKeyedCollection"/> class.
        /// </summary>
        public RoomKeyedCollection() : base() { }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override LocationType GetKeyForItem(Room item)
        {
            return item.Location;
        }

        /// <summary>
        /// Gets the magic rooms.
        /// </summary>
        /// <value>The magic rooms.</value>
        public RoomKeyedCollection MagicRooms
        {
            get
            {
                RoomKeyedCollection coll = new RoomKeyedCollection();
                foreach (Room room in this)
                {
                    if (room.Magic)
                    {
                        coll.Add(room);
                    }
                }
                return coll;
            }
        }
    }
}
