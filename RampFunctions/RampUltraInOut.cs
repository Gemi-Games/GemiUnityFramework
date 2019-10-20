namespace GemiFramework
{
    public class RampUltraInOut : IRamp
    {
        private static RampUltraInOut INSTANCE;

        private RampUltraInOut() { }

        public static RampUltraInOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampUltraInOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

            if (percentage < 0.5f)
                return 0.5f * RampUltraIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampUltraOut.getValue(percentage * 2 - 1);
        }
    }
}
