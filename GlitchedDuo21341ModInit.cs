using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GlitchedDuo_21341.BLL;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.Utils;
using MonoMod.Utils;

namespace GlitchedDuo_21341
{
    public class GlitchedDuo21341ModInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            InitParameters();
            MapStaticUtil.GetArtWorks(new DirectoryInfo(GlitchedDuoModParameters.Path + "/ArtWork"));
            UnitUtil.ChangeCardItem(ItemXmlDataList.instance, GlitchedDuoModParameters.PackageId);
            UnitUtil.ChangePassiveItem(GlitchedDuoModParameters.PackageId);
            SkinUtil.LoadBookSkinsExtra(GlitchedDuoModParameters.PackageId);
            LocalizeUtil.AddLocalLocalize(GlitchedDuoModParameters.Path, GlitchedDuoModParameters.PackageId);
            SkinUtil.PreLoadBufIcons();
            LocalizeUtil.RemoveError();
        }

        private static void InitParameters()
        {
            ModParameters.PackageIds.Add(GlitchedDuoModParameters.PackageId);
            GlitchedDuoModParameters.Path =
                Path.GetDirectoryName(
                    Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(GlitchedDuoModParameters.Path);
            ModParameters.Language = GlobalGameManager.Instance.CurrentOption.language;
            ModParameters.SpritePreviewChange.AddRange(new Dictionary<string, List<LorId>>
            {
                { "FinnDefault_21341", new List<LorId> { new LorId(GlitchedDuoModParameters.PackageId, 10000001) } },
                { "JakeDefault_21341", new List<LorId> { new LorId(GlitchedDuoModParameters.PackageId, 10000002) } }
            });
            ModParameters.BooksIds.AddRange(new List<LorId>
            {
                new LorId(GlitchedDuoModParameters.PackageId, 10000001),
                new LorId(GlitchedDuoModParameters.PackageId, 10000002)
            });
            ModParameters.OnlyCardKeywords.AddRange(new List<Tuple<List<string>, List<LorId>, LorId>>
            {
                new Tuple<List<string>, List<LorId>, LorId>(new List<string> { "GlitchedFinnPage_21341" },
                    new List<LorId> { new LorId(GlitchedDuoModParameters.PackageId, 5) },
                    new LorId(GlitchedDuoModParameters.PackageId, 10000001)),
                new Tuple<List<string>, List<LorId>, LorId>(new List<string> { "GlitchedJakePage_21341" },
                    new List<LorId> { new LorId(GlitchedDuoModParameters.PackageId, 12) },
                    new LorId(GlitchedDuoModParameters.PackageId, 10000002))
            });
            ModParameters.UntransferablePassives.AddRange(new List<LorId>
            {
                new LorId(GlitchedDuoModParameters.PackageId, 2), new LorId(GlitchedDuoModParameters.PackageId, 3)
            });
            ModParameters.PersonalCardList.AddRange(new List<LorId>
            {
                new LorId(GlitchedDuoModParameters.PackageId, 4)
            });
            ModParameters.EgoPersonalCardList.AddRange(new List<LorId>
            {
                new LorId(GlitchedDuoModParameters.PackageId, 13)
            });
            ModParameters.DynamicNames.AddRange(new Dictionary<LorId, LorId>
            {
                {
                    new LorId(GlitchedDuoModParameters.PackageId, 10000001),
                    new LorId(GlitchedDuoModParameters.PackageId, 1)
                },
                {
                    new LorId(GlitchedDuoModParameters.PackageId, 10000002),
                    new LorId(GlitchedDuoModParameters.PackageId, 2)
                }
            });
            ModParameters.DefaultKeyword.Add(GlitchedDuoModParameters.PackageId, "GlitchedDuoModPage_21341");
            ModParameters.BookList.AddRange(new List<LorId>
            {
                new LorId(GlitchedDuoModParameters.PackageId, 3)
            });
        }
    }
}