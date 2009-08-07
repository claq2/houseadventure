//-----------------------------------------------------------------------
// <copyright file="Floor.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;

    /// <summary>
    /// Floor enum
    /// </summary>
    public enum Floor
    {
        /// <summary>
        /// The basement level
        /// </summary>
        Basement,

        /// <summary>
        /// The first floor
        /// </summary>
        FirstFloor,

        /// <summary>
        /// The second floor
        /// </summary>
        SecondFloor,

        /// <summary>
        /// The third floor
        /// </summary>
        ThirdFloor,

        /// <summary>
        /// The monster hangout level
        /// </summary>
        MonsterHangout,

        /// <summary>
        /// Level indicating the object is in the player's inventory
        /// </summary>
        InHand
    }
}
