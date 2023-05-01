// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Reflection;
using System;
using Moq;
using Standard.Reflection.Services.Foundations.Properties;
using Standard.Reflection.Services.Foundations.Types;
using Standard.Reflection.Services.Orchestrations.Properties;
using Standard.Reflection.Models.Orchestrations.Properties;
using System.Collections;
using Standard.Reflection.Models.Foundations.Types.Exceptions;
using Standard.Reflection.Models.Orchestrations.Properties.Exceptions;
using System.Collections.Generic;
using Standard.Reflection.Models.Foundations.Properties.Exceptions;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Orchestrations.Properties
{
    public partial class PropertyOrchestrationServiceTests
    {
        private readonly Mock<ITypeService> typeServiceMock;
        private readonly Mock<IPropertyService> propertyServiceMock;
        private readonly IPropertyOrchestrationService propertyOrchestrationService;

        public PropertyOrchestrationServiceTests()
        {
            this.typeServiceMock = new Mock<ITypeService>(MockBehavior.Strict);
            this.propertyServiceMock = new Mock<IPropertyService>(MockBehavior.Strict);

            this.propertyOrchestrationService =
                new PropertyOrchestrationService(this.typeServiceMock.Object, this.propertyServiceMock.Object);
        }
        private static PropertyInfo[] CreateRandomProperties()
        {
            int randomPropertyCount = GetRandomNumber();

            PropertyInfo[] properties = Enumerable.Range(start: 0, count: randomPropertyCount)
                .Select(i => new Mock<PropertyInfo>().Object)
                    .ToArray();

            return properties;
        }

        private static int GetRandomNumber()
        {
            var random = Random.Shared;
            return random.Next(minValue: 3, maxValue: 8);
        }

        private static PropertyModel CreateSomePropertyModel(object inputObject)
        {
            return new PropertyModel
            {
                Object = inputObject,
            };
        }

        public static IEnumerable<object[]> GetDependencyExceptions()
        {
            var innerException = new Exception();
            var nullObjectException = new NullObjectException(innerException);

            yield return new object[] { new TypeServiceException(nullObjectException) };
            yield return new object[] { new PropertyServiceException(nullObjectException) };
        }
    }
}
