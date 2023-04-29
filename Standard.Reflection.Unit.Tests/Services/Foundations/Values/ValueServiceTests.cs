// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using Moq;
using Standard.Reflection.Brokers.Values;
using Standard.Reflection.Services.Foundations.Values;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Values
{
    public partial class ValueServiceTests
    {
        private readonly Mock<IValueBroker> valueBrokerMock;
        private readonly IValueService valueService;

        public ValueServiceTests()
        {
            this.valueBrokerMock = new Mock<IValueBroker>();
            this.valueService = new ValueService(this.valueBrokerMock.Object);
        }
        private static object CreateSomeObject() => new object();

        private static PropertyInfo CreateSomePropertyInfo() =>
            typeof(string).GetProperty(name: "Length");
    }
}
