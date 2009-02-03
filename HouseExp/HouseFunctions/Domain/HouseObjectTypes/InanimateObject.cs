using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(PortableObject))]
    [XmlInclude(typeof(ContainerObject))]
    [XmlInclude(typeof(ConsumableObject))]
    [XmlInclude(typeof(ProtectiveObject))]
    [XmlInclude(typeof(PainfulObject))]
    [XmlInclude(typeof(OnOffObject))]
    [XmlInclude(typeof(DiggingObject))]
    [XmlInclude(typeof(MultiplePieceObject))]
    [XmlInclude(typeof(DelicateObject))]
    [XmlInclude(typeof(CushioningObject))]
    [XmlInclude(typeof(StationaryObject))]
    [XmlInclude(typeof(LockableDoorObject))]
    public class InanimateObject : GameEntity//, IEquatable<InanimateObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"/> class.
        /// </summary>
        public InanimateObject() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public InanimateObject(string name) : base(name) { }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="InanimateObject"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        //public InanimateObject(string name, int roomNumber, Floor floor)
        //    : base(name, roomNumber, floor)
        //{
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        public InanimateObject(string name, Room room)
            : base(name)
        {
            room.Items.Add(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        /// <param name="shortName">The short name.</param>
        public InanimateObject(string name, Room room, string shortName)
            : base(name, shortName)
        {
            room.Items.Add(this);
        }

        #region IEquatable<InanimateObject> Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(InanimateObject other)
        {
            return this.Name == other.Name;
        }

        #endregion

    }
}
