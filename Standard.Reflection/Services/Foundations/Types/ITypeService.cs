// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace Standard.Reflection.Services.Foundations.Types
{
    internal interface ITypeService
    {
        Type RetrieveType(object @object);
    }
}
