using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// All data relating to the house
    /// </summary>
    public static class TheHouseData
    {
        private static string[] inventoryActions = new string[] { "Drop", "Play", "Read", "Wave" };
        private static string[] freeFormArgumentActions = new string[] { "Say", "Dig" };
        private static string[] roomItemActions = new string[] { "Get", "Kill", "Stab", "Brush", "Unlock", "Spray", "Open" };
        private static string[] nonArgumentActions = new string[] { "Light", "On", "Off" };
        //private static string[] actions = new string[] { "Get", "Drop", "Say", "Kill", "Stab", "Light", "Play", "Read", "Dig", "On", "Off", "Brush", "Wave", "Unlock", "Spray" };

        /// <summary>
        /// 
        /// </summary>
        public static ReadOnlyCollection<string> InventoryActions = new ReadOnlyCollection<string>(inventoryActions);

        /// <summary>
        /// 
        /// </summary>
        public static ReadOnlyCollection<string> FreeFormArgumentActions = new ReadOnlyCollection<string>(freeFormArgumentActions);

        /// <summary>
        /// 
        /// </summary>
        public static ReadOnlyCollection<string> RoomItemActions = new ReadOnlyCollection<string>(roomItemActions);

        /// <summary>
        /// 
        /// </summary>
        public static ReadOnlyCollection<string> NonArgumentActions = new ReadOnlyCollection<string>(nonArgumentActions);

        /// <summary>
        /// String to display when a player tries to go in a direction that doesn't exist.
        /// </summary>
        public const string DisallowedDirectionValue = "You can't go that way";

        /// <summary>
        /// 
        /// </summary>
        public const int MaximumInventoryItems = 4;

        /// <summary>
        /// 
        /// </summary>
        public const int MaximumLooksInDark = 3;

        /// <summary>
        /// Gets the actions.
        /// </summary>
        /// <value>The actions.</value>
        public static ReadOnlyCollection<string> Actions
        {
            get
            {
                List<string> actions = new List<string>();
                foreach (string action in inventoryActions)
                {
                    actions.Add(action);
                }

                foreach (string action in freeFormArgumentActions)
                {
                    actions.Add(action);
                }

                foreach (string action in roomItemActions)
                {
                    actions.Add(action);
                }

                foreach (string action in nonArgumentActions)
                {
                    actions.Add(action);
                }

                return new ReadOnlyCollection<string>(actions);
            }
        }
    }
}
