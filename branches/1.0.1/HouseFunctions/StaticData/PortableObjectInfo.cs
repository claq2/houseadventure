using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PortableObjectInfo : InanimateObjectInfo
    {

        /// <summary>
        /// Indicates whether the item is visible
        /// </summary>
        private bool visible = true;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PortableObject2"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible
        {
            get { return this.visible; }
            private set { this.visible = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"/> class.
        /// </summary>
        public PortableObjectInfo() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public PortableObjectInfo(string name, string shortName, int initialRoom, Floor floor) : base(name, shortName, initialRoom, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="visible">if set to <c>true</c> object is visible.</param>
        public PortableObjectInfo(string name, string shortName, int initialRoom, Floor floor, bool visible)
            : base(name, shortName, initialRoom, floor)
        {
            this.Visible = visible;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObjectInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public PortableObjectInfo(string name, int initialRoom, Floor floor)
            : base(name, initialRoom, floor)
        {
            
        }
         
    }
}
