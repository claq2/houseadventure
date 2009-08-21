using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class LeopardInfo : AdversaryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeopardInfo"></see> class.
        /// </summary>
        public LeopardInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeopardInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public LeopardInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Creates the adversary.
        /// </summary>
        /// <returns></returns>
        public override Adversary2 CreateAdversary()
        {
            return new Leopard(this);
        }
    }
}
