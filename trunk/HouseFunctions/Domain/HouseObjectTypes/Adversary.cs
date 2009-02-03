//-----------------------------------------------------------------------
// <copyright file="Adversary.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Class that represents an adversary
    /// </summary>
    [XmlInclude(typeof(Impostor))]
    public class Adversary : GameEntity//, IEquatable<Adversary>
    {
        /// <summary>
        /// The number of moves left until the hiding adversary reappears
        /// </summary>
        private int movesUntilUnhidden;

        ///// <summary>
        ///// The item's short name
        ///// </summary>
        //private string shortName;

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

        ///// <summary>
        ///// Initializes a new instance of the <see cref="Adversary"/> class.
        ///// </summary>
        ///// <param name="name">The name.</param>
        ///// <param name="roomNumber">The room number.</param>
        ///// <param name="floor">The floor.</param>
        ////public Adversary(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary"/> class.
        /// </summary>
        /// <param name="name">The display name of the adversary.</param>
        /// <param name="room">The initial room.</param>
        public Adversary(string name, Room room) : base(name)
        {
            room.Adversaries.Add(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Adversary"/> class.
        /// </summary>
        /// <param name="name">The display name of the adversary.</param>
        /// <param name="room">The initial room.</param>
        /// <param name="shortName">The short name of the adversary.</param>
        public Adversary(string name, Room room, string shortName)
            : base(name, shortName)
        {
            room.Adversaries.Add(this);
            ////this.shortName = shortName;
        }

        ///// <summary>
        ///// Gets the short name.
        ///// </summary>
        ///// <value>The short name.</value>
        //public string ShortName
        //{
        //    get { return this.shortName; }
        //}

        /// <summary>
        /// Gets or sets the moves until unhidden.
        /// </summary>
        /// <value>The moves until unhidden.</value>
        public int MovesUntilUnhidden
        {
            get { return this.movesUntilUnhidden; }
            set { this.movesUntilUnhidden = value; }
        }

        #region IEquatable<Adversary> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the other parameter; otherwise, false.
        /// </returns>
        public bool Equals(Adversary other)
        {
            return this.Name == other.Name;
        }

        #endregion
    }
}
