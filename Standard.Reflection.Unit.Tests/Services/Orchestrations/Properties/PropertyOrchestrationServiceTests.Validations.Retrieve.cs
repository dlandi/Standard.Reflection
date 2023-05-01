// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using Standard.Reflection.Models.Orchestrations.Properties;
using Standard.Reflection.Models.Orchestrations.Properties.Exceptions;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Orchestrations.Properties
{
    public partial class PropertyOrchestrationServiceTests
    {
        [Fact]
        public void ShouldThrowPropertyOrchestrationDependencyValidationExceptionOnRetrievePropertiesIfNullPropertyModelOccurs()
        {
            // given
            PropertyModel nullPropertyModel = null;
            PropertyModel inputPropertyModel = nullPropertyModel;
            Type someType = typeof(object);

            var argumentNullException =
                new ArgumentNullException(paramName: "propertyModel");

            var nullPropertyModelException =
                new NullPropertyModelException(argumentNullException);

            var expectedPropertyOrchestrationDependencyValidationException =
                new PropertyOrchestrationDependencyValidationException(nullPropertyModelException);

            // when
            Action retrievePropertiesAction = () => this.propertyOrchestrationService.RetrieveProperties(inputPropertyModel);

            PropertyOrchestrationDependencyValidationException actualPropertyOrchestrationDependencyValidationException =
                Assert.Throws<PropertyOrchestrationDependencyValidationException>(retrievePropertiesAction);

            // then
            actualPropertyOrchestrationDependencyValidationException.Should().BeEquivalentTo(expectedPropertyOrchestrationDependencyValidationException);

            this.typeServiceMock.Verify(service =>
                service.RetrieveType(It.IsAny<PropertyModel>()),
                    Times.Never());

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(someType),
                    Times.Never());

            this.typeServiceMock.VerifyNoOtherCalls();
            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
