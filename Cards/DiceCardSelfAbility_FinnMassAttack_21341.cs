using GlitchedDuo_21341.Buffs;

namespace GlitchedDuo_21341.Cards
{
    public class DiceCardSelfAbility_FinnMassAttack_21341 : DiceCardSelfAbilityBase
    {
        private bool _motionChanged;

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return BattleObjectManager.instance.GetAliveList()
                .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>());
        }

        public override void OnEndAreaAttack()
        {
            if (!_motionChanged) return;
            _motionChanged = false;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
        }

        public override void OnApplyCard()
        {
            if (!string.IsNullOrEmpty(owner.UnitData.unitData.workshopSkin) ||
                owner.UnitData.unitData.bookItem != owner.UnitData.unitData.CustomBookItem) return;
            _motionChanged = true;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Aim);
        }

        public override void OnReleaseCard()
        {
            _motionChanged = false;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
        }
    }
}