//-----------------------------------------------------------------------
// <copyright file="AdversaryData.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System;
namespace HouseCore
{
    /// <summary>
    /// All data relating to adversaries in the house
    /// </summary>
    public static class AdversaryData
    {
        /// <summary>
        /// 
        /// </summary>
        public static AdversaryInfoCollection AdversaryInfo = InitializeInfo();

        private static Random random = new Random();

        private static AdversaryInfoCollection InitializeInfo()
        {
            AdversaryInfoCollection result = new AdversaryInfoCollection();
            result.Add(new AdversaryInfo("a savage beast", "bea", 2, Floor.Basement));
            result.Add(new AdversaryInfo("a protoplasmic blob", "blo", 7, Floor.Basement));
            result.Add(new AdversaryInfo("a leopard", "leo", 1, Floor.ThirdFloor));
            result.Add(new AdversaryInfo("an insane monk", "mon", 3, Floor.SecondFloor));
            result.Add(new AdversaryInfo("a vampire", "vam", 6, Floor.FirstFloor));
            result.Add(new AdversaryInfo("a werewolf", "wer", 7, Floor.ThirdFloor));
#if (DEBUG)
            int intImpostorItemNumber = 0;
            int intImpostorRoomNumber = 0;
            Floor floorImpostorFloor = Floor.SecondFloor;
#else
            int intImpostorItemNumber = AdversaryData.random.Next(this.PortableObjects.Count);
            int intImpostorRoomNumber = AdversaryData.random.Next(10);
            Floor floorImpostorFloor = (Floor)this.random.Next(4) + 1;
#endif
            string stringImpostorDisplayName = String.Empty; //this.PortableObjects[intImpostorItemNumber].Name;
            string stringImpostorShortName = String.Empty; //this.PortableObjects[intImpostorItemNumber].ShortName;
            result.Add(new ImpostorInfo(stringImpostorDisplayName, stringImpostorShortName, intImpostorRoomNumber, floorImpostorFloor));
            return result;
        }

        private const string beastName = "a savage beast";
        private const string beastShortName = "bea";
        private const string blobName = "a protoplasmic blob";
        private const string blobShortName = "blo";
        private const string leopardName = "a leopard";
        private const string leopardShortName = "leo";
        private const string monkName = "an insane monk";
        private const string monkShortName = "mon";
        private const string vampireName = "a vampire";
        private const string vampireShortName = "vam";
        private const string werewolfName = "a werewolf";
        private const string werewolfShortName = "wer";

        /// <summary>
        /// Gets the name of the beast.
        /// </summary>
        /// <value>The name of the beast.</value>
        public static string BeastName
        {
            get { return beastName; }
        }

        /// <summary>
        /// Gets the short name of the beast.
        /// </summary>
        /// <value>The short name of the beast.</value>
        public static string BeastShortName
        {
            get { return beastShortName; }
        }

        /// <summary>
        /// Gets the name of the blob.
        /// </summary>
        /// <value>The name of the blob.</value>
        public static string BlobName
        {
            get { return blobName; }
        }

        /// <summary>
        /// Gets the short name of the blob.
        /// </summary>
        /// <value>The short name of the blob.</value>
        public static string BlobShortName
        {
            get { return blobShortName; }
        }

        /// <summary>
        /// Gets the name of the leopard.
        /// </summary>
        /// <value>The name of the leopard.</value>
        public static string LeopardName
        {
            get { return leopardName; }
        }

        /// <summary>
        /// Gets the short name of the leopard.
        /// </summary>
        /// <value>The short name of the leopard.</value>
        public static string LeopardShortName
        {
            get { return leopardShortName; }
        }

        /// <summary>
        /// Gets the name of the monk.
        /// </summary>
        /// <value>The name of the monk.</value>
        public static string MonkName
        {
            get { return monkName; }
        }

        /// <summary>
        /// Gets the short name of the monk.
        /// </summary>
        /// <value>The short name of the monk.</value>
        public static string MonkShortName
        {
            get { return monkShortName; }
        }

        /// <summary>
        /// Gets the name of the vampire.
        /// </summary>
        /// <value>The name of the vampire.</value>
        public static string VampireName
        {
            get { return vampireName; }
        }

        /// <summary>
        /// Gets the short name of the vampire.
        /// </summary>
        /// <value>The short name of the vampire.</value>
        public static string VampireShortName
        {
            get { return vampireShortName; }
        }

        /// <summary>
        /// Gets the name of the werewolf.
        /// </summary>
        /// <value>The name of the werewolf.</value>
        public static string WerewolfName
        {
            get { return werewolfName; }
        }

        /// <summary>
        /// Gets the short name of the werewolf.
        /// </summary>
        /// <value>The short name of the werewolf.</value>
        public static string WerewolfShortName
        {
            get { return werewolfShortName; }
        }
    }
}
