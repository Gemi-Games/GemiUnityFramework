namespace GemiFramework
{
    public class RampQuadInOutBounce : IRamp
    {

        private static RampQuadInOutBounce INSTANCE;

        private RampQuadInOutBounce() { }

        public static RampQuadInOutBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuadInOutBounce();
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
                return 0.5f * RampQuadIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampQuadOut.getValue(percentage * 2 - 1);
        }
    }
}
