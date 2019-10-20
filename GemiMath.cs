using UnityEngine;

namespace GemiFramework
{
    public static class GemiMath
    {
        public static Vector3 Vector2ToVector3(Vector2 lV2)
        {
            Vector3 lV3 = new Vector3(lV2.x, lV2.y, 0f);

            return lV3;
        }
    }
}
