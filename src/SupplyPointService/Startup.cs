using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyPointService.Persistence;

namespace SupplyPointService
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("ConsumptionValidatorConnection");

            services
                .AddTransient<ISupplyCapacityRepository>(context => new SupplyCapacityRepository(new SqlConnection(connectionString)))
                .AddTransient<ISupplyPointRepository>(context => new SupplyPointRepository(new SqlConnection(connectionString)))
                .AddTransient<IMpanRepository>(context => new MpanRepository(new SqlConnection(connectionString)))
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
