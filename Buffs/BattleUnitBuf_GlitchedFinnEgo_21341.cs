using LOR_DiceSystem;

namespace GlitchedDuo_21341.Buffs
{
    public class BattleUnitBuf_GlitchedFinnEgo_21341 : BattleUnitBuf
    {
        public BattleUnitBuf_GlitchedFinnEgo_21341()
        {
            stack = 0;
        }

        public override bool isAssimilation => true;
        public override int paramInBufDesc => 0;
        protected override string keywordId => "FinnEgo_21341";
        protected override string keywordIconId => "FinnEgo_21341";

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        public override AtkResist GetResistBP(AtkResist origin, BehaviourDetail detail)
        {
            return BattleObjectManager.instance.GetAliveList(_owner.faction)
                .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>())
                ? AtkResist.Endure
                : AtkResist.Normal;
        }

        public override AtkResist GetResistHP(AtkResist origin, BehaviourDetail detail)
        {
            return BattleObjectManager.instance.GetAliveList(_owner.faction)
                .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>())
                ? AtkResist.Endure
                : AtkResist.Normal;
        }
    }
}