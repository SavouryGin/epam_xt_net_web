using Data.Repositories.Abstract;
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

        public void DeleteAwardById(int id)
        {
            // TODO: DeleteAwardById
            throw new NotImplementedException();
        }

        public IEnumerable<AwardEntity> GetAllAwards()
        {
            // TODO: GetAllAwards
            throw new NotImplementedException();
        }

        public void UpdateAward(AwardEntity award)
        {
            // TODO: UpdateAward
            throw new NotImplementedException();
        }

        public AwardEntity GetAwardById(Guid id)
        {
            return GetAllAwards().FirstOrDefault(n => n.Id == id);
        }
    }
}
