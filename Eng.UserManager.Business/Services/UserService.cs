using Eng.UserManager.Business.Interfaces;
using Eng.UserManager.DataAccess;
using Eng.UserManager.Domain.Entities;

namespace Eng.UserManager.Business.Services
{
    public class UserService : IUserService
    {
        private UserManagerDataContext _context;
        private IRepositoryService<User> _repository;
        public UserService(UserManagerDataContext context, IRepositoryService<User> repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<User> AddNewUser(string userName, DateTime birthDate)
        {
            var user = new User
            {
                Active = true,
                BirthDate = birthDate,
                Name = userName
            };
            await _repository.Add(user);
            _context.SaveChanges();

            return user;
        }

        public List<User> GetActiveUsers()
        {
            return _repository.GetBaseQuery().Where(x => x.Active).ToList();
        }

        public async Task<User> RemoveUser(int id)
        {
            var user = await _repository.DeleteById(id);
            _context.SaveChanges();

            return user;
        }

        public async Task<User> UpdateUser(int id, bool status)
        {
            var user = await _repository.GetById(id);
            user.Active = status;

            _repository.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
