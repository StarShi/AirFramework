using System;
/********************************************************************************************
 * Author : yueh0607
 * Date : 2023.1.13
 * Description : 
 * �������һ��IUnit�ӿڣ���Ϊ�����ȫ����Ļ��ӿڣ��̳�IDisposable����using�ͷ�
 */
namespace AirFramework
{
    public interface IUnit : IDisposable
    {
        /// <summary>
        /// ���й���Դ�Ƿ��Ѿ��ͷ�
        /// </summary>
        bool Disposed { get; }


       
        
    }
}