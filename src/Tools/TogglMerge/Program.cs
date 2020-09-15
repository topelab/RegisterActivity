using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using TogglData.dto;

namespace TogglMerge
{
    internal class Program
    {
        private static readonly Dictionary<long, TimelineEventsDTO> GlobalDB = new Dictionary<long, TimelineEventsDTO>();

        private static void Main(string[] args)
        {
            var connString = args.Length > 0 ? args[0] : "toggl";
            var filePattern = ConfigHelper.GetConnectionString(connString).GetPart("Data Source");
            var path = Path.GetDirectoryName(filePattern);
            var name = Path.GetFileName(filePattern);
            var files = Directory.GetFiles(path, name);

            foreach (var item in files)
            {
                Console.WriteLine($"Reading {item}...");
                item
                    .ReadDB()
                    .ForEach((r) => { GlobalDB[r.LocalId] = r; });
            }

            var outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\toggleDB.xlsx";
            GlobalDB.Values.WriteToExcel(outputFile);
        }


    }
}
