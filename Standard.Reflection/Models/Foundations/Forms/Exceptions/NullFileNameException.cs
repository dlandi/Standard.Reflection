// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Foundations.Forms.Exceptions
{
    public class NullFileNameException : Xeption
    {
        public NullFileNameException(Exception innerException)
            : base(message: "File Name is null or white space, fix errors and try again.", innerException)
        { }
    }
}
