using System;
using System.Collections.Generic;
using Domain;

namespace Services.Abstract
{
    public interface IUsersService
    {
        void SaveUserToRepository(User user);

        void SaveAllChanges();

        void AddUser(User user);

        void UpdateUser(User user);

        User GetUserById(Guid id);

        void DeleteUserById(Guid id);

        void AddAwardToUser(Guid awardId, Guid userId);

        void RemoveAwardFromUser(Guid awardId, Guid userId);
    }
}
