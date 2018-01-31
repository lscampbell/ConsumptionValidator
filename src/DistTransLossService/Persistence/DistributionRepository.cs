using System.Collections.Generic;
using DistTransLossService.Models;
using Dapper;
using System.Data;
using System;

namespace DistTransLossService.Persistence
{
    public class DistributionRepository : IDistributionRepository
    {
        readonly IDbConnection _connection;
        public DistributionRepository(IDbConnection connection) 
            => _connection = connection;

        public IEnumerable<Distribution> GetAll(string marketParticipantId, string llf, string date) 
            => _connection.Query<Distribution>("SELECT * FROM DistributionLosses " +
                                              $"WHERE MarketParticipantId = '{marketParticipantId}' " +
                                              $"AND LLF = '{llf}' " +
                                              $"AND Date = '{date}'");
    }
}