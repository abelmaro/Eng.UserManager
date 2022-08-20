namespace Eng.UserManager.Business.Exceptions
{
    public class MandatoryFieldException : Exception
    {
        public MandatoryFieldException(string field)
            : base($"The field {field} is required.") { }
    }    
}
