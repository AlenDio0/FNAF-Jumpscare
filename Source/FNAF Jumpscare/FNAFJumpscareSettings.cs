using UnityEngine;
using Verse;

namespace FNAFJumpscare
{
    class FNAFJumpscareSettings : ModSettings
    {
        private string m_ChanceBuffer;
        public int Chance = 10_000;

        private string m_CheckDurationBuffer;
        public float CheckDuration = 1f;

        private string m_VolumeBuffer;
        public float Volume = 100f;

        public void DoWindowContents(Rect canva)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(canva);

            float rowHeight = Text.LineHeight + 8f;

            void DrawIcon(Rect offset, Texture texture) => Widgets.DrawTextureFitted(new Rect(offset.xMax + 10f, offset.y, rowHeight, rowHeight), texture, 1f);

            Rect chanceRect = DrawLabeledField(listing.GetRect(rowHeight), "Chance (1 in N)", ref Chance, ref m_ChanceBuffer, 1);
            DrawIcon(chanceRect, TexButton.ShowBeauty);

            listing.Gap(rowHeight);

            Rect checkRect = DrawLabeledField(listing.GetRect(rowHeight), "Check Duration (seconds)", ref CheckDuration, ref m_CheckDurationBuffer, 0f);
            DrawIcon(checkRect, TexButton.Ingest);

            listing.Gap(rowHeight);

            Rect volumeRect = DrawLabeledField(listing.GetRect(rowHeight), "Jumpscream Volume (%)", ref Volume, ref m_VolumeBuffer, 0f, 1000f);
            DrawIcon(volumeRect, TexButton.IconSoundtrack);

            listing.Gap(200f);
            listing.GapLine();

            Widgets.Label(listing.GetRect(rowHeight + 24f), "DISCLAIMER: Use at your own risk. I strongly recommended not to increase the volume beyond 150%.\nYou've been warned.");

            listing.End();
        }

        private static Rect DrawLabeledField<T>(Rect row, string label, ref T value, ref string buffer, float min = 0, float max = (float)1E+09) where T : struct
        {
            label = $"{label}";
            float labelWidth = 200f;

            Widgets.Label(new Rect(row.x, row.y, labelWidth, row.height), label);

            Rect fieldRect = new Rect(row.x + labelWidth, row.y, 150f, row.height);
            Widgets.TextFieldNumeric(fieldRect, ref value, ref buffer, min, max);

            return fieldRect;
        }

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref Chance, "Chance", 10_000);
            Scribe_Values.Look(ref CheckDuration, "CheckDuration", 1f);
            Scribe_Values.Look(ref Volume, "Volume", 100f);
        }
    }
}
