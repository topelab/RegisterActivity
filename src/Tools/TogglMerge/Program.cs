using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using TogglData.dto;
using TogglData.entities;

namespace TogglMerge
{
    internal class Program
    {
        private static readonly Dictionary<long, TimelineEvents> GlobalDB = new Dictionary<long, TimelineEvents>();
        private static readonly Dictionary<long, TimelineEvents> NewRecordsDB = new Dictionary<long, TimelineEvents>();

        private static void Main(string[] args)
        {
            var connString = args.Length > 0 ? args[0] : "toggl";
            var filePattern = ConfigHelper.GetConnectionString(connString).GetPart("Data Source");
            var path = Path.GetDirectoryName(filePattern);
            var name = Path.GetFileName(filePattern);
            var files = Directory.GetFiles(path, name);

            var globalDB = ConfigHelper.Config["GlobalDB"];
            globalDB.ReadOriginal().ForEach(r => { GlobalDB[r.LocalId] = r; });

            foreach (var item in files)
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
