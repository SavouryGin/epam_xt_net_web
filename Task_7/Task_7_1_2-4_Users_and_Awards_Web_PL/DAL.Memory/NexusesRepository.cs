using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace DAL.Memory
{
    public class NexusesRepository : INexusesRepository
    {
        // NB: Change path to local storage if necessary
        public static string dir = "D:\\code\\temp\\data\\";
        public const string repo = "nexuses.txt";

        public NexusesRepository()
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!File.Exists(dir + repo)) File.Create(dir + repo).Close();
        }

        public Nexus GetNexusById(Guid id) => CommonMethods.GetObjectById<Nexus>(id, repo, dir);

        public IEnumerable<Nexus> GetAllNexuses() => CommonMethods.GetAllObjects<Nexus>(repo, dir);

        public void SaveNexus(Nexus nexus) => CommonMethods.CreateObject(nexus, repo, dir);

        public bool UpdateNexus(Nexus nexus) => CommonMethods.UpdateObject(nexus, repo, dir);

        public bool DeleteNexusById(Guid id) => CommonMethods.DeleteObjectById<Nexus>(id, repo, dir);

        public bool DeleteNexusById(IEnumerable<Guid> ids) => CommonMethods.DeleteObjectById<Nexus>(ids, repo, dir);
    }
}
