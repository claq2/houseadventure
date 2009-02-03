using System;
using System.Collections.Generic;
using System.Text;

namespace HouseFunctions.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IArgumentAction:IActionView
    {
        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        string Argument { get; set;}

    }
}
