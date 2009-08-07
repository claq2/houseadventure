namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class Elevator2 : Room2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator2"/> class.
        /// </summary>
        public Elevator2() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        public Elevator2(string name, int roomNumber, ReadOnlyExitSetCollection exits) : base(name, roomNumber, exits) { }
    }
}
