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
        public void ShouldThrowFormDependencyValidationExceptionOnAddIfDependencyValidationExceptionErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStreamContent();
            string randomName = CreateRandomString();

            var formDependencyValidationException =
                new FormDependencyValidationException(dependencyValidationException);

            var expectedFormValidationException =
                new FormValidationException(formDependencyValidationException);

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(), It.IsAny<Stream>(), It.IsAny<string>()))
                    .Throws(dependencyValidationException);

            // when
            Action retrieveAttributeAction =
                () => this.formService.AddStreamContent(multipartFormDataContent, someContent, randomName);

            FormValidationException actualFormValidationException =
                  Assert.Throws<FormValidationException>(retrieveAttributeAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

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
