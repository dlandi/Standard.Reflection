﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace Standard.Reflection.Brokers.Properties
{
    internal class PropertyBroker : IPropertyBroker
    {
        public PropertyInfo[] GetProperties(Type type) =>
           type.GetProperties();
    }
}
