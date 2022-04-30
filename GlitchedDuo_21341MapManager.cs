using CustomMapUtility;
using UnityEngine;

namespace GlitchedDuo_21341
{
    public class GlitchedDuo_21341MapManager : CustomMapManager
    {
        protected internal override string[] CustomBGMs => new[] { "GlitchedDuo21341.ogg" };

        public override void EnableMap(bool b)
        {
            sephirahColor = Color.black;
            base.EnableMap(b);
        }
    }
}