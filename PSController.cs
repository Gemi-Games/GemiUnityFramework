using UnityEngine;

namespace GemiFramework
{
    public class PSController : MonoBehaviour
    {
        private PSModule[] m_Modules;

        private ParticleSystem m_PS;

        private bool m_PSFound;

        void Awake()
        {
            m_PS = GetComponent<ParticleSystem>();

            m_PSFound = m_PS != null;

            if (!m_PSFound)
            {
                Debug.LogError("Could not find a Particle System on this gameobject: " + gameObject.ToString());
                return;
            }

            m_Modules = GetComponents<PSModule>();

            for (int i = 0; i < m_Modules.Length; i++)
            {
                m_Modules[i].PS = m_PS;
                m_Modules[i].SetPSModule();
            }
        }

        public void SetValue(float lNormalisedValue)
        {
            if (!m_PSFound)
                return;

            for (int i = 0; i < m_Modules.Length; i++)
                m_Modules[i].SetValue(lNormalisedValue);
        }
    }
}
