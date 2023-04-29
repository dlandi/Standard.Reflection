// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace Standard.Reflection.Services.Foundations.Attributes
{
    internal interface IAttributeService
    {
        TAttribute RetrieveAttribute<TAttribute>(PropertyInfo propertyInfo)
            where TAttribute : Attribute;
    }
}
