
namespace GemiFramework
{
    public class RampQuartOut : IRamp
    {
        private static RampQuartOut INSTANCE;

        private RampQuartOut() { }

        public static RampQuartOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuartOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampQuartOut.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            float t = pPercentage - 1;
            return 1 - (t * t * t * t);
        }
    }
}
