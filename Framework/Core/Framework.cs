﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFramework
{
    public static partial class Framework
    {
        
        /// <summary>
        /// 管理任意实现IPoolable和PoolableObject的类型，或者自行获取自定义对象池允许不实现IPoolable
        /// </summary>
        public static IGenericPoolManager Pool { get; } = new GenericPoolManager();  
        
        /// <summary>
        /// 消息注册和转发机制管理器
        /// </summary>
        public static IMessageManager Message { get; } = new MessageManager();
        

    }
}
