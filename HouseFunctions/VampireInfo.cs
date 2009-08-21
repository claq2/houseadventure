using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class VampireInfo : AdversaryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VampireInfo"></see> class.
        /// </summary>
        public VampireInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VampireInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public VampireInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Creates the adversary.
        /// </summary>
        /// <returns></returns>
        public override Adversary2 CreateAdversary()
        {
            return new Vampire(this);
        }
    }
}
