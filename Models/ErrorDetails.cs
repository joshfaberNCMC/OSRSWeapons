namespace OSRSWeapons.Models
{
    /// <summary>
    /// Represents details of an error response
    /// </summary>
    /// <author>Josh Faber</author>
    public class ErrorDetails
    {
        /// <summary>
        /// The status code of the error response
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// The message describing the error
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// The exception message associated with the error
        /// </summary>
        public string? ExceptionMessage { get; set; }
    }
}

