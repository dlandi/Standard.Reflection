// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Orchestrations.Properties.Exceptions
{
    public class FailedPropertyOrchestrationException : Xeption
    {
        public FailedPropertyOrchestrationException(Exception innerException)
            : base(message: "Failed Property Orchestration Service Exception occurred, please contact support for assistance.",
                  innerException)
        { }
    }
}
