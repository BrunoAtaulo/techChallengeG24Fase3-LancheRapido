using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace App.Api.Configurations
{
    public static class CognitoConfig
    {
        private const string version = "1.0.0";
        private const string title = "API Lanche Rápido";

        public static void AddCognito(this IServiceCollection services)
        {
            var poolId = Environment.GetEnvironmentVariable("coguinitoIdPool");
            var clientId = Environment.GetEnvironmentVariable("coguinitoIdClient");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidIssuer = "https://cognito-idp.us-east-1.amazonaws.com/"+ poolId,
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = true,
                      ValidateLifetime = true,
                      ValidAudience = clientId,
                      ValidateAudience = false
                  };

                  options.MetadataAddress = "https://cognito-idp.us-east-1.amazonaws.com/"+ poolId + "/.well-known/openid-configuration";
              });

        }
    }
}
