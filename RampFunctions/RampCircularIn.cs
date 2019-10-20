using System;

namespace GemiFramework
{
    public class RampCircularIn : IRamp
    {
        private static RampCircularIn INSTANCE;

        private RampCircularIn() { }

        public static RampCircularIn getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCircularIn();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampCircularIn.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return -(float)(Math.Sqrt(1 - pPercentage * pPercentage) - 1.0f);
        }
    }
}
