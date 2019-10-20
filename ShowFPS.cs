using UnityEngine;

namespace GemiFramework
{
    public class ShowFPS : MonoBehaviour
    {
        int m_FrameCount;
        int m_FrameCountCurrent;

        float m_FrameTime;

        void Awake()
        {
            m_FrameCount = 0;
            m_FrameCountCurrent = 0;

            m_FrameTime = 0f;
        }

        void Update()
        {
            m_FrameCount++;
            m_FrameTime += Time.unscaledDeltaTime;

            if (m_FrameTime >= 1f)
            {
                m_FrameTime -= 1f;
                m_FrameCountCurrent = m_FrameCount;
                m_FrameCount = 0;
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(25, 25, 100, 30), string.Concat(m_FrameCountCurrent.ToString(), " FPS"));
        }
    }
}
