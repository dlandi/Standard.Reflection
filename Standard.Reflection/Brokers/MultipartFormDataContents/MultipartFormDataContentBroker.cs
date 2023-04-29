// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;

namespace Standard.Reflection.Brokers.MultipartFormDataContents
{
    internal class MultipartFormDataContentBroker : IMultipartFormDataContentBroker
    {
        public MultipartFormDataContent AddByteContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name)
        {
            var byteContent = new ByteArrayContent(content);
            multipartFormDataContent.Add(byteContent);

            return multipartFormDataContent;
        }
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
            Stream stream,
            string name,
            string fileName)
        {
            var streamContent = new StreamContent(stream);
            multipartFormDataContent.Add(streamContent, name, fileName);

            return multipartFormDataContent;
        }
    }
}
