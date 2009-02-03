namespace HouseFunctions.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections.ObjectModel;

    /// <summary>
    /// 
    /// </summary>
    public interface IActionView
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        StringBuilder Message { get; set;}

        /// <summary>
        /// Gets or sets a value indicating whether [clear screen].
        /// </summary>
        /// <value><c>true</c> if [clear screen]; otherwise, <c>false</c>.</value>
        bool ClearScreen { get; set;}

        /// <summary>
        /// Gets or sets the house.
        /// </summary>
        /// <value>The house.</value>
        HouseType House { get; set;}

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>The player.</value>
        Player Player { get; set;}
    }
}