namespace GemiFramework
{
    public class RampQuartIn : IRamp
    {
        private static RampQuartIn INSTANCE;

        private RampQuartIn() { }

        public static RampQuartIn getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuartIn();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampQuartIn.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return pPercentage * pPercentage * pPercentage * pPercentage;
        }
    }
}
