using Microsoft.EntityFrameworkCore;

namespace Naft.Infra.Data;


public class NaftContextData : DbContext
{
    public NaftContextData(DbContextOptions<NaftContextData> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=naft-ecommerce;User ID=sa;Password=1q2w3e4r@#$;Encrypt=false");
    }
}