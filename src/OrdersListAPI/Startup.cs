using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrdersListAPI.Repositories;
using OrdersListAPI.Repositories.OrdersRepository;
using OrdersListAPI.Repositories.ProductsRepository;
using OrdersListAPI.Repositories.StatusesRepository;
using OrdersListAPI.Services.OrdersService;
using OrdersListAPI.Services.ProductsService;
using OrdersListAPI.Services.StatusesService;

namespace OrdersListAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<OrdersContext>(x => x.UseInMemoryDatabase("In-Memory-Db")
                                                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IStatusesRepository, StatusesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();

            services.AddScoped<IStatusesService, StatusesService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IOrdersService, OrdersService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(pol => pol.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
