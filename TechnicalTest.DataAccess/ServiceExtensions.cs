using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.DataAccess.Clients.Database;

namespace TechnicalTest.DataAccess;

public static class ServiceExtensions
{
    public static void AddDataAccessLayer(this IServiceCollection services)
    {
        services.AddDbContext<CandidateDbContext>(options => options.UseInMemoryDatabase("CandidatesDatabase"));
    }
}
