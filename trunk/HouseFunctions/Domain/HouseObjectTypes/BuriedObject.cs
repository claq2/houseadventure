using System;
using System.Collections.Generic;
using System.Text;

namespace HouseFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class BuriedObject : PortableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuriedObject"/> class.
        /// </summary>
        public BuriedObject():base() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="BuriedObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public BuriedObject(string name):base(name){}

        /// <summary>
        /// Initializes a new instance of the <see cref="BuriedObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public BuriedObject(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuriedObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        public BuriedObject(string name, Room room) : base(name, room) { }

        private bool buried;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BuriedObject"/> is buried.
        /// </summary>
        /// <value><c>true</c> if buried; otherwise, <c>false</c>.</value>
        public bool Buried
        {
            get { return buried; }
            set { buried = value; }
        }
    }
}
