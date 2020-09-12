using Data.Repositories.Abstract;
using Data.Repositories;
using Domain;
using Services.Abstract;
using System;
using Mappers;

namespace Services
{
    public class UsersService : IUsersService
    {
        // Dependency injection
        private readonly IUsersRepository _usersRepository;

        public UsersService()
        {
            _usersRepository = new UsersRepository();
        }

        public void AddUser(User user)
        {
            _usersRepository.AddUser(user.ToEntity());
        }

        public void DeleteUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
