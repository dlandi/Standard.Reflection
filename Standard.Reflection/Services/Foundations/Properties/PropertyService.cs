// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Standard.Reflection.Brokers.Properties;

namespace Standard.Reflection.Services.Foundations.Properties
{
    internal class PropertyService : IPropertyService
    {
        private readonly IPropertyBroker propertyBroker;

        public PropertyService(IPropertyBroker propertyBroker) =>
            this.propertyBroker = propertyBroker;

        public PropertyInfo[] RetrieveProperties(Type type) =>
            this.propertyBroker.GetProperties(type);
    }
}
