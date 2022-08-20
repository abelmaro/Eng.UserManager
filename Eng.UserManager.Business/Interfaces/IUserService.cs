using Eng.UserManager.DataAccess.Interfaces;
using Eng.UserManager.Domain.Entities;

namespace Eng.UserManager.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> AddNewUser(string userName, DateTime birthDate);
        Task<User> UpdateUser(int id, bool status);
        Task<User> RemoveUser(int id);
        List<User> GetActiveUsers();
    }
}
