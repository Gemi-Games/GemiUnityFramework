using UnityEngine;

namespace GemiFramework
{
    public static class DebugDraw
    {
        public static void Draw3DCrosshair(Vector3 lPosition, float lSize, float lDuration = 0f)
        {
            Draw3DCrosshair(lPosition, lSize, Color.green, lDuration);
        }

        public static void Draw3DCrosshair(Vector3 lPosition, float lSize, Color lColour, float lDuration = 0f)
        {
            Vector3 lXSize = Vector3.right * lSize / 2f;
            Vector3 lYSize = Vector3.up * lSize / 2f;
            Vector3 lZSize = Vector3.forward * lSize / 2f;

            Vector3 lStart1 = lPosition + lXSize;
            Vector3 lEnd1 = lPosition - lXSize;
            Vector3 lStart2 = lPosition + lYSize;
            Vector3 lEnd2 = lPosition - lYSize;
            Vector3 lStart3 = lPosition + lZSize;
            Vector3 lEnd3 = lPosition - lZSize;

            float lWhiteness = 0.35f;
            Color lFinalColour = Color.Lerp(lColour, Color.white, lWhiteness);

            Debug.DrawLine(lStart1, lEnd1, lFinalColour, lDuration);
            Debug.DrawLine(lStart2, lEnd2, lFinalColour, lDuration);
            Debug.DrawLine(lStart3, lEnd3, lFinalColour, lDuration);
        }
    }
}