using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// States of on/off objects
    /// </summary>
    public enum Switch
    {
        /// <summary>
        /// Initial value for a Switch
        /// </summary>
        Unknown,

        /// <summary>
        /// Means the object is off
        /// </summary>
        Off,

        /// <summary>
        /// Means the object is on
        /// </summary>
        On,
    }
}
