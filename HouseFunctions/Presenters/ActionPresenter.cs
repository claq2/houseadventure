//-----------------------------------------------------------------------
// <copyright file="ActionPresenter.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseFunctions.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    using HouseFunctions;
    using HouseFunctions.Interfaces;

    /// <summary>
    /// Presents the actions that can be taken on an IAction view
    /// </summary>
    public class ActionPresenter
    {
        /// <summary>
        /// The view object.
        /// </summary>
        private IActionView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionPresenter"/> class.
        /// </summary>
        /// <param name="view">The action view.</param>
        public ActionPresenter(IActionView view)
        {
            this.view = view;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            SaveData saveData = new SaveData(this.view);
            StringBuilder stringBuilderOutput = new StringBuilder();
            XmlSerializer serializerSaveData = new XmlSerializer(typeof(SaveData));
            using (TextWriter writer = new StreamWriter("housedata.txt"))
            {
                serializerSaveData.Serialize(writer, saveData);
            }
            this.view.Message = new StringBuilder();
            this.view.Message.Append("Data saved");
            

        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void Load()
        {
            StringBuilder stringBuilderOutput = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));

            // Reading the XML document requires a FileStream.
            Stream reader = new FileStream("housedata.txt", FileMode.Open);

            // Call the Deserialize method to restore the object's state.
            SaveData saveData = new SaveData();
            saveData = (SaveData)serializer.Deserialize(reader);
            reader.Close();
            this.view.Player = saveData.Player;
            this.view.House = saveData.House;
            this.view.Message = new StringBuilder();
            this.view.Message.Append("Data loaded");
        }

        /// <summary>
        /// Northes this instance.
        /// </summary>
        public void North()
        {
            this.ProcessMovement(Direction.North);
        }

        /// <summary>
        /// Southes this instance.
        /// </summary>
        public void South()
        {
            this.ProcessMovement(Direction.South);
        }

        /// <summary>
        /// Easts this instance.
        /// </summary>
        public void East()
        {
            this.ProcessMovement(Direction.East);
        }

        /// <summary>
        /// Wests this instance.
        /// </summary>
        public void West()
        {
            this.ProcessMovement(Direction.West);
        }

        /// <summary>
        /// Ups this instance.
        /// </summary>
        public void Up()
        {
            this.ProcessMovement(Direction.Up);
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public void Down()
        {
            this.ProcessMovement(Direction.Down);
        }
        /// <summary>
        /// Processes the movement.
        /// </summary>
        /// <param name="direction">The direction.</param>
        private void ProcessMovement(Direction direction)
        {
            bool verticalMovement = direction == Direction.Up || direction == Direction.Down;
            if (this.Move(direction))
            {
                this.view.ClearScreen = true;
                this.view.Message = new StringBuilder();
                //// this.Look(verticalMovement);
            }
            else
            {
                this.view.ClearScreen = false;
                this.view.Message = new StringBuilder();
                this.view.Message.Append(TheHouseData.DisallowedDirectionValue);
            }
        }

        /// <summary>
        /// Moves in the specified direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>Boolean that indicates whether the movement was allowed or not.</returns>
        private bool Move(Direction direction)
        {
            Room roomCurrent = this.view.House.Rooms[this.view.Player.Location];
            Elevator elevatorCurrent = roomCurrent as Elevator;
            OnOffObject onOffObjectFlashlight = this.view.House.InanimateObjects[TheHouseData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.view.House.InanimateObjects[TheHouseData.BatteriesShortName] as ConsumableObject;
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
                    this.view.Player.Location.RoomNumber = roomCurrent.Exits[direction].ExitDestination;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == Direction.Up)
            {
                if (elevatorCurrent != null && this.view.Player.Location.Floor != Floor.ThirdFloor)
                {
                    this.view.Player.Location.Floor++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (direction == Direction.Down)
            {
                if (elevatorCurrent != null && this.view.Player.Location.Floor != Floor.Basement)
                {
                    this.view.Player.Location.Floor--;
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
    }
}
