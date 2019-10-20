namespace GemiFramework
{
    public class RampUltraOut : IRamp
    {
        private static RampUltraOut INSTANCE;

        private RampUltraOut() { }

        public static RampUltraOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampUltraOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampUltraOut.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            float t = pPercentage - 1;
            return 1 + (t * t * t * t * t * t * t);
        }
    }
}
