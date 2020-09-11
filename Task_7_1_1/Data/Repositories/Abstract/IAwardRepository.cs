using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IAwardRepository
    {
        void AddAward(AwardEntity award);

        void UpdateAward(AwardEntity award);

        IEnumerable<AwardEntity> GetAllAwards();

        void DeleteAwardById(int id);
    }
}
