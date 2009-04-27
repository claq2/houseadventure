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
        /// <param name="view">The view.</param>
        public SaveData(IHouseView view)
        {
            //this.house = view.House;
            this.player = view.Player;
            this._rooms = view.House.Rooms;
        }

		#region Fields (12) 

        //private AdversaryCollection adversaryCollection;
        //private InanimateObjectsCollection allInanimateObjects;
        //private PortableObject allPortableObjects;
        // TheHouse fields
        // private RoomKeyedCollection allRooms;
        //private RoomKeyedCollection basementRooms = new RoomKeyedCollection();
        //private RoomKeyedCollection firstFloorRooms = new RoomKeyedCollection();
        // PlayerEntity fields
        //private InanimateObjectsCollection inventory = new InanimateObjectsCollection();
        //private int itemsRemovedFromHouse;
        //private RoomKeyedCollection monsterHangoutRooms = new RoomKeyedCollection();
        //private int numberOfMoves;
        //private RoomKeyedCollection secondFloorRooms = new RoomKeyedCollection();
        // private Impostor theImpostor;
        //private RoomKeyedCollection thirdFloorRooms= new RoomKeyedCollection();
        private RoomKeyedCollection _rooms = new RoomKeyedCollection();
        private Player player = new Player();
        //private HouseType house = new HouseType(false);

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
        /// Gets or sets the house.
        /// </summary>
        /// <value>The house.</value>
        //public HouseType House
        //{
        //    get { return this.house; }
        //    set { this.house = value; }
        //}

        /// <summary>
        /// Gets the rooms.
        /// </summary>
        /// <value>The rooms.</value>
        public RoomKeyedCollection Rooms
        {
            get { return _rooms; }
        }

        //private int timesLookedInDark;

        //private InanimateObjectKeyedCollection keyedInventory;

		#endregion Fields 

		#region Properties (8) 

        ///// <summary>
        ///// Gets or sets the basement rooms.
        ///// </summary>
        ///// <value>The basement rooms.</value>
        //public RoomKeyedCollection BasementRooms
        //{
        //    get { return basementRooms; }
        //}

        ///// <summary>
        ///// Gets or sets the first floor rooms.
        ///// </summary>
        ///// <value>The first floor rooms.</value>
        //public RoomKeyedCollection FirstFloorRooms
        //{
        //    get { return firstFloorRooms; }
        //}

        /// <summary>
        /// Gets or sets the items removed from house.
        /// </summary>
        /// <value>The items removed from house.</value>
        //public int ItemsRemovedFromHouse
        //{
        //    get { return itemsRemovedFromHouse; }
        //    set { itemsRemovedFromHouse = value; }
        //}

        ///// <summary>
        ///// Gets or sets the monster hangout rooms.
        ///// </summary>
        ///// <value>The monster hangout rooms.</value>
        //public RoomKeyedCollection MonsterHangoutRooms
        //{
        //    get { return monsterHangoutRooms; }
        //}

        /// <summary>
        /// Gets or sets the number of moves.
        /// </summary>
        /// <value>The number of moves.</value>
        //public int NumberOfMoves
        //{
        //    get { return numberOfMoves; }
        //    set { numberOfMoves = value; }
        //}

        ///// <summary>
        ///// Gets or sets the second floor rooms.
        ///// </summary>
        ///// <value>The second floor rooms.</value>
        //public RoomKeyedCollection SecondFloorRooms
        //{
        //    get { return secondFloorRooms; }
        //}

        ///// <summary>
        ///// Gets or sets the third floor rooms.
        ///// </summary>
        ///// <value>The third floor rooms.</value>
        //public RoomKeyedCollection ThirdFloorRooms
        //{
        //    get { return thirdFloorRooms; }
        //}

        /// <summary>
        /// Gets or sets the times looked in dark.
        /// </summary>
        /// <value>The times looked in dark.</value>
       // public int TimesLookedInDark
        //{
        //    get { return timesLookedInDark; }
        //    set { timesLookedInDark = value; }
        //}

		#endregion Properties 

        /// <summary>
        /// Gets or sets the inventory.
        /// </summary>
        /// <value>The inventory.</value>
        //public InanimateObjectsCollection Inventory
        //{
        //    get { return inventory; }
        //}

        /// <summary>
        /// Gets the keyed inventory.
        /// </summary>
        /// <value>The keyed inventory.</value>
        //public InanimateObjectKeyedCollection KeyedInventory
        //{
        //    get { return keyedInventory; }
        //}

        /// <summary>
        /// Populates the inventory.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        //public void PopulateInventory(InanimateObjectsCollection inventory)
        //{
        //    PopulateCollection<InanimateObject>(inventory, this.inventory);
        //}

        /// <summary>
        /// Populates the rooms.
        /// </summary>
        /// <param name="rooms">The rooms.</param>
        public void PopulateRooms(RoomKeyedCollection rooms)
        {
            PopulateCollection<Room>(rooms, this._rooms);
        }

        /// <summary>
        /// Populates the rooms of one floor.
        /// </summary>
        /// <param name="rooms">The rooms.</param>
        /// <param name="floor">The floor.</param>
        /// <exception cref="System.ArgumentException">Thrown if the floor of one of the rooms in rooms is not the same as the floor parameter.</exception>
        public void PopulateRoomsOfOneFloor(RoomKeyedCollection rooms, Floor floor)
        {
            int intCount = rooms.Count;
            for (int i = 0; i < intCount; i++)
            {
                if (rooms[i].Location.Floor != floor)
                {
                    throw new ArgumentException("The floor of one of the rooms in the collection is not the same as the indicated floor.");
                }
            }

            //switch (floor)
            //{
            //    case Floor.Basement:
            //        PopulateCollection<Room>(rooms, this.basementRooms);
            //        break;
            //    case Floor.FirstFloor:
            //        PopulateCollection<Room>(rooms, this.firstFloorRooms);
            //        break;
            //    case Floor.SecondFloor:
            //        PopulateCollection<Room>(rooms, this.secondFloorRooms);
            //        break;
            //    case Floor.ThirdFloor:
            //        PopulateCollection<Room>(rooms, this.thirdFloorRooms);
            //        break;
            //    case Floor.MonsterHangout:
            //        PopulateCollection<Room>(rooms, this.monsterHangoutRooms);
            //        break;
            //    default:
            //        break;
            //}
        }

        private static void PopulateCollection<T, U>(KeyedCollection<T, U> collection1, KeyedCollection<T, U> collection2) where U : GameEntity
        {
            int intCount = collection1.Count;
            for (int i = 0; i < intCount; i++)
            {
                collection2.Add(collection1[i]);
            }
        }

        /// <summary>
        /// Adds the elements in collection1 to collection2.
        /// </summary>
        /// <typeparam name="T">Must dereive from GameEntity</typeparam>
        /// <param name="collection1">The "from" collection.</param>
        /// <param name="collection2">The "to" collection.</param>
        private static void PopulateCollection<T>(Collection<T> collection1, Collection<T> collection2) where T : GameEntity
        {
            int intCount = collection1.Count;
            for (int i = 0; i < intCount; i++)
            {
                collection2.Add(collection1[i]);
            }
        }
    }
}
