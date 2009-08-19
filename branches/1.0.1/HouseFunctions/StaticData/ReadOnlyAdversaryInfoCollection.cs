using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ReadOnlyAdversaryInfoCollection : ReadOnlyCollection<AdversaryInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyAdversaryInfoCollection"/> class.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="list"/> is null.</exception>
        public ReadOnlyAdversaryInfoCollection(IList<AdversaryInfo> list)
            : base(list)
        { }
    }
}
