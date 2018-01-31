using System.Collections;
using System.Collections.Generic;
using CalculatorService.Models;

namespace CalculatorService
{
    public class CalculatedData
    {
        public List<CombinedProfileLosses> CombinedLosses { get; set; }
        public List<EnergyBand> EnergyBand { get; set; }
        public List<LossBand> LossBand { get; set; }
        IEnumerable<ProfileRow> _profileData { get; set; }
        IEnumerable<TimeBand> _duosTimeBands {get; set; }
        DuosLossService.Models.Tariff _duosTariffs { get; set; }
        IEnumerable<DistributionLoss> _dLosses { get; set; }
        IEnumerable<ChargeBand> _contractBands { get; set; }
        float _tLossFactor { get; set; }

        public CalculatedData(
            IEnumerable<ProfileRow> profileData,
            IEnumerable<TimeBand> duosTimeBands,
            DuosLossService.Models.Tariff duosTariffs,
            IEnumerable<DistributionLoss> dLosses,
            float tLossFactor,
            IEnumerable<ChargeBand> contractBands
        )
        {
            _profileData = profileData;
            _duosTimeBands = duosTimeBands;
            _duosTariffs = duosTariffs;
            _dLosses = dLosses;
            _tLossFactor = tLossFactor;
            _contractBands = contractBands;
        }

        public void Calculate()
        {
            CombinedLosses = new List<CombinedProfileLosses>();
            EnergyBand = new List<EnergyBand>();
            LossBand = new List<LossBand>();

            foreach(var row in _profileData)
            {
                string band = string.Empty;
                float duosPerKwh = 0;
                float dLossFactor = 0;
                float pencePerKwh = 0;

                foreach(var timeRow in _duosTimeBands)
                {
                    if((row.StartTime == timeRow.StartTime) && (row.EndTime == timeRow.EndTime))
                    {
                        switch(timeRow.Type)
                        {
                            case "Red": 
                                duosPerKwh = _duosTariffs.Red;
                                break;
                            case "Amber":
                                duosPerKwh = _duosTariffs.Amber;
                                break; 
                            default:
                                duosPerKwh = _duosTariffs.Green;
                                break; 
                        }
                        band = timeRow.Type;
                     }
                }

                foreach(var lossRow in _dLosses)
                {
                    if((row.StartTime == lossRow.StartTime) && (row.EndTime == lossRow.EndTime))
                        dLossFactor = lossRow.LossAdjustmentFactor;
                }

                CombinedLosses.Add(new CombinedProfileLosses{
                    DuosBand = band,
                    StartTime = row.StartTime,
                    EndTime = row.EndTime,
                    Kwh = row.Kwh,
                    DuosChargePerKwh = duosPerKwh,
                    DuosUnitCharge = ( row.Kwh * duosPerKwh ) / 100F,
                    TLossFactor = _tLossFactor,
                    TLoss = row.Kwh * (_tLossFactor - 1.0F),
                    DLossFactor = dLossFactor,
                    DLoss = row.Kwh * (dLossFactor - 1.0F) 
                });
                
                foreach(var contractRow in _contractBands)
                {
                    if((row.StartTime == contractRow.StartTime) && (row.EndTime == contractRow.EndTime))
                    {
                        band = contractRow.Name;
                        pencePerKwh = contractRow.PencePerKwh;
                    }
                }

                EnergyBand.Add(new EnergyBand{
                    Band = band,
                    PencePerKwh = pencePerKwh,
                    Kwh = row.Kwh,
                    EnergyCost = pencePerKwh * (float)row.Kwh,
                    Count = 1
                });

                LossBand.Add(new LossBand{
                    Band = band,
                    PencePerKwh = pencePerKwh,
                    DLossFactor = dLossFactor,
                    TLossFactor = _tLossFactor,
                    TLossKwh = row.Kwh * (_tLossFactor - 1.0F),
                    DLossKwh = row.Kwh * (dLossFactor - 1.0F),
                    Count = 1
                });
            }    
        }

    }
}