// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Moq;
using Standard.Reflection.Brokers.Attributes;
using Standard.Reflection.Services.Foundations.Attributes;

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
    }

    internal class SomeAttribute : Attribute
    { }
}
