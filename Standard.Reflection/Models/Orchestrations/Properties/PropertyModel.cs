﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace Standard.Reflection.Models.Orchestrations.Properties
{
    internal class PropertyModel
    {
        public object Object { get; set; }
        public PropertyInfo[] Properties { get; set; }
    }
}
