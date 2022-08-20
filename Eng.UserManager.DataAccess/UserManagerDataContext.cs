using Eng.UserManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eng.UserManager.DataAccess
{
    public class UserManagerDataContext : DbContext
    {
        public UserManagerDataContext(DbContextOptions options)
        : base(options)
        {
        }
        public UserManagerDataContext() { }

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
