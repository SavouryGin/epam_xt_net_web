﻿using Common.Entities;
using DAL.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace DAL.Memory
{
    public class AwardedUsersRepositoryJSON : IAwardedUsersRepository
    {
        // NB: Change path to local storage if necessary
        public static string WorkingDirectory = "D:\\code\\temp\\data\\";
        public const string UsersRepo = "Users.txt";
        public const string AwardsRepo = "Awards.txt";
        public const string NexusesRepo = "Nexuses.txt";

        public AwardedUsersRepositoryJSON()
        {
            if (!Directory.Exists(WorkingDirectory)) Directory.CreateDirectory(WorkingDirectory);
            if (!File.Exists(WorkingDirectory + UsersRepo)) File.Create(WorkingDirectory + UsersRepo).Close();
            if (!File.Exists(WorkingDirectory + AwardsRepo)) File.Create(WorkingDirectory + AwardsRepo).Close();
            if (!File.Exists(WorkingDirectory + NexusesRepo)) File.Create(WorkingDirectory + NexusesRepo).Close();
        }

        // Methods for working with files
        private void CreateObject<T>(T obj, string filePath) where T : IBaseEntity
        {
            var objects = new LinkedList<T>(GetAllObjects<T>(filePath));

            objects.AddLast(obj);

            SaveAllObjects(objects, filePath);
        }

        private bool DeleteObjectById<T>(Guid id, string filePath) where T : IBaseEntity
        {
            var list = new List<Guid>(1)
            {
                id
            };

            return DeleteObjectById<T>(list, filePath);
        }

        private bool DeleteObjectById<T>(IEnumerable<Guid> ids, string filePath) where T : IBaseEntity
        {
            var objects = GetAllObjects<T>(filePath);
            var objToDelete = objects.Where(obj => ids.Contains(obj.Id));

            if (objToDelete.Count() == 0)
                return false;

            objects = objects.Except(objToDelete);

            SaveAllObjects(objects, filePath);

            return true;
        }

        private bool UpdateObject<T>(T obj, string filePath) where T : IBaseEntity
        {
            var objects = new List<T>(GetAllObjects<T>(filePath));

            for (int i = 0; i < objects.Count(); i++)
            {
                if (objects[i].Id == obj.Id)
                {
                    objects[i] = obj;
                    SaveAllObjects<T>(objects, filePath);
                    return true;
                }
            }

            return false;
        }

        private T GetObjectById<T>(Guid id, string filePath) where T : IBaseEntity
        {
            var objects = GetAllObjects<T>(filePath);

            var findedObj = objects.Where(obj => obj.Id == id);

            return findedObj.FirstOrDefault();
        }

        private IEnumerable<T> GetAllObjects<T>(string filePath)
        {
            var objects = new LinkedList<T>();
            string[] content = null;

            int i = 0;
            while (i < 5)
            {
                try
                {
                    content = File.ReadAllLines(WorkingDirectory + filePath);

                    foreach (var part in content)
                    {
                        objects.AddLast(JsonConvert.DeserializeObject<T>(part));
                    }

                    return objects;
                }
                catch
                {
                    i++;
                    Thread.Sleep(100);
                }
            }

            return null;
        }

        private void SaveAllObjects<T>(IEnumerable<T> objects, string filePath)
        {
            var content = new LinkedList<string>();
            foreach (var item in objects)
                content.AddLast(JsonConvert.SerializeObject(item));

            int i = 0;
            while (i < 5)
            {
                try
                {
                    File.WriteAllLines(WorkingDirectory + filePath, content.ToArray());
                    return;
                }
                catch
                {
                    i++;
                    Thread.Sleep(100);
                }
            }
        }

        // Interface implementation
        public User GetUserById(Guid id) => GetObjectById<User>(id, UsersRepo);

        public Award GetAwardById(Guid id) => GetObjectById<Award>(id, AwardsRepo);

        public Nexus GetNexusById(Guid id) => GetObjectById<Nexus>(id, NexusesRepo);

        public IEnumerable<Award> GetAllAwards() => GetAllObjects<Award>(AwardsRepo);

        public IEnumerable<Nexus> GetAllNexuses() => GetAllObjects<Nexus>(NexusesRepo);

        public IEnumerable<User> GetAllUsers() => GetAllObjects<User>(UsersRepo);

        public void SaveUser(User user) => CreateObject(user, UsersRepo);

        public void SaveAward(Award award) => CreateObject(award, AwardsRepo);

        public void SaveNexus(Nexus nexus) => CreateObject(nexus, NexusesRepo);

        public bool UpdateUser(User user) => UpdateObject(user, UsersRepo);

        public bool UpdateAward(Award award) => UpdateObject(award, AwardsRepo);

        public bool UpdateNexus(Nexus nexus) => UpdateObject(nexus, NexusesRepo);

        public bool DeleteAwardById(Guid id) => DeleteObjectById<Award>(id, AwardsRepo);

        public bool DeleteNexusById(Guid id) => DeleteObjectById<Nexus>(id, NexusesRepo);

        public bool DeleteNexusById(IEnumerable<Guid> ids) => DeleteObjectById<Nexus>(ids, NexusesRepo);

        public bool DeleteUserById(Guid id) => DeleteObjectById<User>(id, UsersRepo);

        public IEnumerable<User> GetAwardedUsers(Guid Id)
        {
            var usersId = GetAllNexuses().Where(nexus => nexus.AwardId == Id).Select(nexus => nexus.UserId);
            var users = GetAllUsers();

            return users.Where(user => usersId.Contains(user.Id));
        }

        public IEnumerable<Award> GetUserAwards(Guid Id)
        {
            var awardsId = GetAllNexuses().Where(nexus => nexus.UserId == Id).Select(nexus => nexus.AwardId);
            var awards = GetAllAwards();

            return awards.Where(user => awardsId.Contains(user.Id));
        }
    }
}
