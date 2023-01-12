using UnityEngine;
namespace AirFramework
{
    public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        private static T instance = null;
        private static bool initialized = false;
        public static bool Initialized => initialized;
        private static bool autoReset = false;
        //Set this value will reset the Instance
        public static bool AutoReset
        {
            get => autoReset;
            set
            {
                if (value)
                {
                    Unload();
                }
                autoReset = value;
            }
        }
        public static T Instance
        {
            get
            {
                //����֤�̰߳�ȫ
                if (instance == null && !initialized)
                {
                    GameObject container = new GameObject();
                    container.name = "Mono(" + typeof(T) + ")";
                    instance = container.AddComponent<T>();
                    if (!autoReset) DontDestroyOnLoad(container);
                    initialized = true;
                }
                return instance;
            }
        }
        public static void Load()
        {
            _ = Instance;
        }
        public static void Unload()
        {
            if (instance != null)
            {
                Destroy(instance.gameObject);
                initialized = false;
                instance = null;
            }
        }
        public void DynamicUnload()
        {
            if (instance != null)
            {
                Destroy(instance.gameObject);
                initialized = false;
                instance = null;
            }
        }
        protected SingletonMono() { }
    }
}