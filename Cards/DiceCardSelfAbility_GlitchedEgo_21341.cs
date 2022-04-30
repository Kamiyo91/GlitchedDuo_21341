using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlitchedDuo_21341.Cards
{
    public class DiceCardSelfAbility_GlitchedEgo_21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner) => owner.emotionDetail.EmotionLevel > 2;
    }
}
