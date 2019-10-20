namespace GemiFramework
{
    public class RampCircularInOut : IRamp
    {

        private static RampCircularInOut INSTANCE;

        private RampCircularInOut() { }

        public static RampCircularInOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCircularInOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

            if (percentage < 0.5f)
                return 0.5f * RampCircularIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampCircularOut.getValue(percentage * 2 - 1);
        }
    }
}
