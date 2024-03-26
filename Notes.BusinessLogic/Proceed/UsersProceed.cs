﻿using FluentValidation;
using Notes.BusinessLogic.Abstraction;
using Notes.Domain;
using Notes.Repository.Abstracion;

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

        public async Task<User?> GetUser(int userid)
        {
            return await _repository.GetUser(userid);
        }
    }
}