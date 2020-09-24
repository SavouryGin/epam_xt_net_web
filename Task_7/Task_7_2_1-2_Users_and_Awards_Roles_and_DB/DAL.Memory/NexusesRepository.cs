using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DAL.Memory
{
    public class NexusesRepository : INexusesRepository
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["myDBConnection"].ConnectionString;

        public void SaveNexus(Nexus nexus)
        {
            string procedure = "SaveNexus";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", nexus.Id),
                new KeyValuePair<string, object>("@UserId", nexus.UserId),
                new KeyValuePair<string, object>("@AwardId", nexus.AwardId)
            };

            CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }

        public IEnumerable<Nexus> GetAllNexuses()
        {
            string procedure = "GetAllNexuses";
            var data = CommonMethods.GetSQLReaders(_connectionString, procedure);
            var nexuses = new LinkedList<Nexus>();

            foreach (var obj in data)
            {
                Guid id = (Guid)obj["Id"];
                Guid userId = (Guid)obj["UserId"];
                Guid awardId = (Guid)obj["AwardId"];

                var nexus = new Nexus(userId, awardId)
                {
                    Id = id
                };

                nexuses.AddLast(nexus);
            }

            return nexuses;
        }

        public bool DeleteNexusById(Guid id)
        {
            string procedure = "DeleteNexusById";

            var param = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("@Id", id),
            };

            return CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
        }

        public bool DeleteNexusById(IEnumerable<Guid> ids)
        {
            bool result = true;

            foreach (var id in ids)
            {
                string procedure = "DeleteNexusById";

                var param = new KeyValuePair<string, object>[]
                {
                    new KeyValuePair<string, object>("@Id", id),
                };

                result = result && CommonMethods.GetSQLInstruction(_connectionString, procedure, param);
            }

            return result;
        }        
    }
}
