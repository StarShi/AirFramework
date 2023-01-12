using AirFramework.Assets.AirFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirFramework
{
    public interface IPool
    {
        /// <summary>
        /// ���������
        /// </summary>
        Type ObjectType { get; }

        /// <summary>
        /// �����������
        /// </summary>
        int Count { get; }

        /// <summary>
        /// ��ն���ػ���
        /// </summary>
        void Clear();

        /// <summary>
        /// �����Ԥ����
        /// </summary>
        /// <param name="count"></param>
        void Preload(int count);
        /// <summary>
        /// ����ػ������ӵ�
        /// </summary>
        /// <param name="count"></param>
        void PreloadTo(int count);
        /// <summary>
        /// ����ػ������
        /// </summary>
        /// <param name="count"></param>
        void Unload(int count);
        /// <summary>
        /// ����ػ�����ٵ�
        /// </summary>
        /// <param name="count"></param>
        void UnloadTo(int count);
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        object Allocate();

        /// <summary>
        /// �ͷŶ���
        /// </summary>
        /// <param name="item"></param>
        void Release(object item); 

        
    }
}
