﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace AirFramework
{
    /// <summary>
    /// 此分部类负责对象池
    /// </summary>
    [AsyncMethodBuilder(typeof(AsyncTaskMethodBuilder<>))]
    public partial class AsyncTask<T> : PoolableObject<AsyncTask<T>>, IAsyncTask<T>,IAuthorization, IAsyncTokenProperty
    {
        [DebuggerHidden]
        internal static AutoBindPool<AsyncTask<T>> AsyncTaskPool { get; } = Framework.Pool.CreateAutoBindablePool(() => new AsyncTask<T>(), null);
        [DebuggerHidden]
        public static AsyncTask<T> Create(bool fromPool = false)
        {
            if (fromPool)
            {
                return AsyncTaskPool.Allocate();
            }
            return new AsyncTask<T>();
        }
        [DebuggerHidden]
        public override void OnAllocate()
        {
            IsCompleted = false;
        }
        [DebuggerHidden]
        public override void OnRecycle()
        {
            //Token?.Unregister(this);
            Token.Dispose();
            continuation = null;
            Token = null;
            Exception = null;

        }
    }

    /// <summary>
    /// SetResult/SetException
    /// </summary>
    public partial class AsyncTask<T> : PoolableObject<AsyncTask<T>>, IAsyncTask<T>, IAuthorization, IAsyncTokenProperty
    {
        T Result;
        /// <summary>
        /// 返回await结果
        /// </summary>
        [DebuggerHidden]
        public T GetResult() => Result;

        public AsyncTask()
        {
            SetResult = SetResultMethod;
        }
        /// <summary>
        /// 结束当前await并设置结果
        /// </summary>
        [DebuggerHidden]
        public Action<T> SetResult { get; private set; }
        [DebuggerHidden]
        private void SetResultMethod(T result)
        {
            if (Authorization)
            {
                this.Result = result;
                //执行await以后的代码
                continuation?.Invoke();
                
                
            }
            OnAsyncCompleted?.Invoke(result);
            //回收到Pool
            this.Dispose();
        }

        [DebuggerHidden]
        public ExceptionDispatchInfo Exception { get; private set; }
        /// <summary>
        /// 当执行出现异常时状态机调用
        /// </summary>
        /// <param name="exception"></param>
        [DebuggerHidden]
        public void SetException(Exception exception)
        {
            SetResultMethod(default);
        }
    }

    /// <summary>
    /// OnCompleted
    /// </summary>
    public partial class AsyncTask<T> : PoolableObject<AsyncTask<T>>, IAsyncTask<T>, IAuthorization, IAsyncTokenProperty
    {

        [DebuggerHidden]
        public AsyncTask<T> GetAwaiter() => this;

        #region OnCompleted
        public event Action<T> OnAsyncCompleted = null;
        private Action continuation;
        [DebuggerHidden]
        public bool IsCompleted { get; set; }
        [DebuggerHidden]
        public void OnCompleted(Action continuation)
        {
            UnsafeOnCompleted(continuation);
        }

        [DebuggerHidden]
        public void UnsafeOnCompleted(Action continuation)
        {
            this.continuation = continuation;
        }

        #endregion

        #region Token
        /// <summary>
        /// 异步令牌，与AsyncToken作用相同
        /// </summary>
        public AsyncTreeTokenNode Token { get; set; } = null;

        private bool authorization = true;
        /// <summary>
        /// 授权状态：代表当前任务是否挂起与任务链能否继续
        /// </summary>
        public bool Authorization { get => authorization; set => authorization = value; }

        #endregion

        [DebuggerHidden]
        public async void Coroutine()
        {
            await this;
        }


    }
}
