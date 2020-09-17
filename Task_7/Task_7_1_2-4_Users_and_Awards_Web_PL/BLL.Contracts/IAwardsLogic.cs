using Common.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IAwardsLogic
    {
        void AddAward(Award award);

        bool UpdateAwardById(Guid id, Award award);

        Award GetAwardById(Guid id);

        void DeleteAwardById(Guid id);

        IEnumerable<Award> GetAllAwards();

        IEnumerable<User> GetAwardedUsers(Guid awardId);
    }
}
