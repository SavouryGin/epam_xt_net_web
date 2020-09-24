using BLL.Contracts;
using Common.BLL.DR;
using Common.Entities;
using PL.Contracts;
using System;
using System.Collections.Generic;

namespace PL.Web.API
{
    public class UsersAPI : IUsersAPI
    {
        private readonly IUsersLogic _logic = UsersLogicDR.UsersBLL;

        public bool AddAwardToUser(Guid userId, Guid awardId) => _logic.AddAwardToUser(userId, awardId);

        public UserStatus AddUser(User user) => _logic.AddUser(user);

        public UserStatus CheckUser(User user) => _logic.CheckUser(user);

        public void DeleteUserById(Guid id) => _logic.DeleteUserById(id);

        public IEnumerable<User> GetAllUsers() => _logic.GetAllUsers();

        public IEnumerable<Award> GetUserAwards(Guid userId) => _logic.GetUserAwards(userId);

        public User GetUserById(Guid id) => _logic.GetUserById(id);

        public User GetUserByName(string name) => _logic.GetUserByName(name);

        public string[] GetUserRoles(string name) => _logic.GetUserRoles(name);

        public bool IsInRole(string name, string role) => _logic.IsInRole(name, role);

        public bool IsRegistered(string name, string password) => _logic.IsRegistered(name, password);

        public void RemoveAwardFromUser(Guid userId, Guid awardId) => _logic.RemoveAwardFromUser(userId, awardId);

        public bool SetPassword(Guid id, string password) => _logic.SetPassword(id, password);

        public bool UpdateUserById(Guid id, User user) => _logic.UpdateUserById(id, user);
    }
}