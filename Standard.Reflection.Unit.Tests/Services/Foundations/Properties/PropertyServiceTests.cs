// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using Moq;
using Standard.Reflection.Brokers.Properties;
using Standard.Reflection.Services.Foundations.Properties;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Properties
{
    public partial class PropertyServiceTests
    {
        private readonly Mock<IPropertyBroker> propertyBrokerMock;
        private readonly IPropertyService propertyService;

        public PropertyServiceTests()
        {
            this.propertyBrokerMock = new Mock<IPropertyBroker>();
            this.propertyService = new PropertyService(this.propertyBrokerMock.Object);
        }

        private static PropertyInfo[] CreateRandomProperties()
        {
            int randomPropertyCount = GetRandomNumber();

            PropertyInfo[] properties = Enumerable.Range(start: 0, count: randomPropertyCount)
                .Select(i => new Mock<PropertyInfo>().Object)
                    .ToArray();

            return properties;
        }

        private static int GetRandomNumber() =>
            Random.Shared.Next(minValue: 3, maxValue: 8);
    }
}
