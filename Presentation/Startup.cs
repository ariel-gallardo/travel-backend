using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Configuration;
using System.Reflection;
using CustomSettings;
namespace Presentation
{
    public class Startup
    {
        #region props
        private readonly IConfiguration _configuration;
        public Cors CorsSettings { get; set; }
        public Database DatabaseSettings { get; set; }
        #endregion props
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            DatabaseSettings = new Database();
            CorsSettings = new Cors();

            var sDatabase = _configuration.GetSection("Database");
            var sOpenWeather = _configuration.GetSection("OpenWeather");
            var sCors = _configuration.GetSection("Cors");

            DatabaseSettings = sDatabase.Get<Database>();
            CorsSettings = sCors.Get<Cors>();

            services.Configure<Database>(sDatabase);
            services.Configure<OpenWeather>(sOpenWeather);
            services.Configure<Cors>(sCors);

            services.AddDbContext<TravelContext>(opt =>
            {
                opt.UseSqlServer(DatabaseSettings.ConnectionString);
            });

            services.AddCors(setup =>
            {
                setup.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins(CorsSettings.DomainToAllow)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddControllers()
            .ConfigureApiBehaviorOptions(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var output = new Models.Output.Output()
                    {
                        Messages = context.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList(),
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                    return new BadRequestObjectResult(output);
                };
            });
            services.AddScoped<DbContext, TravelContext>();
            ConfigMapper(services);
            Middleware.DependencyInjection.AddDependencies(services);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(s =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
        }

        public void ConfigMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ClearPrefixes();
                cfg.AddProfile(new Services.DomainToOutput());
                cfg.AddProfile(new Services.InputToDomain());
                cfg.AddProfile(new Services.ExternalDomainToDomain());
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
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(e => e.MapControllers());
            app.UseMvc();

        }
    }
}
