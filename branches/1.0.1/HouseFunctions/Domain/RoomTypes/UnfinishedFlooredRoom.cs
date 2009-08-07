using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class UnfinishedFlooredRoom : Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom"/> class.
        /// </summary>
        public UnfinishedFlooredRoom() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnfinishedFlooredRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        public UnfinishedFlooredRoom(string name, LocationType location, ReadOnlyExitSetCollection exits)
            : base(name, location, exits) { }
    }
}
