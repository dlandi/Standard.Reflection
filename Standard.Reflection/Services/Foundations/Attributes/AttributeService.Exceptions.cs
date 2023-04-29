﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Standard.Reflection.Models.Foundations.Attributes.Exceptions;
using Standard.Reflection.Models.Foundations.Properties.Exceptions;

namespace Standard.Reflection.Services.Foundations.Attributes
{
    internal partial class AttributeService : IAttributeService
    {
        private delegate TAttribute ReturningAttributeFunction<TAttribute>()
            where TAttribute : Attribute;

        private TAttribute TryCatch<TAttribute>(ReturningAttributeFunction<TAttribute> returningAttributeFunction)
            where TAttribute : Attribute
        {
            try
            {
                return returningAttributeFunction();
            }
            catch (ArgumentNullException argumentNullException)
            {
                var nullPropertyInfoException =
                    new NullPropertyInfoException(argumentNullException);

                var attributeValidationException =
                    new AttributeValidationException(nullPropertyInfoException);

                throw attributeValidationException;
            }
            catch (NotSupportedException notSupportedException)
            {
                var failedAttributeServiceException =
                    new FailedAttributeServiceException(notSupportedException);

                var attributeDependencyValidationException =
                    new AttributeDependencyValidationException(failedAttributeServiceException);

                throw attributeDependencyValidationException;
            }
            catch (AmbiguousMatchException ambiguousMatchException)
            {
                var failedAttributeServiceException =
                    new FailedAttributeServiceException(ambiguousMatchException);

                var attributeDependencyValidationException =
                    new AttributeDependencyValidationException(failedAttributeServiceException);

                throw attributeDependencyValidationException;

            }
            catch (TypeLoadException typeLoadException)
            {
                var failedAttributeServiceException =
                    new FailedAttributeServiceException(typeLoadException);

                var attributeDependencyValidationException =
                    new AttributeDependencyValidationException(failedAttributeServiceException);

                throw attributeDependencyValidationException;
            }
            catch (Exception exception)
            {
                var failedAttributeServiceException =
                    new FailedAttributeServiceException(exception);

                var attributeServiceException =
                    new AttributeServiceException(failedAttributeServiceException);

                throw attributeServiceException;
            }
        }
    }
}
