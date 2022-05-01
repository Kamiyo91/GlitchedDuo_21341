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
    public class PassiveAbility_GlitchedFinnNpc_21341 : PassiveAbilityBase
    {
        private NpcMechUtil_Finn _util;
        private bool _filterCheck;
        public override void OnWaveStart()
        {
            _util = new NpcMechUtil_Finn(new NpcMechUtilBaseModel
            {
                Owner = owner,
                Hp = 0,
                SetHp = 98,
                MechHp = 171,
                Counter = 0,
                MaxCounter = 4,
                Survive = true,
                HasEgo = true,
                HasMechOnHp = true,
                RecoverLightOnSurvive = true,
                RefreshUI = true,
                EgoType = typeof(BattleUnitBuf_GlitchedFinnEgo_21341),
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
                },
                LorIdEgoMassAttack = new LorId(GlitchedDuoModParameters.PackageId, 14),
                EgoAttackCardId = new LorId(GlitchedDuoModParameters.PackageId, 14)
            });
        }

        public override int SpeedDiceNumAdder()
        {
            return 2;
        }

        public override bool BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            _util.MechHpCheck(dmg);
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

        public override BattleDiceCardModel OnSelectCardAuto(BattleDiceCardModel origin, int currentDiceSlotIdx)
        {
            _util.OnSelectCardPutMassAttack(ref origin);
            return base.OnSelectCardAuto(origin, currentDiceSlotIdx);
        }

        public override void OnRoundEnd()
        {
            _util.ExhaustEgoAttackCards();
            _util.SetOneTurnCard(false);
            _util.RaiseCounter();
        }

        public override void OnRoundEndTheLast()
        {
            _util.CheckPhase();
        }

        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            _util.OnUseCardResetCount(curCard);
            _util.ChangeToEgoMap(curCard.card.GetID());
        }
    }
}