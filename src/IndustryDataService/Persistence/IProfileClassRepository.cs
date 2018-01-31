using System.Collections.Generic;
using IndustryDataService.Models;

namespace IndustryDataService.Persistence
{
    public interface IProfileClassRepository
    {
        IEnumerable<ProfileClass> GetAll();
    }
}
