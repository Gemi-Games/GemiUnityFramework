namespace GemiFramework
{
    public class RampQuintInOut : IRamp
    {
        private static RampQuintInOut INSTANCE;

        private RampQuintInOut() { }

        public static RampQuintInOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuintInOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

            if (percentage < 0.5f)
                return 0.5f * RampQuintIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampQuintOut.getValue(percentage * 2 - 1);
        }
    }
}
