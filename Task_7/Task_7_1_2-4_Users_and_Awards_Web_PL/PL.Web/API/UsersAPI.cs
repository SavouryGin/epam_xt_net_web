using BLL.Contracts;
using Common.BL.DR;
using Common.Entities;
using PL.Contracts;
using System;
using System.Collections.Generic;

namespace PL.Web.API
{
    public class UsersAPI : IUsersAPI
    {
        private readonly IUsersLogic _logic = UsersLogicDR.UsersBLL;

        public void AddUser(User user) => _logic.AddUser(user);

        public User GetUserById(Guid id) => _logic.GetUserById(id);

        public void UpdateUserById(Guid id, User user) => _logic.UpdateUserById(id, user);

        public void DeleteUserById(Guid id) => _logic.DeleteUserById(id);

        public void AddAwardToUser(Guid userId, Guid awardId) => _logic.AddAwardToUser(userId, awardId);

        public void RemoveAwardFromUser(Guid userId, Guid awardId) => _logic.RemoveAwardFromUser(userId, awardId);

        public IEnumerable<User> GetAllUsers() => _logic.GetAllUsers();

        public IEnumerable<Award> GetUserAwards(Guid userId) => _logic.GetUserAwards(userId);
    }
}