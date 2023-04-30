// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using Standard.Reflection.Models.Foundations.Forms.Exceptions;

namespace Standard.Reflection.Services.Foundations.Forms
{
    internal partial class FormService
    {
        private delegate MultipartFormDataContent ReturningMultipartFormDataContentFunction();

        private MultipartFormDataContent TryCatch(ReturningMultipartFormDataContentFunction returningMultipartFormDataContentFunction)
        {
            try
            {
                return returningMultipartFormDataContentFunction();
            }
            catch(NullMultipartFormDataContentException nullMultipartFormDataContentException)
            {
                var formValidationException =
                    new FormValidationException(nullMultipartFormDataContentException);

                throw formValidationException;
            }
        }
    }
}
