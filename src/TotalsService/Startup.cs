using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TotalsService.Persistence;

namespace TotalsService
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
                .AddTransient<IEnergyRepository>(context => new EnergyRepository(new SqlConnection(connectionString)))
                .AddTransient<ILossRepository>(context => new LossRepository(new SqlConnection(connectionString)))
                .AddTransient<IDuosRepository>(context => new DuosRepository(new SqlConnection(connectionString)))                
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
