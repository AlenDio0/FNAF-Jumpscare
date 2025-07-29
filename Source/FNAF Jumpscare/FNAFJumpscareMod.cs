using UnityEngine;
using Verse;

namespace FNAFJumpscare
{
    class FNAFJumpscareMod : Mod
    {
        public static FNAFJumpscareSettings s_Settings;

        public FNAFJumpscareMod(ModContentPack content)
            : base(content)
        {
            s_Settings = GetSettings<FNAFJumpscareSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            s_Settings.DoWindowContents(inRect);
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory() => "1/10000 Chance for Withered Foxy Jumpscare Every Second";

        public override void WriteSettings() => base.WriteSettings();
    }
}
