using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Vampire : Adversary2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vampire"></see> class.
        /// </summary>
        public Vampire()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vampire"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Vampire(AdversaryInfo info)
            : base(info)
        {
        }
    }
}
