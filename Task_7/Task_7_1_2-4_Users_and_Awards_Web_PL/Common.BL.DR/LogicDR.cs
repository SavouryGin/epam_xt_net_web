using BLL.Contracts;
using BLL.Logic;

namespace Common.BL.DR
{
    public static class LogicDR
    {
        private static IAwardedUsersLogic _logic;

        public static IAwardedUsersLogic UserAwardsBLL => _logic ?? (_logic = new AwardedUsersLogic());
    }
}
