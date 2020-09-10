using Mappers;
using Models;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    // Фасад
    class UsersController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public void AddUser(UserModel model)
        {
            _usersService.AddUser(model.ToDomain());
        }


    }
}
