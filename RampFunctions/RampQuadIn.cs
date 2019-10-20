namespace GemiFramework
{
    public class RampQuadIn : IRamp
    {

        private static RampQuadIn INSTANCE;

        private RampQuadIn() { }

        public static RampQuadIn getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuadIn();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampQuadIn.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return pPercentage * pPercentage;
        }
    }
}
