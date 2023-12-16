using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Business.Services.Interfaces;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Business.Services
{
    internal class JoinService(IRegisterActivityDbContextFactory dbContextFactory) : IJoinService
    {
        private readonly IRegisterActivityDbContextFactory dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

        public void Start(string filePattern, string outputFile)
        {
            TryCreateOutputDB(outputFile);
            TryInsertInputDBFiles(Directory.EnumerateFiles(filePattern));
        }

        private void TryInsertInputDBFiles(IEnumerable<string> inputFiles)
        {
            if (inputFiles.Any())
            {
                foreach (var inputFile in inputFiles)
                {
                    TryInsertInputDBFile(inputFile);
                }
            }
        }

        private void TryInsertInputDBFile(string inputFile)
        {
            if (File.Exists(inputFile))
            {
                var data = GetData(inputFile);
                using var outputDB = dbContextFactory.Create("outputDB");
                outputDB.Winlog.AddRange(data);
                outputDB.SaveChanges();
            }
        }

        private List<Winlog> GetData(string inputFile)
        {
            Environment.SetEnvironmentVariable("INPUTFILE", inputFile);
            using var db = dbContextFactory.Create("inputDB");
            var data = db.Winlog.AsNoTracking().Select(r => r).ToList();
            data.ForEach(r => r.LocalId = 0);

            return data;
        }

        private void TryCreateOutputDB(string outputFile)
        {
            Environment.SetEnvironmentVariable("OUTPUTFILE", outputFile);
            using var db = dbContextFactory.Create("outputDB");
            db.Database.EnsureCreated();
        }

    }
}
