// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.Reflection.Models.Foundations.Methods.Exceptions
{
    public class MethodServiceException : Xeption
    {
        public MethodServiceException(Xeption innerException)
            : base(message: "Method service error occurred, contact support.", innerException)
        { }
    }
}
