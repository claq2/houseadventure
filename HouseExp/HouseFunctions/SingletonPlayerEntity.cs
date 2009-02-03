using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SingletonPlayerEntity
    {
        private static readonly SingletonPlayerEntity instance = new SingletonPlayerEntity();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static SingletonPlayerEntity Instance
        {
            get { return SingletonPlayerEntity.instance; }
        } 

        private SingletonPlayerEntity()
        {
        }
    }
}
