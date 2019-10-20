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
    public class RampSpring : IRamp
    {
        private static RampSpring INSTANCE;

        private RampSpring() { }

        public static RampSpring getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampSpring();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float lValue = pSecondsElapsed /= pDuration;

            lValue = Mathf.Clamp01(lValue);

            float lN1 = 0.2f + 2.5f * lValue * lValue * lValue;
            float lN2 = (1f + (1.2f * (1f - lValue)));

            lValue = (Mathf.Sin(lValue * Mathf.PI * lN1) * Mathf.Pow(1f - lValue, 2.2f) + lValue) * lN2;

            return lValue;
        }
    }
}
