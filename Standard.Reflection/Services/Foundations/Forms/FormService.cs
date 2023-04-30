﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;
using Standard.Reflection.Brokers.MultipartFormDataContents;

namespace Standard.Reflection.Services.Foundations.Forms
{
    internal partial class FormService : IFormService
    {
        private readonly IMultipartFormDataContentBroker multipartFormDataContentBroker;

        public FormService(IMultipartFormDataContentBroker multipartFormDataContentBroker) =>
            this.multipartFormDataContentBroker = multipartFormDataContentBroker;

        public MultipartFormDataContent AddByteContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content, string name) =>
        TryCatch(() =>
        {
            ValidateMultipartFormDataContentIsNotNull(multipartFormDataContent);

            return this.multipartFormDataContentBroker.AddByteContent(multipartFormDataContent, content, name);
        });

        public MultipartFormDataContent AddByteContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content, string name, string fileName) =>
            this.multipartFormDataContentBroker.AddByteContent(multipartFormDataContent, content, name, fileName);

        public MultipartFormDataContent AddStringContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name) =>
            this.multipartFormDataContentBroker.AddStringContent(multipartFormDataContent, content, name);

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream stream, string name) =>
            this.multipartFormDataContentBroker.AddStreamContent(multipartFormDataContent, stream, name);

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream stream, string name, string fileName) =>
            this.multipartFormDataContentBroker.AddStreamContent(multipartFormDataContent, stream, name, fileName);
    }
}
