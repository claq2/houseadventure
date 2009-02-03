using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class DropHelper
    {
        private string output;

        /// <summary>
        /// Gets or sets the output.
        /// </summary>
        /// <value>The output.</value>
        public string Output
        {
            get { return output; }
            set { output = value; }
        }
        private bool wonGame;

        /// <summary>
        /// Gets or sets a value indicating whether the game has been won.
        /// </summary>
        /// <value><c>true</c> if the game has been won; otherwise, <c>false</c>.</value>
        public bool WonGame
        {
            get { return wonGame; }
            set { wonGame = value; }
        }
    }
}
