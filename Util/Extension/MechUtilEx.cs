﻿using KamiyoStaticBLL.MechUtilBaseModels;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.BaseClass;

namespace GlitchedDuo_21341.Util.Extension
{
    public class MechUtilEx : MechUtilBase
    {
        private readonly MechUtilBaseModel _model;

        public MechUtilEx(MechUtilBaseModel model) : base(model)
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

        public virtual void ReturnFromEgoMap()
        {
            if (!_model.MapUsed) return;
            _model.MapUsed = false;
            MapUtil.ReturnFromEgoMap(_model.EgoMapName, _model.OriginalMapStageIds);
        }
    }
}