using System.Collections.Generic;
using System.Linq;
using GlitchedDuo_21341.BLL;
using GlitchedDuo_21341.Buffs;
using KamiyoStaticBLL.Enums;
using KamiyoStaticBLL.MechUtilBaseModels;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.BaseClass;
using KamiyoStaticUtil.Utils;
using LOR_XML;

namespace GlitchedDuo_21341.Passives
{
    public class PassiveAbility_GlitchedJake_21341 : PassiveAbilityBase
    {
        private MechUtilBase _util;

        public override void OnWaveStart()
        {
            _util = new MechUtilBase(new MechUtilBaseModel
            {
                Owner = owner,
                Hp = 0,
                SetHp = 31,
                Survive = true,
                HasEgo = true,
                RefreshUI = true,
                RecoverLightOnSurvive = false,
                EgoType = typeof(BattleUnitBuf_GlitchedJakeEgo_21341),
                EgoCardId = new LorId(GlitchedDuoModParameters.PackageId, 4),
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
        }

        public override void OnRoundStartAfter()
        {
            if (owner.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>())
                MapStaticUtil.ActiveCreatureBattleCamFilterComponent();
        }
    }
}