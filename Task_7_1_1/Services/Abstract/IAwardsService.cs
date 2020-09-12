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
        void CreateNewAward(Award award);

        void UpdateAward(Award award);

        Award GetAwardById(Guid id);

        void DeleteAwardById(Guid id);
    }
}
