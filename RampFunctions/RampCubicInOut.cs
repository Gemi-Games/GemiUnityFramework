namespace GemiFramework
{
    public class RampCubicInOut : IRamp
    {

        private static RampCubicInOut INSTANCE;

        private RampCubicInOut() { }

        public static RampCubicInOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCubicInOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

            if (percentage < 0.5f)
                return 0.5f * RampCubicIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampCubicOut.getValue(percentage * 2 - 1);
        }
    }
}
