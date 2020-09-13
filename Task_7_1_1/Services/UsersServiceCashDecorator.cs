using Domain;
using Services.Abstract;
using System;
using System.Collections.Generic;

namespace Services
{
    public class UsersServiceCashDecorator : IUsersService
    {
        private readonly IUsersService _usersService;
        // для кэширования
        private List<User> _users = new List<User>();

        public UsersServiceCashDecorator(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public void CreateNewUser(User user)
        {
            // логирование
            _usersService.CreateNewUser(user);
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
