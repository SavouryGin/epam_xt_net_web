using Data.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    // CRUD repository
    class UsersRepository : IUsersRepository
    {
        // A thread-safe collection of users in a single copy
        public static List<UserEntity> list = new List<UserEntity>();

        public void AddUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
