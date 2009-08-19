namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class NullObjectInfo : InanimateObjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullObjectInfo"/> class.
        /// </summary>
        public NullObjectInfo()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullObjectInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public NullObjectInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override InanimateObject2 CreateObject()
        {
            return new NullObject2(this);
        }
    }
}
