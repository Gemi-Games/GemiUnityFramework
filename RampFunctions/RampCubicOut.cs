namespace GemiFramework
{
    public class RampCubicOut : IRamp
    {

        private static RampCubicOut INSTANCE;

        private RampCubicOut() { }

        public static RampCubicOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCubicOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampCubicOut.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            float t = pPercentage - 1;
            return 1 + (t * t * t);
        }
    }
}
