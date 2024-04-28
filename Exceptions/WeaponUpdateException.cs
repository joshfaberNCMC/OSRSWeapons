namespace OSRSWeapons.Exceptions
{
    /// <summary>
    /// Exception thrown when a weapon fails to update
    /// </summary>
    /// <author>Josh Faber</author>
    public class WeaponUpdateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponUpdateException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public WeaponUpdateException(string message) : base(message)
        {

        }
    }
}
