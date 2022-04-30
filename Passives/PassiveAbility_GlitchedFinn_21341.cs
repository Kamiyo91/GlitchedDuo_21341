﻿using System.Collections.Generic;
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
    public class PassiveAbility_GlitchedFinn_21341 : PassiveAbilityBase
    {
        private MechUtilBase _util;

        public override void OnWaveStart()
        {
            _util = new MechUtilBase(new MechUtilBaseModel
            {
                Owner = owner,
                Hp = 0,
                SetHp = 41,
                Survive = true,
                HasEgo = true,
                RefreshUI = true,
                RecoverLightOnSurvive = false,
                EgoType = typeof(BattleUnitBuf_GlitchedFinnEgo_21341),
                EgoCardId = new LorId(GlitchedDuoModParameters.PackageId, 9),
                HasEgoAbDialog = true,
                HasSurviveAbDialog = true,
                SurviveAbDialogColor = AbColorType.Negative,
                EgoAbColorColor = AbColorType.Negative,
                SurviveAbDialogList = new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "Finn",
                        dialog = ModParameters.EffectTexts.FirstOrDefault(x => x.Key.Equals("FinnSurvive1_Re21341"))
                            .Value.Desc
                    }
                },
                EgoAbDialogList = new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "Finn",
                        dialog = ModParameters.EffectTexts.FirstOrDefault(x => x.Key.Equals("FinnEgoActive1_Re21341"))
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
            if (owner.bufListDetail.HasBuf<BattleUnitBuf_GlitchedFinnEgo_21341>())
                MapStaticUtil.ActiveCreatureBattleCamFilterComponent();
        }
    }
}