namespace OSRSWeapons.Exceptions
{
    public class NoCriteriaMatchException : Exception
    {
        public NoCriteriaMatchException(string message) : base(message)
        {

        }

        public NoCriteriaMatchException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}