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
    [Serializable]
    public struct TimePassed
    {
        public static TimePassed ZERO = new TimePassed(0f, false);
        public static TimePassed LONGFORM_ZERO = new TimePassed(0f, true);

        public int Days;
        public int Hours;
        public int Minutes;
        public int Seconds;
        public int Milliseconds;

        public int SecondsTens;
        public int SecondsUnits;

        public int MilliHundreds;
        public int MilliTens;
        public int MilliUnits;

        public bool LongForm;

        public TimePassed(int lDays, int lHours, int lMins, int lSecs, int lMillis)
        {
            LongForm = true;

            Days = lDays;
            Hours = lHours;
            Minutes = lMins;
            Seconds = lSecs;
            Milliseconds = lMillis;

            SecondsTens = 0;
            SecondsUnits = 0;

            MilliHundreds = 0;
            MilliTens = 0;
            MilliUnits = 0;
        }

        public TimePassed(int lMins, int lSecs, int lMillis)
        {
            LongForm = false;

            Days = 0;
            Hours = 0;
            Minutes = lMins;
            Seconds = lSecs;
            Milliseconds = lMillis;

            SecondsTens = 0;
            SecondsUnits = 0;

            MilliHundreds = 0;
            MilliTens = 0;
            MilliUnits = 0;
        }

        public TimePassed(int totalMillis)
        {
            Days = 0;
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
            Milliseconds = 0;

            SecondsTens = 0;
            SecondsUnits = 0;

            MilliHundreds = 0;
            MilliTens = 0;
            MilliUnits = 0;

            LongForm = false;

            while (totalMillis >= 60000)
            {
                Minutes++;
                totalMillis -= 60000;
            }

            while (totalMillis >= 1000)
            {
                Seconds++;
                totalMillis -= 1000;
            }

            Milliseconds = totalMillis;
            if (Milliseconds >= 1000)
                Milliseconds -= 1000;
        }

        public void LongFormFromMillis(int lTotalMillis)
        {
            Days = 0;
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
            Milliseconds = 0;

            LongForm = true;

            if (LongForm)
            {
                while (lTotalMillis >= 3600 * 24 * 1000)
                {
                    Days++;
                    lTotalMillis -= 3600 * 24 * 1000;
                }

                while (lTotalMillis >= 3600 * 1000)
                {
                    Hours++;
                    lTotalMillis -= 3600 * 1000;
                }
            }

            while (lTotalMillis >= 60 * 1000)
            {
                Minutes++;
                lTotalMillis -= 60 * 1000;
            }

            while (lTotalMillis >= 1000)
            {
                Seconds++;
                lTotalMillis -= 1000;
            }

            Milliseconds = lTotalMillis;
        }

        public TimePassed(float lTotalTime)
            : this(lTotalTime, false)
        {

        }

        public TimePassed(float lTotalTime, bool lLongForm)
        {
            Days = 0;
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
            Milliseconds = 0;

            SecondsTens = 0;
            SecondsUnits = 0;

            MilliHundreds = 0;
            MilliTens = 0;
            MilliUnits = 0;

            LongForm = lLongForm;

            lTotalTime += 0.0005f;

            if (lLongForm)
            {
                while (lTotalTime >= 3600f * 24f)
                {
                    Days++;
                    lTotalTime -= 3600f * 24f;
                }

                while (lTotalTime >= 3600f)
                {
                    Hours++;
                    lTotalTime -= 3600f;
                }
            }

            while (lTotalTime >= 60f)
            {
                Minutes++;
                lTotalTime -= 60f;
            }

            while (lTotalTime >= 1f)
            {
                Seconds++;
                lTotalTime -= 1f;
            }

            float lMultiplied = lTotalTime * 1000f;

            Milliseconds = (int)lMultiplied;
            if (Milliseconds >= 1000)
                Milliseconds -= 1000;
        }

        public void CalculateIndividualNumbers()
        {
            SecondsTens = 0;
            SecondsUnits = 0;

            MilliHundreds = 0;
            MilliTens = 0;
            MilliUnits = 0;

            int lTemp = Seconds;

            while (lTemp >= 10)
            {
                SecondsTens++;
                lTemp -= 10;
            }

            SecondsUnits = lTemp;

            lTemp = Milliseconds;

            while (lTemp >= 100)
            {
                MilliHundreds++;
                lTemp -= 100;
            }

            while (lTemp >= 10)
            {
                MilliTens++;
                lTemp -= 10;
            }

            MilliUnits = lTemp;
        }

        public float ToFloat()
        {
            TimePassed lSavedTime = new TimePassed(ToMillis());

            float lMillisF = (float)Milliseconds * 0.001f;
            float lSecsF = (float)Seconds;
            float lMinsF = (float)Minutes * 60f;
            float lHoursF = 0f;
            float lDaysF = 0f;

            if (LongForm)
            {
                lHoursF = (float)Hours * 3600f;
                lDaysF = (float)Days * 3600f * 24f;
            }

            float lReturnValue = lDaysF + lHoursF + lMinsF + lSecsF + lMillisF;

            lReturnValue -= 0.0001f;

            TimePassed lTimeCheck = new TimePassed(lReturnValue);

            if (lSavedTime != lTimeCheck)
            {
                while (lSavedTime > lTimeCheck)
                {
                    lReturnValue += 0.0008f;
                    lTimeCheck = new TimePassed(lReturnValue);
                }

                while (lSavedTime < lTimeCheck)
                {
                    lReturnValue -= 0.0008f;
                    lTimeCheck = new TimePassed(lReturnValue);
                }
            }

            return lReturnValue;
        }

        public int ToMillis()
        {
            int lMillisM = Milliseconds;
            int lSecsM = Seconds * 1000;
            int lMinsM = Minutes * 60 * 1000;
            int lHoursM = Hours * 3600 * 1000;
            int lDaysM = Days * 3600 * 24 * 1000;

            if (!LongForm)
            {
                lHoursM = 0;
                lDaysM = 0;
            }

            int returnValue = lMillisM + lSecsM + lMinsM + lHoursM + lDaysM;

            return returnValue;
        }

        public int ToSeconds()
        {
            int lSecsS = Seconds;
            int lMinsS = Minutes * 60;
            int lHoursS = Hours * 3600;
            int lDaysS = Days * 3600 * 24;

            if (!LongForm)
            {
                lHoursS = 0;
                lDaysS = 0;
            }

            int returnValue = lSecsS + lMinsS + lHoursS + lDaysS;

            return returnValue;
        }

        public string ToFormatString()
        {
            return ToFormatString(-1);
        }

        public string ToFormatString(int lNumSignificantUnits)
        {
            if (LongForm)
            {
                if (Days > 0)
                {
                    if (lNumSignificantUnits == 3)
                        return Days + "d " + Hours + "h " + Minutes + "m";
                    else if (lNumSignificantUnits == 2)
                        return Days + "d " + Hours + "h";
                    else if (lNumSignificantUnits == 1)
                        return Days + "d";
                    else
                        return Days + "d " + Hours + "h " + Minutes + "m " + Seconds.ToString("00") + "." + Milliseconds.ToString("000") + "s";
                }
                else if (Hours > 0)
                {
                    if (lNumSignificantUnits == 2)
                        return Hours + "h " + Minutes + "m";
                    else if (lNumSignificantUnits == 1)
                        return Hours + "h";
                    else
                        return Hours + "h " + Minutes + "m " + Seconds.ToString("00") + "." + Milliseconds.ToString("000") + "s";
                }
                else if (Minutes > 0)
                {
                    if (lNumSignificantUnits == 1)
                        return Minutes + "m";
                    else
                        return Minutes + "m " + Seconds.ToString("00") + "." + Milliseconds.ToString("000") + "s";
                }
                else
                    return Seconds.ToString("00") + "." + Milliseconds.ToString("000") + "s";
            }
            else
                return Minutes + ":" + Seconds.ToString("00") + "." + Milliseconds.ToString("000");
        }

        public string ToFormatStringWOMillis()
        {
            if (LongForm)
            {
                if (Days > 0)
                    return Days + "d " + Hours + "h " + Minutes + "m " + Seconds.ToString("00") + "s";
                else if (Hours > 0)
                    return Hours + "h " + Minutes + "m " + Seconds.ToString("00") + "s";
                else if (Minutes > 0)
                    return Minutes + "m " + Seconds.ToString("00") + "s";
                else
                    return Seconds.ToString("00") + "s";
            }
            else
                return Minutes + ":" + Seconds.ToString("00");
        }

        public string ToFormatStringSecondsAndMillisOnly()
        {
            return Seconds.ToString("00") + "." + Milliseconds.ToString("000");
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TimePassed))
            {
                return false;
            }

            var passed = (TimePassed)obj;
            return Days == passed.Days &&
                   Hours == passed.Hours &&
                   Minutes == passed.Minutes &&
                   Seconds == passed.Seconds &&
                   Milliseconds == passed.Milliseconds &&
                   SecondsTens == passed.SecondsTens &&
                   SecondsUnits == passed.SecondsUnits &&
                   MilliHundreds == passed.MilliHundreds &&
                   MilliTens == passed.MilliTens &&
                   MilliUnits == passed.MilliUnits &&
                   LongForm == passed.LongForm;
        }

        public override int GetHashCode()
        {
            var hashCode = -51270105;
            hashCode = hashCode * -1521134295 + Days.GetHashCode();
            hashCode = hashCode * -1521134295 + Hours.GetHashCode();
            hashCode = hashCode * -1521134295 + Minutes.GetHashCode();
            hashCode = hashCode * -1521134295 + Seconds.GetHashCode();
            hashCode = hashCode * -1521134295 + Milliseconds.GetHashCode();
            hashCode = hashCode * -1521134295 + SecondsTens.GetHashCode();
            hashCode = hashCode * -1521134295 + SecondsUnits.GetHashCode();
            hashCode = hashCode * -1521134295 + MilliHundreds.GetHashCode();
            hashCode = hashCode * -1521134295 + MilliTens.GetHashCode();
            hashCode = hashCode * -1521134295 + MilliUnits.GetHashCode();
            hashCode = hashCode * -1521134295 + LongForm.GetHashCode();
            return hashCode;
        }

        public static bool operator <(TimePassed time1, TimePassed time2)
        {
            int totalMillis1 = time1.ToMillis();
            int totalMillis2 = time2.ToMillis();

            if (totalMillis1 < totalMillis2)
                return true;
            else
                return false;
        }

        public static bool operator >(TimePassed time1, TimePassed time2)
        {
            int totalMillis1 = time1.ToMillis();
            int totalMillis2 = time2.ToMillis();

            if (totalMillis1 > totalMillis2)
                return true;
            else
                return false;
        }

        public static bool operator <=(TimePassed time1, TimePassed time2)
        {
            int totalMillis1 = time1.ToMillis();
            int totalMillis2 = time2.ToMillis();

            if (totalMillis1 <= totalMillis2)
                return true;
            else
                return false;
        }

        public static bool operator >=(TimePassed time1, TimePassed time2)
        {
            int totalMillis1 = time1.ToMillis();
            int totalMillis2 = time2.ToMillis();

            if (totalMillis1 >= totalMillis2)
                return true;
            else
                return false;
        }

        public static bool operator ==(TimePassed time1, TimePassed time2)
        {
            int totalMillis1 = time1.ToMillis();
            int totalMillis2 = time2.ToMillis();

            if (totalMillis1 == totalMillis2)
                return true;
            else
                return false;
        }

        public static bool operator !=(TimePassed time1, TimePassed time2)
        {
            int totalMillis1 = time1.ToMillis();
            int totalMillis2 = time2.ToMillis();

            if (totalMillis1 != totalMillis2)
                return true;
            else
                return false;
        }

        public static TimePassed operator +(TimePassed time1, TimePassed time2)
        {
            int totalMillis1 = time1.ToMillis();
            int totalMillis2 = time2.ToMillis();

            return new TimePassed(totalMillis1 + totalMillis2);
        }

        public static TimePassed operator -(TimePassed time1, TimePassed time2)
        {
            int totalMillis1 = time1.ToMillis();
            int totalMillis2 = time2.ToMillis();

            return new TimePassed(totalMillis1 - totalMillis2);
        }
    }
}