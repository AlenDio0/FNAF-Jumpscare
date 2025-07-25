using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace FNAFJumpscare
{
    class JumpscareWindow : Window
    {
        private readonly List<Texture2D> m_Frames = new List<Texture2D>();
        private int m_CurrentFrame = 0;
        private float m_LastFrameTime = Time.realtimeSinceStartup;

        private const float m_FrameDuration = 0.03f;
        private const float m_LastFrameDuration = 0.5f;
        private const int m_FramesCount = 13;

        public override Vector2 InitialSize => new Vector2(UI.screenWidth, UI.screenHeight);

        public JumpscareWindow()
        {
            closeOnClickedOutside = false;
            doWindowBackground = false;
            doCloseX = false;
            layer = WindowLayer.Super;
            absorbInputAroundWindow = true;
            forcePause = true;

            for (int i = 1; i <= m_FramesCount; i++)
                m_Frames.Add(ContentFinder<Texture2D>.Get($"Jumpscare/Foxy_{i:D2}"));

            SoundDef sound = SoundDef.Named("FNAFScreamer");
            sound.PlayOneShotOnCamera();
        }

        public override void DoWindowContents(Rect canva)
        {
            float currentTime = Time.realtimeSinceStartup;

            m_CurrentFrame = Mathf.Clamp(m_CurrentFrame, 0, m_Frames.Count - 1);
            GUI.DrawTexture(canva, m_Frames[m_CurrentFrame], ScaleMode.ScaleToFit, true);

            if (m_CurrentFrame == m_Frames.Count - 1)
            {
                if (currentTime - m_LastFrameTime < m_LastFrameDuration)
                    return;

                Close(false);
                return;
            }

            if (currentTime - m_LastFrameTime < m_FrameDuration)
                return;

            m_CurrentFrame++;
            m_LastFrameTime = currentTime;
        }
    }
}
