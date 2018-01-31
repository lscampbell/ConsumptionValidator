using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nancy;
using ProfileDataService.Models;
using LoggingService.Models;
using Nancy.Validation;
using System.Threading.Tasks;

namespace ProfileDataService
{
    public class Module : NancyModule
    {
        ILogger<Module> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;

        public Module(ILoggerFactory loggerFactory, ServiceClient<LogRequest, LogResponse> loggingServiceClient)
        {
            _logger = loggerFactory.CreateLogger<Module>();
            _logServiceClient = loggingServiceClient;

            Get("/{supplyPoint}/{date}", p => GetProfileDataAsync(new ProfileDataRequest 
                { SupplyPoint = p.supplyPoint, Date = p.date }));
        }
        
        async Task<ProfileDataResponse> GetProfileDataAsync(ProfileDataRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to get Profile Data for {request.SupplyPoint}" });
                return new ProfileDataResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new ProfileDataResponse { Success = true, ProfileRows = GetProfileData(request.SupplyPoint) };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Retrieved Profile Data for {request.SupplyPoint}: {result.ProfileRows}" });

            return result;
        }    

        IEnumerable<ProfileRow> GetProfileData(string supplyPoint) 
            => new ProfileRow[] {
                new ProfileRow { StartTime = "00:00:00", EndTime = "00:30:00", Kwh = 800 },
                new ProfileRow { StartTime = "06:00:00", EndTime = "06:30:00", Kwh = 400 },
                new ProfileRow { StartTime = "07:00:00", EndTime = "07:30:00", Kwh = 600 },
                new ProfileRow { StartTime = "10:30:00", EndTime = "11:00:00", Kwh = 200 },
                new ProfileRow { StartTime = "11:00:00", EndTime = "11:30:00", Kwh = 700 },
                new ProfileRow { StartTime = "13:30:00", EndTime = "14:00:00", Kwh = 650 }
            };
    }
}