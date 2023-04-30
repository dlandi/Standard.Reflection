﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;

namespace Standard.Reflection.Services.Foundations.Forms
{
    internal interface IFormService
    {
        MultipartFormDataContent AddByteContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name);

        MultipartFormDataContent AddByteContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name,
            string fileName);

        MultipartFormDataContent AddStringContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name);

        MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream content,
            string name);

        MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream content,
            string name,
            string fileName);
    }
}
