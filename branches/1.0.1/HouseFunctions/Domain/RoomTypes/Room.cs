using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(UnfinishedFlooredRoom))]
    [XmlInclude(typeof(TelephoneBooth))]
    [XmlInclude(typeof(Elevator))]
    [XmlInclude(typeof(MonsterHangout))]
    public class Room : PositionedEntity
    {
        //TODO: remove creator overloads if possible
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Room"/> is magic.
        /// </summary>
        /// <value><c>true</c> if magic; otherwise, <c>false</c>.</value>
        public bool Magic { get; set; }

        private MagicWord magicWordForRoom = MagicWord.NA;

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
        public AdversaryCollection Adversaries { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public InanimateObjectKeyedCollection Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExitSetKeyedCollection Exits { get; set; }

        private void InitializeCollections()
        {
            Adversaries = new AdversaryCollection();
            Items = new InanimateObjectKeyedCollection();
            Exits = new ExitSetKeyedCollection();
        }

        /// <summary>
        /// 
        /// </summary>
        public Room()
        {
            InitializeCollections();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Room(string name) : base(name) 
        {
            InitializeCollections();
            //adversaries = new AdversaryCollection();
            //items = new InanimateObjectsCollection();
            //exits = new ExitSetKeyedCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        public Room(string name, int roomNumber, Floor floor) : base(name, roomNumber, floor) 
        {
            InitializeCollections();
            //adversaries = new AdversaryCollection();
            //items = new InanimateObjectsCollection();
            //exits = new ExitSetKeyedCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        public Room(string name, int roomNumber, Floor floor, RoomExit[] exits)
            : base(name, roomNumber, floor)
        {
            InitializeCollections();
            //adversaries = new AdversaryCollection();
            //items = new InanimateObjectsCollection();
            //exits = new ExitSetKeyedCollection();

            Array.ForEach(exits, Exits.Add);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        public Room(string name, LocationType location, ReadOnlyExitSetCollection exits)
            : base(name, location)
        {
            InitializeCollections();
            foreach (RoomExit exit in exits)
            {
                this.Exits.Add(exit);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> room is magic.</param>
        /// <param name="word">The word.</param>
        public Room(string name, int roomNumber, Floor floor, RoomExit[] exits, bool magic, MagicWord word)
            : base(name, roomNumber, floor)
        {
            InitializeCollections();
            //adversaries = new AdversaryCollection();
            //items = new InanimateObjectsCollection();
            //exits = new ExitSetKeyedCollection();
            this.Magic = magic;
            this.magicWordForRoom = word;
            foreach (RoomExit exit in exits)
            {
                Exits.Add(exit);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">The word.</param>
        public Room(string name, LocationType location, ReadOnlyExitSetCollection exits, bool magic, MagicWord word)
            : base(name, location)
        {
            InitializeCollections();
            //adversaries = new AdversaryCollection();
            //items = new InanimateObjectsCollection();
            //exits = new ExitSetKeyedCollection();
            this.Magic = magic;
            this.magicWordForRoom = word;
            InitializeCollections();
            foreach (RoomExit exit in exits)
            {
                Exits.Add(exit);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionedEntity"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        public Room(string name, LocationType location)
            : base(name, location)
        {
            
        }
         

    }
}
