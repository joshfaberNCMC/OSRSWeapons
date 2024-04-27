namespace OSRSWeapons.Exceptions
{
    public class WeaponUpdateException : Exception
    {
        public WeaponUpdateException(string message) : base(message)
        {

        }

        public WeaponUpdateException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}