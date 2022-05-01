using System.Linq;
using GlitchedDuo_21341.Passives;

namespace GlitchedDuo_21341.Cards
{
    public class DiceCardSelfAbility_GlitchedSwordSlash_21341 : DiceCardSelfAbilityBase
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
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
            if (!(owner.passiveDetail.PassiveList.FirstOrDefault(x => x is PassiveAbility_BestDuo_21341) is
                    PassiveAbility_BestDuo_21341 passive) || !passive.GetBuffStatus()) return;
            owner.allyCardDetail.DrawCards(1);
            foreach (var battleDiceCardModel in owner.allyCardDetail.GetAllDeck()
                         .FindAll(x => x != card.card && x.GetID() == card.card.GetID()))
            {
                battleDiceCardModel.GetBufList();
                battleDiceCardModel.AddCost(-1);
            }
        }
    }
}