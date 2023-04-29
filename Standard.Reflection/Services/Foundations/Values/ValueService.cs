// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using Standard.Reflection.Brokers.Values;

namespace Standard.Reflection.Services.Foundations.Values
{
    internal partial class ValueService : IValueService
    {
        private readonly IValueBroker valueBroker;

        public ValueService(IValueBroker valueBroker) =>
            this.valueBroker = valueBroker;

        public object RetrievePropertyValue(object @object, PropertyInfo propertyInfo) =>
            this.valueBroker.GetPropertyValue(@object,propertyInfo);
    }
}
