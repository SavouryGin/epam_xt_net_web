using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace Data.Repositories.Abstract
{
    public interface IUsersRepository
    {
        void AddUser(UserEntity user);

        void UpdateUser(UserEntity user);

        UserEntity GetUserById(int id);

        void DeleteUserById(int id);

    }
}
