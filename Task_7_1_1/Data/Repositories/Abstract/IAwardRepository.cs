using System;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IAwardRepository
    {
        void AddAward(AwardEntity award);

        void UpdateAward(AwardEntity award);

        AwardEntity GetAwardById(Guid id);

        void DeleteAwardById(int id);
    }
}
