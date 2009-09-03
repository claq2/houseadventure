using System;

namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentInfo : PortableObjectInfo
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

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"></see> class.
        /// </summary>
        public DocumentInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        public DocumentInfo(string name, string shortName, int initialRoom, Floor floor)
            : base(name, shortName, initialRoom, floor)
        {
            this.StateDescription = String.Empty;
            this.Text = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="text">The text.</param>
        /// <param name="stateDescription">The state description.</param>
        public DocumentInfo(string name, string shortName, int initialRoom, Floor floor, string text, string stateDescription)
            : base(name, shortName, initialRoom, floor)
        {
            this.StateDescription = stateDescription;
            this.Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableObjectInfo"></see> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        /// <param name="initialRoom">The initial room.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="visible">if set to <c>true</c> object is visible.</param>
        public DocumentInfo(string name, string shortName, int initialRoom, Floor floor, bool visible)
            : base(name, shortName, initialRoom, floor, visible)
        {
            this.StateDescription = String.Empty;
            this.Text = string.Empty;
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns></returns>
        public override InanimateObject2 CreateObject()
        {
            return new Document(this);
        }
    }
}
