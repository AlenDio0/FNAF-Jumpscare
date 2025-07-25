using UnityEngine;
using Verse;

namespace FNAFJumpscare
{
    class JumpscareComponent : GameComponent
    {
        private float m_LastTime;

        private const float m_CheckDuration = 1f;
        private const int m_Chance = 10_000;

        public JumpscareComponent(Game game)
            : base()
        {
            m_LastTime = Time.realtimeSinceStartup;
        }

        public override void GameComponentTick()
        {
            base.GameComponentTick();

            float currentTime = Time.realtimeSinceStartup;
            if (currentTime - m_LastTime < m_CheckDuration)
                return;
            m_LastTime = currentTime;

            if (Random.Range(0, m_Chance + 1) != m_Chance)
                return;

            Log.Warning("Bad luck, you woke up Whitered Foxy!");
            LongEventHandler.QueueLongEvent(() => Find.WindowStack.Add(new JumpscareWindow()), "Jumpscare", false, null);
        }
    }
}
