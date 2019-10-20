namespace GemiFramework
{
    public class RampCubicInOutBounce : IRamp
    {

        private static RampCubicInOutBounce INSTANCE;

        private RampCubicInOutBounce() { }

        public static RampCubicInOutBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCubicInOutBounce();
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
                return 0.5f * RampCubicIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampCubicOut.getValue(percentage * 2 - 1);
        }
    }
}
