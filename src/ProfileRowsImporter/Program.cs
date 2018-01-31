using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Dapper;

namespace ProfileRowsImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            foreach (var filename in Directory.EnumerateFiles("FTPSourceData", "*.*", SearchOption.AllDirectories))
            {
                Console.WriteLine(filename);
                InsertData(filename);
            }
            Console.WriteLine("end");
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
             "INSERT INTO dbo.ProfileRows " +
             "(Mpan, " +
             "SupplyPointRef, " +
             "Date, " + 
             "Kwh, " + 
             "StartTime, " + 
             "EndTime) ";

         static IEnumerable<string> GetSelectRows(IEnumerable<string> rows)
         {
            foreach (var row in rows.Skip(1))
            {
                var columns = row.Replace("\"", string.Empty).Split(',');
                
                //ToDo: Need to sort out the columns
                yield return $"SELECT {columns[0]}, '{columns[1]}', CONVERT(datetime, '{columns[2]}', 103), '{columns[3]}', {columns[4]}, '{columns[5]}', {columns[6]}, '{columns[7]}', N'{columns[8]}', {columns[9]}, {columns[10]}, {columns[11]}, {columns[12]} ";
            }
         }
    }
}
