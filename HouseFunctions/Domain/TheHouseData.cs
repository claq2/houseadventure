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
        private static string[] actions = new string[] { "Get", "Drop", "Say", "Kill", "Stab", "Light", "Play", "Read", "Dig", "On", "Off", "Brush", "Wave", "Unlock", "Spray" };
        private static ReadOnlyCollection<string> collectionActions = new ReadOnlyCollection<string>(actions);

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
            get { return collectionActions; }
        }
    }
}
