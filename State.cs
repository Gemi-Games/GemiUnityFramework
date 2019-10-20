namespace GemiFramework
{
    public abstract class State<T>
    {
        private static int s_NextID = 0;

        private static int GetID()
        {
            return s_NextID++;
        }

        private int m_ID = GetID();

        public int ID
        {
            get { return m_ID; }
        }

        public abstract void ExitState(T o);

        public abstract void Update(T o);

        public abstract void EnterState(T o);
    }
}