using System.Collections.Generic;
using UtilitiesService;
using CalculatorService.Models;
using DuosLossService.Models;
using DistTransLossService.Models;
using System;
using System.Linq;

namespace CalculatorService
{
    public class RetrieveData
    {
        readonly string _date;
        readonly string _supplyPointRef;
        readonly string _marketParticipantId;
        readonly string _llf;
        readonly CustomerService.Models.CustomerName _customer;
        readonly StringTo _st = new StringTo();
        public RetrieveData(string date, string supplyPointRef, string llf, string marketParticipantId)
        {
            _marketParticipantId = marketParticipantId;
            _date = date;
            _llf = llf;
            _supplyPointRef = supplyPointRef;
            _customer = GetCustomer().First();
        }

        #region Get Duos for day
        public List<Models.TimeBand> GetDuosTimeBands()
        {
            var list = new List<Models.TimeBand>();
            foreach(var item in GetTimeBands())
            {   
                list.Add(new Models.TimeBand {
                    StartTime = _st.TimeSpan(item.StartTime).Result,
                    EndTime = _st.TimeSpan(item.EndTime).Result,
                    Type = item.Band
                });
            };
            return list;
        }

        public List<Tariff> GetDuosTariffs() => GetTariffs().ToList();

        IEnumerable<DuosLossService.Models.TimeBand> GetTimeBands()
            => new GetDataObject<IEnumerable<DuosLossService.Models.TimeBand>>($"http://localhost:1517/api/timebands/{_marketParticipantId}/{_date}")
                .MakeCall();

        IEnumerable<DuosLossService.Models.Tariff> GetTariffs()
            => new GetDataObject<IEnumerable<DuosLossService.Models.Tariff>>($"http://localhost:1517/api/tariffs/{_marketParticipantId}/{_llf}/{_date}")
                .MakeCall();

        #endregion
        #region Get Loss Factors for Day
        public List<DistributionLoss> GetLosses()
        {
            var list = new List<DistributionLoss>();
            foreach(var item in GetDLoss())
            {   
                list.Add(new DistributionLoss {
                    StartTime = _st.TimeSpan(item.StartTime).Result,
                    EndTime = _st.TimeSpan(item.EndTime).Result,
                    LossAdjustmentFactor = item.Factor
                });
            };
            return list;
        }
        public float GetTLossFactor() => GetTLoss().Factor;

        IEnumerable<Distribution> GetDLoss() 
            => new GetDataObject<IEnumerable<Distribution>>($"http://localhost:1514/api/distribution/{_marketParticipantId}/{_llf}/{_date}")
                .MakeCall();

        Transmission GetTLoss() 
            => new GetDataObject<Transmission>($"http://localhost:1514/api/transmission")
                .MakeCall();

        #endregion
        #region Get Profile for Day

        public List<Models.ProfileRow> GetProfileData() 
        {
            var list = new List<Models.ProfileRow>();
            foreach(var item in GetProfile())
            {
                list.Add(new Models.ProfileRow {
                    StartTime = _st.TimeSpan(item.StartTime).Result,
                    EndTime = _st.TimeSpan(item.EndTime).Result,
                    Kwh = (int)item.Kwh
                });
            };
            return list;
        }

        IEnumerable<ProfileRowsService.Models.ProfileRow> GetProfile()
            => new GetDataObject<IEnumerable<ProfileRowsService.Models.ProfileRow>>($"http://localhost:1519/api/profile/supply/{_supplyPointRef}/{_date}")
            .MakeCall();

        #endregion
        #region Get Charges for Day
      
        public string GetCustomerName() => GetCustomer().First().Customer;

        IEnumerable<CustomerService.Models.CustomerName> GetCustomer()
            => new GetDataObject<IEnumerable<CustomerService.Models.CustomerName>>($"http://localhost:1512/api/customer/supply/{_supplyPointRef}")
                .MakeCall();

        public List<CalculatorService.Models.ChargeBand> GetContractBands()
        {
            var list = new List<CalculatorService.Models.ChargeBand>();
            foreach(var item in GetContracts())
            {
                list.Add(new CalculatorService.Models.ChargeBand {
                    Name = item.Name,
                    StartTime = _st.TimeSpan(item.StartTime).Result,
                    EndTime = _st.TimeSpan(item.EndTime).Result,
                    PencePerKwh = item.PencePerKwh
                });
            };
            return list;
        }
        IEnumerable<CustomerService.Models.ContractBand> GetContracts()
            => new GetDataObject<IEnumerable<CustomerService.Models.ContractBand>>($"http://localhost:1512/api/contracts/bands/{_customer.Customer}/supply/{_supplyPointRef}/{_date}")
                .MakeCall();
        
        public int GetSupplyCapacity() => GetCapacity().AvailableCapacity;

        SupplyPointService.Models.SupplyCapacity GetCapacity()
            => new GetDataObject<SupplyPointService.Models.SupplyCapacity>($"http://localhost:1518/api/capacity/supply/{_supplyPointRef}")
                .MakeCall();

        #endregion
    }
}
