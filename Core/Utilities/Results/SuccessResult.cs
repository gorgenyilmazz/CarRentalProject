﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result, IResult
    {
        public SuccessResult(bool success, string message) : base(true, message)
        {

        }
        public SuccessResult(bool success) : base(true)
        {

        }


        public bool Success { get; }
        public string Message { get; }
    }
}
