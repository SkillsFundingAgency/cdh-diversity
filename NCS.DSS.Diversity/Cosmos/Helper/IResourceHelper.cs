﻿using System;
using System.Threading.Tasks;

namespace NCS.DSS.Diversity.Cosmos.Helper
{
    public interface IResourceHelper
    {
        Task<bool> DoesCustomerExist(Guid customerId);
        Task<bool> IsCustomerReadOnly(Guid customerId);
    }
}