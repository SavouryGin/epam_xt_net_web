using DAL.Contracts;
using DAL.Memory;

namespace Common.DAL.DR
{
    public static class AwardsRepoDR
    {
        private static IAwardsRepository repo;

        public static IAwardsRepository AwardsMemory => repo ?? (repo = new AwardsRepository());
    }
}
