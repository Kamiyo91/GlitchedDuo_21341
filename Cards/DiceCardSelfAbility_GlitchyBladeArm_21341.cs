using System.Linq;
using GlitchedDuo_21341.Passives;

namespace GlitchedDuo_21341.Cards
{
    public class DiceCardSelfAbility_GlitchyBladeArm_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            if (!(owner.passiveDetail.PassiveList.FirstOrDefault(x => x is PassiveAbility_BestDuo_21341) is
                    PassiveAbility_BestDuo_21341 passive) || !passive.GetBuffStatus()) return;
            var dice = card.card.CreateDiceCardBehaviorList().FirstOrDefault();
            card.AddDice(dice);
            card.AddDice(dice);
        }
    }
}