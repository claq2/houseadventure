namespace HouseCore
{
    /// <summary>
    /// Class that represents an item allows getting a painful object
    /// </summary>
    public class Glove : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Glove"/> class.
        /// </summary>
        public Glove()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Glove"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Glove(GloveInfo info):base(info)
        {
        }
    }
}
