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
    internal class SplitService(IRegisterActivityDbContextFactory dbContextFactory) : ISplitService
    {
        public void Start(string inputFile, string outputFile, SplitType splitType)
        {
            var data = GetData(inputFile, splitType);
            foreach (var key in data.Keys)
            {
                TryCreateOutputDB($"{outputFile}-{key}", true);
                using var db = dbContextFactory.Create();
                db.Winlog.AddRange(data[key]);
                db.SaveChanges();
            }
        }

        private Dictionary<string, IEnumerable<Winlog>> GetData(string inputFile, SplitType splitType)
        {
            Environment.SetEnvironmentVariable(Constants.InputFile, inputFile);
            using var db = dbContextFactory.Create("inputDB");
            var data = db.Winlog.AsNoTracking().Select(r => r).ToList();
            data.ForEach(r => r.Id = 0);

            int startTimePart = splitType == SplitType.Yearly ? 4 : 7;

            return data.GroupBy(r => r.StartTime[..startTimePart]).ToDictionary(k => k.Key, g => g.Select(r => r));
        }

        private void TryCreateOutputDB(string outputFile, bool create)
        {
            var fullName = string.Concat(outputFile, ".db");
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
