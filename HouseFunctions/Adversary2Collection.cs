using System;
using System.Collections.Generic;

namespace HouseCore
{
    using System.Collections.ObjectModel;
    /// <summary>
    /// 
    /// </summary>
    public class Adversary2Collection : KeyedCollection<string, Adversary2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2Collection"/> class.
        /// </summary>
        public Adversary2Collection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2Collection"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        protected Adversary2Collection(IEqualityComparer<string> comparer)
            : base(comparer)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2Collection"/> class.
        /// </summary>
        /// <param name="comparer">The implementation of the <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> generic interface to use when comparing keys, or null to use the default equality comparer for the type of the key, obtained from <see cref="P:System.Collections.Generic.EqualityComparer`1.Default"/>.</param>
        /// <param name="dictionaryCreationThreshold">The number of elements the collection can hold without creating a lookup dictionary (0 creates the lookup dictionary when the first item is added), or –1 to specify that a lookup dictionary is never created.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="dictionaryCreationThreshold"/> is less than –1.
        /// </exception>
        protected Adversary2Collection(IEqualityComparer<string> comparer, int dictionaryCreationThreshold)
            : base(comparer, dictionaryCreationThreshold)
        {

        }


        /// <summary>
        /// Gets the <see cref="HouseCore.Adversary2"/> with the specified item.
        /// </summary>
        /// <value></value>
        public new Adversary2 this[string item]
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
        protected override string GetKeyForItem(Adversary2 item)
        {
            if (String.IsNullOrEmpty(item.ShortName))
                return item.Name;
            else
                return item.ShortName;

        }

        /// <summary>
        /// Gets the impostor.
        /// </summary>
        /// <value>The impostor.</value>
        public Impostor2 TheImpostor
        {
            get
            {
                foreach (Adversary2 adversary in this)
                {
                    Impostor2 impostor = adversary as Impostor2;
                    if (impostor != null)
                        return impostor;
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

            foreach (Adversary2 adversary in this.Items)
            {
                Impostor2 imposter = adversary as Impostor2;
                string stringItemShortened = item.Length > 3 ? item.Substring(0, 3) : item;
                if (imposter != null && includeImpostors)
                {
                    if (String.Compare(adversary.ShortName, stringItemShortened, StringComparison.OrdinalIgnoreCase) == 0)
                        return true;
                }
                else if (imposter == null)
                    if (String.Compare(adversary.ShortName, stringItemShortened, StringComparison.OrdinalIgnoreCase) == 0)
                        return true;
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
                foreach (Adversary2 adversary in this)
                    if (!(adversary is Impostor2))
                        return true;

                return false;
            }
        }
    }
}
