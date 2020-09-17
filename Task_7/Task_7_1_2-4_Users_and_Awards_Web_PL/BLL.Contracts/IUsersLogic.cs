using Common.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IUsersLogic
    {
        void AddUser(User user);

        User GetUserById(Guid id);

        bool UpdateUserById(Guid id, User user);

        void DeleteUserById(Guid id);

        bool AddAwardToUser(Guid userId, Guid awardId);

        void RemoveAwardFromUser(Guid userId, Guid awardId);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetUserAwards(Guid userId);
    }
}
