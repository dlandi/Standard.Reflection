// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Standard.Reflection.Models.Foundations.Methods.Exceptions;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Methods
{
    public partial class MethodServiceTests
    {
        [Fact]
        public void ShouldThrowMethodServiceExceptionIfExceptionOccurs()
        {
            // given
            var someObject = new object();
            var someException = new Exception();
            var failedMethodServiceException = new FailedMethodServiceException(someException);
            var expectedMethodServiceException = new MethodServiceException(failedMethodServiceException);

            this.methodBrokerMock.Setup(broker =>
                broker.GetMethods(It.IsAny<Type>()))
                    .Throws(someException);

            // when
            Action retrieveTypeAction = () => this.methodService.RetrieveMethods(typeof(MethodServiceTests));

            MethodServiceException actualMethodServiceException =
                Assert.Throws<MethodServiceException>(retrieveTypeAction);

            // then
            actualMethodServiceException.Should().BeEquivalentTo(expectedMethodServiceException);

            this.methodBrokerMock.Verify(broker =>
                broker.GetMethods(It.IsAny<Type>()),
                    Times.Once);

            this.methodBrokerMock.VerifyNoOtherCalls();
        }
    }
}
