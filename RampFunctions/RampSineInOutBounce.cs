using System;
using UnityEngine;

namespace GemiFramework
{
    public class RampSineInOutBounce : IRamp
    {

        private static RampSineInOutBounce INSTANCE;

        private RampSineInOutBounce() { }

        public static RampSineInOutBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampSineInOutBounce();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

            if (percentage < 0.5f)
                percentage = percentage * 2f;
            else
                percentage = 1f - (percentage - 0.5f) * 2f;

            return -0.5f * Mathf.Cos(percentage * Mathf.PI) - 1f;
        }
    }
}
