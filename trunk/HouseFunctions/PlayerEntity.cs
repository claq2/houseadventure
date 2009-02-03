using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRootAttribute("PlayerEntity", Namespace="", IsNullable=false)]
    public class PlayerEntity : PositionedEntity
    {

		#region Fields (6) 

        //private Collection<InanimateObject> inventory;
        private InanimateObjectsCollection inventory;
        private int itemsRemovedFromHouse;
        private const int maximumInventoryItems = 4;
        private const int maximumLooksInDark = 3;
        private int numberOfMoves;
        private int timesLookedInDark;
        private TheSingletonHouse house;
        private Dictionary<ActionShortName, bool> requiesArgument = new Dictionary<ActionShortName, bool>();
		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// 
        /// </summary>
        public PlayerEntity()
        {
            inventory = new InanimateObjectsCollection();
            Location.Floor = Floor.FirstFloor;
            Location.RoomNumber = 1;
            InitializeArgumentDictionary();
        }

        private void InitializeArgumentDictionary()
        {
            requiesArgument.Add(ActionShortName.Bru, true);
            requiesArgument.Add(ActionShortName.Dig, true);
            requiesArgument.Add(ActionShortName.Dro, true);
            requiesArgument.Add(ActionShortName.Get, true);
            requiesArgument.Add(ActionShortName.Inv, false);
            requiesArgument.Add(ActionShortName.Kil, true);
            requiesArgument.Add(ActionShortName.Lig, false);
            requiesArgument.Add(ActionShortName.Loa, false);
            requiesArgument.Add(ActionShortName.Loo, false);
            requiesArgument.Add(ActionShortName.Off, false);
            requiesArgument.Add(ActionShortName.On, false);
            requiesArgument.Add(ActionShortName.Ope, true);
            requiesArgument.Add(ActionShortName.Pla, true);
            requiesArgument.Add(ActionShortName.Qui, false);
            requiesArgument.Add(ActionShortName.Rea, true);
            requiesArgument.Add(ActionShortName.Sav, false);
            requiesArgument.Add(ActionShortName.Say, true);
            requiesArgument.Add(ActionShortName.Spr, true);
            requiesArgument.Add(ActionShortName.Sta, true);
            requiesArgument.Add(ActionShortName.Tak, true);
            requiesArgument.Add(ActionShortName.Unl, true);
            requiesArgument.Add(ActionShortName.Wav, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerEntity"/> class.
        /// </summary>
        /// <param name="house">The house.</param>
        public PlayerEntity(TheSingletonHouse house)
        {
            inventory = new InanimateObjectsCollection();
            Location.Floor = Floor.FirstFloor;
            Location.RoomNumber = 1;
            this.house = house;

        }
		#endregion Constructors 

		#region Methods (25) 


		// Public Methods (25) 

        ///// <summary>
        ///// Brushes the specified item.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns></returns>
        //public string Brush(string item)
        //{
        //    return Brush(item, house.Rooms[this.Location]);
        //}

        /// <summary>
        /// 
        /// </summary>
        public string Brush(string item)
        {
            Room room = house.Rooms[this.Location];
            Adversary adversaryLeopard = house.Adversaries[TheHouseData.LeopardShortName];
            PortableObject portableObjectBrush = house.InanimateObjects[TheHouseData.BrushShortName] as PortableObject;
            StringBuilder sbOutput = new StringBuilder();

            // Trying to brush non adverasry?
            if (!house.Adversaries.Contains(item, false))
            {
                sbOutput.Append("You can't brush that");
            }
            // Trying to brush adversary that is not in the room?
            else if (!room.Adversaries.Contains(item, false))
            {
                sbOutput.Append("I see no ");
                sbOutput.Append(item);
                sbOutput.Append(" here");
            }
            // Trying to brush adversary in the room but don't have a brush?
            else if (!inventory.Contains(portableObjectBrush))
            {
                sbOutput.Append("You have nothing with which to brush the ");
                sbOutput.Append(item);
            }
            // Trying to brush adversary in room with your brush but it's not the leopard?
            else if (!house.Adversaries[item].Equals(adversaryLeopard))
            {
                sbOutput.Append("The ");
                sbOutput.Append(item);
                sbOutput.Append(" will become angry if you persist!");
            }
            // Must be trying to brush the leopard in the room with the brush
            else
            {
                HideAdversary(adversaryLeopard);
                sbOutput.Append("Purrrrrrr!!!!!!!!  The leopard is very gratified for the grooming and leaves");
            }
            return sbOutput.ToString();
        }

        ///// <summary>
        ///// Digs the specified item.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns></returns>
        //public string Dig(string item)
        //{
        //    return Dig(item, TheHouse.GetRoom(this.Location));
        //}

        /// <summary>
        /// Digs the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public string Dig(string item)
        {
            Room room = house.Rooms[this.Location];
            StringBuilder sbOutput = new StringBuilder();
#if DEBUG
            ////this.inventory.Add(house.InanimateObjects[TheHouseData.ShovelShortName]);
#endif
            if (String.Compare(item, "dirt", true, System.Globalization.CultureInfo.CurrentCulture) != 0 && String.Compare(item, "floor", true, System.Globalization.CultureInfo.CurrentCulture) != 0)
            {
                sbOutput.Append("You can't dig the ");
                sbOutput.Append(item);
                sbOutput.Append(".");
            }
            else if (!(room is UnfinishedFlooredRoom))
            {
                sbOutput.Append("I see no dirt to dig here.");
            }
            else if (!this.inventory.Contains(house.InanimateObjects[TheHouseData.ShovelShortName]))
            {
                sbOutput.Append("You don't have anything with which to dig.");
            }
            else
            {
                sbOutput.Append("Digging... ");
                foreach (InanimateObject inanimateObjectCurrent in room.Items)
                {
                    PortableObject portableObjectCurrent = inanimateObjectCurrent as PortableObject;
                    //BuriedObject buriedObj = obj as BuriedObject;
                    if (portableObjectCurrent != null && portableObjectCurrent.Buried == true)
                    {
                        portableObjectCurrent.Buried = false;
                        sbOutput.Append("I found something!");
                        break;
                    }
                }
            }
            return sbOutput.ToString();
        }

        /// <summary>
        /// Drops the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>DropHelper object that contains information about the result.</returns>
        public DropHelper Drop(string item)
        {
            DropHelper dropHelper = new DropHelper();
            StringBuilder sbOutput = new StringBuilder();
            InanimateObject inanimateObjectTarget = null;
            dropHelper.WonGame = false;
            InanimateObjectsCollection multiplePieceObjectsInInventory = new InanimateObjectsCollection();
            try
            {
                inanimateObjectTarget = house.InanimateObjects[item];
            }
            catch (KeyNotFoundException)
            {
            }
            if (inanimateObjectTarget != null)
            {
                if (!(inanimateObjectTarget is PortableObject))
                {
                    sbOutput.Append("You can't drop that");
                }
                else if (!Inventory.Contains(inanimateObjectTarget))
                {
                    sbOutput.Append("You don't have a ");
                    sbOutput.Append(item);
                }
                else if (inanimateObjectTarget.Equals(house.InanimateObjects[TheHouseData.BatteriesShortName]) || inanimateObjectTarget.Equals(house.InanimateObjects[TheHouseData.FlashlightShortName]))
                {
                    LightOff();
                }
                else if (inanimateObjectTarget is ContainerObject && Inventory.ContainsByType(typeof(MultiplePieceObject), multiplePieceObjectsInInventory))
                {
                    sbOutput.Append("Try dropping the following items first:  ");
                    int iCount = 0;
                    foreach (InanimateObject mpo in multiplePieceObjectsInInventory)
                    {
                        sbOutput.Append(mpo.Name);
                        iCount++;
                        if (iCount < multiplePieceObjectsInInventory.Count)
                        {
                            sbOutput.Append(", ");
                        }
                    }
                }
                else if (inanimateObjectTarget is ProtectiveObject && Inventory.ContainsByType(typeof(PainfulObject)))
                {
                    sbOutput.Append("You'll hurt yourself");
                }
                else if (inanimateObjectTarget is DelicateObject && !house.Rooms[Location].Items.ContainsByType(typeof(CushioningObject)))
                {
                    sbOutput.Append("It will break");
                }
                else
                {
                    Inventory.Remove(inanimateObjectTarget);
                    house.Rooms[Location].Items.Add(inanimateObjectTarget);
                    if (Location.Equals(TheHouseData.LocationFirstFloorFrontPorch))
                    {
                        itemsRemovedFromHouse++;
                        if (itemsRemovedFromHouse == house.PortableObjects.Count)
                        {
                            dropHelper.WonGame = true;
                        }
                    }
                }
            }
            else
            {
                 sbOutput.Append("You can't drop that");
            }
            dropHelper.Output = sbOutput.ToString();
            return dropHelper;
        }

        ///// <summary>
        ///// Gets the specified item.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns>GetHelper object that contains the result of the action.</returns>
        //public GetHelper Get(string item)
        //{
        //    GetHelper getHelper = new GetHelper();
        //    bool died;
        //    string response = Get(item, TheHouse.GetRoom(this.Location), out died);
        //    getHelper.Output = response;
        //    getHelper.Died = died;
        //    return getHelper;
        //}

        ///// <summary>
        ///// Gets the specified item.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <param name="died">if set to <c>true</c> [died].</param>
        ///// <returns></returns>
        //public string Get(string item, out bool died)
        //{
        //    return Get(item, TheHouse.GetRoom(this.Location), out died);
        //}

        /// <summary>
        /// Gets the specified item name.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <returns></returns>
        public GetHelper Get(string itemName)
        {
            StringBuilder sbOutput = new StringBuilder();
            GetHelper getHelper = new GetHelper();
            PortableObject portableObjectTarget = null;
            Room room = house.Rooms[Location];
            //died = false;
            getHelper.Died = false;
            // Trying to pick up known object?
            try
            {
                portableObjectTarget = house.InanimateObjects[itemName] as PortableObject;
            }
            catch (KeyNotFoundException)
            {
                portableObjectTarget = null;
            }

            // Is a known portable item
            if (portableObjectTarget != null)
            {
                // Item not in room or item in room but buried or invisible
                if (!house.Rooms[Location].Items.Contains(portableObjectTarget) || (house.Rooms[Location].Items.Contains(portableObjectTarget) && (portableObjectTarget.Buried || !portableObjectTarget.Visible)))
                {
                    // Impostor in room and its name is the same as the target item
                    if (portableObjectTarget.Equals(house.Adversaries.TheImpostor) && house.Rooms[Location].Adversaries.Contains(house.Adversaries.TheImpostor))
                    {
                        getHelper.Died = true;
                        //died = true;
                        sbOutput.Append("Aughhhh . . .\r\n\r\nRemember?!");
                    }
                    else
                    // Nothing by that name is in the room
                    {
                        sbOutput.Append("I see no ");
                        sbOutput.Append(itemName);
                        sbOutput.Append(" here");
                    }
                }
                else if (house.Rooms[Location].Adversaries.ContainsNonImpostor())
                // Room has an adversary that is not the imposter
                {
                    sbOutput.Append("This room's occupant seems to have grown very attached to the ");
                    sbOutput.Append(itemName);
                    sbOutput.Append(" and won't let you have it");
                }
                else if (this.inventory.Count < maximumInventoryItems)
                {
                    if (portableObjectTarget is MultiplePieceObject)
                    {
                        if (this.inventory.ContainsByType(typeof(ContainerObject)))
                        {
                            this.inventory.Add(portableObjectTarget);
                            room.Items.Remove(portableObjectTarget);
                        }
                        else
                        {
                            sbOutput.Append("You can't pick up that many small items!");
                        }
                    }
                    else if (portableObjectTarget is PainfulObject)
                    {
                        bool bHasProtectiveItem = false;
                        foreach (InanimateObject inanimateObject in this.inventory)
                        {
                            if (inanimateObject is ProtectiveObject)
                            {
                                bHasProtectiveItem = true;
                            }
                        }

                        if (bHasProtectiveItem)
                        {
                            this.inventory.Add(portableObjectTarget);
                            room.Items.Remove(portableObjectTarget);
                        }
                        else
                        {
                            sbOutput.Append("Ouch! That hurts! You can't pick that up!");
                        }
                    }
                    else
                    {
                        this.inventory.Add(portableObjectTarget);
                        room.Items.Remove(portableObjectTarget);
                        sbOutput.Append(itemName);
                        sbOutput.Append(" taken");
                    }
                }
                else
                {
                    sbOutput.Append("You can't carry that much.  You'll have to drop something.");
                }
            }
            else
            {
                sbOutput.Append("You can't take the ");
                sbOutput.Append(itemName);
            }
            getHelper.Output = sbOutput.ToString();
            return getHelper;

        }

        /// <summary>
        /// Increments the number of moves.
        /// </summary>
        public void IncrementNumberOfMoves()
        {
            numberOfMoves++;
        }

        /// <summary>
        /// Switches the light to the specified state
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public string Light(Switch state)
        {
            StringBuilder sbOutput = new StringBuilder();
            OnOffObject onOffObjectFlashlight = house.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = house.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
            if (state == Switch.On)
            {
                if (!Inventory.Contains(onOffObjectFlashlight))
                {
                    sbOutput.Append("You have no light to turn on!");
                    return sbOutput.ToString();
                }
                if (!Inventory.Contains(consumableObjectBatteries))
                {
                    sbOutput.Append("It doesn't work");
                    return sbOutput.ToString();
                }
                if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    sbOutput.Append("The batteries are exhausted");
                    return sbOutput.ToString();
                }
                onOffObjectFlashlight.State = Switch.On;
                sbOutput.Append("Light on");
                timesLookedInDark = 0;
                return sbOutput.ToString();
            }
            else
            {
                if (!Inventory.Contains(onOffObjectFlashlight))
                {
                    sbOutput.Append("You have no light to turn off!");
                    return sbOutput.ToString();
                }
                if (!Inventory.Contains(consumableObjectBatteries))
                {
                    sbOutput.Append("It doesn't work anyway -- so why turn it off!");
                    return sbOutput.ToString();
                }
                if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    sbOutput.Append("The batteries are already dead!");
                    return sbOutput.ToString();
                }
                onOffObjectFlashlight.State = Switch.Off;
                sbOutput.Append("Light off");
                return sbOutput.ToString();
            }
        }

        /// <summary>
        /// Turns the light on.
        /// </summary>
        /// <returns></returns>
        public string LightOff()
        {
            return Light(Switch.Off);
        }

        /// <summary>
        /// Turns the light off.
        /// </summary>
        /// <returns></returns>
        public string LightOn()
        {
            return Light(Switch.On);
        }

        /// <summary>
        /// Lists the inventory.
        /// </summary>
        /// <returns></returns>
        public string ListInventory()
        {
            StringBuilder sbOutput = new StringBuilder();

            sbOutput.Append("You are presently carrying\r\n");
            if (this.inventory.Count == 0)
            {
                sbOutput.Append("nothing\r\n");
            }
            else
            {
                foreach (InanimateObject inanimateObject in this.inventory)
                {
                    sbOutput.Append(inanimateObject.Name);
                    sbOutput.Append("\r\n");
                }
            }

            return sbOutput.ToString();
        }

        ///// <summary>
        ///// Looks the specified after verical movement.
        ///// </summary>
        ///// <param name="afterVerticalMovement">if set to <c>true</c>, indicates player just performed a vertical movement.</param>
        ///// <returns></returns>
        //public LookHelper Look(bool afterVerticalMovement)
        //{
        //    LookHelper lookHelper = new LookHelper();
        //    bool died;
        //    string output = Look(TheHouse.GetRoom(this.Location), afterVerticalMovement, out died, out lookHelper);
        //    //lookHelper.Output = output;
        //    //lookHelper.Died = died;
        //    return lookHelper;
        //}

        ///// <summary>
        ///// Looks this instance.
        ///// </summary>
        ///// <param name="afterVerticalMovement">if set to <c>true</c> [after vertical movement].</param>
        ///// <param name="died">if set to <c>true</c> [died].</param>
        ///// <returns></returns>
        //public string Look(bool afterVerticalMovement, out bool died)
        //{
        //    LookHelper lookHelper = new LookHelper();
        //    return Look(TheHouse.GetRoom(this.Location), afterVerticalMovement, out died, out lookHelper);
        //}

        ///// <summary>
        ///// Looks this instance.
        ///// </summary>
        ///// <returns></returns>
        //public string Look()
        //{
        //    bool boolDied;
        //    LookHelper lookHelper = new LookHelper();
        //    return Look(TheHouse.GetRoom(this.Location), false, out boolDied, out lookHelper);
        //}

        /// <summary>
        /// Looks in the current room.
        /// </summary>
        /// <param name="afterVerticalMovement">if set to <c>true</c> indicates that the player just performed a vertical movement.</param>
        /// <returns>LookHelper object that contains results of the Look operation.</returns>
        //public string Look(Room room, bool afterVerticalMovement, out bool died, out LookHelper lookHelper)
        public LookHelper Look(bool afterVerticalMovement)
        {
            Room room = house.Rooms[Location];
            LookHelper lookHelper = new LookHelper();
            Random random = new Random();
            //StringBuilder sbOutput = new StringBuilder();
            //died = false;
            lookHelper.Died = false;
            if (!afterVerticalMovement && Inventory.Contains(house.InanimateObjects[TheHouseData.DimeName]) && room is TelephoneBooth)
            {
                this.Location.Floor = (Floor)random.Next(4);
            }
            //sbOutput.Append("\r\n\r\n");
            //sbOutput.Append("You are ");
            //sbOutput.Append(room.Name);
            lookHelper.RoomName = room.Name;
            if (random.Next(50) < 10)
            {
                house.RemoveFrontPorchItems();
            }
            if (random.Next(50) < 40)
            {
                house.UpdateMonstersInHangout();
            }
            //sbOutput.Append("\r\n");
            //sbOutput.Append("I see:\r\n");
            OnOffObject onOffObjectFlashlight = house.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            if (Location.Floor == Floor.Basement && onOffObjectFlashlight.State == Switch.Off)
            {
                //sbOutput.Append("nothing--it's too dark!");
                lookHelper.Output = "nothing--it's too dark!";
                timesLookedInDark++;
                if (timesLookedInDark > maximumLooksInDark)
                {
                    //sbOutput.Append("Aughhhh . . .\r\nBeware of things unseen !!");
                    lookHelper.Output = "Aughhhh . . .\r\nBeware of things unseen !!";
//                    died = true;
                    lookHelper.Died = true;
                }
            }
            else
            {
                foreach (Adversary adversary in room.Adversaries)
                {
                    //sbOutput.Append(adversary.Name);
                    //sbOutput.Append("\r\n");
                    lookHelper.Adversaries.Add(adversary);
                }
                //foreach (InanimateObject inanimateObject in room.InanimateObjects)
                foreach (InanimateObject inanimateObject in room.Items)
                {
                    PortableObject po = inanimateObject as PortableObject;
                    if (po == null) // if it's an unportable object
                    {
                        //sbOutput.Append(inanimateObject.Name);
                        //sbOutput.Append("\r\n");
                        lookHelper.Items.Add(inanimateObject);
                    }
                    else if (po.Visible && !po.Buried)
                    {
                        //sbOutput.Append(po.Name);
                        //sbOutput.Append("\r\n");
                        lookHelper.Items.Add(inanimateObject);
                    }
                }
                //sbOutput.Append("Obvious exits are:\r\n");
                foreach (RoomExit exit in room.Exits)
                {
                    //sbOutput.Append(exit.ExitDirection.ToString());
                    lookHelper.ExitDirections.Add(exit.ExitDirection);
                    //iCount++;
                    //if (iCount < room.Exits.Count)
                    //{
                    //    sbOutput.Append("\r\n");
                    //}
                }
            }
            //lookHelper.Output = sbOutput.ToString();
            return lookHelper;
        }

        /// <summary>
        /// Moves in the specified direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public bool Move(Direction direction)
        {
            Room roomCurrent = house.Rooms[Location];
            Elevator elevatorCurrent = roomCurrent as Elevator;
            OnOffObject onOffObjectFlashlight = house.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = house.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
            if (direction == Direction.North || direction == Direction.East || direction == Direction.West || direction == Direction.South)
            {
                if (onOffObjectFlashlight.State == Switch.On)
                {
                    consumableObjectBatteries.IncrementTimesUsed();
                    if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                    {
                        onOffObjectFlashlight.State = Switch.Off;
                    }
                }
                if (roomCurrent.Exits.Contains(direction))
                {
                    this.Location.RoomNumber = roomCurrent.Exits[direction].ExitDestination;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == Direction.Up)
            {
                if (elevatorCurrent != null && this.Location.Floor != Floor.ThirdFloor)
                {
                    this.Location.Floor++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == Direction.Down)
            {
                if (elevatorCurrent != null && this.Location.Floor != Floor.Basement)
                {
                    this.Location.Floor--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Opens the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public string Open(string item)
        {
            StringBuilder sbOutput = new StringBuilder();
            LockableDoorObject lockableDoor = house.InanimateObjects[TheHouseData.LockedDoorShortName] as LockableDoorObject;
            PortableObject portableObjectKey = house.PortableObjects[TheHouseData.RustedKeyShortName] as PortableObject;
#if DEBUG
            ////if (!Inventory.Contains(portableObjectKey))
            ////{
            ////    Inventory.Add(portableObjectKey);
            ////}
#endif
            if (String.Compare(item, lockableDoor.Name, true, CultureInfo.CurrentCulture) != 0 && String.Compare(item, "drawer", true, CultureInfo.CurrentCulture) != 0)
            {
                sbOutput.Append("I'm sorry, I only know how to unlock doors and drawers.");
            }
            else if (String.Compare(item, "drawer", true, CultureInfo.CurrentCulture) == 0)
            {
                sbOutput.Append("Show me a drawer and I'll open it!!!");
            }
            else if (!house.Rooms[Location].Items.Contains(lockableDoor))
            {
                sbOutput.Append("I see no door that needs opening!");
            }
            else if (!Inventory.Contains(portableObjectKey))
            {
                sbOutput.Append("I need something first!");
            }
            else
            {
                house.Rooms[Location].Items.Remove(lockableDoor);
                house.Rooms[Location].Exits.Add(new RoomExit(lockableDoor.ExitWhenUnlocked.ExitDirection, lockableDoor.ExitWhenUnlocked.ExitDestination));
                sbOutput.Append("<<<<C-L-I-C-K>>>>\r\nOK, it's open now");
            }
            return sbOutput.ToString();

        }

        /// <summary>
        /// Plays the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public string Play(string item)
        {
            PortableObject portableObjectBanjo = house.PortableObjects[TheHouseData.BanjoShortName] as PortableObject;
            Adversary adversaryBeast = house.Adversaries[TheHouseData.BeastShortName];
#if DEBUG
            ////Inventory.Add(portableObjectBanjo);
#endif
            StringBuilder sbOutput = new StringBuilder();
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = house.PortableObjects[item];
            }
            catch (KeyNotFoundException)
            {
                inanimateObjectTarget = null;
            }

            if (inanimateObjectTarget==null || !(inanimateObjectTarget.Equals(portableObjectBanjo)))
            {
                sbOutput.Append("You can't play that!");
                //return sbOutput.ToString();
            }
            else if (!Inventory.Contains(portableObjectBanjo))
            {
                sbOutput.Append("You have no banjo to play");
            }
            else
            {
                // TODO: play sound
                if (house.Rooms[Location].Adversaries.Contains(adversaryBeast))
                {
                    HideAdversary(adversaryBeast);
                    sbOutput.Append("Music hath charm to soothe the savage beast.  The beast wandered off in a state of bliss.");
                }
            }
            return sbOutput.ToString();
        }

        /// <summary>
        /// Reads the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public string Read(string item)
        {
            PortableObject portableObjectSorcerersBook = house.InanimateObjects[TheHouseData.BookShortName] as PortableObject;
            PortableObject portableObjectParchment = house.InanimateObjects[TheHouseData.ParchmentShortName] as PortableObject;
#if DEBUG
            ////if (!Inventory.Contains(portableObjectSorcerersBook))
            ////{
            ////    Inventory.Add(portableObjectSorcerersBook);
            ////}
            ////if (!Inventory.Contains(portableObjectParchment))
            ////{
            ////    Inventory.Add(portableObjectParchment);
            ////}
#endif
            StringBuilder sbOutput = new StringBuilder();
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = house.InanimateObjects[item]; //keynotfoundexception
            }
            catch (KeyNotFoundException)
            {
            }
            if (inanimateObjectTarget != null)
            {
                if (!(inanimateObjectTarget is PortableObject))
                {
                    sbOutput.Append("You can't read that");
                }
                else if (!Inventory.Contains(inanimateObjectTarget))
                {
                    sbOutput.Append("You don't have a ");
                    sbOutput.Append(item);
                    sbOutput.Append(" to read.");
                }
                else if (inanimateObjectTarget.Equals(portableObjectSorcerersBook))// String.Compare(item, TheHouse.SorcerersBook.Name, true, CultureInfo.CurrentCulture) == 0)
                {
                    sbOutput.Append("The writing is blurry -- it reads:\r\n");
                    sbOutput.Append("magic words to make objects . . . one of the following.\r\n");
                    string[] stringArrayMagicWords = Enum.GetNames(typeof(MagicWord));
                    int intMagicWordCount = stringArrayMagicWords.Length;
                    for (int i=1;i<intMagicWordCount;i++)
                    {
                        sbOutput.Append(stringArrayMagicWords[i]);
                        sbOutput.Append("\r\n");
                    }
                    sbOutput.Append("Note:  Be sure to use the right word in the . . .");
                }
                else if (inanimateObjectTarget.Equals(portableObjectParchment))//String.Compare(item, portableObjectParchment.Name, true, CultureInfo.CurrentCulture) == 0)
                {
                    sbOutput.Append("The parchment is torn -- it reads:\r\n");
                    sbOutput.Append(". . . is the place to use them:\r\n");
                    foreach (Room room in house.Rooms.MagicRooms)
                    {
                        sbOutput.Append(room.Name);
                        sbOutput.Append("\r\n");
                    }
                    // One non-magic decoy room to make things a little harder
                    LocationType locationTypeDecoyRoom = new LocationType(0, Floor.ThirdFloor);
                    sbOutput.Append(house.Rooms[locationTypeDecoyRoom].Name);
                }
            }
            else
            {
                sbOutput.Append("You can't read that!");
            }
            return sbOutput.ToString();
        }

        /// <summary>
        /// Says the specified word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public string Say(string word)
        {
            StringBuilder sbOutput = new StringBuilder();
            bool boolWordIsMagic = false;
            Random random = new Random();
            MagicWord theword = MagicWord.NA;
            try
            {
                theword=(MagicWord)Enum.Parse(typeof(MagicWord), word, true);
                boolWordIsMagic = true;
            }
            catch (ArgumentException)
            {
            }
            if (!boolWordIsMagic)
            {
                sbOutput.Append("Nothing happened");
            }
            else
            {
                if (house.Rooms[Location].Magic && house.Rooms[Location].MagicWordForRoom == theword) 
                {
                    foreach (InanimateObject inanimateObjectCurrent in house.Rooms[Location].Items)
                    {
                        PortableObject portableObjectCurrent = inanimateObjectCurrent as PortableObject;
                        if (portableObjectCurrent != null && !portableObjectCurrent.Visible)
                        {
                            portableObjectCurrent.Visible = true;
                        }
                    }
                    sbOutput.Append("The air shimmers");
                }
                else if (house.Rooms[Location].Magic && house.Rooms[Location].MagicWordForRoom != theword) 
                {
                    sbOutput.Append("You experience disortientation");
                    this.Location = new LocationType(random.Next(10), (Floor)random.Next(4));
                }
                else
                {
                    sbOutput.Append("Nothing happened");
                }
            }
            return sbOutput.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Spray(string item)
        {
            StringBuilder sbOutput = new StringBuilder();
            ConsumableObject consumableObjectBugSpray = house.InanimateObjects[TheHouseData.BugSprayShortName] as ConsumableObject;
            Adversary adversaryBlob = house.Adversaries[TheHouseData.BlobShortName];
#if DEBUG
            ////if (!Inventory.Contains(consumableObjectBugSpray))
            ////{
            ////    Inventory.Add(consumableObjectBugSpray);
            ////}
#endif
            Room room = house.Rooms[Location];
            // Trying to spray adversary in the room but don't have the spray?
            if (!inventory.Contains(consumableObjectBugSpray))
            {
                sbOutput.Append("You have nothing with which to spray the ");
                sbOutput.Append(item);
            }
            // Trying to brush non adverasry?
            else if (!house.Adversaries.Contains(item, false))
            {
                sbOutput.Append("You can't spray that");
            }
            // Trying to spray adversary that is not in the room?
            else if (!room.Adversaries.Contains(item, false))
            {
                sbOutput.Append("I see no ");
                sbOutput.Append(item);
                sbOutput.Append(" here");
            }
            else if (consumableObjectBugSpray.TimesUsed >= consumableObjectBugSpray.UsageLimit)
            {
                sbOutput.Append("The can is empty");
            }
            // Trying to spray adversary in room with your spray but it's not the blob?
            else if (!house.Adversaries[item].Equals(adversaryBlob))
            {
                consumableObjectBugSpray.IncrementTimesUsed();
                sbOutput.Append("The ");
                sbOutput.Append(item);
                sbOutput.Append(" will become angry if you persist!");
            }
            // Must be trying to spray the blob in the room that has the blob
            else
            {
                consumableObjectBugSpray.IncrementTimesUsed();
                HideAdversary(adversaryBlob);
                sbOutput.Append("Blob runs away");
            }
            return sbOutput.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Stab(string item)
        {
            StringBuilder sbOutput = new StringBuilder();
            Room room = house.Rooms[Location];
            PortableObject portableObjectKnife = house.PortableObjects[TheHouseData.KnifeShortName] as PortableObject;
            Adversary adversaryMonk = house.Adversaries[TheHouseData.MonkShortName];
            Adversary adversaryTarget = null;
            try
            {
                adversaryTarget = house.Adversaries[item];
            }
            catch (KeyNotFoundException)
            {
            }

            if (!house.Adversaries.Contains(item, false))
            {
                sbOutput.Append("You can't kill that");
            }
            else if (!room.Adversaries.Contains(item, false))
            {
                sbOutput.Append("I see no ");
                sbOutput.Append(item);
                sbOutput.Append(" here");
            }
            else if (!inventory.Contains(portableObjectKnife))
            {
                sbOutput.Append("You have nothing with which to kill the ");
                sbOutput.Append(item);
            }
            else if (!adversaryTarget.Equals(adversaryMonk))
            {
                sbOutput.Append("The ");
                sbOutput.Append(item);
                sbOutput.Append(" will become angry if you persist!");
            }
            else
            {
                HideAdversary(adversaryMonk);
                sbOutput.Append("Monk has run away");
            }
            
            return sbOutput.ToString();
        }

        private void HideAdversary(Adversary adversary)
        {
            house.Rooms[Location].Adversaries.Remove(adversary);
            house.Rooms[TheHouseData.LocationMonsterHangout].Adversaries.Add(adversary);
            adversary.MovesUntilUnhidden = 5;
        }

        ///// <summary>
        ///// Waves the specified item.
        ///// </summary>
        ///// <param name="item">The item.</param>
        ///// <returns></returns>
        //public string Wave(string item)
        //{
        //    return Wave(item, TheHouse.GetRoom(this.Location));
        //}

        /// <summary>
        /// Waves the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public string Wave(string item)
        {
            StringBuilder sbOutput = new StringBuilder();
            Room room = house.Rooms[Location];
            PortableObject portableObjectGarlic = house.InanimateObjects[TheHouseData.GarlicShortName] as PortableObject;
            OnOffObject onOffObjectFlashlight = house.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            Adversary adversaryVampire = house.Adversaries[TheHouseData.VampireShortName];
            Adversary adversaryWerewolf = house.Adversaries[TheHouseData.WerewolfShortName];

#if DEBUG
            /*
            ConsumableObject consumableObjectBatteries = house.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
            if (!Inventory.Contains(portableObjectGarlic))
            {
                Inventory.Add(portableObjectGarlic);
            }
            if (!Inventory.Contains(onOffObjectFlashlight))
            {
                Inventory.Add(onOffObjectFlashlight);
            }
            if (!Inventory.Contains(consumableObjectBatteries))
            {
                Inventory.Add(consumableObjectBatteries);
            }
            */
#endif
            //InanimateObject inanimateObjectGarlic = new InanimateObject(TheHouse.GarlicName);
            //Adversary adversaryWarewolf = new Adversary(TheHouse.WerewolfName);

            //OnOffObject onOffObjectFlashLight = new OnOffObject(TheHouse.FlashLightName);
            //Adversary adversaryVampire = new Adversary(TheHouse.VampireName);

            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = house.InanimateObjects[item];
            }
            catch (KeyNotFoundException)
            {
            }
            //TheSingletonHouse.Instance.Player.Wave("blah");
            //int indexOfItem = TheHouse.AllInanimateObjects.IndexOf(inanimateObjectTarget);
            if (inanimateObjectTarget == null || !(inanimateObjectTarget is PortableObject))
            {
                // is not portable?
                sbOutput.Append("You can't wave that.");
            }
            else if (!Inventory.Contains(inanimateObjectTarget))
            {
                // is not in inventory?
                sbOutput.Append("You don't have a ");
                sbOutput.Append(item);
                sbOutput.Append(" to wave.");
            }
            else if (!(inanimateObjectTarget.Equals(portableObjectGarlic) || inanimateObjectTarget.Equals(onOffObjectFlashlight)))
            {
                // is not light nor garlic?
                sbOutput.Append("That was fun.");
            }
            else if (inanimateObjectTarget.Equals(onOffObjectFlashlight) && onOffObjectFlashlight.State == Switch.On && room.Adversaries.Contains(adversaryVampire))
            {
                // is light and vamp in room and light on?
                sbOutput.Append("The vampire has fled.");
                HideAdversary(adversaryVampire);
            }
            else if (inanimateObjectTarget.Equals(portableObjectGarlic) && room.Adversaries.Contains(adversaryWerewolf))
            {
                // is garlic and ware in room?
                sbOutput.Append("The warewolf has fled.");
                HideAdversary(adversaryWerewolf);
            }
            else
            {
                // otherwise "no effect"
                sbOutput.Append("It had no effect");
            }
            return sbOutput.ToString();
        }

        private static string FormatCommand(string input)
        {
            return input[0].ToString().ToUpper(CultureInfo.CurrentCulture) + input.Substring(1).ToLower(CultureInfo.CurrentCulture);
        }

        /*
        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="actionHelper">The action helper.</param>
        public void PerformAction(IAction actionHelper)
        {
            string stringActionShortName = String.Empty;
            string stringDirectionShortName = String.Empty;
            if (!String.IsNullOrEmpty(actionHelper.Action))
            {
                stringDirectionShortName = actionHelper.Action.Substring(0, 1);
                if (actionHelper.Action.Length > 2)
                {
                    stringActionShortName = actionHelper.Action.Substring(0, 3);
                }
                else
                {
                    stringActionShortName = actionHelper.Action;
                }
            }

            bool boolDeterminedAction = false;
            bool boolDeterminedDirection = false;
            ActionShortName actionShortName = 0;
            DirectionShortName directionShortName = 0;
            try
            {
                actionShortName = (ActionShortName)Enum.Parse(typeof(ActionShortName), stringActionShortName, true);
                boolDeterminedAction = true;
            }
            catch (ArgumentException)
            {
            }

            if (!boolDeterminedAction)
            {
                try
                {
                    directionShortName = (DirectionShortName)Enum.Parse(typeof(DirectionShortName), stringDirectionShortName, true);
                    boolDeterminedDirection = true;
                }
                catch (ArgumentException)
                {
                }
            }

            if (boolDeterminedAction)
            {
                bool boolRequiresArgument = requiesArgument[actionShortName];
                if (boolRequiresArgument && String.IsNullOrEmpty(actionHelper.Argument))
                {
                    actionHelper.Message = FormatCommand(actionHelper.Action) + " what?";
                }
                else
                {
                    GetHelper getHelper;
                    DropHelper dropHelper;
                    switch (actionShortName)
                    {
                        case ActionShortName.Get:
                            getHelper = Get(actionHelper.Argument);
                            actionHelper.Message = getHelper.Output;
                            actionHelper.Died = getHelper.Died;
                            break;
                        case ActionShortName.Tak:
                            getHelper = Get(actionHelper.Argument);
                            actionHelper.Message = getHelper.Output;
                            actionHelper.Died = getHelper.Died;
                            break;
                        case ActionShortName.Dro:
                            dropHelper = Drop(actionHelper.Argument);
                            actionHelper.Message = dropHelper.Output;
                            actionHelper.WonGame = dropHelper.WonGame;
                            break;
                        case ActionShortName.Say:
                            actionHelper.Message = Say(actionHelper.Argument);
                            break;
                        case ActionShortName.Kil:
                            actionHelper.Message = Stab(actionHelper.Argument);
                            break;
                        case ActionShortName.Sta:
                            actionHelper.Message = Stab(actionHelper.Argument);
                            break;
                        case ActionShortName.Lig:
                            OnOffObject onOffFlashlight = TheSingletonHouse.Instance.InanimateObjects[TheHouseData.FlashlightName] as OnOffObject;
                            Switch switchState = onOffFlashlight.State;

                            if (String.IsNullOrEmpty(actionHelper.Argument))
                            {
                                if (switchState == Switch.Off)
                                {
                                    actionHelper.Message = LightOn();
                                }
                                else
                                {
                                    actionHelper.Message = LightOff();
                                }
                            }
                            else if (String.Compare(actionHelper.Argument, "ON", StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                actionHelper.Message = LightOn();
                            }
                            else
                            {
                                actionHelper.Message = LightOff();
                            }
                            break;
                        case ActionShortName.Pla:
                            actionHelper.Message = Play(actionHelper.Argument);
                            break;
                        case ActionShortName.Rea:
                            actionHelper.Message = Read(actionHelper.Argument);
                            break;
                        case ActionShortName.Dig:
                            actionHelper.Message = Dig(actionHelper.Argument); 
                            break;
                        case ActionShortName.Inv:
                            actionHelper.Message = "You are presently carrying:";
                            if (inventory.Count == 0)
                            {
                                actionHelper.Inventory.Add("nothing");
                            }
                            else
                            {
                                foreach (InanimateObject inanimateObject in inventory)
                                {
                                    actionHelper.Inventory.Add(inanimateObject.Name);
                                }
                            }

                            break;
                        case ActionShortName.Qui:
                            break;
                        case ActionShortName.On:
                            break;
                        case ActionShortName.Off:
                            break;
                        case ActionShortName.Bru:
                            break;
                        case ActionShortName.Wav:
                            break;
                        case ActionShortName.Unl:
                            break;
                        case ActionShortName.Ope:
                            break;
                        case ActionShortName.Spr:
                            break;
                        case ActionShortName.Sav:
                            actionHelper.ClearScreen = true;
                            break;
                        case ActionShortName.Loa:
                            actionHelper.ClearScreen = true;
                            break;
                        case ActionShortName.Loo:
                            actionHelper.ClearScreen = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (boolDeterminedDirection)
            {
                LookHelper lookHelper;
                switch (directionShortName)
                {
                    case DirectionShortName.U:
                        if (Move(Direction.Up))
                        {
                            actionHelper.ClearScreen = true;
                            lookHelper = Look(true);
                            actionHelper.Message = lookHelper.Output;
                           
                        }
                        break;
                    case DirectionShortName.D:
                        actionHelper.ClearScreen = true;
                        break;
                    case DirectionShortName.N:
                        actionHelper.ClearScreen = true;
                        break;
                    case DirectionShortName.E:
                        actionHelper.ClearScreen = true;
                        break;
                    case DirectionShortName.W:
                        actionHelper.ClearScreen = true;
                        break;
                    case DirectionShortName.S:
                        actionHelper.ClearScreen = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                actionHelper.Message = "I don't understand.";
            }
        }
        */
		#endregion Methods 

        /// <summary>
        /// Gets the items removed from house.
        /// </summary>
        /// <value>The items removed from house.</value>
        public int ItemsRemovedFromHouse
        {
            get { return itemsRemovedFromHouse; }
        }

        /// <summary>
        /// Gets the number of moves.
        /// </summary>
        /// <value>The number of moves.</value>
        public int NumberOfMoves
        {
            get { return numberOfMoves; }
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlArray("InventoryList"), XmlArrayItem("Inventory", typeof(InanimateObject))]
        public InanimateObjectsCollection Inventory
        {
            get { return this.inventory; }
        }

        /// <summary>
        /// Populates the save data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void PopulateSaveData(SaveData data)
        {
            data.PopulateInventory(inventory);
            data.ItemsRemovedFromHouse = itemsRemovedFromHouse;
            data.NumberOfMoves = numberOfMoves;
            data.TimesLookedInDark = timesLookedInDark;
        }

        /// <summary>
        /// Restores from save data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void RestoreFromSaveData(SaveData data)
        {
            // inventory = data.Inventory;
            itemsRemovedFromHouse = data.ItemsRemovedFromHouse;
            numberOfMoves = data.NumberOfMoves;
            timesLookedInDark = data.TimesLookedInDark;
            foreach (InanimateObject io in data.Inventory)
            {
                inventory.Add(house.InanimateObjects[io.Name]);
            }
        }
    }
}
