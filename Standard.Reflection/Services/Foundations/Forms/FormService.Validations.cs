// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using Standard.Reflection.Models.Foundations.Forms.Exceptions;

namespace Standard.Reflection.Services.Foundations.Forms
{
    internal partial class FormService
    {
        private static void ValidateMultipartFormDataContentIsNotNull(MultipartFormDataContent multipartFormDataContent)
        {
            if (multipartFormDataContent == null)
            {
                var argumentNullException = new ArgumentNullException(nameof(multipartFormDataContent));

                var nullMultipartFormDataContentException =
                    new NullMultipartFormDataContentException(innerException: argumentNullException);

                throw nullMultipartFormDataContentException;
            }
        }
    }
}
