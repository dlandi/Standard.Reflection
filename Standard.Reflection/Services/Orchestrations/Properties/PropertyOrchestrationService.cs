// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Standard.Reflection.Models.Orchestrations.Properties;
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

        public PropertyModel RetrieveProperties(PropertyModel propertyModel)
        {
            Type type = typeService.RetrieveType(propertyModel.Object);
            PropertyInfo[] properties = propertyService.RetrieveProperties(type);
            propertyModel.Properties = properties;

            return propertyModel;
        }
    }
}
