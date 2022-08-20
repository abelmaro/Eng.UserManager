using Eng.UserManager.Business.Interfaces;
using Eng.UserManager.Business.Services;
using Eng.UserManager.DataAccess;
using Eng.UserManager.DataAccess.Interfaces;
using Eng.UserManager.Domain.Entities;
using Moq;
using Xunit;
using Eng.UserManager.Domain.Exceptions;
using Eng.UserManager.Business.Exceptions;

namespace Eng.UserManager.Tests.Business
{
    public class UserServiceTest
    {
        #region Constants
        public int NON_EXISTENT_ID = 2;
        public int ID = 1;
        public string NAME = "Name";
        public DateTime BIRTH_DATE = DateTime.Now;
        public bool ACTIVE = true;

        private Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private Mock<IRepositoryService<User>> _repositoryServiceMock = new Mock<IRepositoryService<User>>();
        private Mock<UserManagerDataContext> _contextMock = new Mock<UserManagerDataContext>();

        private UserService _service = null!;
        #endregion

        public UserServiceTest()
        {
            _contextMock = new Mock<UserManagerDataContext>();
            _repositoryServiceMock = new Mock<IRepositoryService<User>>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }

        #region Tests
        [Fact]
        public async void AddTest_Successful()
        {
            //Arrage
            _userRepositoryMock.Setup(x => x.Add(GetUser()));

            //Act
            _service = GetService();
            var entity = await _service.AddNewUser(NAME, BIRTH_DATE);

            //Assert
            Assert.True(entity.Active.Equals(true));
            _repositoryServiceMock.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
            _contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public async void UpdateTest_Successful()
        {
            //Arrage
            var entity = GetUser();
            entity.Active = false;

            _repositoryServiceMock.Setup(x => x.GetById(It.Is<int>(x => x == ID))).Returns(Task.FromResult(entity));
            _userRepositoryMock.Setup(x => x.Update(entity));

            //Act
            _service = GetService();
            entity = await _service.UpdateUser(ID, ACTIVE);

            //Assert
            Assert.True(entity.Active.Equals(ACTIVE));
            _repositoryServiceMock.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
            _contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public async void RemoveTest_Entity_Not_Found_Exception()
        {
            //Arrage
            var exception = new EntityNotFoundException(NON_EXISTENT_ID);
            _repositoryServiceMock.Setup(x => x.DeleteById(It.Is<int>(i => i == NON_EXISTENT_ID))).Throws(exception);

            //Act
            try
            {
                _service = GetService();
                await _service.RemoveUser(NON_EXISTENT_ID);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(ex.Message, exception.Message);
                _repositoryServiceMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
                _contextMock.Verify(x => x.FindAsync<User>(It.IsAny<int>()), Times.Never);
                _contextMock.Verify(x => x.SaveChanges(), Times.Never);
            }
        }

        [Fact]
        public async void AddTest_Mandatory_Field_Name_Exception()
        {
            //Arrage
            var entity = GetUser();
            try
            {
                //Act
                _service = GetService();
                await _service.AddNewUser(String.Empty, BIRTH_DATE);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(ex.Message, new MandatoryFieldException(nameof(entity.Name)).Message);
                _repositoryServiceMock.Verify(x => x.Add(It.IsAny<User>()), Times.Never);
                _contextMock.Verify(x => x.SaveChanges(), Times.Never);
            }
        }
        #endregion

        #region Privates
        private User GetUser()
        {
            return new User
            {
                Id = ID,
                Active = ACTIVE,
                Name = NAME,
                BirthDate = BIRTH_DATE
            };
        }

        private UserService GetService()
        {
            return new UserService(_contextMock.Object, _repositoryServiceMock.Object);
        }
        #endregion

    }
}
