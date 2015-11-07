using NUnit.Core.Extensibility;
using NUnit.Framework;
using NUnitEx.ExternalTestCaseSource.Exceptions;
using NUnitEx.ExternalTestCaseSource.Tests.Resources;
using Rhino.Mocks;

namespace NUnitEx.ExternalTestCaseSource.Tests
{
    [TestFixture]
    public class TestCaseSourceXmlAttribute
    {
        [Test(Description = "Test the Install IAddin method with sucess."),
            Category("Install")]
        public void Install_Sucess_TestMethod()
        {
            // Arrange
            var testCaseSourceXmlAttribute = new ExternalTestCaseSource.TestCaseSourceXmlAttribute();

            var extensionPointMock = MockRepository.GenerateMock<IExtensionPoint>();
            extensionPointMock.Expect(x => x.Install(testCaseSourceXmlAttribute)).Repeat.Once();

            var hostMock = MockRepository.GenerateMock<IExtensionHost>();
            hostMock.Expect(x => x.GetExtensionPoint("TestCaseProviders")).Return(extensionPointMock).Repeat.Once();

            // Act
            var result = testCaseSourceXmlAttribute.Install(hostMock);

            // Assert
            extensionPointMock.VerifyAllExpectations();
            hostMock.VerifyAllExpectations();
            Assert.AreEqual(true, result);
        }

        [Test(Description = "Test the Install IAddin method without sucess."),
            Category("Install")]
        public void Install_Fail_TestMethod()
        {
            // Arrange
            var testCaseSourceXmlAttribute = new ExternalTestCaseSource.TestCaseSourceXmlAttribute();

            var hostMock = MockRepository.GenerateMock<IExtensionHost>();
            hostMock.Expect(x => x.GetExtensionPoint("TestCaseProviders")).Return(null).Repeat.Once();

            // Act
            var result = testCaseSourceXmlAttribute.Install(hostMock);

            // Assert
            hostMock.VerifyAllExpectations();
            Assert.AreEqual(false, result);
        }

        [Test(Description = "Test the properties sanity test. All properties are null."),
            Category("GetTestCasesFor"),
            ExpectedException(typeof(AllPropertiesNullOrEmptyException),
            ExpectedMessage = "All properties are null or empty.")]
        public void GetTestCasesFor_AllPropertiesNullOrEmptyException1_TestMethod()
        {
            // Arrange
            var testCaseSourceXmlAttribute = new ExternalTestCaseSource.TestCaseSourceXmlAttribute();

            // Act
            testCaseSourceXmlAttribute.GetTestCasesFor(null);

            // Assert
            // Done by decorator
        }

        [Test(Description = "Test the properties sanity test. FileLocation and ResourceName " +
                            "properties are whitespace and the rest of the properties are null."),
            Category("GetTestCasesFor"),
            ExpectedException(typeof(AllPropertiesNullOrEmptyException),
            ExpectedMessage = "All properties are null or empty.")]
        public void GetTestCasesFor_AllPropertiesNullOrEmptyException2_TestMethod()
        {
            // Arrange
            var testCaseSourceXmlAttribute = new ExternalTestCaseSource.TestCaseSourceXmlAttribute
            {
                FileLocation = " ",
                ResourceName = " "
            };

            // Act
            testCaseSourceXmlAttribute.GetTestCasesFor(null);

            // Assert
            // Done by decorator
        }

        [Test(Description = "Test the properties sanity test. File does not exists."),
            Category("GetTestCasesFor"),
            ExpectedException(typeof(FileNotExistsException),
            ExpectedMessage = "File does not exists.")]
        public void GetTestCasesFor_FileNotExistsException_TestMethod()
        {
            // Arrange
            var testCaseSourceXmlAttribute = new ExternalTestCaseSource.TestCaseSourceXmlAttribute
            {
                FileLocation = "Foo"
            };

            // Act
            testCaseSourceXmlAttribute.GetTestCasesFor(null);

            // Assert
            // Done by decorator
        }

        [Test(Description = "Test the properties sanity test. ResourceName is empty."),
            Category("GetTestCasesFor"),
            ExpectedException(typeof(ResourceNotExistsException),
            ExpectedMessage = "Resource does not exists.")]
        public void GetTestCasesFor_ResourceNotExistsException1_TestMethod()
        {
            // Arrange
            var testCaseSourceXmlAttribute = new ExternalTestCaseSource.TestCaseSourceXmlAttribute
            {
                ResourceName = "",
                ResourceType = typeof(TestCaseSources)
            };

            // Act
            testCaseSourceXmlAttribute.GetTestCasesFor(null);

            // Assert
            // Done by decorator
        }

        [Test(Description = "Test the properties sanity test. ResourceType is null."),
            Category("GetTestCasesFor"),
            ExpectedException(typeof(ResourceNotExistsException),
            ExpectedMessage = "Resource does not exists.")]
        public void GetTestCasesFor_ResourceNotExistsException2_TestMethod()
        {
            // Arrange
            var testCaseSourceXmlAttribute = new ExternalTestCaseSource.TestCaseSourceXmlAttribute
            {
                ResourceName = "TestXMLFile.xml",
                ResourceType = null
            };

            // Act
            testCaseSourceXmlAttribute.GetTestCasesFor(null);

            // Assert
            // Done by decorator
        }


        //[Test, ExternalTestCaseSource.TestCaseSourceXml(FileLocation = "Buu")]
        //public void EatYourOwnDogFood(string s)
        //{
        //}

        //[Test, ExternalTestCaseSource.TestCaseSourceXml(ResourceType = typeof(TestCaseSources),
        //    ResourceName = "TestXMLFile")]
        //public void EatYourOwnDogFood2(string s, int a)
        //{
        //    Assert.IsNotNullOrEmpty(s);
        //}

        //[Test, ExternalTestCaseSource.TestCaseSourceXml()]
        //public void EatYourOwnDogFood3(string s)
        //{
        //    Assert.IsNotNullOrEmpty(s);
        //}
    }
}
