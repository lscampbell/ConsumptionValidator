using System;
using System.Collections.Generic;
using DistTransLossService.Models;

namespace DistTransLossService.Persistence
{
    public interface IDistributionRepository
    {
        IEnumerable<Distribution> GetAll(string marketParticipantId, string llf, string date);
    }
}