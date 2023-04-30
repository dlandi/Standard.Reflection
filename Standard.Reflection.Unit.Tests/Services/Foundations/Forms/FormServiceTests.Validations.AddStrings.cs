// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Moq;
using System.Net.Http;
using System;
using Xunit;
using Standard.Reflection.Models.Foundations.Forms.Exceptions;
using FluentAssertions;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Fact]
        public void ShouldThrowFormValidationExceptionNameOnAddStringContentIfMultipartFormDataContentIsNull()
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent = CreateNullMultipartFormDataContent();
            string someContent = CreateRandomString();
            string randomName = CreateRandomString();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(nameof(MultipartFormDataContent));

            var nullMultipartFormDataContentException =
                new NullMultipartFormDataContentException(argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(nullMultipartFormDataContentException);

            // when
            Action addByteContentAction =
                () => formService.AddStringContent(nullMultipartFormDataContent, someContent, randomName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStringContent(nullMultipartFormDataContent, someContent, randomName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(data: null)]
        [InlineData(data: "")]
        [InlineData(data: "   ")]
        public void ShouldThrowFormValidationExceptionOnAddStringContentIfNameIsNullOrWhiteSpace(string invalidName)
        {
            // given
            var someMultipartFormDataContent = new MultipartFormDataContent();
            string someContent = CreateRandomString();
            string inputContent = someContent;

            var argumentNullException =
                new ArgumentNullException(paramName: "name");

            var nullNameException =
                new NullNameException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullNameException);

            // when
            Action addByteContentAction =
                () => formService.AddStringContent(someMultipartFormDataContent, inputContent, invalidName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStringContent(someMultipartFormDataContent, inputContent, invalidName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
