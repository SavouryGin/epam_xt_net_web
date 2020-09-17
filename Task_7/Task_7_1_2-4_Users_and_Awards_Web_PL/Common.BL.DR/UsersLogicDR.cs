using BLL.Contracts;
using BLL.Logic;

namespace Common.BL.DR
{
    public static class UsersLogicDR
    {
        private static IUsersLogic logic;

        public static IUsersLogic UsersBLL => logic ?? (logic = new UsersLogic());
    }
}
