namespace HouseCore
{
    /// <summary>
    /// Class that represents an item that cannot be dropped without a cushioning object on the floor
    /// </summary>
    public class Vase : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vase"/> class.
        /// </summary>
        public Vase()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vase"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Vase(VaseInfo info)
            : base(info)
        {
        }
    }
}
