using System.Linq;

namespace GlitchedDuo_21341.Passives
{
    public class PassiveAbility_CorruptedFriendship_21341 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            foreach (var battleDiceCardModel in owner.allyCardDetail.GetAllDeck()
                         .Where(x => x.GetOriginCost() == 4))
            {
                battleDiceCardModel.GetBufList();
                battleDiceCardModel.AddCost(-2);
            }
        }
    }
}