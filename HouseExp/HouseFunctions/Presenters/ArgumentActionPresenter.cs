//-----------------------------------------------------------------------
// <copyright file="ArgumentActionPresenter.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseFunctions.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using HouseFunctions.Interfaces;

    /// <summary>
    /// Presents the actions that can be performed on an IArgumentAction view
    /// </summary>
    public class ArgumentActionPresenter
    {
        #region Fields (1) 

        /// <summary>
        /// The view object upon which to act
        /// </summary>
        private IArgumentAction view;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentActionPresenter"/> class.
        /// </summary>
        /// <param name="view">The this.view.</param>
        public ArgumentActionPresenter(IArgumentAction view)
        {
            this.view = view;
        }

        #endregion Constructors 

        #region Methods (9) 

        // Public Methods (9) 

        /// <summary>
        /// Brushes this instance.
        /// </summary>
        public void Brush()
        {
            this.view.Message = new StringBuilder();
            Room room = this.view.House.Rooms[this.view.Player.Location];
            Adversary adversaryLeopard = this.view.House.Adversaries[TheHouseData.LeopardShortName];
            PortableObject portableObjectBrush = this.view.House.InanimateObjects[TheHouseData.BrushShortName] as PortableObject;
            this.view.Message = new StringBuilder();

            // Trying to brush non adverasry?
            if (!this.view.House.Adversaries.Contains(this.view.Argument, false))
            {
                this.view.Message.Append("You can't brush that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to brush adversary that is not in the room?
                this.view.Message.Append("I see no ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" here");
            }
            else if (!this.view.Player.Inventory.Contains(portableObjectBrush))
            {
                // Trying to brush adversary in the room but don't have a brush?
                this.view.Message.Append("You have nothing with which to brush the ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (!this.view.House.Adversaries[this.view.Argument].Equals(adversaryLeopard))
            {
                // Trying to brush adversary in room with your brush but it's not the leopard?
                this.view.Message.Append("The ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" will become angry if you persist!");
            }
            else
            {
                // Must be trying to brush the leopard in the room with the brush
                this.view.House.HideAdversary(adversaryLeopard, this.view.Player.Location);
                this.view.Message.Append("Purrrrrrr!!!!!!!!  The leopard is very gratified for the grooming and leaves");
            }
        }

        /// <summary>
        /// Digs this instance.
        /// </summary>
        public void Dig()
        {
            this.view.Message = new StringBuilder();
            Room room = this.view.House.Rooms[this.view.Player.Location];
#if DEBUG
            ////this.view.Player.Inventory.Add(this.view.House.InanimateObjects[TheHouseData.ShovelShortName]);
#endif
            if (String.Compare(this.view.Argument, "dirt", true, CultureInfo.CurrentCulture) != 0 && String.Compare(this.view.Argument, "floor", true, CultureInfo.CurrentCulture) != 0)
            {
                this.view.Message.Append("You can't dig the ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(".");
            }
            else if (!(room is UnfinishedFlooredRoom))
            {
                this.view.Message.Append("I see no dirt to dig here.");
            }
            else if (!this.view.Player.Inventory.Contains(TheHouseData.ShovelShortName))
            {
                this.view.Message.Append("You don't have anything with which to dig.");
            }
            else
            {
                this.view.Message.Append("Digging... ");
                foreach (InanimateObject inanimateObjectCurrent in room.Items)
                {
                    PortableObject portableObjectCurrent = inanimateObjectCurrent as PortableObject;
                    if (portableObjectCurrent != null && portableObjectCurrent.Buried == true)
                    {
                        portableObjectCurrent.Buried = false;
                        this.view.Message.Append("I found something!");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Lights the specified state.
        /// </summary>
        public void Light()
        {
            this.view.Message = new StringBuilder();
            Switch state = 0;
            OnOffObject onOffObjectFlashlight = this.view.House.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.view.House.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
            if (String.IsNullOrEmpty(view.Argument))
            {
                state = Switch.On;
                if (onOffObjectFlashlight.State == Switch.On)
                {
                    state = Switch.Off;
                }
            }
            else
            {
                try
                {
                    state = (Switch)Enum.Parse(typeof(Switch), view.Argument, true);
                }
                catch (ArgumentException)
                {
                    state = Switch.Off;
                }
            }

            if (state == Switch.On)
            {
                if (!this.view.Player.Inventory.Contains(onOffObjectFlashlight.Identity))
                {
                    this.view.Message.Append("You have no light to turn on!");
                }
                else if (!this.view.Player.Inventory.Contains(consumableObjectBatteries.Identity))
                {
                    this.view.Message.Append("It doesn't work");
                }
                else if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    this.view.Message.Append("The batteries are exhausted");
                }
                else
                {
                    onOffObjectFlashlight.State = Switch.On;
                    this.view.Message.Append("Light on");
                    this.view.Player.TimesLookedInDark = 0;
                }
            }
            else
            {
                if (!this.view.Player.Inventory.Contains(onOffObjectFlashlight.Identity))
                {
                    this.view.Message.Append("You have no light to turn off!");
                }
                else if (!this.view.Player.Inventory.Contains(consumableObjectBatteries.Identity))
                {
                    this.view.Message.Append("It doesn't work anyway -- so why turn it off!");
                }
                else if (consumableObjectBatteries.TimesUsed > consumableObjectBatteries.UsageLimit)
                {
                    this.view.Message.Append("The batteries are already dead!");
                }
                else
                {
                    onOffObjectFlashlight.State = Switch.Off;
                    this.view.Message.Append("Light off");
                }
            }
        }

        /// <summary>
        /// Opens this instance.
        /// </summary>
        public void Open()
        {
            this.view.Message = new StringBuilder();
            LockableDoorObject lockableDoor = this.view.House.InanimateObjects[TheHouseData.LockedDoorShortName] as LockableDoorObject;
            PortableObject portableObjectKey = this.view.House.PortableObjects[TheHouseData.RustedKeyShortName] as PortableObject;
#if DEBUG
            /*
            if (!this.view.Player.Inventory.Contains(portableObjectKey))
            {
                this.view.Player.Inventory.Add(portableObjectKey);
            }
            */
#endif
            if (String.Compare(this.view.Argument, lockableDoor.Identity, true, CultureInfo.CurrentCulture) != 0 && String.Compare(this.view.Argument, "drawer", true, CultureInfo.CurrentCulture) != 0)
            {
                this.view.Message.Append("I'm sorry, I only know how to unlock doors and drawers.");
            }
            else if (String.Compare(this.view.Argument, "drawer", true, CultureInfo.CurrentCulture) == 0)
            {
                this.view.Message.Append("Show me a drawer and I'll open it!!!");
            }
            else if (!this.view.House.Rooms[this.view.Player.Location].Items.Contains(lockableDoor))
            {
                this.view.Message.Append("I see no door that needs opening!");
            }
            else if (!this.view.Player.Inventory.Contains(portableObjectKey))
            {
                this.view.Message.Append("I need something first!");
            }
            else
            {
                this.view.House.Rooms[this.view.Player.Location].Items.Remove(lockableDoor);
                this.view.House.Rooms[this.view.Player.Location].Exits.Add(new RoomExit(lockableDoor.ExitWhenUnlocked.ExitDirection, lockableDoor.ExitWhenUnlocked.ExitDestination));
                this.view.Message.Append("<<<<C-L-I-C-K>>>>\r\nOK, it's open now");
            }
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        public void Play()
        {
            this.view.Message = new StringBuilder();
            PortableObject portableObjectBanjo = this.view.House.PortableObjects[TheHouseData.BanjoShortName] as PortableObject;
            Adversary adversaryBeast = this.view.House.Adversaries[TheHouseData.BeastShortName];
#if DEBUG
            ////this.view.Player.Inventory.Add(portableObjectBanjo);
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.view.House.PortableObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
                inanimateObjectTarget = null;
            }

            if (!inanimateObjectTarget.Equals(portableObjectBanjo))
            {
                this.view.Message.Append("You can't play that!");
            }
            else if (!this.view.Player.Inventory.Contains(portableObjectBanjo))
            {
                this.view.Message.Append("You have no banjo to play");
            }
            else
            {
                // TODO: play sound
                if (this.view.House.Rooms[this.view.Player.Location].Adversaries.Contains(adversaryBeast))
                {
                    this.view.House.HideAdversary(adversaryBeast, this.view.Player.Location);
                    this.view.Message.Append("Music hath charm to soothe the savage beast.  The beast wandered off in a state of bliss.");
                }
            }
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        public void Read()
        {
            this.view.Message = new StringBuilder();
            PortableObject portableObjectSorcerersBook = this.view.House.InanimateObjects[TheHouseData.BookShortName] as PortableObject;
            PortableObject portableObjectParchment = this.view.House.InanimateObjects[TheHouseData.ParchmentShortName] as PortableObject;
#if DEBUG
            /*
            if (!this.view.Player.Inventory.Contains(portableObjectSorcerersBook))
            {
                this.view.Player.Inventory.Add(portableObjectSorcerersBook);
            }

            if (!this.view.Player.Inventory.Contains(portableObjectParchment))
            {
                this.view.Player.Inventory.Add(portableObjectParchment);
            }
            */
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.view.House.InanimateObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            if (inanimateObjectTarget != null)
            {
                if (!(inanimateObjectTarget is PortableObject))
                {
                    this.view.Message.Append("You can't read that");
                }
                else if (!this.view.Player.Inventory.Contains(inanimateObjectTarget))
                {
                    this.view.Message.Append("You don't have a ");
                    this.view.Message.Append(this.view.Argument);
                    this.view.Message.Append(" to read.");
                }
                else if (inanimateObjectTarget.Equals(portableObjectSorcerersBook))
                {
                    this.view.Message.Append("The writing is blurry -- it reads:\r\n");
                    this.view.Message.Append("magic words to make objects . . . one of the following.\r\n");
                    string[] stringArrayMagicWords = Enum.GetNames(typeof(MagicWord));
                    int intMagicWordCount = stringArrayMagicWords.Length;
                    for (int i = 1; i < intMagicWordCount; i++)
                    {
                        this.view.Message.Append(stringArrayMagicWords[i]);
                        this.view.Message.Append("\r\n");
                    }

                    this.view.Message.Append("Note:  Be sure to use the right word in the . . .");
                }
                else if (inanimateObjectTarget.Equals(portableObjectParchment))
                {
                    this.view.Message.Append("The parchment is torn -- it reads:\r\n");
                    this.view.Message.Append(". . . is the place to use them:\r\n");
                    foreach (Room room in this.view.House.Rooms.MagicRooms)
                    {
                        this.view.Message.Append(room.Name);
                        this.view.Message.Append("\r\n");
                    }

                    // One non-magic decoy room to make things a little harder
                    LocationType locationTypeDecoyRoom = new LocationType(0, Floor.ThirdFloor);
                    this.view.Message.Append(this.view.House.Rooms[locationTypeDecoyRoom].Name);
                }
            }
            else
            {
                this.view.Message.Append("You can't read that!");
            }
        }

        /// <summary>
        /// Says this instance.
        /// </summary>
        public void Say()
        {
            this.view.Message = new StringBuilder();
            bool boolWordIsMagic = false;
            Random random = new Random();
            MagicWord theword = MagicWord.NA;
            try
            {
                theword = (MagicWord)Enum.Parse(typeof(MagicWord), this.view.Argument, true);
                boolWordIsMagic = true;
            }
            catch (ArgumentException)
            {
            }

            if (!boolWordIsMagic)
            {
                this.view.Message.Append("Nothing happened");
            }
            else
            {
                if (this.view.House.Rooms[this.view.Player.Location].Magic && this.view.House.Rooms[this.view.Player.Location].MagicWordForRoom == theword)
                {
                    foreach (InanimateObject inanimateObjectCurrent in this.view.House.Rooms[this.view.Player.Location].Items)
                    {
                        PortableObject portableObjectCurrent = inanimateObjectCurrent as PortableObject;
                        if (portableObjectCurrent != null && !portableObjectCurrent.Visible)
                        {
                            portableObjectCurrent.Visible = true;
                        }
                    }

                    this.view.Message.Append("The air shimmers");
                }
                else if (this.view.House.Rooms[this.view.Player.Location].Magic && this.view.House.Rooms[this.view.Player.Location].MagicWordForRoom != theword)
                {
                    this.view.Message.Append("You experience disortientation");
                    this.view.Player.Location = new LocationType(random.Next(10), (Floor)random.Next(4));
                }
                else
                {
                    this.view.Message.Append("Nothing happened");
                }
            }
        }

        /// <summary>
        /// Sprays this instance.
        /// </summary>
        public void Spray()
        {
            this.view.Message = new StringBuilder();
            ConsumableObject consumableObjectBugSpray = this.view.House.InanimateObjects[TheHouseData.BugSprayShortName] as ConsumableObject;
            Adversary adversaryBlob = this.view.House.Adversaries[TheHouseData.BlobShortName];
#if DEBUG
            /*
            if (!this.view.Player.Inventory.Contains(consumableObjectBugSpray))
            {
                this.view.Player.Inventory.Add(consumableObjectBugSpray);
            }
            */
#endif
            Room room = this.view.House.Rooms[this.view.Player.Location];

            // Trying to spray adversary in the room but don't have the spray?
            if (!this.view.Player.Inventory.Contains(consumableObjectBugSpray))
            {
                this.view.Message.Append("You have nothing with which to spray the ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (!this.view.House.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to brush non adverasry?
                this.view.Message.Append("You can't spray that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                // Trying to spray adversary that is not in the room?
                this.view.Message.Append("I see no ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" here");
            }
            else if (consumableObjectBugSpray.TimesUsed >= consumableObjectBugSpray.UsageLimit)
            {
                this.view.Message.Append("The can is empty");
            }
            else if (!this.view.House.Adversaries[this.view.Argument].Equals(adversaryBlob))
            {
                // Trying to spray adversary in room with your spray but it's not the blob?
                consumableObjectBugSpray.IncrementTimesUsed();
                this.view.Message.Append("The ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" will become angry if you persist!");
            }
            else
            {
                // Must be trying to spray the blob in the room that has the blob
                consumableObjectBugSpray.IncrementTimesUsed();
                this.view.House.HideAdversary(adversaryBlob, this.view.Player.Location);
                this.view.Message.Append("Blob runs away");
            }
        }

        /// <summary>
        /// Stabs this instance.
        /// </summary>
        public void Stab()
        {
            this.view.Message = new StringBuilder();
            Room room = this.view.House.Rooms[this.view.Player.Location];
            PortableObject portableObjectKnife = this.view.House.PortableObjects[TheHouseData.KnifeShortName] as PortableObject;
            Adversary adversaryMonk = this.view.House.Adversaries[TheHouseData.MonkShortName];
            Adversary adversaryTarget = null;
            try
            {
                adversaryTarget = this.view.House.Adversaries[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            if (!this.view.House.Adversaries.Contains(this.view.Argument, false))
            {
                this.view.Message.Append("You can't kill that");
            }
            else if (!room.Adversaries.Contains(this.view.Argument, false))
            {
                this.view.Message.Append("I see no ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" here");
            }
            else if (!this.view.Player.Inventory.Contains(portableObjectKnife))
            {
                this.view.Message.Append("You have nothing with which to kill the ");
                this.view.Message.Append(this.view.Argument);
            }
            else if (!adversaryTarget.Equals(adversaryMonk))
            {
                this.view.Message.Append("The ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" will become angry if you persist!");
            }
            else
            {
                this.view.House.HideAdversary(adversaryMonk, this.view.Player.Location);
                this.view.Message.Append("Monk has run away");
            }
        }

        /// <summary>
        /// Waves this instance.
        /// </summary>
        public void Wave()
        {
            this.view.Message = new StringBuilder();
            Room room = this.view.House.Rooms[this.view.Player.Location];
            PortableObject portableObjectGarlic = this.view.House.InanimateObjects[TheHouseData.GarlicShortName] as PortableObject;
            OnOffObject onOffObjectFlashlight = this.view.House.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            Adversary adversaryVampire = this.view.House.Adversaries[TheHouseData.VampireShortName];
            Adversary adversaryWerewolf = this.view.House.Adversaries[TheHouseData.WerewolfShortName];

#if DEBUG
            /*
            ConsumableObject consumableObjectBatteries = this.view.House.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
            if (!this.view.Player.Inventory.Contains(portableObjectGarlic))
            {
                this.view.Player.Inventory.Add(portableObjectGarlic);
            }

            if (!this.view.Player.Inventory.Contains(onOffObjectFlashlight))
            {
                this.view.Player.Inventory.Add(onOffObjectFlashlight);
            }

            if (!this.view.Player.Inventory.Contains(consumableObjectBatteries))
            {
                this.view.Player.Inventory.Add(consumableObjectBatteries);
            }
            */
#endif
            InanimateObject inanimateObjectTarget = null;
            try
            {
                inanimateObjectTarget = this.view.House.InanimateObjects[this.view.Argument];
            }
            catch (KeyNotFoundException)
            {
            }

            if (inanimateObjectTarget == null || !(inanimateObjectTarget is PortableObject))
            {
                // is not portable?
                this.view.Message.Append("You can't wave that.");
            }
            else if (!this.view.Player.Inventory.Contains(inanimateObjectTarget))
            {
                // is not in inventory?
                this.view.Message.Append("You don't have a ");
                this.view.Message.Append(this.view.Argument);
                this.view.Message.Append(" to wave.");
            }
            else if (!(inanimateObjectTarget.Equals(portableObjectGarlic) || inanimateObjectTarget.Equals(onOffObjectFlashlight)))
            {
                // is not light nor garlic?
                this.view.Message.Append("That was fun.");
            }
            else if (inanimateObjectTarget.Equals(onOffObjectFlashlight) && onOffObjectFlashlight.State == Switch.On && room.Adversaries.Contains(adversaryVampire))
            {
                // is light and vamp in room and light on?
                this.view.Message.Append("The vampire has fled.");
                this.view.House.HideAdversary(adversaryVampire, this.view.Player.Location);
            }
            else if (inanimateObjectTarget.Equals(portableObjectGarlic) && room.Adversaries.Contains(adversaryWerewolf))
            {
                // is garlic and ware in room?
                this.view.Message.Append("The warewolf has fled.");
                this.view.House.HideAdversary(adversaryWerewolf, this.view.Player.Location);
            }
            else
            {
                // otherwise "no effect"
                this.view.Message.Append("It had no effect");
            }
        }

        #endregion Methods 
    }
}
