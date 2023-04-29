// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Standard.Reflection.Brokers.Types;

namespace Standard.Reflection.Services
{
    internal class TypeService : ITypeService
    {
        private readonly ITypeBroker typeBroker;

        public TypeService(ITypeBroker typeBroker) =>
            this.typeBroker = typeBroker;

        public Type RetrieveType(object @object) =>
            throw new NotImplementedException();
    }
}
