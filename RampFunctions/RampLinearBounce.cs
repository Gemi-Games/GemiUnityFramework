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
