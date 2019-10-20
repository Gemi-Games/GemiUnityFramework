namespace GemiFramework
{
    public class RampQuintInOutBounce : IRamp
    {
        private static RampQuintInOutBounce INSTANCE;

        private RampQuintInOutBounce() { }

        public static RampQuintInOutBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuintInOutBounce();
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
                return 0.5f * RampQuintIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampQuintOut.getValue(percentage * 2 - 1);
        }
    }
}
