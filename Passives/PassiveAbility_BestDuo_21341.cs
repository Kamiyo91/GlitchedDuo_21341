using GlitchedDuo_21341.Util;

namespace GlitchedDuo_21341.Passives
{
    public class PassiveAbility_BestDuo_21341 : PassiveAbilityBase
    {
        private bool _buffActive;
        private int _memberCount;

        public override void OnWaveStart()
        {
            _memberCount = MatchUtil.SupportUnitIgnore(owner);
            switch (_memberCount)
            {
                case 1:
                    owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Weak, 1);
                    owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Disarm, 1);
                    _buffActive = false;
                    break;
                case 2:
                    owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
                    owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1);
                    _buffActive = true;
                    break;
                default:
                    _buffActive = false;
                    break;
            }
        }

        public override void OnRoundEnd()
        {
            _memberCount = MatchUtil.SupportUnitIgnore(owner);
            switch (_memberCount)
            {
                case 1:
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Weak, 1);
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Disarm, 1);
                    _buffActive = false;
                    break;
                case 2:
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1);
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 1);
                    _buffActive = true;
                    break;
                default:
                    _buffActive = false;
                    break;
            }
        }

        public bool GetBuffStatus()
        {
            return _buffActive;
        }
    }
}