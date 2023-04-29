// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Moq;
using Standard.Reflection.Brokers.Attributes;
using Standard.Reflection.Services.Foundations.Attributes;
using Tynamix.ObjectFiller;
using Xunit;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Attributes
{
    public partial class AttributeServiceTests
    {
        private readonly Mock<IAttributeBroker> attributeBrokerMock;
        private readonly IAttributeService attributeService;

        public AttributeServiceTests()
        {
            this.attributeBrokerMock = new Mock<IAttributeBroker>();
            this.attributeService = new AttributeService(this.attributeBrokerMock.Object);
        }
        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static PropertyInfo CreateSomePropertyInfo() =>
            typeof(string).GetProperty(name: "Length");

        private static PropertyInfo CreateNullPropertyInfo() => null;

        public static TheoryData GetCustomAttributeExceptions()
        {
            return new TheoryData<Exception>()
            {
                new NotSupportedException(),
                new AmbiguousMatchException(),
                new TypeLoadException()
            };
        }

    }

    internal class TestAttribute : Attribute
    { }

}
