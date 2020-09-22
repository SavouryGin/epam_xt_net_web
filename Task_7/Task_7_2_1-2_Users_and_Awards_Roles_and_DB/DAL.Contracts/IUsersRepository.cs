using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUsersRepository
    {
        void SaveUser(User user);

        User GetUserById(Guid id);

        User GetUserByName(string name);

        bool UpdateUser(User user);

        bool DeleteUserById(Guid id);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetUserAwards(Guid Id);

        // New methods for the Role Model
        bool IsRegistered(string name, string password);

        bool IsInRole(string name, string role);

        string[] GetUserRoles(string name);

        bool SetPassword(Guid id, string password);
    }
}
