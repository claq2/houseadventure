namespace HouseCore
{
    /// <summary>
    /// Class that represents an item that can be switched on and off
    /// </summary>
    public class Flashlight : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Flashlight"/> class.
        /// </summary>
        public Flashlight()
            : base()
        {
            this.State = Switch.Off;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Flashlight"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Flashlight(FlashlightInfo info):base(info)
        {
            this.State = Switch.Off;
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public Switch State { get; set; }
    }
}
