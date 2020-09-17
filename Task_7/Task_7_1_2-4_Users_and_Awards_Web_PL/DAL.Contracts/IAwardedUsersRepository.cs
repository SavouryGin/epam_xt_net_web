using Common.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Contracts
{
    public interface IAwardedUsersRepository
    {
        void SaveUser(User user);

        void SaveAward(Award award);

        void SaveNexus(Nexus nexus);

        User GetUserById(Guid id);

        Award GetAwardById(Guid id);

        Nexus GetNexusById(Guid id);

        bool UpdateUser(User user);

        bool UpdateAward(Award award);

        bool UpdateNexus(Nexus nexus);

        bool DeleteUserById(Guid id);

        bool DeleteAwardById(Guid id);

        bool DeleteNexusById(Guid id);

        bool DeleteNexusById(IEnumerable<Guid> ids);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetAllAwards();

        IEnumerable<Nexus> GetAllNexuses();

        IEnumerable<Award> GetUserAwards(Guid Id);

        IEnumerable<User> GetAwardedUsers(Guid Id);
    }
}
