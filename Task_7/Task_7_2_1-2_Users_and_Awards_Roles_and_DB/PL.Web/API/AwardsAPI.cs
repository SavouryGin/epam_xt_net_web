using BLL.Contracts;
using Common.BLL.DR;
using Common.Entities;
using PL.Contracts;
using System;
using System.Collections.Generic;

namespace PL.Web.API
{
    public class AwardsAPI : IAwardsAPI
    {
        private readonly IAwardsLogic _logic = AwardsLogicDR.AwardsBLL;

        public AwardStatus AddAward(Award award) => _logic.AddAward(award);

        public AwardStatus CheckAward(Award award) => _logic.CheckAward(award);

        public void DeleteAwardById(Guid id) => _logic.DeleteAwardById(id);

        public IEnumerable<Award> GetAllAwards() => _logic.GetAllAwards();

        public Award GetAwardById(Guid id) => _logic.GetAwardById(id);

        public IEnumerable<User> GetAwardedUsers(Guid awardId) => _logic.GetAwardedUsers(awardId);

        public bool UpdateAwardById(Guid id, Award award) => _logic.UpdateAwardById(id, award);
    }
}