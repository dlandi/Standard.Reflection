// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using Standard.Reflection.Brokers.Types;
using Standard.Reflection.Services;

namespace Standard.Reflection.Unit.Tests.Services.Foundations
{
    public partial class TypeServiceTests
    {
        private readonly Mock<ITypeBroker> typeBrokerMock;
        private readonly ITypeService typeService;

        public TypeServiceTests()
        {
            this.typeBrokerMock = new Mock<ITypeBroker>();
            this.typeService = new TypeService(this.typeBrokerMock.Object);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { null };
            yield return new object[] { typeof(DateTime) };
            yield return new object[] { typeof(int) };
            yield return new object[] { typeof(long) };
            yield return new object[] { typeof(object) };
            yield return new object[] { typeof(Stream) };
            yield return new object[] { typeof(string) };
            yield return new object[] { typeof(TestClass) };
        }

        public class TestClass
        { }
    }
}
