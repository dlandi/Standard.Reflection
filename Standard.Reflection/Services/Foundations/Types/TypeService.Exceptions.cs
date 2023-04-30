// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Standard.Reflection.Models.Foundations.Types.Exceptions;
using Standard.Reflection.Services.Foundations.Types;

namespace Standard.Reflection.Services
{
    internal partial class TypeService : ITypeService
    {
        private delegate Type ReturningTypeFunction();

        private Type TryCatch(ReturningTypeFunction returningTypeFunction)
        {
            try
            {
                return returningTypeFunction();
            }
            catch (Exception exception)
            {
                var failedTypeServiceException =
                    new FailedTypeServiceException(exception);

                var typeServiceException =
                    new TypeServiceException(failedTypeServiceException);

                throw typeServiceException;
            }
        }
    }
}
