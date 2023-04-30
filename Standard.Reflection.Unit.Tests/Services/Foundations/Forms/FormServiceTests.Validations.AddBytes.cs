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
        public void ShouldThrowFormValidationExceptionOnAddByteContentIfMultipartFormDataContentIsNull()
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent = CreateNullMultipartFormDataContent();
            byte[] someContent = CreateSomeByteArrayContent();
            string randomName = CreateRandomString();

            ArgumentNullException argumentNullException = 
                new ArgumentNullException(nameof(MultipartFormDataContent));

            var nullMultipartFormDataContentException =
                new NullMultipartFormDataContentException(argumentNullException);

            var expecteedFormValidationException =
                new FormValidationException(nullMultipartFormDataContentException);

            // when
            Action addByteContentAction = 
                () => formService.AddByteContent(nullMultipartFormDataContent, someContent, randomName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expecteedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteContent(nullMultipartFormDataContent, someContent, randomName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
