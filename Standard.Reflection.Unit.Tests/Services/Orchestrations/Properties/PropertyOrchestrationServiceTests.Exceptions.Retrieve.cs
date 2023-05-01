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
        [Theory]
        [MemberData(nameof(GetDependencyExceptions))]
        public void ShouldThrowPropertyOrchestrationDependencyExceptionIfDependencyExceptionOccurs(
            Exception dependencyException)
        {
            // given
            object someObject = new object();
            object inputObject = someObject;
            PropertyModel somePropertyModel = CreateSomePropertyModel(inputObject);

            var expectedPropertyOrchestrationDependencyException =
                new PropertyOrchestrationDependencyException(dependencyException);

            this.typeServiceMock.Setup(service =>
                service.RetrieveType(It.IsAny<object>()))
                    .Throws(dependencyException);

            // when
            Action retrievePropertiesAction =
                () => this.propertyOrchestrationService.RetrieveProperties(somePropertyModel);

            PropertyOrchestrationDependencyException actualPropertyOrchestrationDependencyException =
                Assert.Throws<PropertyOrchestrationDependencyException>(retrievePropertiesAction);

            // then
            actualPropertyOrchestrationDependencyException.Should()
                .BeEquivalentTo(expectedPropertyOrchestrationDependencyException);

            this.typeServiceMock.Verify(service =>
                service.RetrieveType(It.IsAny<object>()),
                    Times.Once());

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(It.IsAny<Type>()),
                    Times.Never());

            this.typeServiceMock.VerifyNoOtherCalls();
            this.propertyServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowPropertyOrchestrationServiceExceptionIfExceptionOccurs()
        {
            // given
            object someObject = new object();
            object inputObject = someObject;
            PropertyModel somePropertyModel = CreateSomePropertyModel(inputObject);

            Exception someException = new Exception();

            var expectedFailedPropertyOrchestrationException =
                new FailedPropertyOrchestrationException(someException);

            var expectedPropertyOrchestrationException =
                new PropertyOrchestrationException(expectedFailedPropertyOrchestrationException);

            this.typeServiceMock.Setup(service =>
                service.RetrieveType(It.IsAny<object>()))
                    .Throws(someException);

            // when
            void retrievePropertiesAction() =>
                this.propertyOrchestrationService.RetrieveProperties(somePropertyModel);

            PropertyOrchestrationException actualPropertyOrchestrationException =
                Assert.Throws<PropertyOrchestrationException>(retrievePropertiesAction);

            // then
            actualPropertyOrchestrationException.Should()
                .BeEquivalentTo(expectedPropertyOrchestrationException);

            this.typeServiceMock.Verify(service =>
                service.RetrieveType(It.IsAny<object>()),
                    Times.Once());

            this.propertyServiceMock.Verify(service =>
                service.RetrieveProperties(It.IsAny<Type>()),
                    Times.Never());

            this.typeServiceMock.VerifyNoOtherCalls();
            this.propertyServiceMock.VerifyNoOtherCalls();
        }
    }
}
