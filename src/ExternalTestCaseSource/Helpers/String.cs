namespace NUnitEx.ExternalTestCaseSource.Helpers
{
    /// <summary>
    /// Helpers to string object.
    /// </summary>
    internal static class String
    {
        /// <summary>
        /// Trim the string, event if it is null.
        /// </summary>
        /// <param name="str">The string to be trimmed.</param>
        /// <returns>The trimmed string.</returns>
        internal static string Trim(string str)
        {
            return str?.Trim();
        }
    }
}
