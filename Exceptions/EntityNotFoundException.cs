namespace OSRSWeapons.Exceptions
{

    public class EntityNotFoundException : Exception
    {
        // Constructor with a custom message
        public EntityNotFoundException(string message) : base(message)
        {

        }

        // Constructor with a custom message and inner exception
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }

}