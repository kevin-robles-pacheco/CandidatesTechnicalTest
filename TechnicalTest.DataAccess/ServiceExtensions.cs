using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.DataAccess.Clients.Database;
using TechnicalTest.DataAccess.Clients.Database.Handlers;

namespace TechnicalTest.DataAccess;

public static class ServiceExtensions
{
    public static void AddDataAccessLayer(this IServiceCollection services)
    {
        services.AddDbContext<CandidateDbContext>(options => options.UseInMemoryDatabase("CandidatesDatabase")); 
        services.AddMediatR(typeof(CreateCandidateHandler).Assembly);
        services.AddMediatR(typeof(CreateCandidateExperienceHandler).Assembly);
        services.AddMediatR(typeof(DeleteCandidateHandler).Assembly);
        services.AddMediatR(typeof(DeleteCandidateExperienceHandler).Assembly);
        services.AddMediatR(typeof(UpdateCandidateHandler).Assembly);
        services.AddMediatR(typeof(UpdateCandidateExperienceHandler).Assembly);
        services.AddMediatR(typeof(GetAllCandidateHandler).Assembly);
        services.AddMediatR(typeof(GetByIdCandidateHandler).Assembly);
        services.AddMediatR(typeof(GetByIdCandidateExperienceHandler).Assembly);
    }
}
