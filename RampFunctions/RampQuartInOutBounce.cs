namespace GemiFramework
{
    public class RampQuartInOutBounce : IRamp
    {
        private static RampQuartInOutBounce INSTANCE;

        private RampQuartInOutBounce() { }

        public static RampQuartInOutBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuartInOutBounce();
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
                return 0.5f * RampQuartIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampQuartOut.getValue(percentage * 2 - 1);
        }
    }
}
