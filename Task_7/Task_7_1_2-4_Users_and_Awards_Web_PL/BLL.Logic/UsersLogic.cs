using BLL.Contracts;
using Common.DAL.DR;
using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Logic
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IUsersRepository _usersRepo = UsersRepoDR.UsersMemory;
        private readonly INexusesRepository _nexusesRepo = NexusesRepoDR.NexusesMemory;

        public void AddUser(User user) => _usersRepo.SaveUser(user);

        public User GetUserById(Guid id) => _usersRepo.GetUserById(id);

        public IEnumerable<User> GetAllUsers() => _usersRepo.GetAllUsers();

        public IEnumerable<Award> GetUserAwards(Guid userId) => _usersRepo.GetUserAwards(userId);

        public bool UpdateUserById(Guid id, User user)
        {
            var users = GetAllUsers();

            if (!users.Where(usr => usr.Id == id).Any())
                return false;

            user.Id = id;
            _usersRepo.UpdateUser(user);

            return true;
        }

        public void DeleteUserById(Guid id)
        {
            var nexusId = _nexusesRepo.GetAllNexuses().Where(link => link.UserId == id).Select(link => link.Id);

            _nexusesRepo.DeleteNexusById(nexusId);
            _usersRepo.DeleteUserById(id);
        }

        public bool AddAwardToUser(Guid userId, Guid awardId)
        {
            AwardsLogic awardsLogic = new AwardsLogic();
            var awards = awardsLogic.GetAllAwards();
            var users = GetAllUsers();
            var nexuses = _nexusesRepo.GetAllNexuses();

            if (!users.Where(user => user.Id == userId).Any())
                return false;

            if (!awards.Where(award => award.Id == awardId).Any())
                return false;

            if (nexuses.Where(link => link.UserId == userId && link.AwardId == awardId).Any())
                return false;

            var newNexus = new Nexus(userId, awardId);
            _nexusesRepo.SaveNexus(newNexus);

            return true;
        }

        public void RemoveAwardFromUser(Guid userId, Guid awardId)
        {
            var nexuses = _nexusesRepo.GetAllNexuses();

            var linkToDelete = nexuses.Where(nexus => nexus.UserId == userId && nexus.AwardId == awardId);

            if (linkToDelete != null)
                _nexusesRepo.DeleteNexusById(linkToDelete.FirstOrDefault().Id);
        }
    }
}
