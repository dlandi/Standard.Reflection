// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Foundations.Forms.Exceptions
{
    public class NullContentException : Xeption
    {
        public NullContentException(Exception innerException)
            : base(message: "Content is null, fix errors and try again.", innerException)
        { }
    }
}
