using Domain;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    // Декоратор для логирования событий в сервисе
    public class UsersServiceLoggerDecorator : IUsersService
    {
        private readonly IUsersService _usersService;
        // для кэширования
        private List<User> _users = new List<User>();

        public UsersServiceLoggerDecorator(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public void AddUser(User user)
        {
            // логирование
            _usersService.AddUser(user);
        }

        public void DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
