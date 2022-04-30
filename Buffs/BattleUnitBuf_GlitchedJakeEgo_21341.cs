namespace GlitchedDuo_21341.Buffs
{
    public class BattleUnitBuf_GlitchedJakeEgo_21341 : BattleUnitBuf
    {
        public BattleUnitBuf_GlitchedJakeEgo_21341()
        {
            stack = 0;
        }

        public override bool isAssimilation => true;
        public override int paramInBufDesc => 0;
        protected override string keywordId => "JakeEgo_21341";
        protected override string keywordIconId => "JakeEgo_21341";

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        public override void OnRoundEnd()
        {
            if (BattleObjectManager.instance.GetAliveList(_owner.faction)
                .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedFinnEgo_21341>()))
                _owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 3);
        }
    }
}