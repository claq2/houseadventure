namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    //TODO: Make this abstract and instantiate subclasses

    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(Impostor2))]
    public class Adversary2 : GameEntity
    {
        /// <summary>
        /// Gets or sets the moves until unhidden.
        /// </summary>
        /// <value>The moves until unhidden.</value>
        public int MovesUntilUnhidden { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2"/> class.
        /// </summary>
        public Adversary2()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Adversary2(AdversaryInfo info)
            : base(info.Name, info.ShortName)
        {
        }
    }
}
