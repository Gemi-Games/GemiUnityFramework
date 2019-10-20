namespace GemiFramework
{
    public class RampQuintOut : IRamp
    {
        private static RampQuintOut INSTANCE;

        private RampQuintOut() { }

        public static RampQuintOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuintOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampQuintOut.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            float t = pPercentage - 1;
            return 1 + (t * t * t * t * t);
        }
    }
}
