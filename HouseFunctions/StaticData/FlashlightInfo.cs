using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class FlashlightInfo : PortableObjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlashlightInfo"/> class.
        /// </summary>
        public FlashlightInfo()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlashlightInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public FlashlightInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override HouseCore.InanimateObject2 CreateObject()
        {
            return new Flashlight(this);
        }
    }
}
