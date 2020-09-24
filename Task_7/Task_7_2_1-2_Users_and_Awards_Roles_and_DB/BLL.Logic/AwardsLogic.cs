using BLL.Contracts;
using Common.DAL.DR;
using Common.Entities;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BLL.Logic
{
    public class AwardsLogic : IAwardsLogic
    {
        private readonly IAwardsRepository _awardsRepo = AwardsRepoDR.AwardsMemory;
        private readonly INexusesRepository _nexusesRepo = NexusesRepoDR.NexusesMemory;

        public AwardStatus CheckAward(Award award)
        {
            string titlePattern = @"[a-zA-Zа-яА-ЯёЁ0-9_\-\s]{3,25}";

            if (!Regex.IsMatch(award.Title, titlePattern))
            {
                return AwardStatus.InvalidTitle;
            }

            return _awardsRepo.GetAwardByTitle(award.Title) != null ? AwardStatus.Exists : AwardStatus.Verified;
        }

        public AwardStatus AddAward(Award award)
        {
            AwardStatus res = CheckAward(award);

            if (res == AwardStatus.Verified)
            {
                _awardsRepo.SaveAward(award);
            }

            return res;
        }

        public bool UpdateAwardById(Guid id, Award award)
        {
            var awards = GetAllAwards();

            if (!awards.Where(_award => _award.Id == id).Any())
            {
                return false;
            }

            award.Id = id;
            _awardsRepo.UpdateAward(award);

            return true;
        }

        public void DeleteAwardById(Guid id)
        {
            var nexuses = _nexusesRepo.GetAllNexuses().Where(nexus => nexus.AwardId == id).Select(nexus => nexus.Id);

            _nexusesRepo.DeleteNexusById(nexuses);
            _awardsRepo.DeleteAwardById(id);
        }

        public IEnumerable<Award> GetAllAwards() => _awardsRepo.GetAllAwards();

        public Award GetAwardById(Guid id) => _awardsRepo.GetAwardById(id);

        public IEnumerable<User> GetAwardedUsers(Guid awardId) => _awardsRepo.GetAwardedUsers(awardId);
       
    }
}
