using Common.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Contracts
{
    public interface IUsersRepository
    {
        void SaveUser(User user);

        User GetUserById(Guid id);

        bool UpdateUser(User user);

        bool DeleteUserById(Guid id);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetUserAwards(Guid Id);
    }
}
