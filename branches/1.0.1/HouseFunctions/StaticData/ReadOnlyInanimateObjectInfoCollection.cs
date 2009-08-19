using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ReadOnlyInanimateObjectInfoCollection : ReadOnlyCollection<InanimateObjectInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyInanimateObjectInfoCollection"/> class.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="list"/> is null.</exception>
        public ReadOnlyInanimateObjectInfoCollection(IList<InanimateObjectInfo> list)
            : base(list)
        {
        }
    }
}
