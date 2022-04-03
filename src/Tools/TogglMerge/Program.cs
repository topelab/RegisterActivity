using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using Tools.TogglData.Domain.Entities;

namespace TogglMerge
{
    internal class Program
    {
        private static readonly Dictionary<long, TimelineEvent> GlobalDB = new Dictionary<long, TimelineEvent>();
        private static readonly Dictionary<long, TimelineEvent> NewRecordsDB = new Dictionary<long, TimelineEvent>();

        private static void Main(string[] args)
        {
            string connString = args.Length > 0 ? args[0] : "toggl";
            string filePattern = ConfigHelper.GetConnectionString(connString).GetPart("Data Source");
            string path = Path.GetDirectoryName(filePattern);
            string name = Path.GetFileName(filePattern);
            string[] files = Directory.GetFiles(path, name);

            string globalDB = ConfigHelper.Config["GlobalDB"];
            globalDB.ReadOriginal().ForEach(r => { GlobalDB[r.LocalId] = r; });

            foreach (string item in files)
            {
                Console.WriteLine($"Reading {item}...");
                item
                    .ReadOriginal()
                    .ForEach((r) =>
                    {
                        if (!GlobalDB.ContainsKey(r.LocalId))
                        {
                            NewRecordsDB[r.LocalId] = r;
                            GlobalDB[r.LocalId] = r;
                        }
                    });
            }

            if (NewRecordsDB.Values.Count > 0)
            {
                Console.WriteLine($"Writing {NewRecordsDB.Values.Count} items to {globalDB}");
                globalDB.WriteOriginal(NewRecordsDB.Values);
            }


            //var outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\toggleDB.xlsx";
            //GlobalDB.Values.WriteToExcel(outputFile);
        }


    }
}
