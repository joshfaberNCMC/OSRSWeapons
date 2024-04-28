namespace OSRSWeapons.Exceptions
{
    /// <summary>
    /// Exception thrown when an entity is not found
    /// </summary>
    /// <author>Josh Faber</author>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public EntityNotFoundException(string message) : base(message)
        {

        }
    }
}
