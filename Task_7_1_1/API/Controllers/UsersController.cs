using Mappers;
using Models;
using Services;
using Services.Abstract;

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

        //public UserModel FindUser(string fname, string lname)
        //{
        //    string name = string.Format("{0}|{1}", fname, lname);
        //    _usersService.GetUserById()

        //}


    }
}
