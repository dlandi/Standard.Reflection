﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Orchestrations.Properties.Exceptions
{
    public class NullObjectException : Xeption
    {
        public NullObjectException(Exception innerException)
            : base(message: "Object is null, fix errors and try again.", innerException)
        { }
    }
}
