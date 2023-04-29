﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace Standard.Reflection.Services.Foundations.Properties
{
    internal interface IPropertyService
    {
        PropertyInfo[] RetrieveProperties(Type type);
    }
}
