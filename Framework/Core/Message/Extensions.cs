﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFramework
{
    public static partial class Extensions
    {
        public static IMessageManager Message(this IMessageSender sender)
        {
            return Framework.Message;
        }

       

    }
}
