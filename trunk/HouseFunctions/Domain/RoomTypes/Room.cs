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
        private bool magic;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Room"/> is magic.
        /// </summary>
        /// <value><c>true</c> if magic; otherwise, <c>false</c>.</value>
        public bool Magic
        {
            get { return magic; }
            set { magic = value; }
        }

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
        private AdversaryCollection adversaries;

        /// <summary>
        /// Gets or sets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public AdversaryCollection Adversaries
        {
            get { return adversaries; }
            //set { adversaries = value; }
        }

        //private Collection<InanimateObject> inanimateObjects;

        //public Collection<InanimateObject> InanimateObjects
        //{
        //    get { return inanimateObjects; }
        //    set { inanimateObjects = value; }
        //}

        private InanimateObjectsCollection items;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public InanimateObjectsCollection Items
        {
            get {return items;}
            //set {items = value;}
        }

        private ExitSetKeyedCollection exits;

        /// <summary>
        /// 
        /// </summary>
        public ExitSetKeyedCollection Exits
        {
            get { return exits; }
            //set { exits = value; }
        }

        private void InitializeCollections()
        {
            adversaries = new AdversaryCollection();
            items = new InanimateObjectsCollection();
            exits = new ExitSetKeyedCollection();
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
        public Room(string name, LocationType location, ExitSetKeyedCollection exits)
            : base(name, location)
        {
            InitializeCollections();
            this.exits = exits;
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
            this.magic = magic;
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
        public Room(string name, LocationType location, ExitSetKeyedCollection exits, bool magic, MagicWord word)
            : base(name, location)
        {
            InitializeCollections();
            //adversaries = new AdversaryCollection();
            //items = new InanimateObjectsCollection();
            //exits = new ExitSetKeyedCollection();
            this.magic = magic;
            this.magicWordForRoom = word;
            InitializeCollections();
            this.exits = exits;
        }

    }
}
