using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ConsumableObjectInfo : PortableObjectInfo
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
        /// Initializes a new instance of the <see cref="PortableObjectInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public ConsumableObjectInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="visible">if set to <c>true</c> object is visible.</param>
        public ConsumableObjectInfo(string name, string shortName, int initialRoom, Floor floor, bool visible)
            : base(name, shortName, initialRoom, floor, visible)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObjectInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public ConsumableObjectInfo(string name, int initialRoom, Floor floor)
            : base(name, initialRoom, floor)
        {
            
        }
         
    }
}
