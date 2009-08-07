//-----------------------------------------------------------------------
// <copyright file="Switch.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;

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
