// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Moq;
using Standard.Reflection.Models.Foundations.Forms.Exceptions;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Theory]
        [MemberData(nameof(GetAddExceptions))]
        public void ShouldThrowDependencyValidationExceptionOnAddIfDependencyValidationExceptionErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStreamContent();
            string randomName = CreateRandomString();

            var failedFormServiceException = new FailedFormServiceException(dependencyValidationException);

            var expectedFormDependencyValidationException =
                new FormDependencyValidationException(failedFormServiceException);

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(), It.IsAny<Stream>(), It.IsAny<string>()))
                    .Throws(dependencyValidationException);

            // when
            Action retrieveAttributeAction =
                () => this.formService.AddStreamContent(multipartFormDataContent, someContent, randomName);

            FormDependencyValidationException actualFormDependencyValidationException =
                  Assert.Throws<FormDependencyValidationException>(retrieveAttributeAction);

            // then
            actualFormDependencyValidationException.Should()
                .BeEquivalentTo(expectedFormDependencyValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(), It.IsAny<Stream>(), It.IsAny<string>()),
                    Times.Once());

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

    }
}


//// given
//var multipartFormDataContent = new MultipartFormDataContent();
//var expectedMultipartFormDataContent = new MultipartFormDataContent();
//Stream someContent = CreateSomeStreamContent();
//string randomName = CreateRandomString();

//this.multipartFormDataContentBroker.Setup(broker =>
//    broker.AddStreamContent(multipartFormDataContent, someContent, randomName))
//        .Returns(expectedMultipartFormDataContent);

//// when
//var actualMultipartFormDataContent =
//    formService.AddStreamContent(multipartFormDataContent, someContent, randomName);

//// then
//actualMultipartFormDataContent.Should()
//    .BeSameAs(expectedMultipartFormDataContent);

//this.multipartFormDataContentBroker.Verify(broker =>
//    broker.AddStreamContent(multipartFormDataContent, someContent, randomName),
//        Times.Once);

//this.multipartFormDataContentBroker.VerifyNoOtherCalls();
