// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Methods
{
    public partial class MethodServiceTests
    {
        [Fact]
        public void ShouldRetrieveMethods()
        {
            // given
            MethodInfo[] randomMethodInfos = CreateRandomMethods();
            MethodInfo[] returnedMethodInfos = randomMethodInfos;
            MethodInfo[] expectedMethodInfos = returnedMethodInfos;

            this.methodBrokerMock.Setup(broker =>
                broker.GetMethods(It.IsAny<Type>()))
                    .Returns(returnedMethodInfos);

            // when
            var actualMethodInfos =
                this.methodService.RetrieveMethods(typeof(MethodServiceTests));

            // then
            actualMethodInfos.Should().BeEquivalentTo(expectedMethodInfos);

            this.methodBrokerMock.Verify(broker =>
                broker.GetMethods(It.IsAny<Type>()),
                    Times.Once());

            this.methodBrokerMock.VerifyNoOtherCalls();
        }
    }
}
