namespace GemiFramework
{
    public class RampQuadOut : IRamp
    {

        private static RampQuadOut INSTANCE;

        private RampQuadOut() { }

        public static RampQuadOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuadOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampQuadOut.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return -pPercentage * (pPercentage - 2f);
        }
    }
}
