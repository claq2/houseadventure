namespace HouseCore
{
    /// <summary>
    /// Class that represents an item that can cannot be handled without a protective object
    /// </summary>
    public class DryIce : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DryIce"/> class.
        /// </summary>
        public DryIce()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DryIce"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public DryIce(DryIceInfo info)
            : base(info)
        {
        }
    }
}
