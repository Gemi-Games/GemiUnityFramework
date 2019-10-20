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
    public class ShowFPS : MonoBehaviour
    {
        int m_FrameCount;
        int m_FrameCountCurrent;

        float m_FrameTime;

        void Awake()
        {
            m_FrameCount = 0;
            m_FrameCountCurrent = 0;

            m_FrameTime = 0f;
        }

        void Update()
        {
            m_FrameCount++;
            m_FrameTime += Time.unscaledDeltaTime;

            if (m_FrameTime >= 1f)
            {
                m_FrameTime -= 1f;
                m_FrameCountCurrent = m_FrameCount;
                m_FrameCount = 0;
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(25, 25, 100, 30), string.Concat(m_FrameCountCurrent.ToString(), " FPS"));
        }
    }
}
