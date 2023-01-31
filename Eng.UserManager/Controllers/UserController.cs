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
        public async Task<User> AddUser(string userName, DateTime birthDate)
        {
            return await _userService.AddNewUserAsync(userName, birthDate);
        }

        [HttpPost]
        public async Task<User> UpdateUserStatus(int id, bool status)
        {
            return await _userService.UpdateUserAsync(id, status);
        }

        [HttpPost]
        public async Task<User> RemoveUser(int id)
        {
            return await _userService.RemoveUserAsync(id);
        }

        [HttpGet]
        public List<User> GetAllActiveUsers()
        {
            return _userService.GetActiveUsers();
        }
    }
}
