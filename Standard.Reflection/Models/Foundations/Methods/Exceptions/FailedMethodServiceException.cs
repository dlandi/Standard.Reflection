// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Foundations.Methods.Exceptions
{
    public class FailedMethodServiceException : Xeption
    {
        public FailedMethodServiceException(Exception innerException)
        : base(message: "Failed Method Service Exception occurred, please contact support for assistance.", innerException)
        { }
    }
}
