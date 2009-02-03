//-----------------------------------------------------------------------
// <copyright file="GameEndingArgumentActionPresenter.cs" company="James McLachlan">
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
    /// Presents the actions that can be performed on an <see cref="IGameEndingArgumentAction"/> view
    /// </summary>
    public class GameEndingArgumentActionPresenter
    {
        /// <summary>
        /// The view object upon which to act
        /// </summary>
        private IGameEndingArgumentAction view;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEndingArgumentActionPresenter"/> class.
        /// </summary>
        /// <param name="view">The view upon which to act.</param>
        public GameEndingArgumentActionPresenter(IGameEndingArgumentAction view)
        {
            this.view = view;
        }

        /// <summary>
        /// Drops this instance.
        /// </summary>
        public void Drop()
        {
            this.view.Message = new StringBuilder();
            InanimateObject inanimateObjectTarget = null;
            this.view.GameEnded = false;
            InanimateObjectsCollection multiplePieceObjectsInInventory = new InanimateObjectsCollection();
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
                    this.view.Message.Append("You can't drop that");
                }
                else if (!this.view.Player.Inventory.Contains(inanimateObjectTarget.ToString()))
                {
                    this.view.Message.Append("You don't have a ");
                    this.view.Message.Append(this.view.Argument);
                }
                else if (inanimateObjectTarget.Equals(this.view.House.InanimateObjects[TheHouseData.BatteriesShortName]) || inanimateObjectTarget.Equals(this.view.House.InanimateObjects[TheHouseData.FlashlightShortName]))
                {
                    string stringArgumentBackup = this.view.Argument;
                    StringBuilder stringBuilderMessageBackup = this.view.Message;
                    bool boolClearScreenBackup = this.view.ClearScreen;
                    ArgumentActionPresenter argumentActionPresenter = new ArgumentActionPresenter((IArgumentAction)this.view);
                    this.view.Argument = "off";
                    argumentActionPresenter.Light();
                    this.view.Argument = stringArgumentBackup;
                    this.view.Message = stringBuilderMessageBackup;
                    this.view.ClearScreen = boolClearScreenBackup;
                    this.view.Message.Append(this.view.Argument);
                    this.view.Message.Append(" dropped");
                }
                else if (inanimateObjectTarget is ContainerObject && this.view.Player.Inventory.ContainsByType(typeof(MultiplePieceObject), multiplePieceObjectsInInventory))
                {
                    this.view.Message.Append("Try dropping the following items first:  ");
                    int intCount = 0;
                    foreach (InanimateObject mpo in multiplePieceObjectsInInventory)
                    {
                        this.view.Message.Append(mpo.Name);
                        intCount++;
                        if (intCount < multiplePieceObjectsInInventory.Count)
                        {
                            this.view.Message.Append(", ");
                        }
                    }
                }
                else if (inanimateObjectTarget is ProtectiveObject && this.view.Player.Inventory.ContainsByType(typeof(PainfulObject)))
                {
                    this.view.Message.Append("You'll hurt yourself");
                }
                else if (inanimateObjectTarget is DelicateObject && !this.view.House.Rooms[this.view.Player.Location].Items.ContainsByType(typeof(CushioningObject)))
                {
                    this.view.Message.Append("It will break");
                }
                else
                {
                    this.view.Player.Inventory.Remove(inanimateObjectTarget.ToString());
                    this.view.House.Rooms[this.view.Player.Location].Items.Add(inanimateObjectTarget);
                    this.view.Message.Append(this.view.Argument);
                    this.view.Message.Append(" dropped");
                    if (this.view.Player.Location.Equals(TheHouseData.LocationFirstFloorFrontPorch))
                    {
                        this.view.Player.ItemsRemovedFromHouse++;
                        if (this.view.Player.ItemsRemovedFromHouse == this.view.House.PortableObjects.Count)
                        {
                            this.view.GameEnded = true;
                            this.view.Message = new StringBuilder();
                            this.view.Message.Append(String.Format(CultureInfo.CurrentCulture, "Congratulations--you have successfully completed House Adventure \r\nYou removed all 20 objects in {0} moves", view.Player.NumberOfMoves));
                        }
                    }
                }
            }
            else
            {
                this.view.Message.Append("You can't drop that");
            }
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        public void Get()
        {
            this.view.Message = new StringBuilder();
            this.view.ClearScreen = false;
            PortableObject portableObjectTarget = null;
            Room room = this.view.House.Rooms[this.view.Player.Location];
            this.view.GameEnded = false;

            // Trying to pick up known object?
            try
            {
                portableObjectTarget = this.view.House.InanimateObjects[this.view.Argument] as PortableObject;
            }
            catch (KeyNotFoundException)
            {
                portableObjectTarget = null;
            }

            // Is a known portable item
            if (portableObjectTarget != null)
            {
                // Item not in room or item in room but buried or invisible
                if (!this.view.House.Rooms[this.view.Player.Location].Items.Contains(portableObjectTarget) || (this.view.House.Rooms[this.view.Player.Location].Items.Contains(portableObjectTarget) && (portableObjectTarget.Buried || !portableObjectTarget.Visible)))
                {
                    // Impostor in room and its name is the same as the target item
                    if (portableObjectTarget.Equals(this.view.House.Adversaries.TheImpostor) && this.view.House.Rooms[this.view.Player.Location].Adversaries.Contains(this.view.House.Adversaries.TheImpostor))
                    {
                        this.view.GameEnded = true;
                        this.view.Message.Append("Aughhhh . . .\r\n\r\nRemember?!");
                    }
                    else
                    {
                        // Nothing by that name is in the room
                        this.view.Message.Append("I see no ");
                        this.view.Message.Append(this.view.Argument);
                        this.view.Message.Append(" here");
                    }
                }
                else if (this.view.House.Rooms[this.view.Player.Location].Adversaries.ContainsNonImpostor())
                {
                    // Room has an adversary that is not the imposter
                    this.view.Message.Append("This room's occupant seems to have grown very attached to the ");
                    this.view.Message.Append(this.view.Argument);
                    this.view.Message.Append(" and won't let you have it");
                }
                else if (this.view.Player.Inventory.Count < TheHouseData.MaximumInventoryItems)
                {
                    if (portableObjectTarget is MultiplePieceObject)
                    {
                        if (this.view.Player.Inventory.ContainsByType(typeof(ContainerObject)))
                        {
                            this.view.Player.Inventory.Add(portableObjectTarget);
                            room.Items.Remove(portableObjectTarget);
                        }
                        else
                        {
                            this.view.Message.Append("You can't pick up that many small items!");
                        }
                    }
                    else if (portableObjectTarget is PainfulObject)
                    {
                        bool boolHasProtectiveItem = false;
                        foreach (InanimateObject inanimateObject in this.view.Player.Inventory)
                        {
                            if (inanimateObject is ProtectiveObject)
                            {
                                boolHasProtectiveItem = true;
                            }
                        }

                        if (boolHasProtectiveItem)
                        {
                            this.view.Player.Inventory.Add(portableObjectTarget);
                            room.Items.Remove(portableObjectTarget);
                        }
                        else
                        {
                            this.view.Message.Append("Ouch! That hurts! You can't pick that up!");
                        }
                    }
                    else
                    {
                        this.view.Player.Inventory.Add(portableObjectTarget);
                        room.Items.Remove(portableObjectTarget);
                        this.view.Message.Append(this.view.Argument);
                        this.view.Message.Append(" taken");
                    }
                }
                else
                {
                    this.view.Message.Append("You can't carry that much.  You'll have to drop something.");
                }
            }
            else
            {
                this.view.Message.Append("You can't take the ");
                this.view.Message.Append(this.view.Argument);
            }
        }
    }
}
