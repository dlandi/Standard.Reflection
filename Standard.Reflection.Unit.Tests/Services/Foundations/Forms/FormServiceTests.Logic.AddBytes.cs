// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using FluentAssertions;
using Moq;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Fact]
        public void ShouldAddByteContentWithNoFileName()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            byte[] someContent = CreateSomeByteArrayContent();
            string randomName = CreateRandomString();

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddByteContent(multipartFormDataContent, someContent, randomName))
                    .Returns(expectedMultipartFormDataContent);

            // when
            var actualMultipartFormDataContent =
                formService.AddByteContent(multipartFormDataContent, someContent, randomName);

            // then
            actualMultipartFormDataContent.Should()
                .BeSameAs(expectedMultipartFormDataContent);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(multipartFormDataContent, someContent, randomName),
                    Times.Once);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldAddByteContentWithFileName()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            byte[] someContent = CreateSomeByteArrayContent();
            string randomName = CreateRandomString();
            string randomFileName = CreateRandomString();

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddByteContent(multipartFormDataContent, someContent, randomName, randomFileName))
                    .Returns(expectedMultipartFormDataContent);

            // when
            var actualMultipartFormDataContent =
                formService.AddByteContent(multipartFormDataContent, someContent, randomName, randomFileName);

            // then
            actualMultipartFormDataContent.Should()
                .BeSameAs(expectedMultipartFormDataContent);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(multipartFormDataContent, someContent, randomName, randomFileName),
                    Times.Once);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
