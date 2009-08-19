using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsumableObjectInfo : PortableObjectInfo
    {
        /// <summary>
        /// Gets or sets the usage limit.
        /// </summary>
        /// <value>The usage limit.</value>
        public int UsageLimit {get; private set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObjectInfo"/> class.
        /// </summary>
        public ConsumableObjectInfo()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="usageLimit">The usage limit.</param>
        public ConsumableObjectInfo(string name, string shortName, int initialRoom, Floor floor, int usageLimit)
            : base(name, shortName, initialRoom, floor)
        {
            this.UsageLimit = usageLimit;
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override HouseCore.InanimateObject2 CreateObject()
        {
            return new ConsumableObject2(this);
        }
    }
}
