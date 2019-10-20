using UnityEngine;

namespace GemiFramework
{
    public class RampSpring : IRamp
    {
        private static RampSpring INSTANCE;

        private RampSpring() { }

        public static RampSpring getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampSpring();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float lValue = pSecondsElapsed /= pDuration;

            lValue = Mathf.Clamp01(lValue);

            float lN1 = 0.2f + 2.5f * lValue * lValue * lValue;
            float lN2 = (1f + (1.2f * (1f - lValue)));

            lValue = (Mathf.Sin(lValue * Mathf.PI * lN1) * Mathf.Pow(1f - lValue, 2.2f) + lValue) * lN2;

            return lValue;
        }
    }
}
