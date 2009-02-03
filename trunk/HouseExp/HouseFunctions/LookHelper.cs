using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HouseCore
{
    /// <summary>
    /// Object used to return the result of a Look action.
    /// </summary>
    public class LookHelper:LethalActionHelper
    {

		#region Fields (6) 

        private AdversaryCollection adversaries = new AdversaryCollection();
        private bool died;
        private Collection<Direction> exitDirections = new Collection<Direction>();
        private InanimateObjectsCollection items = new InanimateObjectsCollection();
        private string output;
        private string roomName = String.Empty;

		#endregion Fields 

		#region Properties (6) 

        /// <summary>
        /// Gets the adversaries.
        /// </summary>
        /// <value>The adversaries.</value>
        public AdversaryCollection Adversaries
        {
            get { return adversaries; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the action killed the player.
        /// </summary>
        /// <value><c>true</c> if the action killed the player; otherwise, <c>false</c>.</value>
        public override bool Died
        {
            get
            {
                return died;
            }
            set
            {
                died = value;
            }
        }

        /// <summary>
        /// Gets or sets the exit directions.
        /// </summary>
        /// <value>The exit directions.</value>
        public Collection<Direction> ExitDirections
        {
            get { return exitDirections; }
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public InanimateObjectsCollection Items
        {
            get { return items; }
        }

        /// <summary>
        /// Gets or sets the display output.
        /// </summary>
        /// <value>The display output.</value>
        public override string Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }

		#endregion Properties 

    }
}
