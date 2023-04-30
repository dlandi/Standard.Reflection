// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using FluentAssertions;
using Moq;
using Standard.Reflection.Models.Foundations.Forms.Exceptions;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Fact]
        public void ShouldThrowFormValidationExceptionWithNoFileNameOnAddStreamContentIfMultipartFormDataContentIsNull()
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent = CreateNullMultipartFormDataContent();
            Stream someContent = CreateSomeStream();
            string randomName = CreateRandomString();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(nameof(MultipartFormDataContent));

            var nullMultipartFormDataContentException =
                new NullMultipartFormDataContentException(argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(nullMultipartFormDataContentException);

            // when
            Action addByteContentAction =
                () => formService.AddStreamContent(nullMultipartFormDataContent, someContent, randomName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(nullMultipartFormDataContent, someContent, randomName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormValidationExceptionWithFileNameOnAddStreamContentIfMultipartFormDataContentIsNull()
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent = CreateNullMultipartFormDataContent();
            Stream someContent = CreateSomeStream();
            string randomName = CreateRandomString();
            string randomFileName = CreateRandomString();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(nameof(MultipartFormDataContent));

            var nullMultipartFormDataContentException =
                new NullMultipartFormDataContentException(argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(nullMultipartFormDataContentException);

            // when
            Action addByteContentAction =
                () => formService.AddStreamContent(nullMultipartFormDataContent, someContent, randomName, randomFileName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(nullMultipartFormDataContent, someContent, randomName, randomFileName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormValidationExceptionOnAddStreamContentWithNoFileNameIfStreamContentIsNull()
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            string name = CreateRandomString();
            Stream nullContent = null;

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: "content");

            var nullContentException =
                new NullContentException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullContentException);

            // when
            Action addByteContentAction =
                () => formService.AddStreamContent(nullMultipartFormDataContent, nullContent, name);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(nullMultipartFormDataContent, nullContent, name),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormValidationExceptionOnAddStreamContentWithFileNameIfStreamContentIsNull()
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            string name = CreateRandomString();
            string randomFileName = CreateRandomString();
            Stream nullContent = null;

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: "content");

            var nullContentException =
                new NullContentException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullContentException);

            // when
            Action addByteContentAction =
                () => formService.AddStreamContent(nullMultipartFormDataContent, nullContent, name, randomFileName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(nullMultipartFormDataContent, nullContent, name, randomFileName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(data: null)]
        [InlineData(data: "")]
        [InlineData(data: "   ")]
        public void ShouldThrowFormValidationExceptionWithNoFileNameOnAddStreamContentIfNameIsNullOrWhiteSpace(string invalidName)
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStream();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: nameof(MultipartFormDataContent));

            var nullNameException =
                new NullNameException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullNameException);

            // when
            Action addByteContentAction =
                () => formService.AddStreamContent(nullMultipartFormDataContent, someContent, invalidName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(nullMultipartFormDataContent, someContent, invalidName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(data: null)]
        [InlineData(data: "")]
        [InlineData(data: "   ")]
        public void ShouldThrowFormValidationExceptionWithFileNameOnAddStreamContentIfNameIsNullOrWhiteSpace(string invalidName)
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            string fileName = CreateRandomString();
            Stream someContent = CreateSomeStream();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: nameof(MultipartFormDataContent));

            var nullNameException =
                new NullNameException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullNameException);

            // when
            Action addByteContentAction =
                () => formService.AddStreamContent(nullMultipartFormDataContent, someContent, invalidName, fileName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(nullMultipartFormDataContent, someContent, invalidName, fileName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
