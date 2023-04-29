﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.Reflection.Models.Foundations.Attributes.Exceptions
{
    public class AttributeValidationException : Xeption
    {
        public AttributeValidationException(Xeption innerException)
            : base(message: "Attribute validation error occurred, fix errors and try again.", innerException)
        { }
    }
}
