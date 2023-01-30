﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFramework
{
    public class GenericPoolManager : Unit, IGenericPoolManager
    {
        private readonly Dictionary<Type, IObjectPool> pools = new Dictionary<Type, IObjectPool>();

        /// <summary>
        /// 自旋锁
        /// </summary>
        private readonly object _lock = new object();

        
        public IGenericPool<T> GetPool<T>() where T : class, IPoolable
        {
            //防止创建池相互覆盖
            lock (_lock)
            {
                if (!pools.ContainsKey(typeof(T)))
                {
                    pools.Add(typeof(T), new GenericPool<T>(
                            Extensions.DefaltActivatorCreate<T>,
                            null,
                            (T item) => { item.OnRecycle(); },
                            (T item) => { item.OnAllocate(); }
                            ));
                }

                return pools[typeof(T)] as GenericPool<T>;
            }
        }

        public void Destroy<T>() where T : class, IPoolable
        {
            lock (_lock)
            {
                Type poolType = typeof(T);
                if (pools.ContainsKey(poolType))
                {
                    var pool = pools[poolType];
                    pools.Remove(typeof(T));
                    pool.Dispose();
                }
            }
        }
        public T Allocate<T>() where T : class, IPoolable
        {
            return (T)(GetPool<T>().AllocateObj());
        }
    
        public void Recycle<T>(T item) where T : class, IPoolable
        {
            GetPool<T>().RecycleObj(item);
        }
 
        protected override void OnDispose()
        {
            pools.Clear();
        }
        
        public IGenericPool<T> CreatePool<T>(Func<T> onCreate = null, Action<T> onDestroy = null, Action<T> onRecycle = null, Action<T> onAllocate = null) where T : class
        {
            IGenericPool<T> pool = new GenericPool<T>(
                        onCreate??Extensions.DefaltActivatorCreate<T>,
                        onDestroy,
                        onRecycle,
                        onAllocate
                        );
            return pool;
        }
    }
}
