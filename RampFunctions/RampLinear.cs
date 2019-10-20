namespace GemiFramework
{
    public class RampLinear : IRamp
    {
        private static RampLinear INSTANCE;

        private RampLinear() { }

        public static RampLinear getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampLinear();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return pSecondsElapsed / pDuration;
        }
    }
}
