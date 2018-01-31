using System.Collections.Generic;
using IndustryDataService.Models;
using Dapper;
using System.Data;

namespace IndustryDataService.Persistence
{
    public class ProfileClassRepository : IProfileClassRepository
    {
        readonly IDbConnection _connection;

        public ProfileClassRepository(IDbConnection connection)
            => _connection = connection;

        public IEnumerable<ProfileClass> GetAll()
        => _connection.Query<ProfileClass>("SELECT * FROM dbo.PCs");
    }
}