using System.Linq;
using KamiyoStaticUtil.Utils;

namespace GlitchedDuo_21341.Util
{
    public static class MatchUtil
    {
        public static int SupportUnitIgnore(BattleUnitModel owner)
        {
            return BattleObjectManager.instance
                .GetAliveList(UnitUtil.ReturnOtherSideFaction(owner.faction)).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y =>
                        y.id == new LorId("LorModPackRe21341.Mod", 57) ||
                        y.id == new LorId("LorModPackRe21341.Mod", 54)));
        }
    }
}