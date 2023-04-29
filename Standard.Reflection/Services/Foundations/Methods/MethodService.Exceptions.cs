// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Standard.Reflection.Models.Foundations.Methods.Exceptions;

namespace Standard.Reflection.Services.Foundations.Methods
{
    internal partial class MethodService
    {
        private delegate MethodInfo[] ReturningMethodsFunction();

        private MethodInfo[] TryCatch(ReturningMethodsFunction returningMethodsFunction)
        {
            try
            {
                return returningMethodsFunction();
            }
            catch (Exception exception)
            {
                var failedMethodServiceException = new FailedMethodServiceException(exception);

                var methodServiceException = new MethodServiceException(failedMethodServiceException);

                throw methodServiceException;
            }
        }
    }
}
