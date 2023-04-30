// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using Standard.Reflection.Models.Foundations.Forms.Exceptions;

namespace Standard.Reflection.Services.Foundations.Forms
{
    internal partial class FormService
    {
        private delegate MultipartFormDataContent ReturningMultipartFormDataContentFunction();

        private MultipartFormDataContent TryCatch(ReturningMultipartFormDataContentFunction returningMultipartFormDataContentFunction)
        {
            try
            {
                return returningMultipartFormDataContentFunction();
            }
            catch(NullMultipartFormDataContentException nullMultipartFormDataContentException)
            {
                var formValidationException =
                    new FormValidationException(nullMultipartFormDataContentException);

                throw formValidationException;
            }
            catch (NullNameException nullNameException)
            {
                var formValidationException =
                    new FormValidationException(nullNameException);

                throw formValidationException;
            }
            catch (NullFileNameException nullFileNameException)
            {
                var formValidationException =
                    new FormValidationException(nullFileNameException);

                throw formValidationException;
            }
            catch (NullContentException nullContentException)
            {
                var formValidationException =
                    new FormValidationException(nullContentException);

                throw formValidationException;
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(argumentOutOfRangeException);

                var formValidationException =
                    new FormValidationException(formDependencyValidationException);

                throw formValidationException;
            }
            catch (ArgumentNullException argumentNullException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(argumentNullException);

                var formValidationException =
                    new FormValidationException(formDependencyValidationException);

                throw formValidationException;
            }
            catch (ArgumentException argumentException)
            {
                var formDependencyValidationException =
                    new FormDependencyValidationException(argumentException);

                var formValidationException =
                    new FormValidationException(formDependencyValidationException);

                throw formValidationException;
            }
            catch(Exception exception)
            {
                var failedFormServiceException = new FailedFormServiceException(exception);
                var formServiceException = new FormServiceException(failedFormServiceException);

                throw formServiceException;
            }
        }
    }
}
