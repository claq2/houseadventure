namespace HouseCore
{
    /// <summary>
    /// Class that represents a locked door
    /// </summary>
    public class LockableDoorObject2 : StationaryObject2
    {
        /// <summary>
        /// Gets or sets the exit when unlocked.
        /// </summary>
        /// <value>The exit when unlocked.</value>
        public RoomExit ExitWhenUnlocked { get; private set; }

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
            this.ExitWhenUnlocked = info.ExitWhenUnlocked;
        }
    }
}
