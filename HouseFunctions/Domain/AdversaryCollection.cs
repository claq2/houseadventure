using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    /// <summary>
    /// 
    /// </summary>
    public class AdversaryCollection : KeyedCollection<string, Adversary>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdversaryCollection"/> class.
        /// </summary>
        public AdversaryCollection() : base() { }

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
            foreach (Adversary adversary in this.Items)
            {
                Impostor imposter = adversary as Impostor;
                if (imposter != null && includeImpostors)
                {
                    if (String.Compare(adversary.ShortName, item, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return true;
                    }
                }
                else if (imposter == null)
                {
                    if (String.Compare(adversary.ShortName, item, StringComparison.OrdinalIgnoreCase) == 0)
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
        public bool ContainsNonImpostor()
        {
            bool boolReturn = false;
            foreach (Adversary adversary in this)
            {
                if (!(adversary is Impostor))
                {
                    return true;
                }
            }
            return boolReturn;
        }
    }
}
