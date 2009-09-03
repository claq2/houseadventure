using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Diamond : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        public Diamond()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Diamond(DiamondInfo info)
            : base(info)
        {
            
        }
    }
}
