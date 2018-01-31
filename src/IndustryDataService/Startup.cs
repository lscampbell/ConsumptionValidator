using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IndustryDataService.Persistence;

namespace IndustryDataService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("ConsumptionValidatorConnection");

            services
                .AddTransient<IProfileClassRepository>(context => new ProfileClassRepository(new SqlConnection(connectionString)))
                .AddTransient<IDistributionNetworkOperatorRepository>(context => new DistributionNetworkOperatorRepository(new SqlConnection(connectionString)))
                .AddTransient<IIndependentDistributionNetworkOperatorsRepository>(context => new IndependentDistributionNetworkOperatorsRepository(new SqlConnection(connectionString)))
                .AddTransient<IMeterTimeSwitchClassRepository>(context => new MeterTimeSwitchClassRepository(new SqlConnection(connectionString)))
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
