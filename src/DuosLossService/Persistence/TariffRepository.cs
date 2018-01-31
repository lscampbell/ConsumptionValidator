using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using DuosLossService.Models;

namespace DuosLossService.Persistence
{
    public class TariffRepository : ITariffRepository
    {
        readonly IDbConnection _connection;
        public TariffRepository(IDbConnection connection) => _connection = connection;
        public IEnumerable<Tariff> GetAll(string marketParticipantId, string llf, DateTime date) 
            => _connection.Query<Tariff>(
                "SELECT * FROM dbo.DuosTariffs " +
                $"WHERE LLF = '{llf}' " +
                $"AND MarketParticipantId = '{marketParticipantId}' " +
                $"AND '{date}' BETWEEN StartDate AND EndDate");
    }
}