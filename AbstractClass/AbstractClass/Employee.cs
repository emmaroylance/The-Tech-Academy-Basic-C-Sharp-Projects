﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public class Employee : Person
    {
        public int Id { get; set; }
        public override void SayName()
        {
            base.SayName();
        }

    }
}
