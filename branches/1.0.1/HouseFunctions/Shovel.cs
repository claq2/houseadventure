using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Shovel : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        public Shovel()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Shovel(ShovelInfo info)
            : base(info)
        {
            
        }
    }
}
