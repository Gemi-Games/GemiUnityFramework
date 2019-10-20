namespace GemiFramework
{
    public class RampUltraInOutBounce : IRamp
    {
        private static RampUltraInOutBounce INSTANCE;

        private RampUltraInOutBounce() { }

        public static RampUltraInOutBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampUltraInOutBounce();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

            if (percentage < 0.5f)
                percentage = percentage * 2f;
            else
                percentage = 1f - (percentage - 0.5f) * 2f;

            if (percentage < 0.5f)
                return 0.5f * RampUltraIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampUltraOut.getValue(percentage * 2 - 1);
        }
    }
}
