using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Presentation
{
    public class Startup
    {
        #region props
        private readonly IConfiguration _configuration;
        #endregion props
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TravelContext>(opt =>
            {
                opt.UseSqlServer(_configuration.GetConnectionString("TravelConnection"));
            });
            services.AddControllers();
            services.AddScoped<DbContext, TravelContext>();
            ConfigMapper(services);
            Middleware.DependencyInjection.AddDependencies(services);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void ConfigMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ClearPrefixes();
                cfg.AddProfile(new Services.DomainToOutput());
                cfg.AddProfile(new Services.InputToDomain());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(e => e.MapControllers());
        }
    }
}
