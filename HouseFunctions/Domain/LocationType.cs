using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    using System.Xml.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [XmlRootAttribute("LocationType", Namespace = "", IsNullable = false)]
    public class LocationType : IEquatable<LocationType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationType"/> class.
        /// </summary>
        public LocationType() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationType"/> class.
        /// </summary>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public LocationType(int roomNumber, Floor floor)
        {
            this.roomNumber = roomNumber;
            this.floor = floor;
        }

        private Floor floor;

        /// <summary>
        /// 
        /// </summary>
        public Floor Floor
        {
            get { return floor; }
            set { floor = value; }
        }
        private int roomNumber;

        /// <summary>
        /// Gets or sets the room number.
        /// </summary>
        /// <value>The room number.</value>
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }
   
        #region IEquatable<LocationType> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the other parameter; otherwise, false.
        /// </returns>
        public bool Equals(LocationType other)
        {
            return (this.Floor == other.Floor && this.RoomNumber == other.RoomNumber);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Floor.ToString().GetHashCode() + this.RoomNumber.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        /// </returns>
        public override bool Equals(Object obj)
        {
            LocationType location = obj as LocationType;
            if (obj == null)
                return base.Equals(obj);

            if (location == null)
                return false;
            else
                return Equals(location);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="location1">The location1.</param>
        /// <param name="location2">The location2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(LocationType location1, LocationType location2)
        {
            return location1.Equals(location2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="location1">The location1.</param>
        /// <param name="location2">The location2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(LocationType location1, LocationType location2)
        {
            return (!location1.Equals(location2));
        }

        #endregion
    }
}
