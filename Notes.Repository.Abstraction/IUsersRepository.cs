﻿using Notes.Domain;

namespace Notes.Repository
{
    public interface IUsersRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User?> GetUser(int id);
        Task<User?> CreateUser(User user);
    }
}