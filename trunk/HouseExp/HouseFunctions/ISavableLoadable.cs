using System;
using System.Collections.Generic;
using System.Text;

namespace HouseFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISavableLoadable
    {
        /// <summary>
        /// Populates the save data.
        /// </summary>
        /// <param name="data">The data.</param>
        void PopulateSaveData(SaveData data);

        /// <summary>
        /// Restores from save data.
        /// </summary>
        /// <param name="data">The data.</param>
        void RestoreFromSaveData(SaveData data);
    }
}
