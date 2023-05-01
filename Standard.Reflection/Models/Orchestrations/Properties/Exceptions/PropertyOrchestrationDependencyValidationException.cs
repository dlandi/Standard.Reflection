// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Orchestrations.Properties.Exceptions
{
    public class PropertyOrchestrationDependencyValidationException : Xeption
    {
        public PropertyOrchestrationDependencyValidationException(Exception innerException)
            : base(message: "Property dependency validation error occurred, fix errors and try again.", innerException)
        { }
    }
}
