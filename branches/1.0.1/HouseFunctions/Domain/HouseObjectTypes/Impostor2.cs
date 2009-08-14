namespace HouseCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents an impostor
    /// </summary>
    public class Impostor2 : Adversary2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Impostor2"/> class.
        /// </summary>
        public Impostor2()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Impostor2"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Impostor2(AdversaryInfo info)
            : base(info)
        {
        }
    }
}
