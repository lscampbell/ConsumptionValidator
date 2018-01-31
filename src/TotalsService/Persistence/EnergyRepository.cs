using System.Collections.Generic;
using System.Data;
using Dapper;
using TotalsService.Models;

namespace TotalsService.Persistence
{
    public class EnergyRepository : IEnergyRepository
    {
        readonly IDbConnection _connection;
        public EnergyRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<EnergyRow> GetAllByMpan(string mpan)
            => _connection.Query<EnergyRow>(
                "SELECT * FROM dbo.TotalledEnergy " +
               $"WHERE Mpan = '{mpan}'");

        public IEnumerable<EnergyRow> GetByMpanAndDate(string mpan, string date)
            => _connection.Query<EnergyRow>(
                "SELECT * FROM dbo.TotalledEnergy " +
               $"WHERE Mpan = '{mpan}' " +
               $"AND Date = '{date}'");

        public IEnumerable<EnergyRow> GetByMpanBetweenDates(string mpan, string startDate, string endDate)
            => _connection.Query<EnergyRow>(
                "SELECT * FROM dbo.TotalledEnergy " +
               $"WHERE Mpan = '{mpan}' " +
               $"AND Date BETWEEN '{startDate}' AND '{endDate}'");

        public IEnumerable<EnergyRow> GetAllBySupplyPointRef(string supplyPointRef)
            => _connection.Query<EnergyRow>(
                "SELECT * FROM dbo.TotalledEnergy " +
               $"WHERE SupplyPointRef = '{supplyPointRef}'");

        public IEnumerable<EnergyRow> GetBySupplyPointRefAndDate(string supplyPointRef, string date)
            => _connection.Query<EnergyRow>(
                "SELECT * FROM dbo.TotalledEnergy " +
               $"WHERE SupplyPointRef = '{supplyPointRef}' " +
               $"AND Date = '{date}'");

        public IEnumerable<EnergyRow> GetBySupplyPointRefBetweenDates(string supplyPointRef, string startDate, string endDate)
            => _connection.Query<EnergyRow>(
                "SELECT * FROM dbo.TotalledEnergy " +
               $"WHERE SupplyPointRef = '{supplyPointRef}' " +
               $"AND Date BETWEEN '{startDate}' AND '{endDate}'");

        public bool InsertEnergyRow(EnergyRow row)
        {
            int rowsAffected = _connection.Execute(
            //     "DELETE FROM dbo.TotalledEnergy " + 
            //    $"WHERE SupplyPointRef = '{row.SupplyPointRef}' " +
            //    $"AND Date = '{row.Date}';" +
                @"INSERT INTO dbo.TotalledEnergy(Mpan,SupplyPointRef,Date,Band,PencePerKwh,Kwh,EnergyCost,Count)" +  
                "VALUES" +  
                $"('{row.Mpan}', '{row.SupplyPointRef}', CONVERT(datetime, '{row.Date}', 103), '{row.Band}', {row.PencePerKwh}, {row.Kwh}, {row.EnergyCost}, {row.Count})");

            if (rowsAffected > 0)
                return true;

            return false;
        }
    }
}