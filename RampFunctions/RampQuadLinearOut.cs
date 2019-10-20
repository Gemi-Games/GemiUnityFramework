
namespace GemiFramework
{
    public class RampQuadLinearOut : IRamp
    {
        private static RampQuadLinearOut INSTANCE;

        private RampQuadLinearOut() { }

        public static RampQuadLinearOut getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampQuadLinearOut();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampQuadLinearOut.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            float quadValue = -pPercentage * (pPercentage - 2);
            return (pPercentage + quadValue) * 0.5f;
        }
    }
}
