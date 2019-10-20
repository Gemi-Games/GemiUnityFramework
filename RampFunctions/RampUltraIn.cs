namespace GemiFramework
{
    public class RampUltraIn : IRamp
    {
        private static RampUltraIn INSTANCE;

        private RampUltraIn() { }

        public static RampUltraIn getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampUltraIn();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampUltraIn.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return pPercentage * pPercentage * pPercentage * pPercentage * pPercentage * pPercentage * pPercentage;
        }
    }
}
