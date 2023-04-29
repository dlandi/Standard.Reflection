// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace Standard.Reflection.Brokers.Methods
{
    internal class MethodBroker : IMethodBroker
    {
        public MethodInfo[] GetMethods(Type type) =>
           type.GetMethods();
    }
}
