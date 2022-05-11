using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Linq;
using Topelab.RegisterActivity.Adapters.Context;

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
