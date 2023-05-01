// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Standard.Reflection.Models.Orchestrations.Properties;

namespace Standard.Reflection.Services.Orchestrations.Properties
{
    internal interface IPropertyOrchestrationService
    {
        PropertyModel RetrieveProperties(PropertyModel propertyModel);
    }
}
