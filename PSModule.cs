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
    public class PSModule : MonoBehaviour
    {
        [SerializeField]
        protected float m_Min = 0.5f;

        [SerializeField]
        protected float m_Max = 1f;

        [NonSerialized]
        public ParticleSystem PS;

        public virtual void SetPSModule()
        {

        }

        public virtual void SetValue(float lNormalisedValue)
        {

        }
    }
}
