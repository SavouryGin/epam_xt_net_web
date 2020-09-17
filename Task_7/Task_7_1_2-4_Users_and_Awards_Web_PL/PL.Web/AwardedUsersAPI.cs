using BLL.Contracts;
using Common.BL.DR;
using Common.Entities;
using PL.Contracts;
using System;
using System.Collections.Generic;

namespace PL.Web.AwardedUsersAPI
{
    public class AwardedUsersAPI : IAwardedUsersAPI
    {
        private readonly IAwardedUsersLogic _logic = LogicDR.AwardedUsersBLL;

        public void AddUser(User user) => _logic.AddUser(user);

        public void AddAward(Award award) => _logic.AddAward(award);

        public User GetUserById(Guid id) => _logic.GetUserById(id);

        public Award GetAwardById(Guid id) => _logic.GetAwardById(id);

        public void UpdateAwardById(Guid id, Award award) => _logic.UpdateAwardById(id, award);

        public void UpdateUserById(Guid id, User user) => _logic.UpdateUserById(id, user);

        public void DeleteUserById(Guid id) => _logic.DeleteUserById(id);

        public void DeleteAwardById(Guid id) => _logic.DeleteAwardById(id);

        public void AddAwardToUser(Guid userId, Guid awardId) => _logic.AddAwardToUser(userId, awardId);

        public void RemoveAwardFromUser(Guid userId, Guid awardId) => _logic.RemoveAwardFromUser(userId, awardId);

        public IEnumerable<Award> GetAllAwards() => _logic.GetAllAwards();

        public IEnumerable<User> GetAllUsers() => _logic.GetAllUsers();

        public IEnumerable<Award> GetUserAwards(Guid userId) => _logic.GetUserAwards(userId);

        public IEnumerable<User> GetAwardedUsers(Guid awardId) => _logic.GetAwardedUsers(awardId);
    }
}