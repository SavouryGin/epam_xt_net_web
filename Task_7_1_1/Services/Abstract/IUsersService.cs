using System;
using System.Collections.Generic;
using Domain;

namespace Services.Abstract
{
    public interface IUsersService
    {
        void CreateNewUser(User user);

        void UpdateUser(User user);

        User GetUserById(Guid id);

        void DeleteUserById(Guid id);

        List<User> GetUsersList();
    }
}
