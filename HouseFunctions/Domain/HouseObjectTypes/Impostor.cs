//-----------------------------------------------------------------------
// <copyright file="Impostor.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HouseCore
{
    /// <summary>
    /// Class that represents an impostor
    /// </summary>
    public class Impostor : Adversary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Impostor"/> class.
        /// </summary>
        public Impostor()
            : base() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Impostor"/> class.
        /// </summary>
        /// <param name="name">The name of the item that the impostor is impersonating</param>
        /// <param name="room">The initial room.</param>
        public Impostor(string name, NormalRoom room)
            : base(name, room) 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Impostor"/> class.
        /// </summary>
        /// <param name="name">The name of the item that the impostor is impersonating.</param>
        /// <param name="room">The initial room.</param>
        /// <param name="shortName">The short name of the item that the impostor is impersonating.</param>
        public Impostor(string name, NormalRoom room, string shortName)
            : base(name, room, shortName)
        {
        }
    }
}
