namespace HouseCore
{
    /// <summary>
    /// Class that represents a locked door
    /// </summary>
    public class LockableDoorObject2 : StationaryObject2
    {
        /// <summary>
        /// Gets or sets the direction when unlocked.
        /// </summary>
        /// <value>The direction when unlocked.</value>
        public DirectionConstants DirectionWhenUnlocked { get; private set; }

        /// <summary>
        /// Gets or sets the destination room.
        /// </summary>
        /// <value>The destination room.</value>
        public int DestinationRoom { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObject2"/> class.
        /// </summary>
        public LockableDoorObject2()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObject2"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public LockableDoorObject2(LockableDoorObjectInfo info)
            : base(info)
        {
            this.DestinationRoom = info.DestinationRoom;
            this.DirectionWhenUnlocked = info.DirectionWhenUnlocked;
        }
    }
}
