using System;
using System.Collections.Generic;
using DuosLossService.Models;

namespace DuosLossService.Persistence
{
    public interface ITariffRepository
    {
        IEnumerable<Tariff> GetAll(string marketParticipantId, string LLF, DateTime date);
    }
}