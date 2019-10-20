namespace GemiFramework
{
    public class RampQuintIn : IRamp
    {
        private static RampQuintIn INSTANCE;

        private RampQuintIn() { }

        public static RampQuintIn getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuintIn();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampQuintIn.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return pPercentage * pPercentage * pPercentage * pPercentage * pPercentage;
        }
    }
}
