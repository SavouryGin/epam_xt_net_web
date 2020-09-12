using Mappers;
using Models;
using Services;
using Services.Abstract;

namespace API.Controllers
{
    // Фасад
    public class UsersController
    {
        private readonly IUsersService _usersService;

        public UsersController()
        {
            _usersService = new UsersService();
        }

        public void AddUser(UserModel model)
        {
            _usersService.AddUser(model.ToDomain());
        }


    }
}
