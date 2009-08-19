namespace HouseCore
{
    /// <summary>
    /// Class that represents an item that cannot be picked up without a container object in hand
    /// </summary>
    public class Coins : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coins"/> class.
        /// </summary>
        public Coins()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coins"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Coins(CoinsInfo info)
            : base(info)
        {
        }
    }
}
