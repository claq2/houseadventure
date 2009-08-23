using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ShovelInfo : PortableObjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"></see> class.
        /// </summary>
        public ShovelInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public ShovelInfo(string name, string shortName, int initialRoom, Floor floor)
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
        public ShovelInfo(string name, string shortName, int initialRoom, Floor floor, bool visible)
            : base(name, shortName, initialRoom, floor, visible)
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
