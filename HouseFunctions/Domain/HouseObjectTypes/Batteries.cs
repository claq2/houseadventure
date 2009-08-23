using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Batteries : ConsumableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject2"></see> class.
        /// </summary>
        public Batteries()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Batteries(ConsumableObjectInfo info)
            : base(info)
        {
        }
    }
}
