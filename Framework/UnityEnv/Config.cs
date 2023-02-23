using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AirFramework.Editor
{
    
    public enum LogState
    {
        /// <summary>
        /// �����¼
        /// </summary>

        None,
        /// <summary>
        /// ֻ��¼����
        /// </summary>

        Simple,
        /// <summary>
        /// ��ȫ��־�����ж�ջ����
        /// </summary>

        All
    }

    [CreateAssetMenu(menuName = "FrameworkConfig")]
    public class Config :ScriptableObject
    {

        public LogState logger_log_enable = LogState.Simple;
        public LogState logger_warn_enable = LogState.Simple;
        public LogState logger_exception = LogState.All;
        public LogState logger_error = LogState.All;
        public bool logger_loop_defend = true;


    }
}
