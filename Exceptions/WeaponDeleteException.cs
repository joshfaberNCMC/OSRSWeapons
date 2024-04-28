namespace OSRSWeapons.Exceptions
{
    /// <summary>
    /// Exception thrown when a weapon fails to delete
    /// </summary>
    /// <author>Josh Faber</author>
    public class WeaponDeleteException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponDeleteException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public WeaponDeleteException(string message) : base(message)
        {

        }
    }
}
