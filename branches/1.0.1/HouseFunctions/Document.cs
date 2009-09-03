using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class Document : PortableObject2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        public Document()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObject2"></see> class.
        /// </summary>
        /// <param name="info">The info.</param>
        public Document(DocumentInfo info)
            : base(info)
        {
            this.Text = info.Text;
            this.StateDescription = info.StateDescription;
        }

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
