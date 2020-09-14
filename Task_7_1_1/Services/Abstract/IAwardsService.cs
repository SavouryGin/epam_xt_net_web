using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IAwardsService
    {
        void SaveAllChanges();

        void SaveAwardToRepository(Award award);

        void AddAward(Award award);

        void UpdateAward(Award award);

        Award GetAwardById(Guid id);

        void DeleteAwardById(Guid id);
    }
}
