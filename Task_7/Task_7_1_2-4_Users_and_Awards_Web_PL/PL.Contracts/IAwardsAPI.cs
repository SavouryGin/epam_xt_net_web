using Common.Entities;
using System;
using System.Collections.Generic;

namespace PL.Contracts
{
    public interface IAwardsAPI
    {
        void AddAward(Award award);

        Award GetAwardById(Guid id);

        void UpdateAwardById(Guid id, Award award);

        void DeleteAwardById(Guid id);

        IEnumerable<User> GetAwardedUsers(Guid awardId);

        IEnumerable<Award> GetAllAwards();
    }
}
