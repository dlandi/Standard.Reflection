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
    }
}
