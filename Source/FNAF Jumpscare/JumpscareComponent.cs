using UnityEngine;
using Verse;
using Verse.Sound;

namespace FNAFJumpscare
{
    class JumpscareComponent : GameComponent
    {
        private float m_LastTime = Time.realtimeSinceStartup;

        public JumpscareComponent(Game game)
            : base() { }

        public override void GameComponentUpdate()
        {
            if (Find.TickManager.Paused)
                return;

            var settings = FNAFJumpscareMod.s_Settings;
            float currentTime = Time.realtimeSinceStartup;
            if (currentTime - m_LastTime < settings.CheckDuration)
                return;
            m_LastTime = currentTime;

            if (Random.Range(1, settings.Chance + 1) != settings.Chance)
                return;

            SoundDef sound = SoundDef.Named("FNAFScreamer");
            if (sound != null)
            {
                foreach (SubSoundDef subSound in sound.subSounds)
                    subSound.volumeRange = new FloatRange(settings.Volume, settings.Volume);

                sound.PlayOneShotOnCamera();
            }
            Find.WindowStack.Add(new JumpscareWindow());
        }
    }
}
