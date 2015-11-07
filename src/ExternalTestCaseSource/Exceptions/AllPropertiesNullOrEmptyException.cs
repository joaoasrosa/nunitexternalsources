using System;

namespace NUnitEx.ExternalTestCaseSource.Exceptions
{
    /// <summary>
    /// The exception that is thrown when all properties are null or empty.
    /// </summary>
    public class AllPropertiesNullOrEmptyException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the 
        /// NUnitEx.ExternalTestCaseSource.Exceptions.AllPropertiesNullOrEmptyException class.
        /// </summary>
        public AllPropertiesNullOrEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// NUnitEx.ExternalTestCaseSource.Exceptions.AllPropertiesNullOrEmptyException class 
        /// with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AllPropertiesNullOrEmptyException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// NUnitEx.ExternalTestCaseSource.Exceptions.AllPropertiesNullOrEmptyException class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        ///     (Nothing in Visual Basic) if no inner exception is specified.</param>
        public AllPropertiesNullOrEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
