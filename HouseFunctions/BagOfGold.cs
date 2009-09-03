using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class BagOfGold : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BagOfGold"></see> class.
        /// </summary>
        public BagOfGold():base()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BagOfGold"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public BagOfGold(BagOfGoldInfo info)
            : base(info)
        {
            
        }
    }
}
