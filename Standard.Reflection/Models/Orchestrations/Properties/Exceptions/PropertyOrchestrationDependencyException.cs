// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Orchestrations.Properties.Exceptions
{
    public class PropertyOrchestrationDependencyException : Xeption
    {
        public PropertyOrchestrationDependencyException(Exception innerException)
            : base(message: "Property dependency error occurred, fix errors and try again.", innerException)
        { }
    }
}
