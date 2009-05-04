using System;

namespace HouseCore
{
    /// <summary>
    /// Class of object that represents an empty inventory
    /// </summary>
    public class NullObject : InanimateObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"></see> class.
        /// </summary>
        public NullObject()
            : base("nothing", "not")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public NullObject(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        public NullObject(string name, Room room)
            : base(name, room)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="room">The room.</param>
        /// <param name="shortName">The short name.</param>
        public NullObject(string name, Room room, string shortName)
            : base(name, room, shortName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntity"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        protected NullObject(string name, string shortName)
            : base(name, shortName)
        {
        }
    }
}
