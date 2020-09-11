using Data.Repositories.Abstract;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data.Repositories
{
    // CRUD repository
    class UsersRepository : IUsersRepository
    {
        // A thread-safe collection of users in a single copy
        // public static List<UserEntity> _list = new List<UserEntity>();

        public static string DataPath => Environment.CurrentDirectory + "\\Data\\Users\\";

        public void AddUser(UserEntity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var userName = "User_" + user.Id + ".json";

            var userStr = JsonConvert.SerializeObject(user);

            using (var writer = new StreamWriter(DataPath + userName))
                writer.Write(userStr);
        }

        public void DeleteUserById(Guid id)
        {
            // TODO: реализовать метод DeleteUserById
            throw new NotImplementedException();
        }

        public UserEntity GetUserById(Guid id)
        {
            return GetAllUsers().FirstOrDefault(n => n.Id == id);
        }

        public void UpdateUser(UserEntity user)
        {
            // TODO: реализовать метод UpdateUser
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            var directory = new DirectoryInfo(DataPath);

            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                    yield return JsonConvert.DeserializeObject<UserEntity>(reader.ReadToEnd());
        }
    }
}
