using System;

namespace GemiFramework
{
    public class RampSineIn : IRamp
    {
        private static RampSineIn INSTANCE;

        private RampSineIn() { }

        public static RampSineIn getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampSineIn();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampSineIn.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return -(float)Math.Cos(pPercentage * Math.PI * 0.5f) + 1;
        }

        public static float getValueScaled(float pPercentage, float scale)
        {
            float ramp = getValue(pPercentage);
            float linear = pPercentage;
            return linear + (ramp - linear) * scale;
        }
    }
}
