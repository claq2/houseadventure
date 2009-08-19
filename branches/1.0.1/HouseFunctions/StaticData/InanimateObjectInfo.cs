namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class InanimateObjectInfo
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName { get; private set; }

        /// <summary>
        /// Gets or sets the initial room.
        /// </summary>
        /// <value>The initial room.</value>
        public int InitialRoom { get; private set; }

        /// <summary>
        /// Gets or sets the initial floor.
        /// </summary>
        /// <value>The initial floor.</value>
        public Floor InitialFloor { get; private set; }

        /// <summary>
        /// Gets the identity.
        /// </summary>
        /// <value>The identity.</value>
        public string Identity
        {
            get
            {
                if (string.IsNullOrEmpty(ShortName))
                    return Name;
                else
                    return ShortName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObjectInfo"/> class.
        /// </summary>
        protected InanimateObjectInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        protected InanimateObjectInfo(string name, int initialRoom, Floor floor)
            : this(name, string.Empty, initialRoom, floor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        protected InanimateObjectInfo(string name, string shortName, int initialRoom, Floor floor)
        {
            this.Name = name;
            this.ShortName = shortName;
            this.InitialRoom = initialRoom;
            this.InitialFloor = floor;
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public abstract InanimateObject2 CreateObject();
    }
}
