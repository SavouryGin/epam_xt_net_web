using Common.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Contracts
{
    public interface IAwardsRepository
    {
        void SaveAward(Award award);

        Award GetAwardById(Guid id);

        bool UpdateAward(Award award);

        bool DeleteAwardById(Guid id);

        IEnumerable<Award> GetAllAwards();

        IEnumerable<User> GetAwardedUsers(Guid Id);
    }
}
