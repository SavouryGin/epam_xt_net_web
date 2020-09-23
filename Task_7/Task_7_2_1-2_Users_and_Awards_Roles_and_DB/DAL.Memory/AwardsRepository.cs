using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DAL.Memory
{
    public class AwardsRepository : IAwardsRepository
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["myDBConnection"].ConnectionString;

        public void SaveAward(Award award)
        {
            string procedure = "SaveAward";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", award.Id),
                new KeyValuePair<string, object>("@Title", award.Title),
                new KeyValuePair<string, object>("@Avatar", award.Avatar),
                new KeyValuePair<string, object>("@DateOfCreation", award.DateOfCreation)
            };

            CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }

        public bool UpdateAward(Award award)
        {
            string procedure = "UpdateAward";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", award.Id),
                new KeyValuePair<string, object>("@Avatar", award.Avatar)
            };

            return CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }

        public Award GetAwardById(Guid id)
        {
            Award award = null;
            string procedure = "GetAwardById";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", id),
            };

            var data = CommonMethods.GetSQLReaders(_connectionString, procedure, param);

            foreach (var obj in data)
            {
                Guid _id = (Guid)obj["Id"];
                string title = obj["Title"].ToString();
                string ava = obj["Avatar"].ToString() == "" ? null : obj["Avatar"].ToString();
                DateTime date = (DateTime)obj["DateOfCreation"];

                award = new Award(title, ava)
                {
                    Id = _id,
                    DateOfCreation = date
                };
            }

            return award;
        }

        public bool DeleteAwardById(Guid id)
        {
            string procedure = "DeleteAwardById";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", id),
            };

            return CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }

        public IEnumerable<Award> GetAllAwards()
        {
            string procedure = "GetAllAwards";
            var data = CommonMethods.GetSQLReaders(_connectionString, procedure);
            var awards = new LinkedList<Award>();

            foreach (var obj in data)
            {
                Guid id = (Guid)obj["Id"];
                string title = obj["Title"].ToString();
                string ava = obj["Avatar"].ToString() == "" ? null : obj["Avatar"].ToString();
                DateTime date = (DateTime)obj["DateOfCreation"];

                var award = new Award(title, ava)
                {
                    Id = id,
                    DateOfCreation = date
                };

                awards.AddLast(award);
            }

            return awards;
        }        

        public Award GetAwardByTitle(string title)
        {
            Award award = null;
            string procedure = "GetAwardByTitle";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Title", title),
            };

            var sqlData = CommonMethods.GetSQLReaders(_connectionString, procedure, param);

            foreach (var obj in sqlData)
            {
                Guid id = (Guid)obj["Id"];
                string _title = obj["Title"].ToString();
                string image = obj["Avatar"].ToString() == "" ? null : obj["Avatar"].ToString();
                DateTime date = (DateTime)obj["DateOfCreation"];

                award = new Award(_title, image)
                {
                    Id = id,
                    DateOfCreation = date
                };
            }

            return award;
        }

        public IEnumerable<User> GetAwardedUsers(Guid Id)
        {
            string procedure = "GetAwardedUsers";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@AwardId", Id),
            };

            var data = CommonMethods.GetSQLReaders(_connectionString, procedure, param);
            var users = new LinkedList<User>();

            foreach (var item in data)
            {
                Guid _id = (Guid)item["Id"];
                string name = item["Name"].ToString();
                string password = item["Password"].ToString();
                DateTime birthDay = (DateTime)item["DateOfBirth"];
                DateTime date = (DateTime)item["DateOfCreation"];
                int age = (int)item["Age"];
                bool isAdmin = (bool)item["IsAdmin"];
                string ava = item["Avatar"].ToString() == "" ? null : item["Avatar"].ToString();

                var user = new User(name, birthDay, ava, isAdmin)
                {
                    Password = password,
                    Id = _id,
                    Age = age,
                    DateOfCreation = date
                };

                users.AddLast(user);
            }

            return users;
        }        
    }
}
