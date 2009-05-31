using System;
using System.Collections.Generic;
using System.Text;

namespace HouseCore
{
    using System.Collections.ObjectModel;
    /// <summary>
    /// All data relating to adversaries in the house
    /// </summary>
    public static class AdversaryData
    {
        private const string m_BeastName = "a savage beast";
        private const string m_BeastShortName = "bea";
        private const string m_BlobName = "a protoplasmic blob";
        private const string m_BlobShortName = "blo";
        private const string m_LeopardName = "a leopard";
        private const string m_LeopardShortName = "leo";
        private const string m_MonkName = "an insane monk";
        private const string m_MonkShortName = "mon";
        private const string m_VampireName = "a vampire";
        private const string m_VampireShortName = "vam";
        private const string m_WerewolfName = "a werewolf";
        private const string m_WerewolfShortName = "wer";

        /// <summary>
        /// Gets the name of the beast.
        /// </summary>
        /// <value>The name of the beast.</value>
        public static string BeastName
        {
            get { return m_BeastName; }
        }

        /// <summary>
        /// Gets the short name of the beast.
        /// </summary>
        /// <value>The short name of the beast.</value>
        public static string BeastShortName
        {
            get { return m_BeastShortName; }
        }

        /// <summary>
        /// Gets the name of the blob.
        /// </summary>
        /// <value>The name of the blob.</value>
        public static string BlobName
        {
            get { return m_BlobName; }
        }

        /// <summary>
        /// Gets the short name of the blob.
        /// </summary>
        /// <value>The short name of the blob.</value>
        public static string BlobShortName
        {
            get { return m_BlobShortName; }
        }

        /// <summary>
        /// Gets the name of the leopard.
        /// </summary>
        /// <value>The name of the leopard.</value>
        public static string LeopardName
        {
            get { return m_LeopardName; }
        }

        /// <summary>
        /// Gets the short name of the leopard.
        /// </summary>
        /// <value>The short name of the leopard.</value>
        public static string LeopardShortName
        {
            get { return m_LeopardShortName; }
        }

        /// <summary>
        /// Gets the name of the monk.
        /// </summary>
        /// <value>The name of the monk.</value>
        public static string MonkName
        {
            get { return m_MonkName; }
        }

        /// <summary>
        /// Gets the short name of the monk.
        /// </summary>
        /// <value>The short name of the monk.</value>
        public static string MonkShortName
        {
            get { return m_MonkShortName; }
        }

        /// <summary>
        /// Gets the name of the vampire.
        /// </summary>
        /// <value>The name of the vampire.</value>
        public static string VampireName
        {
            get { return m_VampireName; }
        }

        /// <summary>
        /// Gets the short name of the vampire.
        /// </summary>
        /// <value>The short name of the vampire.</value>
        public static string VampireShortName
        {
            get { return m_VampireShortName; }
        }

        /// <summary>
        /// Gets the name of the werewolf.
        /// </summary>
        /// <value>The name of the werewolf.</value>
        public static string WerewolfName
        {
            get { return m_WerewolfName; }
        }

        /// <summary>
        /// Gets the short name of the werewolf.
        /// </summary>
        /// <value>The short name of the werewolf.</value>
        public static string WerewolfShortName
        {
            get { return m_WerewolfShortName; }
        }
    }
}
