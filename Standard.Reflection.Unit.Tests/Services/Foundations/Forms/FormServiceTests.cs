﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;
using System.Text;
using Moq;
using Standard.Reflection.Brokers.MultipartFormDataContents;
using Standard.Reflection.Services.Foundations.Forms;
using Tynamix.ObjectFiller;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        private readonly Mock<IMultipartFormDataContentBroker> multipartFormDataContentBroker;
        private readonly IFormService formService;

        public FormServiceTests()
        {
            this.multipartFormDataContentBroker = new Mock<IMultipartFormDataContentBroker>();
            this.formService = new FormService(multipartFormDataContentBroker.Object);
        }
        private static MultipartFormDataContent CreateNullMultipartFormDataContent() => null;

        private static byte[] CreateSomeByteArrayContent() =>
            Encoding.UTF8.GetBytes(CreateRandomString());

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static MemoryStream CreateSomeStreamContent() =>
            new MemoryStream();

        private static MemoryStream CreateSomeStream() =>
            new MemoryStream();

    }
}