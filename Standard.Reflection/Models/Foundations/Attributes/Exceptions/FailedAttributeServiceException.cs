﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Foundations.Properties.Exceptions
{
    public class FailedAttributeServiceException : Xeption
    {
        public FailedAttributeServiceException(Exception innerException)
        : base(message: "Failed Attribute Service Exception occurred, please contact support for assistance.",
              innerException)
        { }
    }
}
