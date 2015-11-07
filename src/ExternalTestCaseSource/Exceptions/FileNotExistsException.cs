﻿using System;

namespace NUnitEx.ExternalTestCaseSource.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the file is not found.
    /// </summary>
    public class FileNotExistsException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the 
        /// NUnitEx.ExternalTestCaseSource.Exceptions.FileNotExistsException class.
        /// </summary>
        public FileNotExistsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// NUnitEx.ExternalTestCaseSource.Exceptions.FileNotExistsException class 
        /// with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FileNotExistsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// NUnitEx.ExternalTestCaseSource.Exceptions.FileNotExistsException class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        ///     (Nothing in Visual Basic) if no inner exception is specified.</param>
        public FileNotExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
