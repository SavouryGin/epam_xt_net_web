using Common.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Contracts
{
    public interface INexusesRepository
    {
        void SaveNexus(Nexus nexus);
        
        Nexus GetNexusById(Guid id);

        bool UpdateNexus(Nexus nexus);

        bool DeleteNexusById(Guid id);

        bool DeleteNexusById(IEnumerable<Guid> ids);

        IEnumerable<Nexus> GetAllNexuses();
    }
}
