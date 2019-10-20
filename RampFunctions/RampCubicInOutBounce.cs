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
    public class RampCubicInOutBounce : IRamp
    {

        private static RampCubicInOutBounce INSTANCE;

        private RampCubicInOutBounce() { }

        public static RampCubicInOutBounce getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampCubicInOutBounce();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            float percentage = pSecondsElapsed / pDuration;
            if (percentage < 0.5f)
                percentage = percentage * 2f;
            else
                percentage = 1f - (percentage - 0.5f) * 2f;
            if (percentage < 0.5f)
                return 0.5f * RampCubicIn.getValue(2 * percentage);
            else
                return 0.5f + 0.5f * RampCubicOut.getValue(percentage * 2 - 1);
        }
    }
}
