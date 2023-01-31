using Eng.UserManager.DataAccess.Interfaces;
using Eng.UserManager.Domain.Entities;

namespace Eng.UserManager.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> AddNewUserAsync(string userName, DateTime birthDate);
        Task<User> UpdateUserAsync(int id, bool status);
        Task<User> RemoveUserAsync(int id);
        List<User> GetActiveUsers();
    }
}
