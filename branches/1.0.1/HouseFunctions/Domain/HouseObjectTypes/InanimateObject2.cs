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
    [XmlInclude(typeof(Box))]
    [XmlInclude(typeof(ConsumableObject2))]
    [XmlInclude(typeof(Glove))]
    [XmlInclude(typeof(DryIce))]
    [XmlInclude(typeof(Flashlight))]
    [XmlInclude(typeof(Coins))]
    [XmlInclude(typeof(Vase))]
    [XmlInclude(typeof(Pillow))]
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
        /// <param name="info">The info.</param>
        protected InanimateObject2(InanimateObjectInfo info)
            : base(info.Name, info.ShortName)
        {
        }
    }
}
