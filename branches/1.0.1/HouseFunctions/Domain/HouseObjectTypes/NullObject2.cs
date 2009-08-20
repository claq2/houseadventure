using System;
namespace HouseCore
{
    /// <summary>
    /// Class of object that represents an empty inventory
    /// </summary>
    public sealed class NullObject2 : InanimateObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullObject2"></see> class.
        /// </summary>
        private NullObject2()
            : base("nothing")
        {
        }

        /// <summary>
        /// The Singleton instance
        /// </summary>
        public static readonly NullObject2 Instance = new NullObject2();
    }
}
