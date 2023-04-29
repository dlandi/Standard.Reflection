// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;
using Standard.Reflection.Brokers.MultipartFormDataContents;

namespace Standard.Reflection.Services.Foundations.Forms
{
    internal class FormService : IFormService
    {
        private readonly IMultipartFormDataContentBroker multipartFormDataContentBroker;

        public FormService(IMultipartFormDataContentBroker multipartFormDataContentBroker) =>
            this.multipartFormDataContentBroker = multipartFormDataContentBroker;

        public MultipartFormDataContent AddByteContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content, string name) =>
            this.multipartFormDataContentBroker.AddByteContent(multipartFormDataContent, content, name);

        public MultipartFormDataContent AddStringContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name) =>
            this.multipartFormDataContentBroker.AddStringContent(multipartFormDataContent, content, name);

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream stream, string name) =>
            throw new System.NotImplementedException();

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            string content, string name, string fileName) =>
            throw new System.NotImplementedException();
    }
}
