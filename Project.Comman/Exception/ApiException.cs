﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.CrossCutting.Comman.Exception
{
    public class ApiException : IOException
    {
        public ApiException(string message) : base(message) { }
    }
}
