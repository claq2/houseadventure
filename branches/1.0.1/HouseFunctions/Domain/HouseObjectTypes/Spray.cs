using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Spray : ConsumableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject2"></see> class.
        /// </summary>
        public Spray()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableObject2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Spray(SprayInfo info)
            : base(info)
        {
        }
    }
}
