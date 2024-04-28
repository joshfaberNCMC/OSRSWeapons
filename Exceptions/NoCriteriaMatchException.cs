namespace OSRSWeapons.Exceptions
{
    /// <summary>
    /// Exception thrown when no items match the specified search criteria
    /// </summary>
    /// <author>Josh Faber</author>
    public class NoCriteriaMatchException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoCriteriaMatchException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception</param>
        public NoCriteriaMatchException(string message) : base(message)
        {

        }
    }
}
