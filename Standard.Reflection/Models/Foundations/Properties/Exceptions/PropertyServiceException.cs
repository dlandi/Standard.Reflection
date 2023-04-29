﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.Reflection.Models.Foundations.Properties.Exceptions
{
    public class PropertyServiceException : Xeption
    {
        public PropertyServiceException(Xeption innerException)
            : base(message: "Property service error occurred, contact support.", innerException)
        { }
    }
}
