// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Foundations.Attributes.Exceptions
{
    internal class NullPropertyInfoException : Xeption
    {
        public NullPropertyInfoException(Exception innerException)
            : base(message: "PropertyInfo is null, fix errors and try again.", innerException)
        { }
    }
}
