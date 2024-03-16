using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Naft.Infra;
using Naft.Infra.Data;
using Naft.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);
ConfigureMvc(builder);
ConfigureAuthentication(builder);


var app = builder.Build();

LoadSettings(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void LoadSettings(WebApplication app)
{
    Settings.JwtKey = app.Configuration.GetValue<string>("JwtKey");
    Settings.ApiKey = app.Configuration.GetValue<string>("ApiKey");
    Settings.ApiKeyName = app.Configuration.GetValue<string>("ApiKey");
}

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
  
    services.AddSwaggerGen();
    services.AddEndpointsApiExplorer();
    
    services.AddDbContext<NaftContextData>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services
        .AddMemoryCache()
        .AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
        })
        .Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        })
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<TokenService>();
    builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
        
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.JwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
}