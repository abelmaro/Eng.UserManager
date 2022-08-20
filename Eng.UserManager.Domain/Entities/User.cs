namespace Eng.UserManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
