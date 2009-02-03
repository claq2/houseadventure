using System;
using System.Collections.Generic;
using System.Text;

namespace HouseFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class Imposter : Adversary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Imposter"/> class.
        /// </summary>
        public Imposter() : base() { }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="Imposter"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //public Imposter(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Imposter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        public Imposter(string name, Room room) : base(name, room) { }

    }
}
