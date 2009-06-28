using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ReadOnlyExitSet : ReadOnlyCollection<RoomExit>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyExitSet"/> class.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="list"/> is null.
        /// </exception>
        public ReadOnlyExitSet(IList<RoomExit> list)
            : base(list)
        {

        }

    }
}
