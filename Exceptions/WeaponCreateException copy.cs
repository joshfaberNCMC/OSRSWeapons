namespace OSRSWeapons.Exceptions
{
    /// <summary>
    /// Exception thrown when a weapon fails to be created
    /// </summary>
    /// <author>Josh Faber</author>
    public class WeaponCreateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponCreateException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public WeaponCreateException(string message) : base(message)
        {

        }
    }
}
