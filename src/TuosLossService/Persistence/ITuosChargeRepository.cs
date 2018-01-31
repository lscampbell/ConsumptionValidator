using System.Collections.Generic;
using TuosLossService.Models;

namespace TuosLossService.Persistence
{
    public interface ITuosChargeRepository
    {
        IEnumerable<TuosCharge> GetAll(string marketParticipantId, string date);
    }
}