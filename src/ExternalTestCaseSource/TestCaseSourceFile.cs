using System;
using System.IO;
using System.Reflection;
using NUnitEx.ExternalTestCaseSource.Enums;
using NUnitEx.ExternalTestCaseSource.Exceptions;
using String = NUnitEx.ExternalTestCaseSource.Helpers.String;

namespace NUnitEx.ExternalTestCaseSource
{
    /// <summary>
    /// Abstract class to handle all the file operations related
    /// to the test case source.
    /// </summary>
    public abstract class TestCaseSourceFile : TestCaseSourceBase
    {
        #region PUBLIC PROPERTIES

        /// <summary>
        /// The file location.
        /// </summary>
        public string FileLocation
        {
            get { return _fileLocation; }
            set { _fileLocation = String.Trim(value); }
        }

        /// <summary>
        /// The resource type.
        /// </summary>
        public Type ResourceType { get; set; }

        /// <summary>
        /// The resource name.
        /// </summary>
        public string ResourceName
        {
            get { return _resourceName; }
            set { _resourceName = String.Trim(value); }
        }

        #endregion


        #region PROTECTED METHODS

        /// <summary>
        /// Check is an attribute decorats an method.
        /// </summary>
        /// <param name="method">The method to check.</param>
        /// <returns>True if the method is decorated with the attribute, false otherwise.</returns>
        protected bool CheckAttribute<T>(MethodInfo method) where T : TestCaseSourceFile
        {
            // Get the custom attributes
            var attributes = method.GetCustomAttributes(true);
            foreach (Attribute attribute in attributes)
            {
                if (!(attribute is T)) continue;

                // If the attribute match with the current type, extract the properties
                FileLocation = ((T)attribute).FileLocation;
                ResourceType = ((T)attribute).ResourceType;
                ResourceName = ((T)attribute).ResourceName;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check the attribute properties needed to run the test.
        /// </summary>
        protected void CheckAttributeProperties()
        {
            // Check if all properties are null. Performance.
            if (string.IsNullOrEmpty(FileLocation) && string.IsNullOrEmpty(ResourceName) && null == ResourceType)
            {
                throw new AllPropertiesNullOrEmptyException("All properties are null or empty.");
            }

            // Check the file location.
            if (!string.IsNullOrEmpty(FileLocation) && !File.Exists(FileLocation))
            {
                throw new FileNotExistsException("File does not exists.");
            }

            // Check the file resource.
            if (string.IsNullOrEmpty(FileLocation) && (string.IsNullOrEmpty(ResourceName) || null == ResourceType))
            {
                throw new ResourceNotExistsException("Resource does not exists.");
            }

            // Check the storage type.
            CheckStorageType();
        }

        #endregion


        #region PROTECTED FIELDS

        /// <summary>
        /// The file storage type.
        /// </summary>
        protected FileStoreType FileStoreType { get; set; }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Check the storage type base on the properties.
        /// </summary>
        private void CheckStorageType()
        {
            FileStoreType = string.IsNullOrEmpty(FileLocation) ? FileStoreType.Resource : FileStoreType.FileSystem;
        }

        #endregion


        #region PRIVATE FIELDS

        private string _fileLocation;
        private string _resourceName;

        #endregion
    }
}
