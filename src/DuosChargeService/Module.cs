using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nancy;
using DuosChargeService.Models;
using LoggingService.Models;
using Nancy.Validation;
using System.Threading.Tasks;

namespace DuosChargeService
{
    public class Module : NancyModule
    {
        ILogger<Module> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;

        public Module(ILoggerFactory loggerFactory, ServiceClient<LogRequest, LogResponse> loggingServiceClient)
        {
            _logger = loggerFactory.CreateLogger<Module>();
            _logServiceClient = loggingServiceClient;

            Get("/tariffs/{date}", p => GetTariffsAsync(new TariffsRequest{ Date = p.date}));
            Get("/timebands/{date}", p => GetTimeBandsAsync(new TimeBandsRequest{ Date = p.date}));
        }

        async Task<TariffsResponse> GetTariffsAsync(TariffsRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get tariffs for {request.Date}" });
                return new TariffsResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new TariffsResponse { Success = true, Charges = GetTariffs(request.Date) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Tariffs for {request.Date}: {result.Charges}" });

            return result;
        }

        Tariff GetTariffs(string date) => new Tariff{
            Red = 4.874F,
            Amber = 0.434F,
            Green = 0.011F,
            Fixed = 3.45F,
            Capacity = 3.14F,
            ExceededCapacity = 4.2F
        };

        async Task<TimeBandsResponse> GetTimeBandsAsync(TimeBandsRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to generate factorial for {request.Date} - " });
                return new TimeBandsResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new TimeBandsResponse { Success = true, TimeBands = GetTimeBands(request) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved TimeBands for {request.Date}: {result.TimeBands}" });

            return result;
        }

        IEnumerable<TimeBand> GetTimeBands(TimeBandsRequest request) => new TimeBand[] {
            new TimeBand { Type = "Green", StartTime = "00:00:00", EndTime = "00:30:00" },
            new TimeBand { Type = "Green", StartTime = "00:30:00", EndTime = "01:00:00" },
            new TimeBand { Type = "Green", StartTime = "01:00:00", EndTime = "01:30:00" },
            new TimeBand { Type = "Green", StartTime = "01:30:00", EndTime = "02:00:00" },
            new TimeBand { Type = "Green", StartTime = "02:00:00", EndTime = "02:30:00" },
            new TimeBand { Type = "Green", StartTime = "02:30:00", EndTime = "03:00:00" },
            new TimeBand { Type = "Green", StartTime = "03:00:00", EndTime = "03:30:00" },
            new TimeBand { Type = "Green", StartTime = "03:30:00", EndTime = "04:00:00" },
            new TimeBand { Type = "Green", StartTime = "04:00:00", EndTime = "04:30:00" },
            new TimeBand { Type = "Green", StartTime = "04:30:00", EndTime = "05:00:00" },
            new TimeBand { Type = "Green", StartTime = "05:00:00", EndTime = "05:30:00" },
            new TimeBand { Type = "Green", StartTime = "05:30:00", EndTime = "06:00:00" },
            new TimeBand { Type = "Green", StartTime = "06:00:00", EndTime = "06:30:00" },
            new TimeBand { Type = "Green", StartTime = "06:30:00", EndTime = "07:00:00" },
            new TimeBand { Type = "Amber", StartTime = "07:00:00", EndTime = "07:30:00" },
            new TimeBand { Type = "Amber", StartTime = "07:30:00", EndTime = "08:00:00" },
            new TimeBand { Type = "Amber", StartTime = "08:00:00", EndTime = "08:30:00" },
            new TimeBand { Type = "Amber", StartTime = "08:30:00", EndTime = "09:00:00" },
            new TimeBand { Type = "Amber", StartTime = "09:00:00", EndTime = "09:30:00" },
            new TimeBand { Type = "Amber", StartTime = "09:30:00", EndTime = "10:00:00" },
            new TimeBand { Type = "Amber", StartTime = "10:00:00", EndTime = "10:30:00" },
            new TimeBand { Type = "Amber", StartTime = "10:30:00", EndTime = "11:00:00" },
            new TimeBand { Type = "Red", StartTime = "11:00:00", EndTime = "11:30:00" },
            new TimeBand { Type = "Red", StartTime = "11:30:00", EndTime = "12:00:00" },
            new TimeBand { Type = "Red", StartTime = "12:00:00", EndTime = "12:30:00" },
            new TimeBand { Type = "Red", StartTime = "12:30:00", EndTime = "13:00:00" },
            new TimeBand { Type = "Red", StartTime = "13:00:00", EndTime = "13:30:00" },
            new TimeBand { Type = "Red", StartTime = "13:30:00", EndTime = "14:00:00" }
        };
    }
}