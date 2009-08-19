//-----------------------------------------------------------------------
// <copyright file="Adversary.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System.Xml.Serialization;

    /// <summary>
    /// Class that represents an adversary
    /// </summary>
    [XmlInclude(typeof(Impostor))]
    public class Adversary : GameEntity
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary"/> class.
        /// </summary>
        public Adversary()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary"/> class.
        /// </summary>
        /// <param name="name">The display name of the adversary.</param>
        public Adversary(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary"/> class.
        /// </summary>
        /// <param name="name">The display name of the adversary.</param>
        /// <param name="room">The initial room.</param>
        public Adversary(string name, NormalRoom room) : base(name)
        {
            room.Adversaries.Add(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary"/> class.
        /// </summary>
        /// <param name="name">The display name of the adversary.</param>
        /// <param name="room">The initial room.</param>
        /// <param name="shortName">The short name of the adversary.</param>
        public Adversary(string name, NormalRoom room, string shortName)
            : base(name, shortName)
        {
            room.Adversaries.Add(this);
        }

        /// <summary>
        /// Gets or sets the moves until unhidden.
        /// </summary>
        /// <value>The moves until unhidden.</value>
        public int MovesUntilUnhidden { get; set; }
    }
}
