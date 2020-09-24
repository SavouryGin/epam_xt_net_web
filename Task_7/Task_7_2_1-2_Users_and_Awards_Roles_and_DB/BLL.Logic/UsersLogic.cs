using BLL.Contracts;
using Common.DAL.DR;
using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BLL.Logic
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IUsersRepository _usersRepo = UsersRepoDR.UsersMemory;
        private readonly INexusesRepository _nexusesRepo = NexusesRepoDR.NexusesMemory;

        public UserStatus CheckUser(User user)
        {
            string namePattern = @"^[a-zA-Z0-9_\-]{3,25}$";

            if (!Regex.IsMatch(user.Name, namePattern))
            {
                return UserStatus.InvalidName;
            }

            return _usersRepo.GetUserByName(user.Name) != null ? UserStatus.Exists : UserStatus.Verified;
        }

        public UserStatus AddUser(User user)
        {
            var res = CheckUser(user);

            if (res == UserStatus.Verified)
            {
                _usersRepo.SaveUser(user);
            }

            return res;
        }

        public void DeleteUserById(Guid id)
        {
            var nexuses = _nexusesRepo.GetAllNexuses().Where(nexus => nexus.UserId == id).Select(nexus => nexus.Id);

            _nexusesRepo.DeleteNexusById(nexuses);
            _usersRepo.DeleteUserById(id);
        }

        public bool UpdateUserById(Guid id, User user)
        {
            var _user = GetUserById(id);

            if (_user == null)
            {
                return false;
            }

            user.Id = id;
            user.Password = _user.Password;
            user.IsAdmin = _user.IsAdmin;

            _usersRepo.UpdateUser(user);

            return true;
        }

        public bool AddAwardToUser(Guid userId, Guid awardId)
        {
            AwardsLogic awardsLogic = new AwardsLogic();
            var users = GetAllUsers();
            var awards = awardsLogic.GetAllAwards();
            var nexuses = _nexusesRepo.GetAllNexuses();

            if (!users.Where(user => user.Id == userId).Any())
            {
                return false;
            }

            if (!awards.Where(award => award.Id == awardId).Any())
            {
                return false;
            }

            if (nexuses.Where(_nexus => _nexus.UserId == userId && _nexus.AwardId == awardId).Any())
            {
                return false;
            }

            var nexus = new Nexus(userId, awardId);
            _nexusesRepo.SaveNexus(nexus);

            return true;
        }

        public void RemoveAwardFromUser(Guid userId, Guid awardId)
        {
            var nexuses = _nexusesRepo.GetAllNexuses();
            var toDelete = nexuses.Where(nexus => nexus.UserId == userId && nexus.AwardId == awardId);

            if (toDelete != null)
            {
                _nexusesRepo.DeleteNexusById(toDelete.FirstOrDefault().Id);
            }
        }

        public IEnumerable<User> GetAllUsers() => _usersRepo.GetAllUsers();

        public IEnumerable<Award> GetUserAwards(Guid userId) => _usersRepo.GetUserAwards(userId);

        public User GetUserById(Guid id) => _usersRepo.GetUserById(id);

        public User GetUserByName(string name) => _usersRepo.GetUserByName(name);

        public string[] GetUserRoles(string name) => _usersRepo.GetUserRoles(name);

        public bool IsInRole(string name, string role) => _usersRepo.IsInRole(name, role);

        public bool IsRegistered(string name, string password) => _usersRepo.IsRegistered(name, password);       

        public bool SetPassword(Guid id, string password) => _usersRepo.SetPassword(id, password);        
    }
}
