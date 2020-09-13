using Mappers;
using Models;
using Services;
using Services.Abstract;
using System;
using System.Linq;

namespace API.Controllers
{
    public class UsersController
    {
        private readonly IUsersService _usersService;

        public UsersController()
        {
            _usersService = new UsersService();
        }

        public void CreateNewUser(UserModel model)
        {
            _usersService.CreateNewUser(model.ModelToDomain());
        }

        public UserModel FindUserByName(string fname, string lname)
        {
            string name = string.Format("{0}|{1}", fname, lname);
            var user = _usersService.GetUsersList().FirstOrDefault(n => n.Name == name);
            if (user == null) return null;
            return user.DomainToModel();
        }
    }
}
