// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations
{
    public partial class TypeServiceTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldRetrieveType(Type expectedType)
        {
            // given
            object someObject = new object();
            object inputObject = someObject;

            this.typeBrokerMock.Setup(broker =>
                broker.GetType(inputObject))
                    .Returns(expectedType);

            // when
            Type actualType = this.typeService.RetrieveType(inputObject);

            // then
            actualType.Should().BeSameAs(expectedType);

            this.typeBrokerMock.Verify(broker =>
                broker.GetType(inputObject),
                    Times.Once());

            this.typeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
