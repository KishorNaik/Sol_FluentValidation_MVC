﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Models.ChildPoco
{
    public class ParentModel
    {
        public String ParentBirtday { get; set; }

        public ChildModel Child { get; set; }
    }
}
