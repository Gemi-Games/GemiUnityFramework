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
    public class PSController : MonoBehaviour
    {
        private PSModule[] m_Modules;

        private ParticleSystem m_PS;

        private bool m_PSFound;

        void Awake()
        {
            m_PS = GetComponent<ParticleSystem>();

            m_PSFound = m_PS != null;

            if (!m_PSFound)
            {
                Debug.LogError("Could not find a Particle System on this gameobject: " + gameObject.ToString());
                return;
            }

            m_Modules = GetComponents<PSModule>();

            for (int i = 0; i < m_Modules.Length; i++)
            {
                m_Modules[i].PS = m_PS;
                m_Modules[i].SetPSModule();
            }
        }

        public void SetValue(float lNormalisedValue)
        {
            if (!m_PSFound)
                return;

            for (int i = 0; i < m_Modules.Length; i++)
                m_Modules[i].SetValue(lNormalisedValue);
        }
    }
}
