﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFramework
{
    public static partial class Extensions
    {

        public static bool TryRequestAll<T1>(this UnitMessageDispatcherContanier container, out UnitList<T1> result)
        {
            var events = Framework.Message.GetDispatcher(container.Value.TypeValue).Value.Get(container.Value.Receiver, typeof(Func<T1>));
            container.Dispose();
            result = new();
            if (events == null || events.Count == 0) return false;

            foreach (var func in events)
            {
                result.Value.Add((func as Func<T1>).Invoke());
            }
            return true;
        }
        public static bool TryRequestAll<T1,T2>(this UnitMessageDispatcherContanier container,T1 arg1, out UnitList<T2> result)
        {
            var events = Framework.Message.GetDispatcher(container.Value.TypeValue).Value.Get(container.Value.Receiver, typeof(Func<T1>));
            container.Dispose();
            result = new();
            if (events == null || events.Count == 0) return false;

            foreach (var func in events)
            {
                result.Value.Add((func as Func<T1,T2>).Invoke(arg1));
            }
            return true;
        }
        public static bool TryRequestAll<T1, T2,T3>(this UnitMessageDispatcherContanier container, T1 arg1,T2 arg2, out UnitList<T3> result)
        {
            var events = Framework.Message.GetDispatcher(container.Value.TypeValue).Value.Get(container.Value.Receiver, typeof(Func<T1>));
            container.Dispose();
            result = new();
            if (events == null || events.Count == 0) return false;

            foreach (var func in events)
            {
                result.Value.Add((func as Func<T1, T2,T3>).Invoke(arg1,arg2));
            }
            return true;
        }
        public static bool TryRequestAll<T1, T2, T3,T4>(this UnitMessageDispatcherContanier container, T1 arg1, T2 arg2,T3 arg3, out UnitList<T4> result)
        {
            var events = Framework.Message.GetDispatcher(container.Value.TypeValue).Value.Get(container.Value.Receiver, typeof(Func<T1>));
            container.Dispose();
            result = new();
            if (events == null || events.Count == 0) return false;

            foreach (var func in events)
            {
                result.Value.Add((func as Func<T1, T2, T3,T4>).Invoke(arg1, arg2,arg3));
            }
            return true;
        }
        public static bool TryRequestAll<T1, T2, T3, T4,T5>(this UnitMessageDispatcherContanier container, T1 arg1, T2 arg2, T3 arg3,T4 arg4, out UnitList<T5> result)
        {
            var events = Framework.Message.GetDispatcher(container.Value.TypeValue).Value.Get(container.Value.Receiver, typeof(Func<T1>));
            container.Dispose();
            result = new();
            if (events == null || events.Count == 0) return false;

            foreach (var func in events)
            {
                result.Value.Add((func as Func<T1, T2, T3, T4,T5>).Invoke(arg1, arg2, arg3,arg4));
            }
            return true;
        }
        public static bool TryRequestAll<T1, T2, T3, T4, T5,T6>(this UnitMessageDispatcherContanier container, T1 arg1, T2 arg2, T3 arg3, T4 arg4,T5 arg5, out UnitList<T6> result)
        {
            var events = Framework.Message.GetDispatcher(container.Value.TypeValue).Value.Get(container.Value.Receiver, typeof(Func<T1>));
            container.Dispose();
            result = new();
            if (events == null || events.Count == 0) return false;

            foreach (var func in events)
            {
                result.Value.Add((func as Func<T1, T2, T3, T4, T5,T6>).Invoke(arg1, arg2, arg3, arg4,arg5));
            }
            return true;
        }
    }
}
