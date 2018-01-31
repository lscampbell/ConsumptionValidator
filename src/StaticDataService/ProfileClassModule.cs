using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nancy;
using StaticDataService.Models;
using StaticDataService.Persistence;
using LoggingService.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace StaticDataService
{
    public class ProfileClassModule : NancyModule
    {
        ILogger<ProfileClassModule> _logger;
        ServiceClient<LogRequest, LogResponse> _logServiceClient;
        //readonly IProfileClassRepository _repository;
        ProfileClassRepository _repository = new ProfileClassRepository(new SqlConnection(""));
        public ProfileClassModule(
            ILoggerFactory loggerFactory, 
            ServiceClient<LogRequest, LogResponse> loggingServiceClient)
        {
            
            _logger = loggerFactory.CreateLogger<ProfileClassModule>();
            _logServiceClient = loggingServiceClient;

            Get("/profile-class", _ => GetPCAsync());
        }

        async Task<ProfileClassResponse> GetPCAsync()
        {
            var result = new ProfileClassResponse { Success = true, ProfileClasses = GetProfileClass() };
            await _logServiceClient.PostAsync(new LogRequest { Message = "Got Profile Classes" });

            return result;
        }

        IEnumerable<ProfileClass> GetProfileClass() => _repository.GetAll();
    }
}