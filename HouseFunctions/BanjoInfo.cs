﻿using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class BanjoInfo : PortableObjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BanjoInfo"></see> class.
        /// </summary>
        public BanjoInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BanjoInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public BanjoInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BanjoInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="visible">if set to <c>true</c> object is visible.</param>
        public BanjoInfo(string name, string shortName, int initialRoom, Floor floor, bool visible)
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