// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using FluentAssertions;
using Moq;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Attributes
{
    public partial class AttributeServiceTests
    {
        [Fact]
        public void ShouldRetrieveAttribute()
        {
            // given
            TestAttribute someAttribute = new TestAttribute();
            TestAttribute expectedSomeAttribute = someAttribute;

            this.attributeBrokerMock.Setup(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(It.IsAny<PropertyInfo>(), It.IsAny<bool>()))
                    .Returns(someAttribute);

            // when
            TestAttribute actualSomeAttribute =
                this.attributeService.RetrieveAttribute<TestAttribute>(It.IsAny<PropertyInfo>());

            // then
            actualSomeAttribute.Should().BeSameAs(expectedSomeAttribute);

            this.attributeBrokerMock.Verify(broker =>
                broker.GetPropertyCustomAttribute<TestAttribute>(It.IsAny<PropertyInfo>(), It.IsAny<bool>()),
                    Times.Once());

            this.attributeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
