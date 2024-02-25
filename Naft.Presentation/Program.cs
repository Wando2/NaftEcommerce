// using System.IO.Compression;
// using System.Text;
// using System.Text.Json.Serialization;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.ResponseCompression;
// using Microsoft.IdentityModel.Tokens;
// using Naft.Infra;
// using Naft.Infra.Services;
//
// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
//
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//
//
//
// var app = builder.Build();
//
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
//
// app.UseAuthentication();
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();
//
// void LoadSettings(WebApplication app)
// {
//     Settings.JwtKey = app.Configuration.GetValue<string>("JwtKey");
//     Settings.ApiKey = app.Configuration.GetValue<string>("ApiKey");
//     Settings.ApiKeyName = app.Configuration.GetValue<string>("ApiKey");
// }
//
// void ConfigureServices(IServiceCollection services)
// {
//   
//     services.AddSwaggerGen();
//     services.AddEndpointsApiExplorer();
// }
//
// void ConfigureMvc(WebApplicationBuilder builder)
// {
//     builder.Services
//         .AddMemoryCache()
//         .AddResponseCompression(options =>
//         {
//             options.Providers.Add<GzipCompressionProvider>();
//         })
//         .Configure<GzipCompressionProviderOptions>(options =>
//         {
//             options.Level = CompressionLevel.Optimal;
//         })
//         .AddControllers()
//         .ConfigureApiBehaviorOptions(options =>
//         {
//             options.SuppressModelStateInvalidFilter = true;
//         })
//         .AddJsonOptions(x =>
//         {
//             x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//             x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//         });
// }
//
// void ConfigureAuthentication(WebApplicationBuilder builder)
// {
//     builder.Services.AddTransient<TokenService>();
//     builder.Services.AddAuthentication(x =>
//         {
//             x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//             x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//         })
//         .AddJwtBearer(x =>
//         {
//         
//             x.TokenValidationParameters = new TokenValidationParameters
//             {
//                 ValidateIssuerSigningKey = true,
//                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.JwtKey)),
//                 ValidateIssuer = false,
//                 ValidateAudience = false
//             };
//         });
// }