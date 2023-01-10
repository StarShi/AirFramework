namespace RootFramework
{
    public interface IPool<T>
    {

        /// <summary>
        /// �ص�ǰ��������
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        /// 
        T Allocate();

        /// <summary>
        /// �ͷŶ���
        /// </summary>
        /// <param name="obj"></param>
        void Release(T obj);


        /// <summary>
        /// ж�ػ���
        /// </summary>
        /// <param name="count"></param>
        void Unload(int count);


        /// <summary>
        /// ��ǰ����
        /// </summary>
        /// <param name="count"></param>
        void Preload(int count);
    }
}