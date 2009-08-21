using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Werewolf : Adversary2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2"></see> class.
        /// </summary>
        public Werewolf()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Werewolf(AdversaryInfo info)
            : base(info)
        {
        }
    }
}
