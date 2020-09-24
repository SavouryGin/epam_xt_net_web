using BLL.Contracts;
using Common.BLL.DR;
using System;
using System.Web.Security;

namespace PL.Web.API
{
    public class MyRoleProvider : RoleProvider
    {
        private readonly IUsersLogic _logic = UsersLogicDR.UsersBLL;

        public override string[] GetRolesForUser(string username) => _logic.GetUserRoles(username);

        public override bool IsUserInRole(string username, string roleName) => _logic.IsInRole(username, roleName);

        #region NotImplemented
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}