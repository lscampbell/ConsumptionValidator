using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nancy;
using MpanSetupService.Models;
using LoggingService.Models;
using Nancy.Validation;
using System.Threading.Tasks;

namespace MpanSetupService
{
    public class Module : NancyModule
    {
        ILogger<Module> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;


        public Module(ILoggerFactory loggerFactory, ServiceClient<LogRequest, LogResponse> loggingServiceClient)
        {
            _logger = loggerFactory.CreateLogger<Module>();
            _logServiceClient = loggingServiceClient;

            Get("/customers/{supplyPoint}/mpan", p => GetCompleteMpanAsync(new CompleteMpanRequest
                { SupplyPoint = p.supplyPoint }));
            Get("/customer/{supplyPoint}", p => GetSupplyCapacityAsync(new SupplyCapacityRequest 
                { SupplyPoint = p.supplyPoint }));
            Get("/customers/{customer}/contracts/{supplyPoint}/{date}", p => GetContractBandsAsync(new ChargeBandsRequest 
                { Customer = p.customer, SupplyPoint = p.supplyPoint, Date = p.date }));
        }
        
        async Task<CompleteMpanResponse> GetCompleteMpanAsync(CompleteMpanRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get complete mpan for {request.SupplyPoint}" });
                return new CompleteMpanResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new CompleteMpanResponse { Success = true, CompleteMpans = GetCompleteMpan(request.SupplyPoint) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Complete Mpan for {request.SupplyPoint}: {result.CompleteMpans}" });

            return result;
        }

        IEnumerable<MpanMeta> GetCompleteMpan(string customer) => new MpanMeta[] {
                new MpanMeta { Mpan = "001111209912345678321", Customer = "test-customer" }
            };

        async Task<SupplyCapacityResponse> GetSupplyCapacityAsync(SupplyCapacityRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get transmission loss factors for {request.SupplyPoint}" });
                return new SupplyCapacityResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new SupplyCapacityResponse { Success = true, Value = GetSupplyCapacity(request.SupplyPoint) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Supply Capacity for {request.SupplyPoint}: {result.Value}" });

            return result;
        }

        SupplyCapacity GetSupplyCapacity(string supplyPoint) => new SupplyCapacity { Value = 1500, UOM = "kva" };

        async Task<ChargeBandsResponse> GetContractBandsAsync(ChargeBandsRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get Contract Bands for {request.Customer}-{request.SupplyPoint}-{request.Date}" });
                return new ChargeBandsResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new ChargeBandsResponse { Success = true, ChargeBands = GetContractBands(request.Customer) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Contract Bands for {request.Customer}: {result.ChargeBands}" });

            return result;
        }

        IEnumerable<ChargeBand> GetContractBands(string customer) => new ChargeBand[] {
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "00:00:00", EndTime = "00:30:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "00:30:00", EndTime = "01:00:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "01:00:00", EndTime = "01:30:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "01:30:00", EndTime = "02:00:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "02:00:00", EndTime = "02:30:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "02:30:00", EndTime = "03:00:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "03:00:00", EndTime = "03:30:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "03:30:00", EndTime = "04:00:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "04:00:00", EndTime = "04:30:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "04:30:00", EndTime = "05:00:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "05:00:00", EndTime = "05:30:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 2.6F, StartTime = "05:30:00", EndTime = "06:00:00", Name = "Night" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "06:00:00", EndTime = "06:30:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "06:30:00", EndTime = "07:00:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "07:00:00", EndTime = "07:30:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "07:30:00", EndTime = "08:00:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "08:00:00", EndTime = "08:30:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "08:30:00", EndTime = "09:00:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "09:00:00", EndTime = "09:30:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "09:30:00", EndTime = "10:00:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "10:00:00", EndTime = "10:30:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "10:30:00", EndTime = "11:00:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "11:00:00", EndTime = "11:30:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "11:30:00", EndTime = "12:00:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "12:00:00", EndTime = "12:30:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "12:30:00", EndTime = "13:00:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "13:00:00", EndTime = "13:30:00", Name = "Day" },
                new ChargeBand { PencePerKwh = 5.2F, StartTime = "13:30:00", EndTime = "14:00:00", Name = "Day" }
        };
        
    }
}