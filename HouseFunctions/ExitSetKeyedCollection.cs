using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HouseCore
{
    /// <summary>
    /// Collection of room exits keyed on the direction of the exit
    /// </summary>
    public class ExitSetKeyedCollection : KeyedCollection<Direction,RoomExit>
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
        /// Initializes a new instance of the <see cref="ExitSetKeyedCollection"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        protected ExitSetKeyedCollection(IEqualityComparer<Direction> comparer)
            : base(comparer)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitSetKeyedCollection"/> class.
        /// </summary>
        /// <param name="comparer">The implementation of the <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> generic interface to use when comparing keys, or null to use the default equality comparer for the type of the key, obtained from <see cref="P:System.Collections.Generic.EqualityComparer`1.Default"/>.</param>
        /// <param name="dictionaryCreationThreshold">The number of elements the collection can hold without creating a lookup dictionary (0 creates the lookup dictionary when the first item is added), or –1 to specify that a lookup dictionary is never created.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="dictionaryCreationThreshold"/> is less than –1.
        /// </exception>
        protected ExitSetKeyedCollection(IEqualityComparer<Direction> comparer, int dictionaryCreationThreshold)
            : base(comparer, dictionaryCreationThreshold)
        {
            
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
