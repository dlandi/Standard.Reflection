// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.Reflection.Models.Foundations.Attributes.Exceptions
{
    public class AttributeServiceException : Xeption
    {
        public AttributeServiceException(Xeption innerException)
            : base(message: "Attribute service error occurred, contact support.", innerException)
        { }
    }
}
