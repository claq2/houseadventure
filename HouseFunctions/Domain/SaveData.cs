namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.ObjectModel;
    using HouseCore.Interfaces;

    /// <summary>
    /// Object used to store application sate to disk and load it again.
    /// </summary>
    [XmlRootAttribute("SaveData", Namespace = "", IsNullable = false)]
    public class SaveData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveData"/> class.
        /// </summary>
        public SaveData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveData"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="rooms">The rooms.</param>
        public SaveData(Player player, RoomKeyedCollection rooms)
        {
            //this.house = view.House;
            this.player = player;
            this._rooms = rooms;
        }

		#region Fields (2) 

        private RoomKeyedCollection _rooms = new RoomKeyedCollection();
        private Player player = new Player();

		#endregion Fields 

		#region Properties (2) 

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player
        {
            get { return this.player; }
            set { this.player = value; }
        }

        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <value>The rooms.</value>
        public RoomKeyedCollection Rooms
        {
            get { return _rooms; }
        }

		#endregion Properties 

 
    }
}
