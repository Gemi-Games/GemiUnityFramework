using System;

namespace GemiFramework
{
    public class RampSineOut : IRamp
    {
        private static RampSineOut INSTANCE;

        private RampSineOut() { }

        public static RampSineOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampSineOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampSineOut.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return (float)Math.Sin(pPercentage * Math.PI * 0.5f);
        }

        public static float getValueScaled(float pPercentage, float scale)
        {
            float ramp = getValue(pPercentage);
            float linear = pPercentage;
            return linear + (ramp - linear) * scale;
        }
    }
}
