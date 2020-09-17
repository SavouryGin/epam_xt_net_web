using Common.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace DAL.Memory
{
    public static class CommonMethods
    {
        public static void CreateObject<T>(T obj, string file, string directory) where T : IBaseEntity
        {
            var objects = new LinkedList<T>(GetAllObjects<T>(file, directory));

            objects.AddLast(obj);

            SaveAllObjects(objects, file, directory);
        }

        public static bool DeleteObjectById<T>(Guid id, string file, string directory) where T : IBaseEntity
        {
            var list = new List<Guid>(1)
            {
                id
            };

            return DeleteObjectById<T>(list, file, directory);
        }

        public static bool DeleteObjectById<T>(IEnumerable<Guid> ids, string file, string directory) where T : IBaseEntity
        {
            var objects = GetAllObjects<T>(file, directory);
            var objToDelete = objects.Where(obj => ids.Contains(obj.Id));

            if (objToDelete.Count() == 0)
                return false;

            objects = objects.Except(objToDelete);

            SaveAllObjects(objects, file, directory);

            return true;
        }

        public static bool UpdateObject<T>(T obj, string file, string directory) where T : IBaseEntity
        {
            var objects = new List<T>(GetAllObjects<T>(file, directory));

            for (int i = 0; i < objects.Count(); i++)
            {
                if (objects[i].Id == obj.Id)
                {
                    objects[i] = obj;
                    SaveAllObjects<T>(objects, file, directory);
                    return true;
                }
            }

            return false;
        }

        public static T GetObjectById<T>(Guid id, string file, string directory) where T : IBaseEntity
        {
            var objects = GetAllObjects<T>(file, directory);

            var findedObj = objects.Where(obj => obj.Id == id);

            return findedObj.FirstOrDefault();
        }

        public static IEnumerable<T> GetAllObjects<T>(string file, string directory)
        {
            var objects = new LinkedList<T>();
            string[] content = null;

            int i = 0;
            while (i < 5)
            {
                try
                {
                    content = File.ReadAllLines(directory + file);

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

        public static void SaveAllObjects<T>(IEnumerable<T> objects, string file, string directory)
        {
            var content = new LinkedList<string>();
            foreach (var item in objects)
                content.AddLast(JsonConvert.SerializeObject(item));

            int i = 0;
            while (i < 5)
            {
                try
                {
                    File.WriteAllLines(directory + file, content.ToArray());
                    return;
                }
                catch
                {
                    i++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
