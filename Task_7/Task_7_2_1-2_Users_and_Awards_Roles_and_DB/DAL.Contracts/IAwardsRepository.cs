using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IAwardsRepository
    {
        void SaveAward(Award award);

        Award GetAwardById(Guid id);

        Award GetAwardByTitle(string title);

        bool UpdateAward(Award award);

        bool DeleteAwardById(Guid id);

        IEnumerable<Award> GetAllAwards();

        IEnumerable<User> GetAwardedUsers(Guid Id);
    }
}
