using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(builder.Configuration, "AzureAd");
builder.Services.AddCors();

//This enforces global authorization, similar to using the [Authorize] attribute on controllers and / or operations
//builder.Services.AddControllers(options =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//                     .RequireAuthenticatedUser()
//                     .RequireAssertion(handler =>
//                     {
//                         var scopeClaim = handler.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope");
//                         var scopes = scopeClaim?.Value.Split(' ');
//                         var hasScope = scopes?.Where(scope => scope == builder.Configuration.GetSection("AzureAd:Scopes").Value).Any() ?? false;
//                         return hasScope;
//                     })
//                     .Build();
//    options.Filters.Add(new AuthorizeFilter(policy));
//});
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DirigentesApi", Version = "v1" });
});

builder.Logging.AddLog4Net("log4net.config");


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "Dirigentes Api v1"));

//}
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseRouting();
app.UseStaticFiles();
//app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();