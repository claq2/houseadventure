namespace HouseCore
{
    /// <summary>
    /// Class that represents an item that can be picked up
    /// </summary>
    public class PortableObject2 : InanimateObject2
    {
        #region Fields (2)

        /// <summary>
        /// Indicates whether the item is visible
        /// </summary>
        private bool visible = true;

        #endregion Fields

        #region Constructors (5)

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"/> class.
        /// </summary>
        public PortableObject2()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public PortableObject2(PortableObjectInfo info)
            : base(info)
        {
            this.Visible = info.Visible;
        }

        #endregion Constructors

        #region Properties (2)

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PortableObject2"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }

        #endregion Properties
    }
}
