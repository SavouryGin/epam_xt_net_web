using Common.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IUsersLogic
    {
        UserStatus AddUser(User user);

        UserStatus CheckUser(User user);

        User GetUserById(Guid id);

        User GetUserByName(string name);

        bool UpdateUserById(Guid id, User user);

        void DeleteUserById(Guid id);

        bool AddAwardToUser(Guid userId, Guid awardId);

        void RemoveAwardFromUser(Guid userId, Guid awardId);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetUserAwards(Guid userId);

        // New methods for the Role Model
        bool IsRegistered(string name, string password);

        bool IsInRole(string name, string role);

        string[] GetUserRoles(string name);

        bool SetPassword(Guid id, string password);
    }
}
