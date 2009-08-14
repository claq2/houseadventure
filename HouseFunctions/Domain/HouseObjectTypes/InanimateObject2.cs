using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(PortableObject2))]
    [XmlInclude(typeof(ContainerObject2))]
    [XmlInclude(typeof(ConsumableObject2))]
    [XmlInclude(typeof(ProtectiveObject2))]
    [XmlInclude(typeof(PainfulObject2))]
    [XmlInclude(typeof(OnOffObject2))]
    [XmlInclude(typeof(MultiplePieceObject2))]
    [XmlInclude(typeof(DelicateObject2))]
    [XmlInclude(typeof(CushioningObject2))]
    [XmlInclude(typeof(StationaryObject2))]
    [XmlInclude(typeof(LockableDoorObject2))]
    [XmlInclude(typeof(NullObject2))]
    [XmlInclude(typeof(GameEntity))]
    public abstract class InanimateObject2 : GameEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject2"/> class.
        /// </summary>
        protected InanimateObject2() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected InanimateObject2(string name) : base(name) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        protected InanimateObject2(InanimateObjectInfo info)
            : base(info.Name, info.ShortName)
        {
        }
    }
}
