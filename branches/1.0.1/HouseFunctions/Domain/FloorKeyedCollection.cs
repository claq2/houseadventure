namespace HouseCore
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    public class FloorKeyedCollection : KeyedCollection<Floor, Room2KeyedCollection>
    {
        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override Floor GetKeyForItem(Room2KeyedCollection item)
        {
            return item.RoomFloor;
        }

        /// <summary>
        /// Gets the magic rooms.
        /// </summary>
        /// <value>The magic rooms.</value>
        public Room2KeyedCollection MagicRooms
        {
            get
            {
                Room2KeyedCollection coll = new Room2KeyedCollection();
                foreach (Room2KeyedCollection roomCollection in this)
                    foreach (Room2 room in roomCollection)
                        if (room.Magic)
                            coll.Add(room);

                return coll;
            }
        }
    }
}
