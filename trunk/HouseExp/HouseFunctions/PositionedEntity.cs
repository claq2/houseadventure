using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    using System.Xml.Serialization;
    /// <summary>
    /// 
    /// </summary>
    [XmlRootAttribute("PositionedEntity", Namespace = "", IsNullable = false)]
    public class PositionedEntity : GameEntity
    {
        private LocationType location;

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public LocationType Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionedEntity"/> class.
        /// </summary>
        public PositionedEntity()
            : base()
        {
            this.Location = new LocationType();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionedEntity"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PositionedEntity(string name)
            : base(name)
        {
            this.Location = new LocationType();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionedEntity"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public PositionedEntity(string name, int roomNumber, Floor floor)
            : base(name)
        {
            this.Location = new LocationType(roomNumber, floor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositionedEntity"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        public PositionedEntity(string name, LocationType location)
            : base(name)
        {
            this.Location = location;
        }
    }
}
