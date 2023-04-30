// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
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

        private static void ValidateNameIsNotNullOrWhiteSpace(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                var argumentNullException = new ArgumentNullException(nameof(name));

                var nullNameException =
                    new NullNameException(innerException: argumentNullException);

                throw nullNameException;
            }
        }

        private static void ValidateFileNameIsNotNullOrWhiteSpace(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                var argumentNullException = new ArgumentNullException(nameof(fileName));

                var nullNameException =
                    new NullFileNameException(innerException: argumentNullException);

                throw nullNameException;
            }
        }

        private static void ValidateByteContentIsNotNull(byte[] content)
        {
            if (content == null)
            {
                var argumentNullException = new ArgumentNullException(nameof(content));

                var nullContentException =
                    new NullContentException(innerException: argumentNullException);

                throw nullContentException;
            }
        }
        private static void ValidateStringContentIsNotNullOrWhiteSpace(string content)
        {
            if (String.IsNullOrWhiteSpace(content))
            {
                var argumentNullException = new ArgumentNullException(nameof(content));

                var nullNameException =
                    new NullContentException(innerException: argumentNullException);

                throw nullNameException;
            }
        }
        
        private static void ValidateStreamContentIsNotNull(Stream content)
        {
            if (content == null)
            {
                var argumentNullException = new ArgumentNullException(nameof(content));

                var nullContentException =
                    new NullContentException(innerException: argumentNullException);

                throw nullContentException;
            }
        }
    }
}
