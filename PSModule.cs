using System;
using UnityEngine;

namespace GemiFramework
{
    public class PSModule : MonoBehaviour
    {
        [SerializeField]
        protected float m_Min = 0.5f;

        [SerializeField]
        protected float m_Max = 1f;

        [NonSerialized]
        public ParticleSystem PS;

        public virtual void SetPSModule()
        {

        }

        public virtual void SetValue(float lNormalisedValue)
        {

        }
    }
}
