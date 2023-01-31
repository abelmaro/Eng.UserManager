using Eng.UserManager.Business.Exceptions;
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

        public async Task<User> AddNewUserAsync(string userName, DateTime birthDate)
        {
            var user = new User
            {
                Active = true,
                BirthDate = birthDate,
                Name = userName
            };
            ValidateMandatoryFields(user);

            await _repository.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public List<User> GetActiveUsers()
        {
            return _repository.GetBaseQuery().Where(x => x.Active).ToList();
        }

        public async Task<User> RemoveUserAsync(int id)
        {
            var user = await _repository.DeleteByIdAsync(id);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUserAsync(int id, bool status)
        {
            var user = await _repository.GetByIdAsync(id);
            user.Active = status;

            _repository.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public void ValidateMandatoryFields(User user) {
            if (string.IsNullOrEmpty(user.Name))
                throw new MandatoryFieldException(nameof(user.Name));
            if (user.BirthDate == new DateTime())
                throw new MandatoryFieldException(nameof(user.BirthDate));
        }
    }
}
