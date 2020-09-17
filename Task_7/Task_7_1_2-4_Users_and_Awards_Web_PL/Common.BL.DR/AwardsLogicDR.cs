using BLL.Contracts;
using BLL.Logic;

namespace Common.BL.DR
{
    public static class AwardsLogicDR
    {
        private static IAwardsLogic logic;

        public static IAwardsLogic AwardsBLL => logic ?? (logic = new AwardsLogic());
    }
}
