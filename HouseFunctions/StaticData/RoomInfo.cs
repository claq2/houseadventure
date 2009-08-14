namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Contains readonly information for creating Room objects
    /// </summary>
    public class RoomInfo
    {
        /// <summary>
        /// Gets or sets the floor.
        /// </summary>
        /// <value>The floor.</value>
        public Floor Floor { get; private set; }

        /// <summary>
        /// Gets or sets the exits.
        /// </summary>
        /// <value>The exits.</value>
        public ReadOnlyExitSetCollection Exits { get; private set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the room number.
        /// </summary>
        /// <value>The room number.</value>
        public int RoomNumber { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RoomInfo"/> is magic.
        /// </summary>
        /// <value><c>true</c> if magic; otherwise, <c>false</c>.</value>
        public bool Magic { get; private set; }

        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        /// <value>The word.</value>
        public MagicWord Word { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomInfo"/> class.
        /// </summary>
        public RoomInfo()
            : this(String.Empty, -1, Floor.Undefined, new RoomExit[] { }, MagicWord.Undefined)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public RoomInfo(string name, int roomNumber, Floor floor, RoomExit[] exits)
            : this(name, roomNumber, floor, exits, MagicWord.Undefined)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomInfo"/> class and sets Magic to true if word is not Undefined.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="word">The magic word.</param>
        public RoomInfo(string name, int roomNumber, Floor floor, RoomExit[] exits, MagicWord word)
        {
            this.Name = name;
            this.Floor = floor;
            this.RoomNumber = roomNumber;
            this.Exits = new ReadOnlyExitSetCollection(exits);
            this.Magic = word != MagicWord.Undefined;
            this.Word = word;
        }
    }
}
