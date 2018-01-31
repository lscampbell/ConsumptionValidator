using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Linq;
using Dapper;
using System.Threading;

namespace ElexonImportService
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Console.WriteLine("start");

            foreach (var filename in Directory.EnumerateFiles("FTPSourceData", "*.*", SearchOption.AllDirectories))
            {
                if(filename.Contains(".DS_Store") || filename.Contains("old") ) continue;
                Console.WriteLine(filename);
                InsertData(filename);
            }
            Console.WriteLine("finished");
        }

        static void InsertData(string filename)
        {
            Console.WriteLine("insert");
            var contents = File.ReadLines(filename);
            var sql = QueryString + string.Join(" UNION ", GetSelectRows(contents));

            const string connectionString = "Server=localhost;Database=ConsumptionValidator;User Id=sa;pwd=SA!sql2017";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine(sql);
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        static string QueryString =>
            "INSERT INTO dbo.DistributionLosses " +
            "(Date, " +  
            "StartTime, " + 
            "EndTime, " +
            "MarketParticipantId, " +
            "LLF, " +
            "Factor) ";

         static IEnumerable<string> GetSelectRows(IEnumerable<string> rows)
         {
            const int difference = 30;
            var area = string.Empty;
            var llf = string.Empty;
            var date = new DateTime();
            var zeroTime = TimeSpan.Parse("00:00:00");
            var startTime = string.Empty;
            var endTime = string.Empty;

            foreach (var row in rows)
            {
                var columns = row.Split('|');
                
                switch(new string[] {"ZHD", "DIS", "LLF", "SDT", "SPL"}.FirstOrDefault<string>(s => columns[0].Contains(s)))
                {
                    case "ZHD":
                        break;
                    case "DIS":
                        area = columns[1];
                        break;
                    case "LLF":
                        llf = columns[1];
                        break;
                    case "SDT":
                        date = DateTime.ParseExact(columns[1], "yyyyMMdd", CultureInfo.CurrentCulture);
                        break;
                    case "SPL":
                    {
                        startTime = zeroTime.Add(TimeSpan.FromMinutes(difference * (Int32.Parse(columns[1]) - 1))).ToString(@"hh\:mm\:ss");
                        endTime = zeroTime.Add(TimeSpan.FromMinutes(difference * Int32.Parse(columns[1]))).ToString(@"hh\:mm\:ss");
                        yield return $"SELECT CONVERT(datetime, '{date}', 103), '{startTime}', '{endTime}', '{area}', '{llf}', {columns[2]}";
                        break;
                    }
                }
            }
         }

    }
}
                