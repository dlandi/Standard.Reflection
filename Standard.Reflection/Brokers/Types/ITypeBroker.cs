// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace Standard.Reflection.Brokers.Types
{
    internal interface ITypeBroker
    {
        Type GetType(object @object);
    }
}
