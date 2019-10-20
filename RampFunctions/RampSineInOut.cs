using System;

namespace GemiFramework
{
    public class RampSineInOut : IRamp
    {

        private static RampSineInOut INSTANCE;

        private RampSineInOut() { }

        public static RampSineInOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampSineInOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

		return -0.5f * (float)(Math.Cos(percentage * Math.PI) - 1);
        }
    }
}
