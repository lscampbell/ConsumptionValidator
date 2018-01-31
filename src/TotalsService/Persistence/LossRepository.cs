using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using Dapper;
using TotalsService.Models;

namespace TotalsService.Persistence
{
    public class LossRepository : ILossRepository
    {
        readonly IDbConnection _connection;
        public LossRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<LossRow> GetAllByMpan(string mpan)
            => _connection.Query<LossRow>(
                "SELECT * FROM dbo.TotalledLoss " +
               $"WHERE Mpan = '{mpan}'");

        public IEnumerable<LossRow> GetByMpanAndDate(string mpan, string date)
            => _connection.Query<LossRow>(
                "SELECT * FROM dbo.TotalledLoss " +
               $"WHERE Mpan = '{mpan}' " +
               $"AND Date = '{date}'");

        public IEnumerable<LossRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate)
            => _connection.Query<LossRow>(
                "SELECT * FROM dbo.TotalledLoss " +
               $"WHERE Mpan = '{mpan}' " +
               $"AND Date BETWEEN '{startDate}' AND '{endDate}'");

        public IEnumerable<LossRow> GetAllBySupplyPointRef(string supplyPointRef)
            => _connection.Query<LossRow>(
                "SELECT * FROM dbo.TotalledLoss " +
               $"WHERE SupplyPointRef = '{supplyPointRef}'");

        public IEnumerable<LossRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date)
            => _connection.Query<LossRow>(
                "SELECT * FROM dbo.TotalledLoss " +
               $"WHERE SupplyPointRef = '{supplyPointRef}' " +
               $"AND Date = '{date}'");

        public IEnumerable<LossRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate)
            => _connection.Query<LossRow>(
                "SELECT * FROM dbo.TotalledLoss " +
               $"WHERE SupplyPointRef = '{supplyPointRef}' " +
               $"AND Date BETWEEN '{startDate}' AND '{endDate}'");

        public bool InsertLossRow(LossRow row)
        {
            int rowsAffected = _connection.Execute(
            //     "DELETE FROM dbo.TotalledLoss " + 
            //    $"WHERE SupplyPointRef = '{row.SupplyPointRef}' " +
            //    $"AND Date = '{row.Date}';" +
                @"INSERT INTO dbo.TotalledLoss(Mpan,SupplyPointRef,Date,Band,PencePerKwh,DLossKwh,TLossKwh,Count)" +  
                "VALUES" +  
                $"('{row.Mpan}', '{row.SupplyPointRef}', CONVERT(datetime, '{row.Date}', 103), '{row.Band}', {row.PencePerKwh}, {row.DLossKwh}, {row.TLossKwh}, {row.Count})");

            if (rowsAffected > 0)
                return true;

            return false;
        }
    }
}