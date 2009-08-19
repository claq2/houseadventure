namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class LockableDoorObjectInfo : StationaryObjectInfo
    {
        /// <summary>
        /// Gets or sets the exit when unlocked.
        /// </summary>
        /// <value>The exit when unlocked.</value>
        public RoomExit ExitWhenUnlocked { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObjectInfo"/> class.
        /// </summary>
        public LockableDoorObjectInfo()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LockableDoorObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exitWhenUnlocked">The exit when unlocked.</param>
        public LockableDoorObjectInfo(string name, string shortName, int initialRoom, Floor floor, RoomExit exitWhenUnlocked)
            : base(name, shortName, initialRoom, floor)
        {
            this.ExitWhenUnlocked = exitWhenUnlocked;
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override HouseCore.InanimateObject2 CreateObject()
        {
            return new LockableDoorObject2(this);
        }
    }
}
