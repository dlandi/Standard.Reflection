// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace Standard.Reflection.Services.Orchestrations.Properties
{
    internal interface IPropertyOrchestrationService
    {
        PropertyInfo[] RetrieveProperties(object @object);
    }
}
