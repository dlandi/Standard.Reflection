// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Standard.Reflection.Models.Foundations.Properties.Exceptions;
using Standard.Reflection.Models.Foundations.Types.Exceptions;
using Standard.Reflection.Models.Orchestrations.Properties;
using Standard.Reflection.Models.Orchestrations.Properties.Exceptions;

namespace Standard.Reflection.Services.Orchestrations.Properties
{
    internal partial class PropertyOrchestrationService
    {
        private delegate PropertyModel ReturningPropertyModelFunction();

        private PropertyModel TryCatch(ReturningPropertyModelFunction returningPropertyModelFunction)
        {
            try
            {
                return returningPropertyModelFunction();
            }
            catch (NullPropertyModelException nullPropertyModelException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(nullPropertyModelException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (NullObjectException nullObjectException)
            {
                var propertyOrchestrationDependencyValidationException =
                    new PropertyOrchestrationDependencyValidationException(nullObjectException);

                throw propertyOrchestrationDependencyValidationException;
            }
            catch (TypeServiceException typeServiceException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(typeServiceException);

                throw propertyOrchestrationDependencyException;
            }
            catch (PropertyServiceException propertyServiceException)
            {
                var propertyOrchestrationDependencyException =
                    new PropertyOrchestrationDependencyException(propertyServiceException);

                throw propertyOrchestrationDependencyException;
            }
            catch (Exception exception)
            {
                var failedPropertyOrchestrationException =
                    new FailedPropertyOrchestrationException(exception);

                var propertyPropertyOrchestrationException =
                    new PropertyOrchestrationException(failedPropertyOrchestrationException);

                throw propertyPropertyOrchestrationException;
            }
        }
    }
}
