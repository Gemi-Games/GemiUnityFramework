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
using UnityEngine;

namespace GemiFramework
{
    [Serializable]
    public struct FloatRange
    {
        public float Min;
        public float Max;

        public float Value;

        public static FloatRange Default
        {
            get { return new FloatRange(0f, 1f, 1f); }
        }

        public float Delta
        {
            get
            {
                return Max - Min;
            }
        }

        public FloatRange(float lMin, float lMax)
            : this(lMin, lMax, lMin)
        {
        }

        public FloatRange(float lMin, float lMax, float lValue)
        {
            Min = lMin;
            Max = lMax;
            Value = lValue;
        }

        public float GetValue()
        {
            return Min + (Max - Min) * Mathf.Clamp01(Value);
        }

        public float GetValueFromNormalisedPosition(float lNormalisedPosition)
        {
            return Min + (Max - Min) * lNormalisedPosition;
        }

        public float GetRandomValue()
        {
            return Min + (Max - Min) * UnityEngine.Random.value;
        }
    }
}