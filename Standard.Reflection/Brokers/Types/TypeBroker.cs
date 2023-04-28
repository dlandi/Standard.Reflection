// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace Standard.Reflection.Brokers.Types
{
    internal class TypeBroker : ITypeBroker
    {
        public Type GetType(object @object) =>
            @object.GetType();
    }
}
