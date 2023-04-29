﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using Standard.Reflection.Models.Foundations.Properties.Exceptions;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Properties
{
    public partial class PropertyServiceTests
    {
        [Fact]
        public void ShouldThrowPropertyServiceExceptionIfExceptionOccurs()
        {
            // given
            var someObject = new object();
            var someException = new Exception();
            var failedPropertyServiceException = new FailedPropertyServiceException(someException);
            var expectedPropertyServiceException = new PropertyServiceException(failedPropertyServiceException);

            this.propertyBrokerMock.Setup(broker =>
                broker.GetProperties(It.IsAny<Type>()))
                    .Throws(someException);

            // when
            Action retrieveTypeAction = () => this.propertyService.RetrieveProperties(typeof(PropertyServiceTests));

            PropertyServiceException actualPropertyServiceException =
                Assert.Throws<PropertyServiceException>(retrieveTypeAction);

            // then
            actualPropertyServiceException.Should().BeEquivalentTo(expectedPropertyServiceException);

            this.propertyBrokerMock.Verify(broker =>
                broker.GetProperties(It.IsAny<Type>()),
                    Times.Once);

            this.propertyBrokerMock.VerifyNoOtherCalls();
        }
    }
}
