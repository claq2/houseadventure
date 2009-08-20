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
            : base("nothing", 0, Floor.InHand)
        {
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override InanimateObject2 CreateObject()
        {
            return NullObject2.Instance;
        }
    }
}
