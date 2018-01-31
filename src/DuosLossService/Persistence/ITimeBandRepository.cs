using System;
using System.Collections.Generic;
using DuosLossService.Models;

namespace DuosLossService.Persistence
{
    public interface ITimeBandRepository
    {
        IEnumerable<TimeBand> GetAll(string marketParticipantId, DateTime date);
    }
}