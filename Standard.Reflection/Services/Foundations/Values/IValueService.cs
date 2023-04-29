// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace Standard.Reflection.Services.Foundations.Values
{
    internal interface IValueService
    {
        object RetrievePropertyValue(object @object, PropertyInfo propertyInfo);
    }
}
