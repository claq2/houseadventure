using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class BatteriesInfo : ConsumableObjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatteriesInfo"></see> class.
        /// </summary>
        public BatteriesInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatteriesInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="usageLimit">The usage limit.</param>
        public BatteriesInfo(string name, string shortName, int initialRoom, Floor floor, int usageLimit)
            : base(name, shortName, initialRoom, floor, usageLimit)
        {
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override InanimateObject2 CreateObject()
        {
            throw new NotImplementedException();
        }
    }
}
