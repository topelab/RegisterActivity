using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using NLog.Web.AspNetCore;
using NUnit.Framework;
using Topelab.RegisterActivity.Domain.Entities;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Builders;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.Data.Sqlite;

namespace Topelab.RegisterActivity.Adapters.Tests
{
    [TestFixture]
    public class WinlogDbContextTest
    {
        private readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => builder.AddNLog());

        private ILogger logger;

        [Test]
        public void Test_Of_WinlogDbContext()
        {
            logger = MyLoggerFactory.CreateLogger("WinlogDbContextTest");
            var dbContextFactory = new RegisterActivityDbContextFactory(MyLoggerFactory, logger);

            using var db = dbContextFactory.Create("memory");
            try
            {
                logger.LogInformation("Hello WinlogDbContextTest");

                db.Database.EnsureCreated();

                //TODO: Do the test
                var result = db.Winlog
                    .Where(e => e.LocalId != 0)
                    .AsNoTracking().ToList();

                Assert.NotNull(result);
                logger.LogInformation("Test of WinlogDbContextTest is OK");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "WinlogDbContextTest error");
                Assert.Fail(ex.Message);
            }
        }
    }
}
