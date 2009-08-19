namespace HouseCore
{
    /// <summary>
    /// Class that represents an item that can be used a limited number of time
    /// </summary>
    public class ConsumableObject2 : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject2"/> class.
        /// </summary>
        public ConsumableObject2()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject2"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public ConsumableObject2(ConsumableObjectInfo info)
            : base(info)
        {
            this.UsageLimit = info.UsageLimit;
        }

        /// <summary>
        /// Gets or sets the usage limit.
        /// </summary>
        /// <value>The usage limit.</value>
        public int UsageLimit { get; set; }

        /// <summary>
        /// Gets or sets the times used.
        /// </summary>
        /// <value>The times used.</value>
        public int TimesUsed { get; set; }

        /// <summary>
        /// Increments the times used.
        /// </summary>
        public void IncrementTimesUsed()
        {
            this.TimesUsed++;
        }
    }
}
