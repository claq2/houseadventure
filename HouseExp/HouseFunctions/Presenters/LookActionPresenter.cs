//-----------------------------------------------------------------------
// <copyright file="LookActionPresenter.cs" company="James McLachlan">
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
    /// Presents the actions that can be taken on an ILookAction object
    /// </summary>
    public class LookActionPresenter
    {
        /// <summary>
        /// The view object.
        /// </summary>
        private ILookAction view;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookActionPresenter"/> class.
        /// </summary>
        /// <param name="view">The view object.</param>
        public LookActionPresenter(ILookAction view)
        {
            this.view = view;
        }

        /// <summary>
        /// Looks in the current room.
        /// </summary>
        public void Look()
        {
            Room room = this.view.House.Rooms[this.view.Player.Location];
            Random random = new Random();
            this.view.GameEnded = false;
            this.view.ClearScreen = true;
            this.view.ExitDirections.Clear();
            this.view.Adversaries.Clear();
            this.view.Items.Clear();
            this.view.RoomName = String.Empty;
            this.view.Message = new StringBuilder();
            TelephoneBooth telephoneBooth = room as TelephoneBooth;
            if (!this.view.AfterVerticalMovement && this.view.Player.Inventory.Contains(TheHouseData.DimeShortName) && telephoneBooth != null)
            {
                this.view.Player.Location.Floor = (Floor)random.Next(4);
                room = this.view.House.Rooms[this.view.Player.Location];
            }

            this.view.RoomName = room.Name;
            if (random.Next(50) < 10)
            {
                this.view.House.RemoveFrontPorchItems();
            }

            if (random.Next(50) < 40)
            {
                this.view.House.UpdateMonstersInHangout();
            }

            OnOffObject onOffObjectFlashlight = this.view.House.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            if (this.view.Player.Location.Floor == Floor.Basement && onOffObjectFlashlight.State == Switch.Off)
            {
                this.view.Message.Append("nothing--it's too dark!");
                this.view.Player.TimesLookedInDark++;
                if (this.view.Player.TimesLookedInDark > TheHouseData.MaximumLooksInDark)
                {
                    this.view.Message.Append("Aughhhh . . .\r\nBeware of things unseen !!");
                    this.view.GameEnded = true;
                }
            }
            else
            {
                foreach (Adversary adversary in room.Adversaries)
                {
                    this.view.Adversaries.Add(adversary.Name);
                }

                foreach (InanimateObject inanimateObject in room.Items)
                {
                    PortableObject portableObject = inanimateObject as PortableObject;
                    if (portableObject == null) 
                    {
                        // If it's a stationary object
                        this.view.Items.Add(inanimateObject.Name);
                    }
                    else if (portableObject.Visible && !portableObject.Buried)
                    {
                        this.view.Items.Add(inanimateObject.Name);
                    }
                }

                foreach (RoomExit exit in room.Exits)
                {
                    this.view.ExitDirections.Add(exit.ExitDirection.ToString());
                }
            }
        }
    }
}
