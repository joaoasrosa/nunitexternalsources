using System;
using NUnit.Framework;

namespace NUnitEx.ExternalTestCaseSource.Tests.Exceptions
{
    [TestFixture]
    public class FileNotExistsException
    {
        [Test(Description = "Test the constructor of the FileNotExistsException class without parameters."),
            Category("Constructor")]
        public void Constructor_ZeroParameters_TestMethod()
        {
			// Arrange
			var exception = new ExternalTestCaseSource.Exceptions.FileNotExistsException();

			// Act

			// Assert
			Assert.AreEqual("Exception of type 'NUnitEx.ExternalTestCaseSource.Exceptions.FileNotExistsException' was thrown.", exception.Message);
			Assert.IsNull(exception.InnerException);
        }

        [Test(Description = "Test the constructor of the FileNotExistsException class with 1 parameter."),
            Category("Constructor")]
        public void Constructor_OneParameter_TestMethod()
        {
            // Arrange
            var exception = new ExternalTestCaseSource.Exceptions.FileNotExistsException("Foo");

            // Act

            // Assert
            Assert.AreEqual("Foo", exception.Message);
            Assert.IsNull(exception.InnerException);
        }

        [Test(Description = "Test the constructor of the FileNotExistsException class with 2 parameters."),
            Category("Constructor")]
        public void Constructor_TwoParameters_TestMethod()
        {
            // Arrange
            var exception = new ExternalTestCaseSource.Exceptions.FileNotExistsException("Bar", new Exception());

            // Act

            // Assert
            Assert.AreEqual("Bar", exception.Message);
            Assert.IsNotNull(exception.InnerException);
            Assert.IsInstanceOf<Exception>(exception.InnerException);
        }
    }
}
