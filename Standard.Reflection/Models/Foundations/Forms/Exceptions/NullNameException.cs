// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Foundations.Forms.Exceptions
{
    public class NullNameException : Xeption
    {
        public NullNameException(Exception innerException)
            : base(message: "Name is null or white space, fix errors and try again.", innerException)
        { }
    }
}
