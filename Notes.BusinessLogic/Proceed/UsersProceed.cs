using FluentValidation;
using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Repository.Abstracion;
using System.Reflection.PortableExecutable;

namespace Notes.BusinessLogic.Proceed
{
    public class UsersProceed : IUsersProceed
    {
        private readonly IUsersRepository _repository;
        private readonly IValidator<User> _userValidator;

        public UsersProceed(IUsersRepository repository, IValidator<User> userValidator)
        {
            _repository = repository;
            _userValidator = userValidator;
        }

        public async Task<Result<User>> CreateUser(User user)
        {
            return _userValidator.Validate(user).IsValid
                ? await _repository.CreateUser(user)
                : new Result<User>() { Status = Status.NotValid };
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _repository.GetAllUsers();
        }

        public async Task<Result<User>> GetUser(int userid)
        {
            return userid >= 0 ?
                await _repository.GetUser(userid) :
                new Result<User>() { Status = Status.NotValid };
        }

        public async Task<Result<User>> DeleteUser(int userid)
        {
            return userid >= 0 ?
                await _repository.DeleteUser(userid) :
                new Result<User>() { Status = Status.NotValid };
        }

        public async Task<Result<User>> UpdateUser(User user)
        {
            return _userValidator.Validate(user).IsValid
                ? await _repository.UpdateUser(user)
                : new Result<User>() { Status = Status.NotValid };
        }
    }
}
