using DAL.Contracts;
using DAL.Memory;

namespace Common.DAL.DR
{
    public static class NexusesRepoDR
    {
        private static INexusesRepository repo;

        public static INexusesRepository NexusesMemory => repo ?? (repo = new NexusesRepository());
    }
}
