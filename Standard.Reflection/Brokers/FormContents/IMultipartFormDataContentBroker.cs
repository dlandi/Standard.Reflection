// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;

namespace Standard.Reflection.Brokers.FormContents
{
    internal interface IMultipartFormDataContentBroker
    {
        MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream stream,
            string name);

        MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name,
            string fileName);

        MultipartFormDataContent AddStringContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name);
    }
}
