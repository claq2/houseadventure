using System;
using System.Collections.Generic;
using System.Text;

namespace HouseFunctions.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInventoryAction:IActionView
    {
        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
        IList<string> Inventory { get;}

    }
}
