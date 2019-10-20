using System;

namespace GemiFramework
{
    public class RampElasticOut : IRamp
    {
        private static RampElasticOut INSTANCE;

        private RampElasticOut() { }

        public static RampElasticOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampElasticOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampElasticOut.getValue(pSecondsElapsed, 0f, 1f, pDuration);
        }

        /// <param name="t">Current time in seconds.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float getValue(float t, float b, float c, float d)
        {
            if ((t /= d) == 1f)
                return b + c;

            float p = d * 0.3f;
            float s = p / 4f;

            return (c * (float)Math.Pow(2f, -10f * t) * (float)Math.Sin((t * d - s) * (2f * (float)Math.PI) / p) + c + b);
        }
    }
}
