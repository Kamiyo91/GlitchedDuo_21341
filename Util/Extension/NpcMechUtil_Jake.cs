using KamiyoStaticBLL.MechUtilBaseModels;
using KamiyoStaticUtil.BaseClass;

namespace GlitchedDuo_21341.Util.Extension
{
    public class NpcMechUtil_Jake : NpcMechUtilBase
    {
        private readonly NpcMechUtilBaseModel _model;

        public NpcMechUtil_Jake(NpcMechUtilBaseModel model) : base(model)
        {
            _model = model;
        }

        public void CheckPhase()
        {
            if (_model.Owner.hp > _model.MechHp || _model.Phase > 0) return;
            _model.Phase++;
            ForcedEgo();
        }
    }
}