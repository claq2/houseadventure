using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ExitSetKeyedCollection:KeyedCollection<Direction,RoomExit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitSetKeyedCollection"/> class.
        /// </summary>
        public ExitSetKeyedCollection() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitSetKeyedCollection"/> class.
        /// </summary>
        /// <param name="exits">The exits.</param>
        public ExitSetKeyedCollection(RoomExit[] exits)
            : base()
        {
            foreach (RoomExit exit in exits)
            {
                this.Add(exit);
            }

        }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override Direction GetKeyForItem(RoomExit item)
        {
            return item.ExitDirection;
        }
    }
}
