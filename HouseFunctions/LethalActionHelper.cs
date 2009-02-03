using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class LethalActionHelper
    {
        /// <summary>
        /// Gets or sets the display output.
        /// </summary>
        /// <value>The display output.</value>
        public abstract string Output
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the action killed the player.
        /// </summary>
        /// <value><c>true</c> if the action killed the player; otherwise, <c>false</c>.</value>
        public abstract bool Died
        {
            get;
            set;
        }
    }
}
