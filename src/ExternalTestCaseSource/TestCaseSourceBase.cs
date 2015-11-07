using System;
using NUnit.Core.Extensibility;

namespace NUnitEx.ExternalTestCaseSource
{
    /// <summary>
    /// Base test case source class for external providers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public abstract class TestCaseSourceBase : Attribute, IAddin
    {
        #region IAddin IMPLEMENTATION

        /// <summary> 
        /// When called, the add-in installs itself into 
        /// the host, if possible. Because NUnit uses separate 
        /// hosts for the client and test domain environments, 
        /// an add-in may be invited to istall itself more than 
        /// once. The add-in is responsible for checking which 
        /// extension points are supported by the host that is 
        /// passed to it and taking the appropriate action. 
        /// </summary> 
        /// <param name="host">The host in which to install the add-in</param> 
        /// <returns>True if the add-in was installed, otehrwise false</returns> 
        public bool Install(IExtensionHost host)
        {
            // Get the extension provider
            var dataPointProviders = host.GetExtensionPoint("TestCaseProviders");
            // Sanity check
            if (null == dataPointProviders) return false;
            // Install it
            dataPointProviders.Install(this);
            return true;
        }

        #endregion
    }
}
