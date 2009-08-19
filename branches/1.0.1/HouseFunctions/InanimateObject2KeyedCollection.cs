namespace HouseCore
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    public class InanimateObject2KeyedCollection : KeyedCollection<string, InanimateObject2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject2KeyedCollection"/> class.
        /// </summary>
        public InanimateObject2KeyedCollection() : base() { }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override string GetKeyForItem(InanimateObject2 item)
        {
            if (String.IsNullOrEmpty(item.ShortName))
                return item.Name;
            else
                return item.ShortName;
        }

        /// <summary>
        /// Determines whether [contains by type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="matchingItems">The matching items.</param>
        /// <returns>
        /// 	<c>true</c> if [contains by type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsByType(Type type, InanimateObjects2Collection matchingItems)
        {
            bool boolReturn = false;
            matchingItems.Clear();
            foreach (InanimateObject2 inanimateObject in this)
            {
                Type objectType = inanimateObject.GetType();
                if (objectType.Equals(type))
                {
                    boolReturn = true;
                    matchingItems.Add(inanimateObject);
                }
            }

            return boolReturn;
        }

        /// <summary>
        /// Determines whether [contains by type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if [contains by type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsByType(Type type)
        {
            bool boolReturn = false;
            foreach (InanimateObject2 inanimateObject in this)
            {
                Type objectType = inanimateObject.GetType();
                if (objectType.Equals(type))
                {
                    boolReturn = true;
                    break;
                }
            }

            return boolReturn;
        }
    }
}
