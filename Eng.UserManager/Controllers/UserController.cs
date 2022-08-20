using Eng.UserManager.Business.Interfaces;
using Eng.UserManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eng.UserManager.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public Task<User> AddUser(string userName, DateTime birthDate)
        {
            return _userService.AddNewUser(userName, birthDate);
        }

        [HttpPost]
        public Task<User> UpdateUserStatus(int id, bool status)
        {
            return _userService.UpdateUser(id, status);
        }

        [HttpPost]
        public Task<User> RemoveUser(int id)
        {
            return _userService.RemoveUser(id);
        }

        [HttpGet]
        public List<User> GetAllActiveUsers()
        {
            return _userService.GetActiveUsers();
        }
    }
}
