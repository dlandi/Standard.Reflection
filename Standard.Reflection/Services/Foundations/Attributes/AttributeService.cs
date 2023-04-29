﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using Standard.Reflection.Brokers.Attributes;

namespace Standard.Reflection.Services.Foundations.Attributes
{
    internal class AttributeService : IAttributeService
    {
        private readonly IAttributeBroker attributeBroker;

        public AttributeService(IAttributeBroker attributeBroker) =>
            this.attributeBroker = attributeBroker;

        public TAttribute RetrieveAttribute<TAttribute>(PropertyInfo propertyInfo)
            where TAttribute : Attribute =>
            this.attributeBroker.GetPropertyCustomAttribute<TAttribute>(propertyInfo, true);
    }
}
