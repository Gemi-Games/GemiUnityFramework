namespace GemiFramework
{
    public class RampCircularInOutBounce : IRamp
    {

        private static RampCircularInOutBounce INSTANCE;

        private RampCircularInOutBounce() { }

        public static RampCircularInOutBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCircularInOutBounce();
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
                return 0.5f * RampCircularIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampCircularOut.getValue(percentage * 2 - 1);
        }
    }
}
