namespace Eng.UserManager.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id)
            : base($"Record with ID: {id} was not found") { }
    }
}
