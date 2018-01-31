using System.Collections.Generic;
using DistTransLossService.Models;
using Dapper;
using System.Data;

namespace DistTransLossService.Persistence
{
    public class TransmissionRepository : ITransmissionRepository
    {
        readonly IDbConnection _connection;
        public TransmissionRepository(IDbConnection connection) 
            => _connection = connection;

        public IEnumerable<Transmission> GetAll() 
            => _connection.Query<Transmission>("SELECT * FROM dbo.TransmissionLoss");

    }
}