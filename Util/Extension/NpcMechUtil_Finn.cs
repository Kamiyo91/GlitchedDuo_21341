using GlitchedDuo_21341.Buffs;
using KamiyoStaticBLL.MechUtilBaseModels;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.BaseClass;

namespace GlitchedDuo_21341.Util.Extension
{
    public class NpcMechUtil_Finn : NpcMechUtilBase
    {
        private readonly NpcMechUtilBaseModel _model;

        public NpcMechUtil_Finn(NpcMechUtilBaseModel model) : base(model)
        {
            _model = model;
        }

        public virtual void ChangeToEgoMap(LorId cardId)
        {
            if (cardId != _model.EgoAttackCardId ||
                SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject.isEgo) return;
            _model.MapUsed = true;
            MapUtil.ChangeMap(new MapModel
            {
                Stage = _model.EgoMapName,
                StageIds = _model.OriginalMapStageIds,
                OneTurnEgo = true,
                IsPlayer = true,
                Component = _model.EgoMapType,
                Bgy = _model.BgY ?? 0.5f,
                Fy = _model.FlY ?? 407.5f / 1080f
            });
        }

        public void CheckPhase()
        {
            if (_model.Owner.hp > _model.MechHp || _model.Phase > 0) return;
            _model.Phase++;
            ForcedEgo();
            SetMassAttack(true);
            SetCounter(_model.MaxCounter);
        }

        public virtual void ReturnFromEgoMap()
        {
            if (!_model.MapUsed) return;
            _model.MapUsed = false;
            MapUtil.ReturnFromEgoMap(_model.EgoMapName, _model.OriginalMapStageIds);
        }

        public override void OnSelectCardPutMassAttack(ref BattleDiceCardModel origin)
        {
            if (!BattleObjectManager.instance.GetAliveList()
                    .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>())) return;
            if (!_model.MassAttackStartCount || _model.Counter < _model.MaxCounter || _model.OneTurnCard)
                return;
            origin = BattleDiceCardModel.CreatePlayingCard(
                ItemXmlDataList.instance.GetCardItem(_model.LorIdEgoMassAttack));
            SetOneTurnCard(true);
        }
    }
}