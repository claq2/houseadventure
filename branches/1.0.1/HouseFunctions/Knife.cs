using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Knife : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        public Knife()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Knife(KnifeInfo info)
            : base(info)
        {
            
        }
    }
}
