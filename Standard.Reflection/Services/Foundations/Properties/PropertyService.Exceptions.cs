// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Standard.Reflection.Models.Foundations.Properties.Exceptions;

namespace Standard.Reflection.Services.Foundations.Properties
{
    internal partial class PropertyService
    {
        private delegate PropertyInfo[] ReturningPropertiesFunction();

        private PropertyInfo[] TryCatch(ReturningPropertiesFunction returningPropertiesFunction)
        {
            try
            {
                return returningPropertiesFunction();
            }
            catch (Exception exception)
            {
                var failedPropertyServiceException = new FailedPropertyServiceException(exception);

                var propertyServiceException = new PropertyServiceException(failedPropertyServiceException);

                throw propertyServiceException;
            }
        }
    }
}
