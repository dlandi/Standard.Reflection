// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.Reflection.Models.Foundations.Forms.Exceptions
{
    public class NullMultipartFormDataContentException : Xeption
    {
        public NullMultipartFormDataContentException(Exception innerException)
            : base(message: "MultipartFormDataContent is null, fix errors and try again.", innerException)
        { }
    }
}
