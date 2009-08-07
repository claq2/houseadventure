//-----------------------------------------------------------------------
// <copyright file="Room2.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(UnfinishedFlooredRoom2))]
    [XmlInclude(typeof(TelephoneBooth2))]
    [XmlInclude(typeof(Elevator2))]
    public class Room2 : GameEntity
    {
        /// <summary>
        /// Gets or sets the room number.
        /// </summary>
        /// <value>The room number.</value>
        public int RoomNumber { get; set; }

                /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Room"/> is magic.
        /// </summary>
        /// <value><c>true</c> if magic; otherwise, <c>false</c>.</value>
        public bool Magic { get; set; }

        private MagicWord magicWordForRoom = MagicWord.NA;

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
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public AdversaryCollection Adversaries { get { return this.adversaries; } }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public InanimateObjectKeyedCollection Items { get { return this.items; } }

        /// <summary>
        /// Gets the exits.
        /// </summary>
        /// <value>The exits.</value>
        public ExitSetKeyedCollection Exits { get { return this.exits; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room2"/> class.
        /// </summary>
        public Room2()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Room2(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        public Room2(string name, int roomNumber)
            : base(name)
        {
            this.RoomNumber = roomNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        public Room2(string name, int roomNumber, RoomExit[] exits)
            : this(name, roomNumber)
        {
            Array.ForEach(exits, Exits.Add);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        public Room2(string name, int roomNumber, ReadOnlyExitSetCollection exits)
            : this(name, roomNumber)
        {
            foreach (RoomExit exit in exits)
                this.Exits.Add(exit);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> room is magic.</param>
        /// <param name="word">The word.</param>
        public Room2(string name, int roomNumber, RoomExit[] exits, bool magic, MagicWord word)
            : this(name, roomNumber)
        {
            this.Magic = magic;
            this.magicWordForRoom = word;
            foreach (RoomExit exit in exits)
                Exits.Add(exit);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="exits">The exits.</param>
        /// <param name="magic">if set to <c>true</c> [magic].</param>
        /// <param name="word">The word.</param>
        public Room2(string name, int roomNumber, ReadOnlyExitSetCollection exits, bool magic, MagicWord word)
            : this(name, roomNumber)
        {
            this.Magic = magic;
            this.magicWordForRoom = word;
            foreach (RoomExit exit in exits)
                Exits.Add(exit);
        }
    }
}
