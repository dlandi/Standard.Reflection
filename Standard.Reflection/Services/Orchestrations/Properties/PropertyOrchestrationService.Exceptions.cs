// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

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
        }
    }
}
