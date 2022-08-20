using Eng.UserManager.Business.Interfaces;
using Eng.UserManager.Domain.Entities;
using Eng.UserManager.WebApi.Controllers;
using Moq;
using Xunit;

namespace Eng.UserManager.Tests.WebApi
{
    public class UserControllerTest
    {
        #region Constants
        public int ID = 1;
        public string NAME = "Name";
        public DateTime BIRTH_DATE = DateTime.Now;
        public bool ACTIVE = true;

        private Mock<IUserService> _userService = new Mock<IUserService>();

        private UserController _controller = null!;
        #endregion

        public UserControllerTest() {
            _userService = new Mock<IUserService>();
        }

        #region Tests
        [Fact]
        public void Should_Call_UserService()
        {

            //Arrage
            var activeUsers = new List<User> { new User { Id = ID, Name = NAME, BirthDate = BIRTH_DATE, Active = ACTIVE } };
            _userService.Setup(service => service.GetActiveUsers()).Returns(activeUsers);

            //Arrage
            _controller = GetController();
            var act = _controller.GetAllActiveUsers();

            //Assert
            _userService.Verify(x => x.GetActiveUsers(), Times.Once);

        }
        #endregion

        #region Privates
        private UserController GetController(){
            return new UserController(_userService.Object);
        }
        #endregion

    }
}
