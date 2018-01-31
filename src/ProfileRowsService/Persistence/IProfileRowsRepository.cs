using System;
using System.Collections.Generic;
using ProfileRowsService.Models;

namespace ProfileRowsService.Persistence
{
    public interface IProfileRowsRepository
    {
        IEnumerable<ProfileRow> GetByMpan(string mpan, string date);
        IEnumerable<ProfileRow> GetBySupplyPointRef(string supplyPointRef, string date);
    }
}