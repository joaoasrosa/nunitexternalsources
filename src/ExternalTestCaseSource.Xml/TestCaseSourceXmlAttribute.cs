using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using NUnit.Core.Extensibility;
using NUnitEx.ExternalTestCaseSource.Enums;
using NUnitEx.ExternalTestCaseSource.Helpers;

namespace NUnitEx.ExternalTestCaseSource
{
    [NUnitAddin(Name = "TestCaseSourceXmlAttribute", Description = "TestCaseSourceXmlAttribute")]
    public class TestCaseSourceXmlAttribute : TestCaseSourceFile, ITestCaseProvider
    {
        #region ITestCaseProvider IMPLEMENTATION

        /// <summary> 
        /// Determine whether any test cases are available for a parameterized method. 
        /// </summary> 
        /// <param name="method">A MethodInfo representing a parameterized test</param> 
        /// <returns>True if any cases are available, otherwise false.</returns> 
        public bool HasTestCasesFor(MethodInfo method)
        {
            return CheckAttribute<TestCaseSourceXmlAttribute>(method);
        }

        /// <summary> 
        /// Return an IEnumerable providing test cases for use in 
        /// running a paramterized test. 
        /// </summary> 
        /// <param name="method"></param> 
        /// <returns></returns> 
        public IEnumerable GetTestCasesFor(MethodInfo method)
        {
            // Sanity checks
            CheckAttributeProperties();

            var returnObjects = new List<object[]>();

            if (null == method.DeclaringType) return returnObjects;

            // Get the parameters base on the method signature
            // XPath like:
            // //Namespace/class/methodname/instance/param1
            // //Namespace/class/methodname/instance/param2
            // Will have N instances
            var xmlDocument = ReadXmlFile();

            // Create XPath
            var xPath = $"//{method.DeclaringType.Namespace}/{method.DeclaringType.Name}/{method.Name}/instance";

            // Get the arguments names
            var args = method.GetParameters();

            // Select the nodes
            var nodes = xmlDocument.SelectNodes(xPath);
            
            if (null == nodes) return returnObjects;

            foreach (XmlNode node in nodes)
            {
                var returnObject = new object[args.Length];
                for (var i = 0; i < args.Length; i++)
                {
                    var argNode = node[args[i].Name];

                    if (null == argNode) continue;

                    returnObject[i] = Convert.ChangeType(argNode.InnerText, args[i].ParameterType);
                }
                returnObjects.Add(returnObject);
            }
            return returnObjects;
        }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Method to read the XML file from the storage.
        /// </summary>
        /// <returns>Returns the XmlDocument.</returns>
        private XmlDocument ReadXmlFile()
        {
            var xmlDocument = new XmlDocument();
            switch (FileStoreType)
            {
                case FileStoreType.FileSystem:
                    xmlDocument.Load(FileLocation);
                    break;
                case FileStoreType.Resource:
                    xmlDocument.LoadXml(Resource.GetResourceLookup<string>(ResourceType, ResourceName));
                    break;
            }
            return xmlDocument;
        }

        #endregion
    }
}
