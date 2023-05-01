﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Standard.Reflection.Models.Orchestrations.Properties;
using Standard.Reflection.Models.Orchestrations.Properties.Exceptions;

namespace Standard.Reflection.Services.Orchestrations.Properties
{
    internal partial class PropertyOrchestrationService
    {
        private static void ValidatePropertyModel(PropertyModel propertyModel)
        {
            ValidatePropertyModelIsNotNull(propertyModel);
            ValidateObjectIsNotNull(propertyModel);
        }

        private static void ValidatePropertyModelIsNotNull(PropertyModel propertyModel)
        {
            if (propertyModel is null)
            {
                var argumentNullException = new ArgumentNullException(nameof(propertyModel));
                var nullPropertyModelException = new NullPropertyModelException(argumentNullException);

                throw nullPropertyModelException;
            }
        }
        private static void ValidateObjectIsNotNull(PropertyModel propertyModel)
        {
            if (propertyModel.Object is null)
            {
                var argumentNullException = new ArgumentNullException(nameof(propertyModel.Object));
                var nullObjectException = new NullObjectException(argumentNullException);

                throw nullObjectException;
            }
        }
    }
}
