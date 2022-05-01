using System.Linq;
using GlitchedDuo_21341.Passives;

namespace GlitchedDuo_21341.Cards
{
    public class DiceCardSelfAbility_FightMe_21341 : DiceCardSelfAbilityBase
    {
        public override string[] Keywords
        {
            get
            {
                return new[]
                {
                    "BestDuoPage_21341"
                };
            }
        }
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            if (!(owner.passiveDetail.PassiveList.FirstOrDefault(x => x is PassiveAbility_BestDuo_21341) is
                    PassiveAbility_BestDuo_21341 passive) || !passive.GetBuffStatus()) return;
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                dmgRate = 10
            });
        }
    }
}