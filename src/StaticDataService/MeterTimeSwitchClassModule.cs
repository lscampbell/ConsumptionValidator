using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nancy;
using StaticDataService.Models;
using StaticDataService.Persistence;
using LoggingService.Models;
using Nancy.Validation;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace StaticDataService
{
    public class MeterTimeSwitchClassModule : NancyModule
    {
        ILogger<MeterTimeSwitchClassModule> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;
        readonly IMeterTimeSwitchClassRepository _repository;

        public MeterTimeSwitchClassModule(
            ILoggerFactory loggerFactory, 
            ServiceClient<LogRequest, LogResponse> loggingServiceClient, 
            IMeterTimeSwitchClassRepository repository)
        {
            _logger = loggerFactory.CreateLogger<MeterTimeSwitchClassModule>();
            _logServiceClient = loggingServiceClient;
            _repository = repository;

            Get("/meter-time-switch-class", _ => GetMTSCAsync());
        }

        async Task<MeterTimeSwitchClassResponse> GetMTSCAsync()
        {
            var result = new MeterTimeSwitchClassResponse { Success = true, MeterTimeSwitchClasses = GetMeterTimeSwitchClass() };
            await _logServiceClient.PostAsync(new LogRequest { Message = "Got the Meter Time Switch Classes" });

            return result;
        }

        IEnumerable<MeterTimeSwitchClass> GetMeterTimeSwitchClass() => _repository.GetAll();
    }
}