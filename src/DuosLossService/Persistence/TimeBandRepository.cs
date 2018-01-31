using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DuosLossService.Models;

namespace DuosLossService.Persistence
{
    public class TimeBandRepository : ITimeBandRepository
    {        
        readonly IDbConnection _connection;
        public TimeBandRepository(IDbConnection connection) 
            => _connection = connection;

        public IEnumerable<TimeBand> GetAll(string marketParticipantId, DateTime date) 
            => _connection.Query<TimeBand>(
                "SELECT * FROM dbo.DuosTimeBands " +
                $"WHERE MarketParticipantId = '{marketParticipantId}' " +
                $"AND '{date}' BETWEEN StartDate AND EndDate");
    }
}