using System.Collections.Generic;
using System.Linq;
using GlitchedDuo_21341.Buffs;
using GlitchedDuo_21341.Util.Extension;
using KamiyoStaticBLL.Enums;
using KamiyoStaticBLL.MechUtilBaseModels;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.Utils;
using LOR_XML;

namespace GlitchedDuo_21341.Passives
{
    public class PassiveAbility_GlitchedJakeNpc_21341 : PassiveAbilityBase
    {
        private bool _filterCheck;
        private NpcMechUtil_Jake _util;

        public override void OnWaveStart()
        {
            _util = new NpcMechUtil_Jake(new NpcMechUtilBaseModel
            {
                Owner = owner,
                Hp = 0,
                SetHp = 78,
                MechHp = 161,
                Survive = true,
                HasEgo = true,
                HasMechOnHp = true,
                RecoverLightOnSurvive = true,
                RefreshUI = true,
                EgoType = typeof(BattleUnitBuf_GlitchedJakeEgo_21341),
                HasEgoAbDialog = true,
                HasSurviveAbDialog = true,
                SurviveAbDialogColor = AbColorType.Negative,
                EgoAbColorColor = AbColorType.Negative,
                SurviveAbDialogList = new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "Jake",
                        dialog = ModParameters.EffectTexts.FirstOrDefault(x => x.Key.Equals("JakeSurvive1_21341"))
                            .Value.Desc
                    }
                },
                EgoAbDialogList = new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "Jake",
                        dialog = ModParameters.EffectTexts.FirstOrDefault(x => x.Key.Equals("JakeEgoActive1_21341"))
                            .Value.Desc
                    }
                }
            });
            if (owner.hp <= 161) _util.CheckPhase();
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
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>()) return;
            _filterCheck = true;
            MapStaticUtil.ActiveCreatureBattleCamFilterComponent();
        }

        public override void OnRoundEndTheLast()
        {
            _util.CheckPhase();
        }

        public override void OnRoundEndTheLast_ignoreDead()
        {
            if (!owner.IsDead() || !_filterCheck) return;
            _filterCheck = false;
            MapStaticUtil.ActiveCreatureBattleCamFilterComponent(false);
        }
    }
}