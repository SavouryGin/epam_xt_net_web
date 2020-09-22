using Common.Entities;
using System;
using System.Collections.Generic;

namespace PL.Contracts
{
    public interface IAwardsAPI
    {
        AwardStatus AddAward(Award award);

        AwardStatus CheckAward(Award award);

        bool UpdateAwardById(Guid id, Award award);

        Award GetAwardById(Guid id);

        void DeleteAwardById(Guid id);

        IEnumerable<Award> GetAllAwards();

        IEnumerable<User> GetAwardedUsers(Guid awardId);
    }
}
