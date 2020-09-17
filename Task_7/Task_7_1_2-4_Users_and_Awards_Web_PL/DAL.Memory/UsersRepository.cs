using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Memory
{
    public class UsersRepository : IUsersRepository
    {
        // NB: Change path to local storage if necessary
        public static string path = "D:\\code\\temp\\data\\";
        public const string repo = "users.txt";

        public UsersRepository()
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!File.Exists(path + repo)) File.Create(path + repo).Close();
        }

        public User GetUserById(Guid id) => CommonMethods.GetObjectById<User>(id, repo, path);

        public IEnumerable<User> GetAllUsers() => CommonMethods.GetAllObjects<User>(repo, path);

        public void SaveUser(User user) => CommonMethods.CreateObject(user, repo, path);

        public bool UpdateUser(User user) => CommonMethods.UpdateObject(user, repo, path);

        public bool DeleteUserById(Guid id) => CommonMethods.DeleteObjectById<User>(id, repo, path);

        public IEnumerable<Award> GetUserAwards(Guid Id)
        {
            AwardsRepository awardsRepo = new AwardsRepository();
            NexusesRepository nexusesRepo = new NexusesRepository();

            var awardsId = nexusesRepo.GetAllNexuses().Where(nexus => nexus.UserId == Id).Select(nexus => nexus.AwardId);
            var awards = awardsRepo.GetAllAwards();

            return awards.Where(user => awardsId.Contains(user.Id));
        }
    }
}
