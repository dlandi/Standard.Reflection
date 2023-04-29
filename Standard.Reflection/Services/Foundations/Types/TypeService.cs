// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Standard.Reflection.Brokers.Types;
using Standard.Reflection.Services.Foundations.Types;

namespace Standard.Reflection.Services
{
    internal partial class TypeService : ITypeService
    {
        private readonly ITypeBroker typeBroker;

        public TypeService(ITypeBroker typeBroker) =>
            this.typeBroker = typeBroker;

        public Type RetrieveType(object @object) =>
        TryCatch(() =>
        {
            Type type = this.typeBroker.GetType(@object);

            return type;
        });
    }
}
