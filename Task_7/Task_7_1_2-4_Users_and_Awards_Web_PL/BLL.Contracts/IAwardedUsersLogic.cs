using Common.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IAwardedUsersLogic
    {
        void AddUser(User user);

        User GetUserById(Guid id);

        bool UpdateUserById(Guid id, User user);

        void DeleteUserById(Guid id);

        void AddAward(Award award);

        bool UpdateAwardById(Guid id, Award award);

        Award GetAwardById(Guid id);

        void DeleteAwardById(Guid id);

        bool AddAwardToUser(Guid userId, Guid awardId);

        void RemoveAwardFromUser(Guid userId, Guid awardId);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetAllAwards();

        IEnumerable<User> GetAwardedUsers(Guid awardId);

        IEnumerable<Award> GetUserAwards(Guid userId);
    }
}
