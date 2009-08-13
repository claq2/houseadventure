//-----------------------------------------------------------------------
// <copyright file="ReadOnlyExitSetCollection.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    public class ReadOnlyExitSetCollection : ReadOnlyCollection<RoomExit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyExitSetCollection"/> class.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="list"/> is null.
        /// </exception>
        public ReadOnlyExitSetCollection(IList<RoomExit> list)
            : base(list)
        {

        }

    }
}
