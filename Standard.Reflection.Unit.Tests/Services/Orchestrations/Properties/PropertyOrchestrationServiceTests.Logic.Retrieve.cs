// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Orchestrations.Properties
{
    public partial class PropertyOrchestrationServiceTests
    {
        [Fact]
        public void ShouldRetrieveProperties()
        {
            // given
            object someObject = new object();
            object inputObject = someObject;
            Type someType = typeof(object);
            PropertyInfo[] randomProperties = CreateRandomProperties();
            PropertyInfo[] returnedProperties = randomProperties;
            PropertyInfo[] expectedProperties = returnedProperties;
            var sequence = new MockSequence();

            this.typeServiceMock.InSequence(sequence).Setup(service =>
                service.RetrieveType(inputObject))
                    .Returns(someType);

            this.propertyServiceMock.InSequence(sequence).Setup(service =>
                service.RetrieveProperties(someType))
                    .Returns(returnedProperties);

            // when
            var actualProperties =
                this.propertyOrchestrationService.RetrieveProperties(inputObject);

            // then
            actualProperties.Should().BeEquivalentTo(expectedProperties);

            this.typeServiceMock.Verify(service =>
                service.RetrieveType(inputObject),
                    Times.Once());

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(someType),
                    Times.Once());

            this.typeServiceMock.VerifyNoOtherCalls();
            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
