using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using DAL.Contracts;
using Common.Entities;

namespace DAL.Memory
{
    public class UsersRepository : IUsersRepository
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["myDBConnection"].ConnectionString;

        public void SaveUser(User user)
        {
            string procedure = "SaveUser";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", user.Id),
                new KeyValuePair<string, object>("@Name", user.Name),
                new KeyValuePair<string, object>("@Password", user.Password),
                new KeyValuePair<string, object>("@DateOfBirth", user.DateOfBirth),
                new KeyValuePair<string, object>("@Age", user.Age),
                new KeyValuePair<string, object>("@IsAdmin", user.IsAdmin),
                new KeyValuePair<string, object>("@Avatar", user.Avatar)
            };

            CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }

        public bool UpdateUser(User user)
        {
            string procedure = "UpdateUser";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", user.Id),
                new KeyValuePair<string, object>("@Name", user.Name),
                new KeyValuePair<string, object>("@Password", user.Password),
                new KeyValuePair<string, object>("@DateOfBirth", user.DateOfBirth),
                new KeyValuePair<string, object>("@Age", user.Age),
                new KeyValuePair<string, object>("@IsAdmin", user.IsAdmin),
                new KeyValuePair<string, object>("@Avatar", user.Avatar)
            };

            return CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }

        public User GetUserById(Guid id)
        {
            User user = null;
            string procedure = "GetUserById";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", id),
            };

            var data = CommonMethods.GetSQLReaders(_connectionString, procedure, param);

            foreach (var obj in data)
            {
                Guid _id = (Guid)obj["Id"];
                string name = obj["Name"].ToString();
                string password = obj["Password"].ToString();
                DateTime birthDay = (DateTime)obj["DateOfBirth"];
                int age = (int)obj["Age"];
                bool isAdmin = (bool)obj["IsAdmin"];
                string ava = obj["Avatar"].ToString() == "" ? null : obj["Avatar"].ToString();

                user = new User(name, birthDay, ava, isAdmin)
                {
                    Password = password,
                    Id = _id,
                    Age = age
                };
            }

            return user;
        }

        public bool DeleteUserById(Guid id)
        {
            string procedure = "DeleteUserById";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", id),
            };

            return CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }

        public IEnumerable<User> GetAllUsers()
        {
            string procedure = "GetAllUsers";
            var data = CommonMethods.GetSQLReaders(_connectionString, procedure);
            var users = new LinkedList<User>();

            foreach (var obj in data)
            {
                Guid id = (Guid)obj["Id"];
                string name = obj["Name"].ToString();
                string password = obj["Password"].ToString();
                DateTime birthDay = (DateTime)obj["DateOfBirth"];
                int age = (int)obj["Age"];
                bool isAdmin = (bool)obj["IsAdmin"];
                string ava = obj["Avatar"].ToString() == "" ? null : obj["Avatar"].ToString();

                var user = new User(name, birthDay, ava, isAdmin)
                {
                    Password = password,
                    Id = id,
                    Age = age
                };

                users.AddLast(user);
            }

            return users;
        }

        public IEnumerable<Award> GetUserAwards(Guid Id)
        {
            string procedure = "GetUserAwards";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@UserId", Id),
            };

            var data = CommonMethods.GetSQLReaders(_connectionString, procedure, param);
            var awards = new LinkedList<Award>();

            foreach (var obj in data)
            {
                Guid _id = (Guid)obj["Id"];
                string title = obj["Title"].ToString();
                string ava = obj["Avatar"].ToString() == "" ? null : obj["Avatar"].ToString();

                var award = new Award(title, ava)
                {
                    Id = _id
                };

                awards.AddLast(award);
            }

            return awards;
        }

        public User GetUserByName(string name)
        {
            User user = null;
            string procedure = "GetUserByName";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Name", name),
            };

            var data = CommonMethods.GetSQLReaders(_connectionString, procedure, param);

            foreach (var obj in data)
            {
                Guid id = (Guid)obj["Id"];
                string _name = obj["Name"].ToString();
                string password = obj["Password"].ToString();
                DateTime birthDay = (DateTime)obj["DateOfBirth"];
                int age = (int)obj["Age"];
                bool isAdmin = (bool)obj["IsAdmin"];
                string ava = obj["Avatar"].ToString() == "" ? null : obj["Avatar"].ToString();

                user = new User(_name, birthDay, ava, isAdmin)
                {
                    Password = password,
                    Id = id,
                    Age = age
                };
            }

            return user;
        }

        public string[] GetUserRoles(string name)
        {
            var roles = new LinkedList<string>();
            var user = GetUserByName(name);

            if (user == null)
            {
                return roles.ToArray();
            }

            roles.AddLast("user");

            return user.IsAdmin ? roles.Append("admin").ToArray() : roles.ToArray();
        }

        public bool IsInRole(string name, string role)
        {
            string procedure = "IsInRole";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Name", name),
                new KeyValuePair<string, object>("@Role", role)
            };

            var data = CommonMethods.GetSQLObject(_connectionString, procedure, param);

            return (int)data > 0;
        }

        public bool IsRegistered(string name, string password)
        {
            string procedure = "IsRegistered";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Name", name),
                new KeyValuePair<string, object>("@Password", password)
            };

            var data = CommonMethods.GetSQLObject(_connectionString, procedure, param);

            return (int)data > 0;
        }        

        public bool SetPassword(Guid id, string password)
        {
            string procedure = "SetPassword";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", id),
                new KeyValuePair<string, object>("@Password", password)
            };

            return CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }        
    }
}
