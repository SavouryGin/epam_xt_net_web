using System;
using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IAwardsRepository
    {
        void CreateNewAward(AwardEntity award);

        void UpdateAward(AwardEntity award);

        AwardEntity GetAwardById(Guid id);

        void DeleteAwardById(Guid id);

        IEnumerable<AwardEntity> GetAllAwards();
    }
}
