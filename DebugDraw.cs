/**
 * 
 *  Copyright (C) 2019 Marios Kalogerou
 * 
 *  This file is part of Gemi Games Unity Framework (GemiFramework).
 * 
 *  GemiFramework is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  GemiFramework is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with GemiFramework. If not, see <http://www.gnu.org/licenses/>.
 * 
 **/

using UnityEngine;

namespace GemiFramework
{
    public static class DebugDraw
    {
        public static void Draw3DCrosshair(Vector3 lPosition, float lSize, float lDuration = 0f)
        {
#if UNITY_EDITOR
            Draw3DCrosshair(lPosition, lSize, Color.green, lDuration);
#endif
        }

        public static void Draw3DCrosshair(Vector3 lPosition, float lSize, Color lColour, float lDuration = 0f)
        {
#if UNITY_EDITOR
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
#endif
        }
    }
}