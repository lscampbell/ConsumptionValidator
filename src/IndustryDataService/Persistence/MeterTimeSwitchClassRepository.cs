using System.Collections.Generic;
using IndustryDataService.Models;
using Dapper;
using System.Data;

namespace IndustryDataService.Persistence
{
    public class MeterTimeSwitchClassRepository : IMeterTimeSwitchClassRepository
    {
        readonly IDbConnection _connection;

        public MeterTimeSwitchClassRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<MeterTimeSwitchClass> GetAll()
            => _connection.Query<MeterTimeSwitchClass>("SELECT * FROM dbo.MTCs");
    }
}
