using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Room2 : GameEntity
    {
        /// <summary>
        /// Gets or sets the room number.
        /// </summary>
        /// <value>The room number.</value>
        public int RoomNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="NormalRoom"/> is magic.
        /// </summary>
        /// <value><c>true</c> if magic; otherwise, <c>false</c>.</value>
        public bool Magic { get; set; }

        private MagicWord magicWordForRoom = MagicWord.Undefined;

        private Adversary2Collection adversaries = new Adversary2Collection();
        private InanimateObject2KeyedCollection items = new InanimateObject2KeyedCollection();
        private ReadOnlyExitSetCollection exits;

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
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public Adversary2Collection Adversaries { get { return this.adversaries; } }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public InanimateObject2KeyedCollection Items { get { return this.items; } }

        /// <summary>
        /// Gets the exits.
        /// </summary>
        /// <value>The exits.</value>
        public ReadOnlyExitSetCollection Exits { get { return this.exits; } private set { this.exits = value; } }

        /// <summary>
        /// Gets or sets the room to the north.
        /// </summary>
        /// <value>The north.</value>
        public Room2 North { get; set; }

        /// <summary>
        /// Gets or sets the room to the south.
        /// </summary>
        /// <value>The south.</value>
        public Room2 South { get; set; }

        /// <summary>
        /// Gets or sets the room to the east.
        /// </summary>
        /// <value>The east.</value>
        public Room2 East { get; set; }

        /// <summary>
        /// Gets or sets the room to the west.
        /// </summary>
        /// <value>The west.</value>
        public Room2 West { get; set; }

        /// <summary>
        /// Gets or sets room above.
        /// </summary>
        /// <value>Up.</value>
        public Room2 Up { get; set; }

        /// <summary>
        /// Gets or sets room below.
        /// </summary>
        /// <value>Down.</value>
        public Room2 Down { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        protected Room2()
            : base()
        {
            InitializeDirections();
        }

        private void InitializeDirections()
        {
            this.North = null;
            this.South = null;
            this.East = null;
            this.West = null;
            this.Up = null;
            this.West = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected Room2(string name)
            : base(name)
        {
            InitializeDirections();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        protected Room2(string name, int roomNumber)
            : this(name)
        {
            this.RoomNumber = roomNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        protected Room2(string name, int roomNumber, RoomExit[] exits)
            : this(name, roomNumber)
        {
            this.Exits = new ReadOnlyExitSetCollection(exits);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        protected Room2(string name, int roomNumber, ReadOnlyExitSetCollection exits)
            : this(name, roomNumber)
        {
            this.Exits = new ReadOnlyExitSetCollection(exits);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> room is magic.</param>
        /// <param name="word">The word.</param>
        protected Room2(string name, int roomNumber, RoomExit[] exits, bool magic, MagicWord word)
            : this(name, roomNumber)
        {
            this.Magic = magic;
            this.magicWordForRoom = word;
            this.Exits = new ReadOnlyExitSetCollection(exits);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">The word.</param>
        protected Room2(string name, int roomNumber, ReadOnlyExitSetCollection exits, bool magic, MagicWord word)
            : this(name, roomNumber)
        {
            this.Magic = magic;
            this.magicWordForRoom = word;
            //foreach (RoomExit exit in exits)
            //    Exits.Add(exit);
            this.Exits = new ReadOnlyExitSetCollection(exits);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        /// <param name="roomInfo">The room info.</param>
        protected Room2(NormalRoomInfo roomInfo)
            : base(roomInfo.Name)
        {
            InitializeDirections();
            this.Name = roomInfo.Name;
            this.Magic = roomInfo.Magic;
            this.RoomNumber = roomInfo.RoomNumber;
            this.MagicWordForRoom = roomInfo.Word;
            this.Exits = new ReadOnlyExitSetCollection(roomInfo.Exits);
        }
    }
}
