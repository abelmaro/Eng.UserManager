using Eng.UserManager.DataAccess.Interfaces;
using Eng.UserManager.Domain.Entities;

namespace Eng.UserManager.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserManagerDataContext context) : base(context) { 
        
        }
    }
}
