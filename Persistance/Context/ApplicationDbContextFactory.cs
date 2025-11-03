using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistance.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-JBOMDJF\\SEVINC; Initial Catalog=HayatCaseDb;  Integrated Security = true; TrustServerCertificate=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
