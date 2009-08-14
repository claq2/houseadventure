
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
    public class InanimateObjects2Collection : Collection<InanimateObject2>
    {
        /// <summary>
        /// Replaces the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to replace.</param>
        /// <param name="item">The new value for the element at the specified index. The value can be null for reference types.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.-or-index is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"></see>.</exception>
        protected override void SetItem(int index, InanimateObject2 item)
        {
            base.SetItem(index, item);
        }

        /// <summary>
        /// Determines whether [contains by type] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// true if collection contains an item of the parameter item's type, false if not
        /// </returns>
        public bool ContainsByType(InanimateObject2 item)
        {
            bool boolReturn = false;
            foreach (InanimateObject2 inanimateObject in this)
            {
                if (!inanimateObject.GetType().Equals(item.GetType()))
                    continue;

                boolReturn = true;
                break;
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
            //matchingItems = new List<InanimateObject>();
            //Type itemType = item.GetType();
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
            foreach (InanimateObject inanimateObject in this)
            {
                if (!inanimateObject.GetType().Equals(item.GetType()))
                    continue;

                boolReturn = true;
                break;
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
}
