using System.Collections.Generic;
using System.Data;
using Dapper;
using TuosLossService.Models;

namespace TuosLossService.Persistence
{
    public class TuosChargeRepository : ITuosChargeRepository
    {
        readonly IDbConnection _connection;
        public TuosChargeRepository(IDbConnection connection) 
            => _connection = connection;

        public IEnumerable<TuosCharge> GetAll(string marketParticipantId, string date)
            => _connection.Query<TuosCharge>(
                "SELECT * FROM dbo.TuosCharges " +
               $"WHERE MarketParticipantId = '{marketParticipantId}' " +
               $"AND '{date}' BETWEEN StartDate AND EndDate");
    }
}