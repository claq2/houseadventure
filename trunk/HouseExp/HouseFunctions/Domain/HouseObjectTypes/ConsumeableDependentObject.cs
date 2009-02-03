using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsumableDependentObject : ConsumableObject
    {
        private string dependsOn;

        /// <summary>
        /// 
        /// </summary>
        public string DependsOn
        {
            get { return dependsOn; }
            set { dependsOn = value; }
        }
        private Switch stateThatConsumes;

        /// <summary>
        /// 
        /// </summary>
        public Switch StateThatConsumes
        {
            get { return stateThatConsumes; }
            set { stateThatConsumes = value; }
        }
    }
}
