namespace HouseCore
{
    /// <summary>
    /// Contains readonly information for creating NormalRoom objects
    /// </summary>
    public class NormalRoomInfo : RoomInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoomInfo"/> class.
        /// </summary>
        public NormalRoomInfo()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoomInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public NormalRoomInfo(string name, int roomNumber, Floor floor, RoomExit[] exits)
            : base(name, roomNumber, floor, exits)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoomInfo"/> class and sets Magic to true if word is not Undefined.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="word">The magic word.</param>
        public NormalRoomInfo(string name, int roomNumber, Floor floor, RoomExit[] exits, MagicWord word):base(name, roomNumber, floor, exits, word)
        {
        }

        /// <summary>
        /// Creates the room.
        /// </summary>
        /// <returns></returns>
        public override Room2 CreateRoom()
        {
            return new NormalRoom2(this);
        }
    }
}
