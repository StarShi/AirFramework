﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFramework
{
    public class Entity : Unit,IMessageReceiver,IMessageSender
    {

        

        public Entity() 
        { 

        }
        protected override void OnDispose()
        {
            
        }
    }
}
