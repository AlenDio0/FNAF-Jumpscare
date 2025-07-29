using UnityEngine;
using Verse;
using Verse.Sound;

namespace FNAFJumpscare
{
    class JumpscareComponent : GameComponent
    {
        private float m_LastTime = Time.realtimeSinceStartup;

        private const float m_CheckDuration = 1f;
        private const int m_Chance = 10_000;

        public JumpscareComponent(Game game)
            : base() { }

        public override void GameComponentUpdate()
        {
            float currentTime = Time.realtimeSinceStartup;
            if (currentTime - m_LastTime < m_CheckDuration)
                return;
            m_LastTime = currentTime;

            if (Random.Range(1, m_Chance + 1) != m_Chance)
                return;

            SoundDef.Named("FNAFScreamer")?.PlayOneShotOnCamera();
            Find.WindowStack.Add(new JumpscareWindow());
        }
    }
}
