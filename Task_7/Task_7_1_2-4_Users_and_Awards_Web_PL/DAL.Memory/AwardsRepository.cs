using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Memory
{
    public class AwardsRepository : IAwardsRepository
    {
        // NB: Change path to local storage if necessary
        public static string dir = "D:\\code\\temp\\data\\";
        public const string repo = "awards.txt";

        public AwardsRepository()
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!File.Exists(dir + repo)) File.Create(dir + repo).Close();
        }

        public Award GetAwardById(Guid id) => CommonMethods.GetObjectById<Award>(id, repo, dir);

        public IEnumerable<Award> GetAllAwards() => CommonMethods.GetAllObjects<Award>(repo, dir);

        public void SaveAward(Award award) => CommonMethods.CreateObject(award, repo, dir);

        public bool UpdateAward(Award award) => CommonMethods.UpdateObject(award, repo, dir);

        public bool DeleteAwardById(Guid id) => CommonMethods.DeleteObjectById<Award>(id, repo, dir);

        public IEnumerable<User> GetAwardedUsers(Guid Id)
        {
            UsersRepository usersRepo = new UsersRepository();
            NexusesRepository nexusesRepo = new NexusesRepository();

            var usersId = nexusesRepo.GetAllNexuses().Where(nexus => nexus.AwardId == Id).Select(nexus => nexus.UserId);
            var users = usersRepo.GetAllUsers();

            return users.Where(user => usersId.Contains(user.Id));
        }
    }
}
