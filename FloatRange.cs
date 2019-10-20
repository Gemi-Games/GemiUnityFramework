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