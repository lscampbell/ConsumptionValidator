using System.Collections.Generic;
using System.Data;
using Dapper;
using TotalsService.Models;

namespace TotalsService.Persistence
{
    public class DuosRepository : IDuosRepository
    {
        readonly IDbConnection _connection;
        public DuosRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<DuosRow> GetAllByMpan(string mpan)
            => _connection.Query<DuosRow>(
                "SELECT * FROM dbo.TotalledDuos " +
               $"WHERE Mpan = '{mpan}'");

        public IEnumerable<DuosRow> GetByMpanAndDate(string mpan, string date)
            => _connection.Query<DuosRow>(
                "SELECT * FROM dbo.TotalledDuos " +
               $"WHERE Mpan = '{mpan}' " +
               $"AND Date = '{date}'");

        public IEnumerable<DuosRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate)
            => _connection.Query<DuosRow>(
                "SELECT * FROM dbo.TotalledDuos " +
               $"WHERE Mpan = '{mpan}' " +
               $"AND Date BETWEEN '{startDate}' AND '{endDate}'");

        public IEnumerable<DuosRow> GetAllBySupplyPointRef(string supplyPointRef)
            => _connection.Query<DuosRow>(
                "SELECT * FROM dbo.TotalledDuos " +
               $"WHERE SupplyPointRef = '{supplyPointRef}'");

        public IEnumerable<DuosRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date)
            => _connection.Query<DuosRow>(
                "SELECT * FROM dbo.TotalledDuos " +
               $"WHERE SupplyPointRef = '{supplyPointRef}' " +
               $"AND Date =  '{date}'");

        public IEnumerable<DuosRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate)
            => _connection.Query<DuosRow>(
                "SELECT * FROM dbo.TotalledDuos " +
               $"WHERE SupplyPointRef = '{supplyPointRef}' " +
               $"AND Date BETWEEN '{startDate}' AND '{endDate}'");

        public bool InsertDuosRow(DuosRow row)
        {
            int rowsAffected = _connection.Execute(
            //     "DELETE FROM dbo.TotalledDuos " + 
            //    $"WHERE SupplyPointRef = '{row.SupplyPointRef}' " +
            //    $"AND Date = '{row.Date}';" +
                @"INSERT INTO dbo.TotalledDuos(Mpan,SupplyPointRef,Date,Band,Units,UOM,UnitCharge,Charge,Count)" +  
                "VALUES" +  
                $"('{row.Mpan}', '{row.SupplyPointRef}', CONVERT(datetime, '{row.Date}', 103), '{row.Band}', {row.Units}, '{row.UOM}', {row.UnitCharge}, {row.Charge}, {row.Count})");

            if (rowsAffected > 0)
                return true;

            return false;
        }
    }
}