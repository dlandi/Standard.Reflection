// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.Reflection.Models.Orchestrations.Properties.Exceptions
{
    public class PropertyOrchestrationException : Xeption
    {
        public PropertyOrchestrationException(Xeption innerException)
            : base(message: "Property service error occurred, contact support.", innerException)
        { }
    }
}
