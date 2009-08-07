using System;
using System.Runtime.Serialization;

namespace HouseCore.Exceptions
{
    /// <summary>
    /// Thrown when the argument passed in the view is null or empty
    /// </summary>
    [Serializable]
    public class NullViewArgumentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullViewArgumentException"/> class.
        /// </summary>
        public NullViewArgumentException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullViewArgumentException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public NullViewArgumentException(string message)
            : base(message)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullViewArgumentException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public NullViewArgumentException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullViewArgumentException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected NullViewArgumentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            
        }
    }
}
