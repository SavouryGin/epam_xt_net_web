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
        private readonly IAwardedUsersRepository _repo = RepositoryDR.AwardedUsersMemory;

        public void AddUser(User user) => _repo.SaveUser(user);

        public void AddAward(Award award) => _repo.SaveAward(award);

        public User GetUserById(Guid id) => _repo.GetUserById(id);

        public Award GetAwardById(Guid id) => _repo.GetAwardById(id);

        public IEnumerable<Award> GetAllAwards() => _repo.GetAllAwards();

        public IEnumerable<User> GetAllUsers() => _repo.GetAllUsers();

        public IEnumerable<User> GetAwardedUsers(Guid awardId) => _repo.GetAwardedUsers(awardId);

        public IEnumerable<Award> GetUserAwards(Guid userId) => _repo.GetUserAwards(userId);

        public bool UpdateUserById(Guid id, User user)
        {
            var users = GetAllUsers();

            if (!users.Where(usr => usr.Id == id).Any())
                return false;

            user.Id = id;
            _repo.UpdateUser(user);

            return true;
        }

        public bool UpdateAwardById(Guid id, Award award)
        {
            var awards = GetAllAwards();

            if (!awards.Where(awrd => awrd.Id == id).Any())
                return false;

            award.Id = id;
            _repo.UpdateAward(award);

            return true;
        }

        public void DeleteUserById(Guid id)
        {
            var nexusId = _repo.GetAllNexuses().Where(link => link.UserId == id).Select(link => link.Id);

            _repo.DeleteNexusById(nexusId);
            _repo.DeleteUserById(id);
        }

        public void DeleteAwardById(Guid id)
        {
            var nexusId = _repo.GetAllNexuses().Where(nexus => nexus.AwardId == id).Select(nexus => nexus.Id);

            _repo.DeleteNexusById(nexusId);
            _repo.DeleteAwardById(id);
        }

        public bool AddAwardToUser(Guid userId, Guid awardId)
        {
            var users = GetAllUsers();
            var awards = GetAllAwards();
            var nexuses = _repo.GetAllNexuses();

            if (!users.Where(user => user.Id == userId).Any())
                return false;

            if (!awards.Where(award => award.Id == awardId).Any())
                return false;

            if (nexuses.Where(link => link.UserId == userId && link.AwardId == awardId).Any())
                return false;

            var newNexus = new Nexus(userId, awardId);
            _repo.SaveNexus(newNexus);

            return true;
        }

        public void RemoveAwardFromUser(Guid userId, Guid awardId)
        {
            var nexuses = _repo.GetAllNexuses();

            var linkToDelete = nexuses.Where(nexus => nexus.UserId == userId && nexus.AwardId == awardId);

            if (linkToDelete != null)
                _repo.DeleteNexusById(linkToDelete.FirstOrDefault().Id);
        }
    }
}
