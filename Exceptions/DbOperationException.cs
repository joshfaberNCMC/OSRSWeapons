namespace OSRSWeapons.Exceptions
{
    /// <summary>
    /// Exception thrown when there is an error performing database operations
    /// </summary>
    /// <author>Josh Faber</author>
    public class DbOperationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponCreateException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public DbOperationException(string message) : base(message)
        {

        }
    }
}
