using FluentValidation;
using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Repository;
using System.Reflection.PortableExecutable;

namespace Notes.BusinessLogic
{
    public class UsersProceed : IUsersProceed
    {
        private readonly IUsersRepository _repository;
        private readonly IValidator<Note> _noteValidator;
        private readonly IValidator<User> _userValidator;

        public UsersProceed(IUsersRepository repository, IValidator<Note> noteValidator, IValidator<User> userValidator)
        {
            _repository = repository;
            _noteValidator = noteValidator;
            _userValidator = userValidator;
        }

        public async Task<User?> AddAccess(Note note, User user)
        {
            return _noteValidator.Validate(note).IsValid
                 && _userValidator.Validate(user).IsValid
                 ? await _repository.AddAccess(note, user)
                 : null;
        }

        public async Task<User?> CreateUser(User user)
        {
            return _userValidator.Validate(user).IsValid
               ? await _repository.CreateUser(user)
               : null;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _repository.GetAllUsers();
        }

        public async Task<ICollection<Note>?> GetNotes(User user)
        {
            return _userValidator.Validate(user).IsValid
                ? await _repository.GetNotes(user)
                : null;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _repository.GetUser(id);
        }
    }
}
