
namespace HouseCore
{
    //using System.Reflection;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    public class InanimateObjectsCollection : Collection<InanimateObject>
    {
        /// <summary>
        /// Replaces the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to replace.</param>
        /// <param name="item">The new value for the element at the specified index. The value can be null for reference types.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.-or-index is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"></see>.</exception>
        protected override void SetItem(int index, InanimateObject item)
        {
            base.SetItem(index, item);
        }

        // TODO: Prevent duplicate items

        /// <summary>
        /// Determines whether [contains by type] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// true if collection contains an item of the parameter item's type, false if not
        /// </returns>
        public bool ContainsByType(InanimateObject item)
        {
            bool boolReturn = false;
            Type itemType = item.GetType();
            foreach (InanimateObject inanimateObject in this)
            {
                Type objectType = inanimateObject.GetType();
                if (objectType.Equals(itemType))
                {
                    boolReturn = true;
                    break;
                }
            }
            return boolReturn;
        }

        /// <summary>
        /// Determines whether [contains by type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="matchingItems">The matching items.</param>
        /// <returns>
        /// 	<c>true</c> if [contains by type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsByType(Type type, InanimateObjectsCollection matchingItems)
        {
            bool boolReturn = false;
            matchingItems.Clear();
            //Type itemType = item.GetType();
            foreach (InanimateObject inanimateObject in this)
            {
                Type objectType = inanimateObject.GetType();
                if (objectType.Equals(type))
                {
                    boolReturn = true;
                    matchingItems.Add(inanimateObject);
                    //break;
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
            //matchingItems = new List<InanimateObject>();
            //Type itemType = item.GetType();
            foreach (InanimateObject inanimateObject in this)
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

    /// <summary>
    /// 
    /// </summary>
    public class InanimateObjectKeyedCollection : KeyedCollection<string, InanimateObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObjectKeyedCollection"/> class.
        /// </summary>
        public InanimateObjectKeyedCollection() : base() { }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override string GetKeyForItem(InanimateObject item)
        {
            if (String.IsNullOrEmpty(item.ShortName))
            {
                return item.Name;
            }
            else
            {
                return item.ShortName;
            }
        }

        /// <summary>
        /// Determines whether [contains by type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="matchingItems">The matching items.</param>
        /// <returns>
        /// 	<c>true</c> if [contains by type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsByType(Type type, InanimateObjectsCollection matchingItems)
        {
            bool boolReturn = false;
            matchingItems.Clear();
            //Type itemType = item.GetType();
            foreach (InanimateObject inanimateObject in this)
            {
                Type objectType = inanimateObject.GetType();
                if (objectType.Equals(type))
                {
                    boolReturn = true;
                    matchingItems.Add(inanimateObject);
                    //break;
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
            //matchingItems = new List<InanimateObject>();
            //Type itemType = item.GetType();
            foreach (InanimateObject inanimateObject in this)
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
