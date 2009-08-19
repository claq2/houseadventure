using System.Collections.ObjectModel;
using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ImpostorInfo : NormalAdversaryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImpostorInfo"/> class.
        /// </summary>
        public ImpostorInfo() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImpostorInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public ImpostorInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Creates the adversary.
        /// </summary>
        /// <returns></returns>
        public override Adversary2 CreateAdversary()
        {
            return new Impostor2(this);
        }
    }
}
