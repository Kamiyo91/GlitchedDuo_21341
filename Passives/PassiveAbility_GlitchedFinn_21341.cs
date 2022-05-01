using System.Collections.Generic;
using System.Linq;
using GlitchedDuo_21341.BLL;
using GlitchedDuo_21341.Buffs;
using GlitchedDuo_21341.Util.Extension;
using KamiyoStaticBLL.Enums;
using KamiyoStaticBLL.MechUtilBaseModels;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.Utils;
using LOR_XML;

namespace GlitchedDuo_21341.Passives
{
    public class PassiveAbility_GlitchedFinn_21341 : PassiveAbilityBase
    {
        private MechUtilEx _util;
        private bool _filterCheck;
        public override void OnWaveStart()
        {
            _util = new MechUtilEx(new MechUtilBaseModel
            {
                Owner = owner,
                Hp = 0,
                SetHp = 41,
                Survive = true,
                HasEgo = true,
                HasEgoAttack = true,
                RecoverLightOnSurvive = false,
                EgoType = typeof(BattleUnitBuf_GlitchedFinnEgo_21341),
                EgoCardId = new LorId(GlitchedDuoModParameters.PackageId, 4),
                EgoAttackCardId = new LorId(GlitchedDuoModParameters.PackageId, 13),
                HasEgoAbDialog = true,
                HasSurviveAbDialog = true,
                SurviveAbDialogColor = AbColorType.Negative,
                EgoAbColorColor = AbColorType.Negative,
                SurviveAbDialogList = new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "Finn",
                        dialog = ModParameters.EffectTexts.FirstOrDefault(x => x.Key.Equals("FinnSurvive1_21341"))
                            .Value.Desc
                    }
                },
                EgoMapName = "GlitchedDuo_21341",
                EgoMapType = typeof(GlitchedDuo_21341MapManager),
                BgY = 0.55f,
                OriginalMapStageIds = new List<LorId>
                {
                    new LorId(GlitchedDuoModParameters.PackageId, 1)
                },
                EgoAbDialogList = new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "Finn",
                        dialog = ModParameters.EffectTexts.FirstOrDefault(x => x.Key.Equals("FinnEgoActive1_21341"))
                            .Value.Desc
                    }
                }
            });
            UnitUtil.CheckSkinProjection(owner);
        }

        public override bool BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            _util.SurviveCheck(dmg);
            return base.BeforeTakeDamage(attacker, dmg);
        }

        public override void OnStartBattle()
        {
            UnitUtil.RemoveImmortalBuff(owner);
        }

        public override void OnRoundStart()
        {
            if (!_util.EgoCheck()) return;
            _util.EgoActive();
        }

        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            _util.OnUseExpireCard(curCard.card.GetID());
            _util.ChangeToEgoMap(curCard.card.GetID());
        }

        public override void OnRoundStartAfter()
        {
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_GlitchedFinnEgo_21341>()) return;
            _filterCheck = true;
            MapStaticUtil.ActiveCreatureBattleCamFilterComponent();
        }

        public override void OnRoundEndTheLast_ignoreDead()
        {
            _util.ReturnFromEgoMap();
            if (!owner.IsDead() || !_filterCheck) return;
            _filterCheck = false;
            MapStaticUtil.ActiveCreatureBattleCamFilterComponent(false);
        }
    }
}