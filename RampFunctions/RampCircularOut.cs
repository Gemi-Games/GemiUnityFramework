using System;

namespace GemiFramework
{
    public class RampCircularOut : IRamp
    {

        private static RampCircularOut INSTANCE;

        private RampCircularOut() { }

        public static RampCircularOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCircularOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampCircularOut.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            float t = pPercentage - 1;
            return (float)Math.Sqrt(1 - t * t);
        }
    }
}
