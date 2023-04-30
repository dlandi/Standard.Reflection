// ----------------------------------------------------------------------------------
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
            byte[] content,
            string name) =>
        TryCatch(() =>
        {
            ValidateMultipartFormDataContentIsNotNull(multipartFormDataContent);
            ValidateByteContentIsNotNull(content);
            ValidateNameIsNotNullOrWhiteSpace(name);

            return this.multipartFormDataContentBroker.AddByteContent(multipartFormDataContent, content, name);
        });

        public MultipartFormDataContent AddByteContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name,
            string fileName) =>
        TryCatch(() =>
        {
            ValidateMultipartFormDataContentIsNotNull(multipartFormDataContent);
            ValidateByteContentIsNotNull(content);
            ValidateNameIsNotNullOrWhiteSpace(name);
            ValidateFileNameIsNotNullOrWhiteSpace(fileName);

            return this.multipartFormDataContentBroker.AddByteContent(multipartFormDataContent, content, name, fileName);
        });

        public MultipartFormDataContent AddStringContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name) =>
        TryCatch(() =>
        {
            ValidateMultipartFormDataContentIsNotNull(multipartFormDataContent);
            ValidateStringContentIsNotNullOrWhiteSpace(content);
            ValidateNameIsNotNullOrWhiteSpace(name);

            MultipartFormDataContent returnedMultipartFormDataContent =
                this.multipartFormDataContentBroker.AddStringContent(multipartFormDataContent, content, name);

            return returnedMultipartFormDataContent;
        });

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream content,
            string name) =>
        TryCatch(() =>
        {
            ValidateMultipartFormDataContentIsNotNull(multipartFormDataContent);
            ValidateStreamContentIsNotNull(content);

            MultipartFormDataContent returnedMultipartFormDataContent =
                this.multipartFormDataContentBroker.AddStreamContent(multipartFormDataContent, content, name);
            
            return returnedMultipartFormDataContent;
        });

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream content,
            string name,
            string fileName) =>
        TryCatch(() =>
        {
            ValidateMultipartFormDataContentIsNotNull(multipartFormDataContent);
            ValidateStreamContentIsNotNull(content);

            MultipartFormDataContent returnedMultipartFormDataContent =
                this.multipartFormDataContentBroker.AddStreamContent(multipartFormDataContent, content, name, fileName);

            return returnedMultipartFormDataContent;
        });
    }
}
