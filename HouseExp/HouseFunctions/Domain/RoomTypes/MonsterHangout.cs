namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class MonsterHangout:Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterHangout"/> class.
        /// </summary>
        public MonsterHangout() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterHangout"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public MonsterHangout(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterHangout"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        public MonsterHangout(string name, LocationType location, ExitSetKeyedCollection exits) : base(name, location, exits) { }
    }
}
