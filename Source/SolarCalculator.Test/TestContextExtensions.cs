using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;

namespace SolarCalculation.Test
{
    public static class TestContextExtensions
    {
        private static string TestPath(this string filePath)
        {  
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);
        }
        
        public static IEnumerable<T> ReadRecords<T>(this string filePath) where T : class, new()
        {
            var reader = File.OpenText((filePath ?? "").TestPath());
            var csvFile = new CsvReader(reader);
            csvFile.Configuration.HasHeaderRecord = true;
            csvFile.Read();
            csvFile.ReadHeader();
            return csvFile.GetRecords<T>().ToList();
        }
    }
}