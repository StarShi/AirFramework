﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFramework
{
    public interface IMessage
    {

    }
    public interface IMessage<out TResponse> 
    {

    }
}