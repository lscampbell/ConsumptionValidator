using System.Collections.Generic;
using IndustryDataService.Models;

namespace IndustryDataService.Persistence
{
    public interface IMeterTimeSwitchClassRepository
    {
        IEnumerable<MeterTimeSwitchClass> GetAll();
    }
}
