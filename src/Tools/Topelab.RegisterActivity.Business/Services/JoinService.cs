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
            var path = Path.GetDirectoryName(filePattern);
            var pattern = $"{Path.GetFileNameWithoutExtension(filePattern)}.db";
            TryInsertInputDBFiles(path, Directory.EnumerateFiles(path, pattern));
        }

        private void TryInsertInputDBFiles(string path, IEnumerable<string> inputFiles)
        {
            if (inputFiles.Any())
            {
                foreach (var inputFile in inputFiles)
                {
                    TryInsertInputDBFile(Path.Combine(path, Path.GetFileNameWithoutExtension(inputFile)));
                }
            }
        }

        private void TryInsertInputDBFile(string inputFile)
        {
            var data = GetData(inputFile);
            using var outputDB = dbContextFactory.Create("outputDB");
            outputDB.Winlog.AddRange(data);
            outputDB.SaveChanges();
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
