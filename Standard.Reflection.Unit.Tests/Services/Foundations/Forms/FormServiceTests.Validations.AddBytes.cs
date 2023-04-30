// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Moq;
using Standard.Reflection.Models.Foundations.Forms.Exceptions;
using System;
using System.Net.Http;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Fact]
        public void ShouldThrowFormValidationExceptionWithNoFileNameOnAddByteContentIfMultipartFormDataContentIsNull()
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent = CreateNullMultipartFormDataContent();
            byte[] someContent = CreateSomeByteArrayContent();
            string randomName = CreateRandomString();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(nameof(MultipartFormDataContent));

            var nullMultipartFormDataContentException =
                new NullMultipartFormDataContentException(argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(nullMultipartFormDataContentException);

            // when
            Action addByteContentAction =
                () => formService.AddByteContent(nullMultipartFormDataContent, someContent, randomName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(nullMultipartFormDataContent, someContent, randomName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormValidationExceptionWithFileNameOnAddByteContentIfMultipartFormDataContentIsNull()
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent = CreateNullMultipartFormDataContent();
            byte[] someContent = CreateSomeByteArrayContent();
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
                () => formService.AddByteContent(nullMultipartFormDataContent, someContent, randomName, randomFileName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(nullMultipartFormDataContent, someContent, randomName, randomFileName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(data: null)]
        [InlineData(data: "")]
        [InlineData(data: "   ")]
        public void ShouldThrowFormValidationExceptionWithNoFileNameOnAddByteContentIfNameIsNullOrWhiteSpace(string invalidName)
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            byte[] someContent = CreateSomeByteArrayContent();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: nameof(MultipartFormDataContent));

            var nullNameException =
                new NullNameException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullNameException);

            // when
            Action addByteContentAction =
                () => formService.AddByteContent(nullMultipartFormDataContent, someContent, invalidName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(nullMultipartFormDataContent, someContent, invalidName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(data: null)]
        [InlineData(data: "")]
        [InlineData(data: "   ")]
        public void ShouldThrowFormValidationExceptionWithFileNameOnAddByteContentIfNameIsNullOrWhiteSpace(string invalidName)
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            string fileName = CreateRandomString();
            byte[] someContent = CreateSomeByteArrayContent();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: nameof(MultipartFormDataContent));

            var nullNameException =
                new NullNameException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullNameException);

            // when
            Action addByteContentAction =
                () => formService.AddByteContent(nullMultipartFormDataContent, someContent, invalidName, fileName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(nullMultipartFormDataContent, someContent, invalidName, fileName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(data: null)]
        [InlineData(data: "")]
        [InlineData(data: "   ")]
        public void ShouldThrowFormValidationExceptionOnAddByteContentIfFileNameIsNullOrWhiteSpace(string invalidFileName)
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            string name = CreateRandomString();
            byte[] someContent = CreateSomeByteArrayContent();

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: nameof(MultipartFormDataContent));

            var nullFileNameException =
                new NullFileNameException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullFileNameException);

            // when
            Action addByteContentAction =
                () => formService.AddByteContent(nullMultipartFormDataContent, someContent, name, invalidFileName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(nullMultipartFormDataContent, someContent, name, invalidFileName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormValidationExceptionOnAddByteContentWithNoFileNameIfByteContentIsNull()
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            string name = CreateRandomString();
            byte[] nullContent = null;

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: "content");

            var nullContentException =
                new NullContentException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullContentException);

            // when
            Action addByteContentAction =
                () => formService.AddByteContent(nullMultipartFormDataContent, nullContent, name);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(nullMultipartFormDataContent, nullContent, name),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormValidationExceptionOnAddByteContentWithFileNameIfByteContentIsNull()
        {
            // given
            var nullMultipartFormDataContent = new MultipartFormDataContent();
            string name = CreateRandomString();
            string randomFileName = CreateRandomString();
            byte[] nullContent = null;

            ArgumentNullException argumentNullException =
                new ArgumentNullException(paramName: "content");

            var nullContentException =
                new NullContentException(innerException: argumentNullException);

            var expectedFormValidationException =
                new FormValidationException(innerException: nullContentException);

            // when
            Action addByteContentAction =
                () => formService.AddByteContent(nullMultipartFormDataContent, nullContent, name, randomFileName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(nullMultipartFormDataContent, nullContent, name, randomFileName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
