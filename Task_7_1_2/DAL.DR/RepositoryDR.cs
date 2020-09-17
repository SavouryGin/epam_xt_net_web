using DAL.Contracts;
using DAL.Memory;

namespace DAL.DR
{
    public static class RepositoryDR
    {
        private static IAwardedUsersRepository _repo;

        public static IAwardedUsersRepository AwardedUsersMemory => _repo ?? (_repo = new AwardedUsersRepositoryJSON());
    }
}
