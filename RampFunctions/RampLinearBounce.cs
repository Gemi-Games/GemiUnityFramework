namespace GemiFramework
{
    public class RampLinearBounce : IRamp
    {
        private static RampLinearBounce INSTANCE;

        private RampLinearBounce() { }

        public static RampLinearBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampLinearBounce();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float timeNorm = pSecondsElapsed / pDuration;

            if(timeNorm < 0.5f)
            {
                return timeNorm * 2f;
            }
            else
            {
                return 1f - (timeNorm - 0.5f) * 2f;
            }
        }
    }
}
