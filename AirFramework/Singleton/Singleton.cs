using System;

namespace RootFramework
{
    public class Singleton<T> where T : Singleton<T>
    {
        private static readonly object _instanceLock = new object();

        //volatile��ֹ�߳��Ż�
        private volatile static T instance;

        private static bool initialized = false;
        public static bool Initialized => initialized;
        public static T Instance
        {
            get
            {
                //Double Checkʵ���̰߳�ȫ
                if (instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (instance == null && !initialized)
                        {

                            instance = Activator.CreateInstance<T>();
                            initialized = true;
                        }
                    }
                }
                return instance;
            }
        }

        public static void Unload()
        {
            if (instance != null)
            {
                initialized = false;
                instance = null;
            }
        }
        protected Singleton() { }



    }
}