// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace Standard.Reflection.Services.Foundations.Methods
{
    internal interface IMethodService
    {
        MethodInfo[] RetrieveMethods(Type type);
    }
}
