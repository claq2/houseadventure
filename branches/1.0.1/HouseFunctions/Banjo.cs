using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Banjo : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        public Banjo():base()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Banjo(BanjoInfo info)
            : base(info)
        {
            
        }
    }
}
