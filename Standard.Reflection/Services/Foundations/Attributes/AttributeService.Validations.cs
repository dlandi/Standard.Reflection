// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using System;

namespace Standard.Reflection.Services.Foundations.Attributes
{
    internal partial class AttributeService : IAttributeService
    {
        private void Validate(PropertyInfo propertyInfo)
        {
            if(propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }
        }
    }
}
