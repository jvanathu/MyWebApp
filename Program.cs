using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using MyWebApp.Config.Security;
using System.Security.Claims;

var bld = WebApplication.CreateBuilder();

bld.Services
   .AddFastEndpoints()
   .SwaggerDocument();

var domain = $"https://{bld.Configuration["Auth0:Domain"]}/";

bld.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = domain;
    options.Audience = bld.Configuration["Auth0:Audience"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };
});

bld.Services.AddAuthorization(options =>
{
    // Add Auth0 Authorize Scopes here
    var scopes = new List<string> { "user:create", "person:get" };
    foreach (var scope in scopes)
    {
        options.AddPolicy(scope, policy => policy.Requirements.Add(new ScopeRequirement(scope, domain)));
    }
});
bld.Services.AddSingleton<IAuthorizationHandler, ScopeAuthorizationHandler>();

var app = bld.Build();
app.UseFastEndpoints()
   .UseSwaggerGen()
   .UseSwaggerUi();

app.Run();
