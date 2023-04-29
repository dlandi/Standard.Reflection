﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.Reflection.Models.Foundations.Types.Exceptions
{
    public class TypeServiceException : Xeption
    {
        public TypeServiceException(Xeption innerException)
            : base(message: "Type service error occurred, contact support.", innerException)
        { }
    }
}
