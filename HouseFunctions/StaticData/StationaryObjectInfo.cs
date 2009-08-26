using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class StationaryObjectInfo : InanimateObjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StationaryObjectInfo"/> class.
        /// </summary>
        public StationaryObjectInfo()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationaryObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public StationaryObjectInfo(string name, int initialRoom, Floor floor)
            : base(name, initialRoom, floor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationaryObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public StationaryObjectInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override InanimateObject2 CreateObject()
        {
            return new StationaryObject2(this);
        }
    }
}
