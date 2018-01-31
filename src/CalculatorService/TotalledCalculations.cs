using System.Collections.Generic;
using CalculatorService.Models;
using System.Linq;

namespace CalculatorService
{
    public class TotalledCalculations
    {
        IEnumerable<CombinedProfileLosses> _combinedLosses { get; set; }
        public List<DuosBand> DuosBand { get; set; }
        int _supplyCapacity { get; set; }
        DuosLossService.Models.Tariff _duosTariffs { get; set; }
        IEnumerable<LossBand> _lossBand { get; set; }
        IEnumerable<EnergyBand> _energyBand { get; set; }


        public TotalledCalculations(
            IEnumerable<CombinedProfileLosses> combinedLosses,
            int supplyCapacity, DuosLossService.Models.Tariff duosTariffs,
            IEnumerable<LossBand> lossBand, IEnumerable<EnergyBand> energyBand)
        {
            _combinedLosses = combinedLosses;
            DuosBand = new List<DuosBand>();
            _supplyCapacity = supplyCapacity;
            _duosTariffs = duosTariffs;
            _lossBand = lossBand;
            _energyBand = energyBand;
        }

        public void Total()
        {
            var tempTotallDuos = _combinedLosses.GroupBy(s => s.DuosBand)
                .Select(s => new {
                    Band = s.Key,
                    Kwh = s.Sum(g => g.Kwh),
                    DuosUnitCharge = s.Sum(g => g.DuosUnitCharge),
                    Count = s.Sum(g => 1)
                }).ToList();

            var green = tempTotallDuos.Find(f => f.Band == "Green");
            var amber = tempTotallDuos.Find(f => f.Band == "Amber");
            var red = tempTotallDuos.Find(f => f.Band == "Red");

            DuosBand.Add(new DuosBand{
                Band = "Green Unit Charge",
                Units = green.Kwh,
                UOM = "p/kwh", 
                UnitCharge = _duosTariffs.Green,
                Charge = (decimal)_duosTariffs.Green * green.Kwh,
                Count = green.Count
            });
            DuosBand.Add(new DuosBand{
                Band = "Amber Unit Charge",
                Units = amber.Kwh,
                UOM = "p/kwh", 
                UnitCharge = _duosTariffs.Amber,
                Charge = (decimal)_duosTariffs.Amber * green.Kwh,
                Count = amber.Count
            });
            DuosBand.Add(new DuosBand{
                Band = "Red Unit Charge",
                Units = red.Kwh,
                UOM = "p/kwh", 
                UnitCharge = _duosTariffs.Red,
                Charge = (decimal)_duosTariffs.Red * red.Kwh,
                Count = red.Count
            });
            DuosBand.Add(new DuosBand{
                Band = "Capacity Charge",
                Units = _supplyCapacity,
                UOM = "p/kva/day", 
                UnitCharge = _duosTariffs.Capacity,
                Charge = (decimal)_duosTariffs.Capacity * _supplyCapacity,
                Count = 1
            });
            DuosBand.Add(new DuosBand{
                Band = "Exceeded Capacity Charge",
                Units = _supplyCapacity,
                UOM = "p/kva/day", 
                UnitCharge = _duosTariffs.ExceededCapacity,
                Charge = (decimal)(_duosTariffs.ExceededCapacity * _supplyCapacity),
                Count = 1
            });
            DuosBand.Add(new DuosBand{
                Band = "Fixed Charge",
                Units = 1,
                UOM = "p/day", 
                UnitCharge = _duosTariffs.Fixed,
                Charge = (decimal)_duosTariffs.Fixed * 1,
                Count = 1
            });
        }
    }
}