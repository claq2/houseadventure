namespace HouseCore
{
    /// <summary>
    /// Class that represents an item that, when on the floor, will allow the dropping of a delicate object
    /// </summary>
    public class Pillow : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pillow"/> class.
        /// </summary>
        public Pillow()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pillow"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Pillow(PillowInfo info)
            : base(info)
        {
        }
    }
}
