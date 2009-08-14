using System.Collections.ObjectModel;
using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class AdversaryInfo
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName { get; private set; }

        /// <summary>
        /// Gets or sets the initial room.
        /// </summary>
        /// <value>The initial room.</value>
        public int InitialRoom { get; private set; }

        /// <summary>
        /// Gets or sets the initial floor.
        /// </summary>
        /// <value>The initial floor.</value>
        public Floor InitialFloor { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdversaryInfo"/> class.
        /// </summary>
        public AdversaryInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdversaryInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public AdversaryInfo(string name, string shortName, int initialRoom, Floor floor)
        {
            this.Name = name;
            this.ShortName = shortName;
            this.InitialRoom = initialRoom;
            this.InitialFloor = floor;
        }
    }
}
