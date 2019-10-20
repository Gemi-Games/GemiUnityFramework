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
