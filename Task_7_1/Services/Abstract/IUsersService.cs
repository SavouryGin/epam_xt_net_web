using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.Abstract
{
    public interface IUsersService
    {
        void AddUser(User user);

        void UpdateUser(User user);

        User GetUserById(int id);

        void DeleteUserById(int id);
    }
}
