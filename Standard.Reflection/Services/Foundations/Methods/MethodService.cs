// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Standard.Reflection.Brokers.Methods;

namespace Standard.Reflection.Services.Foundations.Methods
{
    internal partial class MethodService : IMethodService
    {
        private readonly IMethodBroker methodBroker;

        public MethodService(IMethodBroker methodBroker) =>
            this.methodBroker = methodBroker;

        public MethodInfo[] RetrieveMethods(Type type) =>
        TryCatch(() =>
        {
            return this.methodBroker.GetMethods(type);
        });
    }
}
