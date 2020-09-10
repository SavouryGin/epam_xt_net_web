using Data.Repositories.Abstract;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    // CRUD repository
    class UsersRepository : IUsersRepository
    {
        // A thread-safe collection of users in a single copy
        public static List<UserEntity> list = new List<UserEntity>();

        public const string LocalDataPath = "Data\\";
        public static string DataPath => Environment.CurrentDirectory + "\\" + LocalDataPath;

        public void AddUser(UserEntity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var userName = "Note_" + user.Id + ".json";

            var userStr = JsonConvert.SerializeObject(user);

            using (var writer = new StreamWriter(LocalDataPath + userName))
                writer.Write(userStr);
        }

        public void DeleteUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetUserById(Guid id)
        {
            return GetAllUsers().FirstOrDefault(n => n.Id == id);
        }

        public void UpdateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory + "\\" + LocalDataPath);

            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                    yield return JsonConvert.DeserializeObject<UserEntity>(reader.ReadToEnd());
        }
    }
}
