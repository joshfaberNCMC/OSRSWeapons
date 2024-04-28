namespace OSRSWeapons.Exceptions
{
    /// <summary>
    /// Exception thrown when attempting to modify an unmodifiable weapon
    /// </summary>
    /// <author>Josh Faber</author>
    public class WeaponUnmodifiableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponUnmodifiableException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public WeaponUnmodifiableException(string message) : base(message)
        {

        }
    }
}
