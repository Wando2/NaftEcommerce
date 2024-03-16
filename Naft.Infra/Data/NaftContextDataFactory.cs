using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Naft.Infra.Data;

public class NaftContextDataFactory : IDesignTimeDbContextFactory<NaftContextData>
{
    public NaftContextData CreateDbContext(string[] args)
    {
        // Get the base directory of your application
        var baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"..\Naft.Presentation");

        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(baseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        // Create DbContextOptionsBuilder using the configured SQL Server provider
        var builder = new DbContextOptionsBuilder<NaftContextData>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);

        // Return a new instance of the DbContext
        return new NaftContextData(builder.Options);
    }
}