// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;

namespace Standard.Reflection.Brokers.FormContents
{
    internal class MultipartFormDataContentBroker : IMultipartFormDataContentBroker
    {
        public MultipartFormDataContent AddStringContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name)
        {
            var stringContent = new StringContent(content);
            multipartFormDataContent.Add(stringContent, name);

            return multipartFormDataContent;
        }

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream stream,
            string name)
        {
            var streamContent = new StreamContent(stream);
            multipartFormDataContent.Add(streamContent, name);

            return multipartFormDataContent;
        }

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name,
            string fileName)
        {
            var stringContent = new StringContent(content);
            multipartFormDataContent.Add(stringContent, name, fileName);

            return multipartFormDataContent;
        }
    }
}
