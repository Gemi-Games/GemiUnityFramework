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
    public class StateMachine<T>
    {
        public T Owner;

        private State<T> m_CurrentState;

        public State<T> CurrentState
        {
            get { return m_CurrentState; }
            private set { m_CurrentState = value; }
        }

        private float m_StateTime;

        public float StateTime
        {
            get { return m_StateTime; }
            private set { m_StateTime = value; }
        }

        private bool m_Enabled;

        public bool Enabled
        {
            get { return m_Enabled; }
            set { m_Enabled = value; }
        }

        public StateMachine(T lOwner)
        {
            Owner = lOwner;
            CurrentState = null;
            StateTime = 0f;
            m_Enabled = true;
        }

        public void ChangeState(State<T> lNewState)
        {
            ChangeState(lNewState, false);
        }

        public void ChangeState(State<T> lNewState, bool lChangeToSelf)
        {
            if (CurrentState != null)
            {
                if (!lChangeToSelf && lNewState.ID == CurrentState.ID)
                    return;
                else
                    CurrentState.ExitState(Owner);
            }

            CurrentState = lNewState;

            CurrentState.EnterState(Owner);

            StateTime = 0f;
        }

        public void Update()
        {
            if (m_Enabled && CurrentState != null)
            {
                CurrentState.Update(Owner);

                StateTime += Time.deltaTime;
            }
        }
    }
}
