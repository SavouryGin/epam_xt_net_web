using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface INexusesRepository
    {
        void SaveNexus(Nexus nexus);

        bool DeleteNexusById(Guid id);

        bool DeleteNexusById(IEnumerable<Guid> ids);

        IEnumerable<Nexus> GetAllNexuses();
    }
}
