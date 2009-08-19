namespace HouseCore
{
    /// <summary>
    /// Class that represents an item allows getting a multiple piece object
    /// </summary>
    public class Box : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Box"/> class.
        /// </summary>
        public Box()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Box"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Box(BoxInfo info)
            : base(info)
        { 
        }
    }
}
