using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Document : PortableObject2
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the state description.
        /// </summary>
        /// <value>The state description.</value>
        public string StateDescription { get; set; }
    }
}
