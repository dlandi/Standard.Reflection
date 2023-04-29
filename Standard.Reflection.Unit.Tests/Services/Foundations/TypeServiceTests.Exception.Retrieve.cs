// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Standard.Reflection.Models.Foundations.Types.Exceptions;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations
{
    public partial class TypeServiceTests
    {
        [Fact]
        public void ShouldThrowTypeServiceExceptionIfExceptionOccurs()
        {
            // given
            var someObject = new object();
            var someException = new Exception();
            var failedTypeServiceException = new FailedTypeServiceException(someException);
            var expectedTypeServiceException = new TypeServiceException(failedTypeServiceException);

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(It.IsAny<object>()))
                    .Throws(someException);

            // when
            Action retrieveTypeAction = () => this.typeService.RetrieveType(someObject);

            TypeServiceException actualTypeServiceException =
                Assert.Throws<TypeServiceException>(retrieveTypeAction);

            // then
            actualTypeServiceException.Should().BeEquivalentTo(expectedTypeServiceException);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(It.IsAny<object>()),
                    Times.Once);

            this.typeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
