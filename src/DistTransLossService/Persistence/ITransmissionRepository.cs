using System.Collections.Generic;
using DistTransLossService.Models;

namespace DistTransLossService.Persistence
{
    public interface ITransmissionRepository
    {   
        IEnumerable<Transmission> GetAll();
    }
}