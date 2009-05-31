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
    [XmlInclude(typeof(NullObject))]
    [XmlInclude(typeof(GameEntity))]
    public abstract class InanimateObject : GameEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"/> class.
        /// </summary>
        protected InanimateObject() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected InanimateObject(string name) : base(name) { }

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
        protected InanimateObject(string name, Room room)
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
        protected InanimateObject(string name, Room room, string shortName)
            : base(name, shortName)
        {
            room.Items.Add(this);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntity"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        protected InanimateObject(string name, string shortName)
            : base(name, shortName)
        {
        }
    }
}
