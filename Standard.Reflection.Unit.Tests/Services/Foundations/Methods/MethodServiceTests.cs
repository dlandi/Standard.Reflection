// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using Moq;
using Standard.Reflection.Brokers.Methods;
using Standard.Reflection.Services.Foundations.Methods;

namespace Standard.Reflection.Unit.Tests.Services.Foundations.Methods
{
    public partial class MethodServiceTests
    {
        private readonly Mock<IMethodBroker> methodBrokerMock;
        private readonly IMethodService methodService;

        public MethodServiceTests()
        {
            this.methodBrokerMock = new Mock<IMethodBroker>();
            this.methodService = new MethodService(this.methodBrokerMock.Object);
        }

        private static MethodInfo[] CreateRandomMethods()
        {
            int randomMethodCount = GetRandomNumber();

            MethodInfo[] methods = Enumerable.Range(start: 0, count: randomMethodCount)
                .Select(i => new Mock<MethodInfo>().Object)
                    .ToArray();

            return methods;
        }

        private static int GetRandomNumber()
        {

            var random = new Random();
            return random.Next(minValue: 3, maxValue: 8);
        }
    }
}
