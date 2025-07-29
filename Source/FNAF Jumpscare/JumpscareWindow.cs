using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace FNAFJumpscare
{
    class JumpscareWindow : Window
    {
        private readonly List<Texture2D> m_Frames = new List<Texture2D>();
        private int m_CurrentFrame = 0;
        private float m_LastFrameTime = Time.realtimeSinceStartup;

        private const float m_FrameDuration = 0.033f;

        public override Vector2 InitialSize => new Vector2(UI.screenWidth, UI.screenHeight);
        protected override float Margin => 0f;

        public JumpscareWindow()
        {
            layer = WindowLayer.Super;
            doCloseX = false;
            closeOnAccept = false;
            closeOnCancel = false;
            doWindowBackground = false;
            drawShadow = false;
            soundAppear = null;
            soundClose = null;

            int frameCount = ContentFinder<Texture2D>.GetAllInFolder("Jumpscare").Count();
            for (int i = 1; i < frameCount + 1; i++)
            {
                Texture2D frame = ContentFinder<Texture2D>.Get($"Jumpscare/Foxy_{i:D2}");
                if (frame != null)
                    m_Frames.Add(frame);
            }
        }

        public override void DoWindowContents(Rect canva)
        {
            float currentTime = Time.realtimeSinceStartup;

            m_CurrentFrame = Mathf.Clamp(m_CurrentFrame, 0, m_Frames.Count - 1);
            GUI.DrawTexture(canva, m_Frames[m_CurrentFrame], ScaleMode.StretchToFill, true);

            if (currentTime - m_LastFrameTime < m_FrameDuration)
                return;

            if (m_CurrentFrame >= m_Frames.Count - 1)
            {
                Close(false);
                return;
            }

            m_CurrentFrame++;
            m_LastFrameTime = currentTime;
        }
    }
}
