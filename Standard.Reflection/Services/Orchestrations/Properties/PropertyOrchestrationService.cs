// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Standard.Reflection.Services.Foundations.Properties;
using Standard.Reflection.Services.Foundations.Types;

namespace Standard.Reflection.Services.Orchestrations.Properties
{
    internal class PropertyOrchestrationService : IPropertyOrchestrationService
    {
        private readonly ITypeService typeService;
        private readonly IPropertyService propertyService;

        public PropertyOrchestrationService(ITypeService typeService, IPropertyService propertyService)
        {
            this.typeService = typeService;
            this.propertyService = propertyService;
        }

        public PropertyInfo[] RetrieveProperties(object @object)
        {
            Type type = typeService.RetrieveType(@object);

            PropertyInfo[] properties = propertyService.RetrieveProperties(type);

            return properties;
        }
    }
}
