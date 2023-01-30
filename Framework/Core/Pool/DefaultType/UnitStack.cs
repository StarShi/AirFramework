﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFramework
{
    public class UnitStack<T> : PoolableObject<Stack<T>> 
    {
        public override void OnAllocate()
        {
            
        }

        public override void OnRecycle()
        {
            Value.Clear();
        }
    }
}
