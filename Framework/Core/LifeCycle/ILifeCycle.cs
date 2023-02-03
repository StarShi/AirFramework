using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirFramework
{
    /// <summary>
    /// ����ӿڼ̳иýӿ���ʵ���Զ�����������,��Ҫ��ĳЩλ�õ���Framework.LifeCycle.Publish<T>();���㲥��������
    /// </summary>
    public interface ILifeCycle: IMessage
    {
        /// <summary>
        /// �ӿ���Ҫ��ʽʵ�ָ÷������ڷ����ڵ��� Framework.LifeCycle.Register<T>(Action); TΪ�ӿ�����
        /// </summary>
        void OnLifeCycleRegister() { }
        /// <summary>
        /// �ӿ���Ҫ��ʽʵ�ָ÷������ڷ����ڵ��� Framework.LifeCycle.UnRegister<T>(Action); TΪ�ӿ�����
        /// </summary>
        void OnLifeCycleUnRegister() { }
    }
}
