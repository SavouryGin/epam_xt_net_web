using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
