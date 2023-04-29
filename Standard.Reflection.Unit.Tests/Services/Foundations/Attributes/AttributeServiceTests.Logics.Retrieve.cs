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
            SomeAttribute someAttribute = new SomeAttribute();
            SomeAttribute expectedSomeAttribute = someAttribute;

            this.attributeBrokerMock.Setup(broker =>
                broker.GetPropertyCustomAttribute<SomeAttribute>(It.IsAny<PropertyInfo>(), It.IsAny<bool>()))
                    .Returns(someAttribute);

            // when
            SomeAttribute actualSomeAttribute =
                this.attributeService.RetrieveAttribute<SomeAttribute>(It.IsAny<PropertyInfo>());

            // then
            actualSomeAttribute.Should().BeSameAs(expectedSomeAttribute);

            this.attributeBrokerMock.Verify(broker =>
                broker.GetPropertyCustomAttribute<SomeAttribute>(It.IsAny<PropertyInfo>(), It.IsAny<bool>()),
                    Times.Once());

            this.attributeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
