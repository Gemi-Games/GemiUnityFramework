namespace GemiFramework
{
    public class RampQuadInOut : IRamp
    {

        private static RampQuadInOut INSTANCE;

        private RampQuadInOut() { }

        public static RampQuadInOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuadInOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;

            if (percentage < 0.5f)
                return 0.5f * RampQuadIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampQuadOut.getValue(percentage * 2 - 1);
        }
    }
}
