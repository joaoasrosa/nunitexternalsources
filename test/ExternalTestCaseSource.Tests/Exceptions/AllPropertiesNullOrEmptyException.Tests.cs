using System;
using NUnit.Framework;

namespace NUnitEx.ExternalTestCaseSource.Tests.Exceptions
{
    [TestFixture]
    public class AllPropertiesNullOrEmptyException
    {
        [Test(Description = "Test the constructor of the AllPropertiesNullOrEmptyException class without parameters."),
            Category("Constructor")]
        public void Constructor_ZeroParameters_TestMethod()
        {
			// Arrange
			var exception = new ExternalTestCaseSource.Exceptions.AllPropertiesNullOrEmptyException();

			// Act

			// Assert
			Assert.AreEqual("Exception of type 'NUnitEx.ExternalTestCaseSource.Exceptions.AllPropertiesNullOrEmptyException' was thrown.", exception.Message);
			Assert.IsNull(exception.InnerException);
        }

        [Test(Description = "Test the constructor of the AllPropertiesNullOrEmptyException class with 1 parameter."),
            Category("Constructor")]
        public void Constructor_OneParameter_TestMethod()
        {
            // Arrange
            var exception = new ExternalTestCaseSource.Exceptions.AllPropertiesNullOrEmptyException("Foo");

            // Act

            // Assert
            Assert.AreEqual("Foo", exception.Message);
            Assert.IsNull(exception.InnerException);
        }

        [Test(Description = "Test the constructor of the AllPropertiesNullOrEmptyException class with 2 parameters."),
            Category("Constructor")]
        public void Constructor_TwoParameters_TestMethod()
        {
            // Arrange
            var exception = new ExternalTestCaseSource.Exceptions.AllPropertiesNullOrEmptyException("Bar", new Exception());

            // Act

            // Assert
            Assert.AreEqual("Bar", exception.Message);
            Assert.IsNotNull(exception.InnerException);
            Assert.IsInstanceOf<Exception>(exception.InnerException);
        }
    }
}
