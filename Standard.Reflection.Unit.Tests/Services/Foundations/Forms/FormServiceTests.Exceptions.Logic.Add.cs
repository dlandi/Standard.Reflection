// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using FluentAssertions;
using Moq;
using Standard.Reflection.Brokers.MultipartFormDataContents;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Fact]
        public void ShouldAddByteContent()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var content = new byte[] { 1, 2, 3 };
            string name = "test";
            var expectedMultipartFormDataContent = new MultipartFormDataContent();

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddByteContent(multipartFormDataContent, content, name))
                    .Returns(expectedMultipartFormDataContent);

            // when
            var actualMultipartFormDataContent = formService.AddByteContent(multipartFormDataContent, content, name);

            // then
            actualMultipartFormDataContent.Should()
                .BeSameAs(expectedMultipartFormDataContent);

            this.multipartFormDataContentBroker.Verify(broker => 
                broker.AddByteContent(multipartFormDataContent, content, name),
                    Times.Once);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
