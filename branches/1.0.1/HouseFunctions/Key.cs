using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Key : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        public Key()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Key(KeyInfo info)
            : base(info)
        {
            
        }
    }
}
