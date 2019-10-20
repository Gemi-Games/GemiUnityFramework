namespace GemiFramework
{
    public class RampQuartInOut : IRamp
    {
        private static RampQuartInOut INSTANCE;

        private RampQuartInOut() { }

        public static RampQuartInOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuartInOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

            if (percentage < 0.5f)
                return 0.5f * RampQuartIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampQuartOut.getValue(percentage * 2 - 1);
        }
    }
}
