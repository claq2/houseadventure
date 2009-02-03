using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HouseFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class HouseEntity
    {
        private Collection<Collection<Room>> rooms;

        /// <summary>
        /// 
        /// </summary>
        public Collection<Collection<Room>> Rooms
        {
            get { return rooms; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HouseEntity()
        {
            rooms = new Collection<Collection<Room>>();
        }
    }
}
