using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossCutting.injection;
using Domain.Security;
using Infra.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase.ConfigureDependencyDatabases(services);
            ConfigureService.ConfigureDependencyServices(services);
            ConfigureRepository.ConfigureDependencyRepositories(services);

            var signingConfiguration = new SigningConfiguration();         
            var tokenConfiguration = Configuration.GetSection("Token").Get<TokenConfiguration>();
            services.AddSingleton(signingConfiguration);
            services.AddSingleton(tokenConfiguration);

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                var validation = options.TokenValidationParameters;
                validation.IssuerSigningKey = signingConfiguration.Key;
                validation.ValidAudience = tokenConfiguration.Audience;
                validation.ValidIssuer = tokenConfiguration.Issuer;
                validation.ValidateIssuerSigningKey = true;
                validation.ValidateLifetime = true;
                validation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(options => {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.RoutePrefix = string.Empty;
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Net Core 3.1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
