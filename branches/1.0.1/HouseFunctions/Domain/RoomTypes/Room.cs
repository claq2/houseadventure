using System;
using System.Xml.Serialization;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(UnfinishedFlooredRoom))]
    [XmlInclude(typeof(TelephoneBooth))]
    [XmlInclude(typeof(Elevator))]
    public class NormalRoom : PositionedEntity
    {
        //TODO: remove creator overloads if possible
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NormalRoom"/> is magic.
        /// </summary>
        /// <value><c>true</c> if magic; otherwise, <c>false</c>.</value>
        public bool Magic { get; set; }

        private MagicWord magicWordForRoom = MagicWord.Undefined;

        private AdversaryCollection adversaries = new AdversaryCollection();
        private InanimateObjectKeyedCollection items = new InanimateObjectKeyedCollection();
        private ExitSetKeyedCollection exits = new ExitSetKeyedCollection();

        /// <summary>
        /// Gets or sets the magic word for room.
        /// </summary>
        /// <value>The magic word for room.</value>
        public MagicWord MagicWordForRoom
        {
            get { return magicWordForRoom; }
            set { magicWordForRoom = value; }
        }

        /// <summary>
        /// Gets or sets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public AdversaryCollection Adversaries { get { return this.adversaries; } }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public InanimateObjectKeyedCollection Items { get { return this.items; } }

        /// <summary>
        /// 
        /// </summary>
        public ExitSetKeyedCollection Exits { get { return this.exits; } }

        /// <summary>
        /// 
        /// </summary>
        public NormalRoom()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public NormalRoom(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public NormalRoom(string name, int roomNumber, Floor floor)
            : base(name, roomNumber, floor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public NormalRoom(string name, int roomNumber, Floor floor, RoomExit[] exits)
            : base(name, roomNumber, floor)
        {
            Array.ForEach(exits, Exits.Add);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        public NormalRoom(string name, LocationType location, ReadOnlyExitSetCollection exits)
            : base(name, location)
        {
            foreach (RoomExit exit in exits)
                this.Exits.Add(exit);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> room is magic.</param>
        /// <param name="word">The word.</param>
        public NormalRoom(string name, int roomNumber, Floor floor, RoomExit[] exits, bool magic, MagicWord word)
            : base(name, roomNumber, floor)
        {
            this.Magic = magic;
            this.magicWordForRoom = word;
            foreach (RoomExit exit in exits)
                Exits.Add(exit);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalRoom"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">The word.</param>
        public NormalRoom(string name, LocationType location, ReadOnlyExitSetCollection exits, bool magic, MagicWord word)
            : base(name, location)
        {
            this.Magic = magic;
            this.magicWordForRoom = word;
            foreach (RoomExit exit in exits)
                Exits.Add(exit);
        }
    }
}
