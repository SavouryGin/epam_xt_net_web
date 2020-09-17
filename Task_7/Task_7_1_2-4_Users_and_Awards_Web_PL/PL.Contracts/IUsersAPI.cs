using Common.Entities;
using System;
using System.Collections.Generic;

namespace PL.Contracts
{
    public interface IUsersAPI
    {
        void AddUser(User user);

        User GetUserById(Guid id);

        void UpdateUserById(Guid id, User user);

        void DeleteUserById(Guid id);

        IEnumerable<Award> GetUserAwards(Guid userId);

        void AddAwardToUser(Guid userId, Guid awardId);

        void RemoveAwardFromUser(Guid userId, Guid awardId);

        IEnumerable<User> GetAllUsers();
    }
}
