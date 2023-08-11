﻿using System.Text;
using System.Text.Json.Serialization;
using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Matches;
using Artemis.Contracts.Repositories;
using Artemis.Data.Db.Configurations;
using Artemis.Data.Db.Repositories;
using Artemis.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Artemis.API
{
    public static class IoC
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition(
                    JwtBearerDefaults.AuthenticationScheme,
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme.",
                    });

                opt.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme,
                                },
                            },
                            new string[]
                            {
                            }
                        },
                    });
            });

            services.AddDbContext<IdentityDbContext<User, IdentityRole<string>, string>, DefaultDbContext>(
                opt =>
                {
                    opt.UseSqlServer(
                        "",
                        op => op.MigrationsAssembly("Artemis.Data.Db"));
                });

            services.AddScoped<ICityRepository<City>, CityRepository>();

            services.AddScoped<ICountryRepository<Country>, CountryRepository>();

            services.AddScoped<ILocationRepository<Location>, LocationRepository>();

            services.AddScoped<IMatchRepository<Match>, MatchRepository>();

            services.AddScoped<IRemovableRepository<Shot>, ShotRepository>();

            services.AddScoped<ITimestampRepository<Timestamp>, TimestampRepository>();

            services.AddScoped<IUserRepository<User>, UserRepository>();

            services.AddScoped<IUnitOfWork, DefaultUnitOfWork>();

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddIdentity<User, IdentityRole<string>>()
                .AddEntityFrameworkStores<DefaultDbContext>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidIssuer = configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)),
                    ValidateLifetime = true,
                };
            });
        }
    }
}
