﻿/**
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
using System.Collections.Generic;
using UnityEngine;

namespace GemiFramework
{
    public enum AxisCode
    {
        MouseWheel = 0,
        Horizontal = 1,
        Vertical = 2,
    }

    public enum AxisDirection
    {
        Negative = -1,
        Neutral = 0,
        Positive = 1,
    }

    [Serializable]
    public struct KeyMapping
    {
        public const string POSITIVE_STRING = "Up";
        public const string NEGATIVE_STRING = "Down";

        public bool Valid;
        public KeyCode Key;
        public string AxisName;
        public AxisDirection Direction;

        public KeyMapping(KeyCode lKey)
        {
            Valid = true;

            Key = lKey;

            AxisName = null;
            Direction = 0;
        }

        public KeyMapping(string lAxisName, AxisDirection lDirection)
        {
            Valid = true;

            Key = KeyCode.None;

            AxisName = lAxisName;
            Direction = lDirection;
        }

        public override string ToString()
        {
            if (!Valid)
            {
                return "N/A";
            }
            else if (AxisName != null && AxisName.Length > 0)
            {
                string lDir = "???";

                if (Direction > 0)
                    lDir = POSITIVE_STRING;
                else if (Direction < 0)
                    lDir = NEGATIVE_STRING;

                return string.Concat(AxisName, " ", lDir);
            }
            else
            {
                return Key.ToString();
            }
        }

        public static bool operator ==(KeyMapping l0, KeyMapping l1)
        {
            if (!l0.Valid && !l1.Valid)
                return true;
            else if (l0.AxisName != null && l0.AxisName.Length > 0)
            {
                if (l1.AxisName != null && 
                    l0.AxisName == l1.AxisName && 
                    l0.Direction == l1.Direction)
                    return true;
                else
                    return false;
            }
            else if (l0.Key == l1.Key)
                return true;
            else
                return false;
        }

        public static bool operator !=(KeyMapping l0, KeyMapping l1)
        {
            return !(l0 == l1);
        }

        //internal static KeyMapping FromCode(int lCode)
        //{

        //}
    }

    public static class GemiInput
    {
        private static string[] s_AxisNames;

        private static KeyCode[] s_KeyCodes;

        private static Dictionary<string, bool> s_PreviousAxisKey = new Dictionary<string, bool>(8);

        public static bool GetAnyKeyPressed(out KeyMapping lKeyCode)
        {
            if (s_AxisNames == null)
                s_AxisNames = Enum.GetNames(typeof(AxisCode));

            if (s_KeyCodes == null)
                s_KeyCodes = Enum.GetValues(typeof(KeyCode)) as KeyCode[];

            for (int i = 0; i < s_AxisNames.Length; i++)
            {
                string lAxisName = s_AxisNames[i];

                if (Input.GetAxisRaw(lAxisName) > 0.001f)
                {
                    lKeyCode = new KeyMapping(lAxisName, AxisDirection.Positive);
                    return true;
                }
                else if (Input.GetAxisRaw(lAxisName) < -0.001f)
                {
                    lKeyCode = new KeyMapping(lAxisName, AxisDirection.Negative);
                    return true;
                }
            }

            for (int i = 0; i < s_KeyCodes.Length; i++)
            {
                if (Input.GetKey(s_KeyCodes[i]))
                {
                    lKeyCode = new KeyMapping(s_KeyCodes[i]);

                    return true;
                }
            }

            lKeyCode = new KeyMapping(KeyCode.None);

            return false;
        }

        public static bool GetKeyDown(KeyMapping[] lKeys)
        {
            if (lKeys == null)
                return false;

            for (int i = 0; i < lKeys.Length; i++)
            {
                KeyMapping lKey = lKeys[i];

                if (!lKey.Valid)
                {
                    continue;
                }
                else if (lKey.AxisName != null && lKey.AxisName.Length > 0)
                {
                    if (!s_PreviousAxisKey.ContainsKey(lKey.AxisName))
                        s_PreviousAxisKey.Add(lKey.AxisName, false);

                    float lAxisValue = Input.GetAxisRaw(lKey.AxisName);

                    if ((lKey.Direction == AxisDirection.Positive &&
                         lAxisValue > 0.001f) ||
                        (lKey.Direction == AxisDirection.Negative &&
                        lAxisValue < -0.001f))
                    {
                        if (!s_PreviousAxisKey[lKey.AxisName])
                        {
                            s_PreviousAxisKey[lKey.AxisName] = true;
                            return true;
                        }
                    }
                    else if (s_PreviousAxisKey[lKey.AxisName])
                    {
                        s_PreviousAxisKey[lKey.AxisName] = false;
                    }

                }
                else if (Input.GetKeyDown(lKey.Key))
                    return true;
            }

            return false;
        }

        public static bool GetKeyUp(KeyMapping[] lKeys)
        {
            if (lKeys == null)
                return false;

            for (int i = 0; i < lKeys.Length; i++)
            {
                KeyMapping lKey = lKeys[i];

                if (!lKey.Valid)
                {
                    continue;
                }
                else if (lKey.AxisName != null && lKey.AxisName.Length > 0)
                {
                    if (!s_PreviousAxisKey.ContainsKey(lKey.AxisName))
                        s_PreviousAxisKey.Add(lKey.AxisName, false);

                    float lAxisValue = Input.GetAxisRaw(lKey.AxisName);

                    if (lAxisValue > -0.001f &&
                        lAxisValue < 0.001f &&
                        s_PreviousAxisKey[lKey.AxisName])
                    {
                        s_PreviousAxisKey[lKey.AxisName] = false;
                        return true;
                    }
                }
                else if (Input.GetKeyUp(lKey.Key))
                    return true;
            }

            return false;
        }

        public static bool GetKey(KeyMapping[] lKeys)
        {
            if (lKeys == null)
                return false;

            for (int i = 0; i < lKeys.Length; i++)
            {
                KeyMapping lKey = lKeys[i];

                if (!lKey.Valid)
                {
                    continue;
                }
                else if (lKey.AxisName != null && lKey.AxisName.Length > 0)
                {
                    float lAxisValue = Input.GetAxisRaw(lKey.AxisName);

                    if ((lKey.Direction == AxisDirection.Positive &&
                        lAxisValue > 0.1f) ||
                        (lKey.Direction == AxisDirection.Negative &&
                        lAxisValue < -0.1f))
                    {
                        return true;
                    }
                }
                else if (Input.GetKey(lKey.Key))
                    return true;
            }

            return false;
        }
    }
}