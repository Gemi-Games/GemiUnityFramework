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

using System;

namespace GemiFramework
{
    public class RampSineIn : IRamp
    {
        private static RampSineIn INSTANCE;

        private RampSineIn() { }

        public static RampSineIn getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new RampSineIn();
            return INSTANCE;
        }

        public float getRamp(float pSecondsElapsed, float pDuration)
        {
            return RampSineIn.getValue(pSecondsElapsed / pDuration);
        }

        public static float getValue(float pPercentage)
        {
            return -(float)Math.Cos(pPercentage * Math.PI * 0.5f) + 1;
        }

        public static float getValueScaled(float pPercentage, float scale)
        {
            float ramp = getValue(pPercentage);
            float linear = pPercentage;
            return linear + (ramp - linear) * scale;
        }
    }
}
