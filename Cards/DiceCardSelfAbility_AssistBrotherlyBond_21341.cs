using System.Linq;
using GlitchedDuo_21341.Passives;

namespace GlitchedDuo_21341.Cards
{
    public class DiceCardSelfAbility_AssistBrotherlyBond_21341 : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new[]
                {
                    "BrotherDuoPage_21341"
                };
            }
        }

        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            if (BattleObjectManager.instance.GetAliveList(owner.faction)
                    .Count(x => x.passiveDetail.HasPassive<PassiveAbility_BestDuo_21341>()) < 2) return;
            foreach (var unit in BattleObjectManager.instance.GetAliveList(owner.faction))
                unit.allyCardDetail.DrawCards(1);
            var dice = card.card.CreateDiceCardBehaviorList().FirstOrDefault();
            card.AddDice(dice);
        }
    }
}