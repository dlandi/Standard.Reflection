// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using System;

namespace Standard.Reflection.Brokers.Properties
{
    internal class PropertyInfoBroker : IPropertyInfoBroker
    {
        public PropertyInfo[] GetProperties(Type type) =>
           type.GetProperties();
    }
}
