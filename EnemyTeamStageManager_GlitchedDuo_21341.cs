using CustomMapUtility;

namespace GlitchedDuo_21341
{
    public class EnemyTeamStageManager_GlitchedDuo_21341 : EnemyTeamStageManager
    {
        public override void OnWaveStart()
        {
            CustomMapHandler.InitCustomMap<GlitchedDuo_21341MapManager>("GlitchedDuo_21341", false, true, 0.5f, 0.55f);
            CustomMapHandler.EnforceMap();
            Singleton<StageController>.Instance.CheckMapChange();
        }

        public override void OnRoundStart()
        {
            CustomMapHandler.EnforceMap();
        }
    }
}