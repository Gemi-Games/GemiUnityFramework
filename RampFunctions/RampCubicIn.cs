namespace GemiFramework
{
    public class RampCubicIn : IRamp
    {

        private static RampCubicIn INSTANCE;

        private RampCubicIn() {}

        public static RampCubicIn getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCubicIn();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampCubicIn.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return pPercentage * pPercentage * pPercentage;
        }
    }
}
