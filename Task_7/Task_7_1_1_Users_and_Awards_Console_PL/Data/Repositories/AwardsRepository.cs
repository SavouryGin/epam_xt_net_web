﻿using Data.Repositories.Abstract;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data.Repositories
{
    public class AwardsRepository : IAwardsRepository
    {
        public static string DataPath => Environment.CurrentDirectory + "\\Data\\Awards\\";

        public void CreateNewAward(AwardEntity award)
        {
            if (award == null)
                throw new ArgumentNullException(nameof(award));

            var awardName = "Award_" + award.Id + ".json";

            var awardStr = JsonConvert.SerializeObject(award);

            using (var writer = new StreamWriter(DataPath + awardName))
                writer.Write(awardStr);
        }

        public void DeleteAwardById(Guid id)
        {
            var fileName = "Award_" + id + ".json";
            var pathToFile = DataPath + fileName;
            File.Delete(pathToFile);
        }

        public IEnumerable<AwardEntity> GetAllAwards()
        {
            var directory = new DirectoryInfo(DataPath);

            foreach (var file in directory.GetFiles())
                using (var reader = new StreamReader(file.FullName))
                    yield return JsonConvert.DeserializeObject<AwardEntity>(reader.ReadToEnd());
        }

        public void UpdateAward(AwardEntity award)
        {
            var oldAward = GetAwardById(award.Id);

            if (oldAward == null)
            {
                CreateNewAward(award);
            }
            else
            {
                DeleteAwardById(oldAward.Id);
                CreateNewAward(award);
            }
        }

        public AwardEntity GetAwardById(Guid id)
        {
            return GetAllAwards().FirstOrDefault(n => n.Id == id);
        }
    }
}
