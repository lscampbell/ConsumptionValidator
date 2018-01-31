using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace DemoDataImporter
{
    class Program
    {
        // public static object GetRows { get; private set; }
        // public static string QueryString { get; private set; }
        // private static IEnumerable<string> GetSelectRows(object contents) => throw new NotImplementedException();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Inserting data");

            var contents = GetRows;
            var sql = QueryString + string.Join(" UNION ", GetSelectRows(contents));

            const string connectionString = "Server=localhost;Database=ConsumptionValidator;User Id=sa;pwd=SA!sql2017";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Execute(sql);
                    Console.WriteLine("Data entry complete!");
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

        #region Test Contract Bands 

        // static string QueryString =>
        //     "INSERT INTO dbo.ContractBands " +
        //     "(Mpan, " +
        //     "SupplyPointRef, " +
        //     "Customer, " + 
        //     "Date, " + 
        //     "PencePerKwh, " + 
        //     "StartTime, " + 
        //     "EndTime, " + 
        //     "Name) ";

        // static IEnumerable<string> GetSelectRows(IEnumerable<dynamic> contents)
        // {
        //     foreach (var row in contents)
        //         yield return $"SELECT '{row.Mpan}', '{row.SupplyPointRef}', '{row.Customer}', CONVERT(datetime, '{row.Date}', 103), {row.PencePerKwh}, '{row.StartTime}', '{row.EndTime}', '{row.Name}'";
        // }

        // static IEnumerable<object> GetRows => new object [] {
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "00:00:00", EndTime = "00:30:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "00:30:00", EndTime = "01:00:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "01:00:00", EndTime = "01:30:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "01:30:00", EndTime = "02:00:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "02:00:00", EndTime = "02:30:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "02:30:00", EndTime = "03:00:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "03:00:00", EndTime = "03:30:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "03:30:00", EndTime = "04:00:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "04:00:00", EndTime = "04:30:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "04:30:00", EndTime = "05:00:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "05:00:00", EndTime = "05:30:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 2.6F, StartTime = "05:30:00", EndTime = "06:00:00", Name = "Night" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "06:00:00", EndTime = "06:30:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "06:30:00", EndTime = "07:00:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "07:00:00", EndTime = "07:30:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "07:30:00", EndTime = "08:00:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "08:00:00", EndTime = "08:30:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "08:30:00", EndTime = "09:00:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "09:00:00", EndTime = "09:30:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "09:30:00", EndTime = "10:00:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "10:00:00", EndTime = "10:30:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "10:30:00", EndTime = "11:00:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "11:00:00", EndTime = "11:30:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "11:30:00", EndTime = "12:00:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "12:00:00", EndTime = "12:30:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "12:30:00", EndTime = "13:00:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "13:00:00", EndTime = "13:30:00", Name = "Day" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Customer = "Test Customer", Date = "01/02/2012 00:00:00", PencePerKwh = 5.2F, StartTime = "13:30:00", EndTime = "14:00:00", Name = "Day" }
        // };

        #endregion
        #region Test Profile Rows

        // static string QueryString =>
        //     "INSERT INTO dbo.ProfileRows " +
        //     "(Mpan, " +
        //     "SupplyPointRef, " +
        //     "Date, " + 
        //     "Kwh, " + 
        //     "StartTime, " + 
        //     "EndTime) ";

        // static IEnumerable<object> GetRows => new object [] {
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Date = "01/02/2012 00:00:00", Kwh = 800, StartTime = "00:00:00", EndTime = "00:30:00" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Date = "01/02/2012 00:00:00", Kwh = 400, StartTime = "06:00:00", EndTime = "06:30:00" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Date = "01/02/2012 00:00:00", Kwh = 600, StartTime = "07:00:00", EndTime = "07:30:00" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Date = "01/02/2012 00:00:00", Kwh = 200, StartTime = "10:30:00", EndTime = "11:00:00" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Date = "01/02/2012 00:00:00", Kwh = 700, StartTime = "11:00:00", EndTime = "11:30:00" },
        //         new { Mpan = "001112229912345678345", SupplyPointRef = "9912345678345", Date = "01/02/2012 00:00:00", Kwh = 650, StartTime = "13:30:00", EndTime = "14:00:00" }
        // };

        // static IEnumerable<string> GetSelectRows(IEnumerable<dynamic> contents)
        // {
        //     foreach (var row in contents)
        //         yield return $"SELECT '{row.Mpan}', '{row.SupplyPointRef}', CONVERT(datetime, '{row.Date}', 103), {row.Kwh}, '{row.StartTime}', '{row.EndTime}'";
        // }

        #endregion
        #region Test Distribution Loss

        // static string QueryString =>
        //     "INSERT INTO dbo.DistributionLosses " +
        //     "(Date, " + 
        //     "StartTime, " + 
        //     "EndTime, " +
        //     "MarketParticipantId, " +
        //     "LLF, " +
        //     "Factor )";

        // static IEnumerable<object> GetRows => new object [] {
        //         new { Date = "01/02/2012 00:00:00", StartTime = "00:00:00", EndTime = "00:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "00:30:00", EndTime = "01:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "01:00:00", EndTime = "01:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "01:30:00", EndTime = "02:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "02:00:00", EndTime = "02:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "02:30:00", EndTime = "03:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "03:00:00", EndTime = "03:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "03:30:00", EndTime = "04:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "04:00:00", EndTime = "04:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "04:30:00", EndTime = "05:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "05:00:00", EndTime = "05:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "05:30:00", EndTime = "06:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.02F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "06:00:00", EndTime = "06:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.04F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "06:30:00", EndTime = "07:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.04F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "07:00:00", EndTime = "07:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.04F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "07:30:00", EndTime = "08:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.04F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "08:00:00", EndTime = "08:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "08:30:00", EndTime = "09:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "09:00:00", EndTime = "09:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "09:30:00", EndTime = "10:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "10:00:00", EndTime = "10:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "10:30:00", EndTime = "11:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "11:00:00", EndTime = "11:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "11:30:00", EndTime = "12:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "12:00:00", EndTime = "12:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "12:30:00", EndTime = "13:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "13:00:00", EndTime = "13:30:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F },
        //         new { Date = "01/02/2012 00:00:00", StartTime = "13:30:00", EndTime = "14:00:00", MarketParticipantId = "LOND", LLF = "801", Factor = 1.06F }
        // };

        // static IEnumerable<string> GetSelectRows(IEnumerable<dynamic> contents)
        // {
        //     foreach (var row in contents)
        //         yield return $"SELECT CONVERT(datetime, '{row.Date}', 103), '{row.StartTime}', '{row.EndTime}', '{row.MarketParticipantId}', '{row.LLF}', {row.Factor}";
        // }

        #endregion
        #region Test Duos Time Bands
        static string QueryString =>
            "INSERT INTO dbo.DuosTimeBands " +
            "(MarketParticipantId, " +
            "StartDate, " +
            "EndDate, " + 
            "LLF, " +
            "ApplicableDays, " + 
            "ApplicableMonths, " + 
            "StartTime, " + 
            "EndTime, " + 
            "Band) ";

        static IEnumerable<object> GetRows => new object [] {
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "00:00:00", EndTime = "00:30:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "00:30:00", EndTime = "01:00:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "01:00:00", EndTime = "01:30:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "01:30:00", EndTime = "02:00:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "02:00:00", EndTime = "02:30:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "02:30:00", EndTime = "03:00:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "03:00:00", EndTime = "03:30:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "03:30:00", EndTime = "04:00:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "04:00:00", EndTime = "04:30:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "04:30:00", EndTime = "05:00:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "05:00:00", EndTime = "05:30:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "05:30:00", EndTime = "06:00:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "06:00:00", EndTime = "06:30:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "06:30:00", EndTime = "07:00:00", Band = "Green" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "07:00:00", EndTime = "07:30:00", Band = "Amber" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "07:30:00", EndTime = "08:00:00", Band = "Amber" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "08:00:00", EndTime = "08:30:00", Band = "Amber" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "08:30:00", EndTime = "09:00:00", Band = "Amber" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "09:00:00", EndTime = "09:30:00", Band = "Amber" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "09:30:00", EndTime = "10:00:00", Band = "Amber" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "10:00:00", EndTime = "10:30:00", Band = "Amber" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "10:30:00", EndTime = "11:00:00", Band = "Amber" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "11:00:00", EndTime = "11:30:00", Band = "Red" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "11:30:00", EndTime = "12:00:00", Band = "Red" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "12:00:00", EndTime = "12:30:00", Band = "Red" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "12:30:00", EndTime = "13:00:00", Band = "Red" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "13:00:00", EndTime = "13:30:00", Band = "Red" },
                new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", ApplicableDays = "Mon,Tue,Wed,Thu,Fri", ApplicableMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", StartTime = "13:30:00", EndTime = "14:00:00", Band = "Red" }
        };

        static IEnumerable<string> GetSelectRows(IEnumerable<dynamic> contents)
        {
            foreach (var row in contents)
                yield return $"SELECT '{row.MarketParticipantId}', CONVERT(datetime, '{row.StartDate}', 103), CONVERT(datetime, '{row.EndDate}', 103), '{row.LLF}', '{row.ApplicableDays}', '{row.ApplicableMonths}', '{row.StartTime}', '{row.EndTime}', '{row.Band}'";
        }
        #endregion
        #region Test Duos Tariffs
        // static string QueryString =>
        //     "INSERT INTO dbo.DuosTariffs " +
        //     "(MarketParticipantId, " +
        //     "StartDate, " +
        //     "EndDate, " + 
        //     "LLF, " +
        //     "Name, " +
        //     "Red, " + 
        //     "Amber, " + 
        //     "Green, " + 
        //     "Fixed, " + 
        //     "Capacity, " + 
        //     "ExceededCapacity) ";

        // static IEnumerable<object> GetRows => new object [] {
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F },
        //         new { MarketParticipantId = "TEST", StartDate = "01/12/2011 00:00:00", EndDate = "31/03/2012 00:00:00", LLF = "222", Name = "LVHH Metered", Red = 4.874F, Amber = 0.434F, Green = 0.011F, Fixed = 3.45F, Capacity = 3.14F, ExceededCapacity = 4.2F }
        // };  
        
        // static IEnumerable<string> GetSelectRows(IEnumerable<dynamic> contents)
        // {
        //     foreach (var row in contents)
        //         yield return $"SELECT '{row.MarketParticipantId}', CONVERT(datetime, '{row.StartDate}', 103), CONVERT(datetime, '{row.EndDate}', 103), '{row.LLF}', '{row.Name}', {row.Red}, {row.Amber}, {row.Green}, {row.Fixed}, {row.Capacity}, {row.ExceededCapacity}";
        // }
        #endregion  
    }  
}  
