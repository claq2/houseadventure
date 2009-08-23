namespace HouseCore
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(Impostor2))]
    public abstract class Adversary2 : GameEntity
    {
        /// <summary>
        /// Gets or sets the moves until unhidden.
        /// </summary>
        /// <value>The moves until unhidden.</value>
        public int MovesUntilUnhidden { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2"/> class.
        /// </summary>
        protected Adversary2()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary2"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        protected Adversary2(AdversaryInfo info)
            : base(info.Name, info.ShortName)
        {
        }
    }
}
