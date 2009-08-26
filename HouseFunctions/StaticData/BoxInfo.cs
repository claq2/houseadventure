using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class BoxInfo : PortableObjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxInfo"/> class.
        /// </summary>
        public BoxInfo()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public BoxInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override InanimateObject2 CreateObject()
        {
            return new Box(this);
        }
    }
}
