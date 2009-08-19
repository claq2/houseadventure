//-----------------------------------------------------------------------
// <copyright file="AdversaryCollection.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HouseCore
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    public class AdversaryCollection : KeyedCollection<string, Adversary>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdversaryCollection"/> class.
        /// </summary>
        public AdversaryCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdversaryCollection"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        protected AdversaryCollection(IEqualityComparer<string> comparer)
            : base(comparer)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdversaryCollection"/> class.
        /// </summary>
        /// <param name="comparer">The implementation of the <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> generic interface to use when comparing keys, or null to use the default equality comparer for the type of the key, obtained from <see cref="P:System.Collections.Generic.EqualityComparer`1.Default"/>.</param>
        /// <param name="dictionaryCreationThreshold">The number of elements the collection can hold without creating a lookup dictionary (0 creates the lookup dictionary when the first item is added), or –1 to specify that a lookup dictionary is never created.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="dictionaryCreationThreshold"/> is less than –1.
        /// </exception>
        protected AdversaryCollection(IEqualityComparer<string> comparer, int dictionaryCreationThreshold)
            : base(comparer, dictionaryCreationThreshold)
        {
            
        }
                                                 

        /// <summary>
        /// Gets the <see cref="HouseCore.Adversary"/> with the specified item.
        /// </summary>
        /// <value></value>
        public new Adversary this[string item]
        {
            get
            {
                string stringItemShortenedValue = item.Length > 3 ? item.Substring(0, 3) : item;
                return base[stringItemShortenedValue];
            }
        }
        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override string GetKeyForItem(Adversary item)
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
        /// Gets the impostor.
        /// </summary>
        /// <value>The impostor.</value>
        public Impostor TheImpostor
        {
            get
            {
                foreach (Adversary adversary in this)
                {
                    Impostor impostor = adversary as Impostor;
                    if (impostor != null)
                    {
                        return impostor;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="includeImpostors">if set to <c>true</c> [include impostors].</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string item, bool includeImpostors)
        {
            //TODO: reduce nesting depth below
            if (String.IsNullOrEmpty(item))
                return false;

            foreach (Adversary adversary in this.Items)
            {
                Impostor imposter = adversary as Impostor;
                string stringItemShortened = item.Length > 3 ? item.Substring(0, 3) : item;
                if (imposter != null && includeImpostors)
                {
                    if (String.Compare(adversary.ShortName, stringItemShortened, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return true;
                    }
                }
                else if (imposter == null)
                {
                    if (String.Compare(adversary.ShortName, stringItemShortened, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether collection contains an adversary that is not an impostor.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if collection contains an adversary that is not an impostor; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsNonImpostor
        {
            get
            {
                foreach (Adversary adversary in this)
                {
                    if (!(adversary is Impostor))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
