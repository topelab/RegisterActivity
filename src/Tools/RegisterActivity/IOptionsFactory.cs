﻿using Microsoft.EntityFrameworkCore;
using Tools.TogglData.Adapters.Context;

namespace RegisterActivity
{
    internal interface IOptionsFactory
    {
        /// <summary>
        /// Create options for TogglDataFbContext
        /// </summary>
        /// <param name="connectionStringLabel">Label for connection string</param>
        DbContextOptions<TogglDataDbContext> Create(string connectionStringLabel);
    }
}