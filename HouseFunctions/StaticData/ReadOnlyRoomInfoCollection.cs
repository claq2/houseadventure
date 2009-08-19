namespace HouseCore
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    public class ReadOnlyRoomInfoCollection : ReadOnlyCollection<RoomInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyRoomInfoCollection"/> class.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="list"/> is null.</exception>
        public ReadOnlyRoomInfoCollection(IList<RoomInfo> list)
            : base(list)
        {
        }
    }
}
