using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectionConstants
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DirectionConstants North = new DirectionConstants("North", true);
        /// <summary>
        /// 
        /// </summary>
        public static readonly DirectionConstants South = new DirectionConstants("South", true);
        /// <summary>
        /// 
        /// </summary>
        public static readonly DirectionConstants East = new DirectionConstants("East", true);
        /// <summary>
        /// 
        /// </summary>
        public static readonly DirectionConstants West = new DirectionConstants("West", true);
        /// <summary>
        /// 
        /// </summary>
        public static readonly DirectionConstants Up = new DirectionConstants("Up", false);
        /// <summary>
        /// 
        /// </summary>
        public static readonly DirectionConstants Down = new DirectionConstants("Down", false);

        private string name;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is cardinal.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is cardinal; otherwise, <c>false</c>.
        /// </value>
        public bool IsCardinal { get; private set; }
        private DirectionConstants(string name, bool isCardinal)
        {
            this.name = name;
            this.IsCardinal = isCardinal;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.name;
        }
    }

    /// <summary>
    /// Directions in which to move
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// North
        /// </summary>
        North,

        /// <summary>
        /// East
        /// </summary>
        East,

        /// <summary>
        /// West
        /// </summary>
        West,

        /// <summary>
        /// South
        /// </summary>
        South,

        /// <summary>
        /// Up
        /// </summary>
        Up,

        /// <summary>
        /// Down
        /// </summary>
        Down,
    }
}
