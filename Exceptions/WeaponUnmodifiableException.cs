namespace OSRSWeapons.Exceptions
{

    public class WeaponUnmodifiableException : Exception
    {
        // Constructor with a custom message
        public WeaponUnmodifiableException(string message) : base(message)
        {

        }

        // Constructor with a custom message and inner exception
        public WeaponUnmodifiableException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }

}