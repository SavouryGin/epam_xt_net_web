using BLL.Contracts;
using Common.DAL.DR;
using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Logic
{
    public class AwardsLogic : IAwardsLogic
    {
        private readonly IAwardsRepository _awardsRepo = AwardsRepoDR.AwardsMemory;
        private readonly INexusesRepository _nexusesRepo = NexusesRepoDR.NexusesMemory;

        public void AddAward(Award award) => _awardsRepo.SaveAward(award);

        public Award GetAwardById(Guid id) => _awardsRepo.GetAwardById(id);

        public IEnumerable<Award> GetAllAwards() => _awardsRepo.GetAllAwards();

        public IEnumerable<User> GetAwardedUsers(Guid awardId) => _awardsRepo.GetAwardedUsers(awardId);

        public bool UpdateAwardById(Guid id, Award award)
        {
            var awards = GetAllAwards();

            if (!awards.Where(awrd => awrd.Id == id).Any())
                return false;

            award.Id = id;
            _awardsRepo.UpdateAward(award);

            return true;
        }

        public void DeleteAwardById(Guid id)
        {
            var nexusId = _nexusesRepo.GetAllNexuses().Where(nexus => nexus.AwardId == id).Select(nexus => nexus.Id);

            _nexusesRepo.DeleteNexusById(nexusId);
            _awardsRepo.DeleteAwardById(id);
        }
    }
}
