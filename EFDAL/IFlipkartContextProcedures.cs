﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EFDAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EFDAL
{
    public partial interface IFlipkartContextProcedures
    {
        Task<int> usp_InsertCategoryAsync(string Name, string Description, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
