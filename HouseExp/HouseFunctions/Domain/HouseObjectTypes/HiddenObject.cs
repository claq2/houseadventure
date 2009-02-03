using System;
using System.Collections.Generic;
using System.Text;

namespace HouseFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class HiddenObject : PortableObject
    {
        private bool hidden;

        /// <summary>
        /// 
        /// </summary>
        public bool Hidden
        {
            get
            {
                return hidden;
            }
            set
            {
                hidden = value;
            }
        }
    }
}
