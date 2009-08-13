//-----------------------------------------------------------------------
// <copyright file="MagicWord.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// Magic words
    /// </summary>
    public enum MagicWord
    {
        /// <summary>
        /// Magic word is undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// A magic word
        /// </summary>
        Abracadabra,

        /// <summary>
        /// A magic word
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Shazaam")]
        Shazaam,

        /// <summary>
        /// A magic word
        /// </summary>
        Seersucker,

        /// <summary>
        /// A magic word
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ugaboom")]
        Ugaboom
    }
}
