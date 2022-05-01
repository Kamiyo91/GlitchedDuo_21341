namespace GlitchedDuo_21341.Cards
{
    public class DiceCardSelfAbility_GlitchedEgo_21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.emotionDetail.EmotionLevel > 2;
        }
    }
}