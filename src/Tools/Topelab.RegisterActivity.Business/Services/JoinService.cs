using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services.Interfaces;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Business.Services
{
    internal class JoinService(IRegisterActivityDbContextFactory dbContextFactory) : IJoinService
    {
        private readonly IRegisterActivityDbContextFactory dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

        public void Start(string filePattern, string outputFile, bool create)
        {
            TryCreateOutputDB(outputFile, create);
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
            using var db = dbContextFactory.Create();
            db.Winlog.AddRange(data);
            db.SaveChanges();
        }

        private List<Winlog> GetData(string inputFile)
        {
            Environment.SetEnvironmentVariable(Constants.InputFile, inputFile);
            using var db = dbContextFactory.Create("inputDB");
            var data = db.Winlog.AsNoTracking().Select(r => r).ToList();
            data.ForEach(r => r.LocalId = 0);

            return data;
        }

        private void TryCreateOutputDB(string outputFile, bool create)
        {
            string fullName = string.Concat(outputFile, ".db");
            if (create && File.Exists(fullName))
            {
                File.Delete(fullName);
            }

            Environment.SetEnvironmentVariable(Constants.OutputFile, outputFile);
            using var db = dbContextFactory.Create();
            db.Database.EnsureCreated();
        }

    }
}
