using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// Object used to return the result of a Get action.
    /// </summary>
    public class GetHelper:LethalActionHelper
    {
        private string output;

        private bool died;

        /// <summary>
        /// Gets or sets a value indicating whether the action killed the player.
        /// </summary>
        /// <value><c>true</c> if the action killed the player; otherwise, <c>false</c>.</value>
        public override bool Died
        {
            get
            {
                return died;
            }
            set
            {
                died = value;
            }
        }

        /// <summary>
        /// Gets or sets the display output.
        /// </summary>
        /// <value>The display output.</value>
        public override string Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
            }
        }
    }
}
