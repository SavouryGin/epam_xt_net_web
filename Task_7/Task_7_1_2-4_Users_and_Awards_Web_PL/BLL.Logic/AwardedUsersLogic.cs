using BLL.Contracts;
using Common.DAL.DR;
using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Logic
{
    public class AwardedUsersLogic : IAwardedUsersLogic
    {
        private readonly IAwardedUsersRepository Repo = RepositoryDR.AwardedUsersMemory;

        public void AddUser(User user) => Repo.SaveUser(user);

        public void AddAward(Award award) => Repo.SaveAward(award);

        public User GetUserById(Guid id) => Repo.GetUserById(id);

        public Award GetAwardById(Guid id) => Repo.GetAwardById(id);

        public IEnumerable<Award> GetAllAwards() => Repo.GetAllAwards();

        public IEnumerable<User> GetAllUsers() => Repo.GetAllUsers();

        public IEnumerable<User> GetAwardedUsers(Guid awardId) => Repo.GetAwardedUsers(awardId);

        public IEnumerable<Award> GetUserAwards(Guid userId) => Repo.GetUserAwards(userId);

        public bool UpdateUserById(Guid id, User user)
        {
            var users = GetAllUsers();

            if (!users.Where(usr => usr.Id == id).Any())
                return false;

            user.Id = id;
            Repo.UpdateUser(user);

            return true;
        }

        public bool UpdateAwardById(Guid id, Award award)
        {
            var awards = GetAllAwards();

            if (!awards.Where(awrd => awrd.Id == id).Any())
                return false;

            award.Id = id;
            Repo.UpdateAward(award);

            return true;
        }

        public void DeleteUserById(Guid id)
        {
            var nexusId = Repo.GetAllNexuses().Where(link => link.UserId == id).Select(link => link.Id);

            Repo.DeleteNexusById(nexusId);
            Repo.DeleteUserById(id);
        }

        public void DeleteAwardById(Guid id)
        {
            var nexusId = Repo.GetAllNexuses().Where(nexus => nexus.AwardId == id).Select(nexus => nexus.Id);

            Repo.DeleteNexusById(nexusId);
            Repo.DeleteAwardById(id);
        }

        public bool AddAwardToUser(Guid userId, Guid awardId)
        {
            var users = GetAllUsers();
            var awards = GetAllAwards();
            var nexuses = Repo.GetAllNexuses();

            if (!users.Where(user => user.Id == userId).Any())
                return false;

            if (!awards.Where(award => award.Id == awardId).Any())
                return false;

            if (nexuses.Where(link => link.UserId == userId && link.AwardId == awardId).Any())
                return false;

            var newNexus = new Nexus(userId, awardId);
            Repo.SaveNexus(newNexus);

            return true;
        }

        public void RemoveAwardFromUser(Guid userId, Guid awardId)
        {
            var nexuses = Repo.GetAllNexuses();

            var linkToDelete = nexuses.Where(nexus => nexus.UserId == userId && nexus.AwardId == awardId);

            if (linkToDelete != null)
                Repo.DeleteNexusById(linkToDelete.FirstOrDefault().Id);
        }
    }
}
