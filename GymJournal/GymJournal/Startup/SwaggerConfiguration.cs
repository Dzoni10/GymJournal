﻿using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace GymJournal.Startup
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gym Journal",
                    Version = "v1"
                });
                var jwtSecurityScheme = new OpenApiSecurityScheme
                { BearerFormat="JWT",
                  Name = "JWT Authentication",
                  In = ParameterLocation.Header,
                  Type = SecuritySchemeType.Http,
                  Scheme = JwtBearerDefaults.AuthenticationScheme,
                  Description = "Put **ONLY** your JWT Bearer token in the text box below!",
                  Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });
            });
            return services;
        }
    }
}
