using System.Collections.ObjectModel;
using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class NormalAdversaryInfo : AdversaryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalAdversaryInfo"/> class.
        /// </summary>
        public NormalAdversaryInfo():base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalAdversaryInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public NormalAdversaryInfo(string name, string shortName, int initialRoom, Floor floor):base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Creates the adversary.
        /// </summary>
        /// <returns></returns>
        public override Adversary2 CreateAdversary()
        {
            return new Adversary2(this);
        }
    }
}
