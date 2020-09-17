using Common.Entities;
using System;
using System.Collections.Generic;

namespace PL.Contracts
{
    public interface IAwardedUsersAPI
    {
        void AddUser(User user);

        void AddAward(Award award);

        User GetUserById(Guid id);

        Award GetAwardById(Guid id);

        void UpdateUserById(Guid id, User user);

        void UpdateAwardById(Guid id, Award award);

        void DeleteUserById(Guid id);       

        void DeleteAwardById(Guid id);

        IEnumerable<User> GetAwardedUsers(Guid awardId);

        IEnumerable<Award> GetUserAwards(Guid userId);

        void AddAwardToUser(Guid userId, Guid awardId);

        void RemoveAwardFromUser(Guid userId, Guid awardId);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetAllAwards();        
    }
}
