namespace HouseCore
{
    /// <summary>
    /// Class of object that represents an empty inventory
    /// </summary>
    public class NullObject2 : InanimateObject2
    {
        //TODO: turn this into a Singleton

        /// <summary>
        /// Initializes a new instance of the <see cref="InanimateObject"></see> class.
        /// </summary>
        public NullObject2()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullObject2"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public NullObject2(NullObjectInfo info)
            : base(info)
        {
        }
    }
}
