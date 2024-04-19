using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;
using TechnicalTest.Infraestructure.Services.Candidates.Queries;

namespace TechnicalTest.Infraestructure;

public static class ServiceExtensions
{
    public static void AddInfraestructureLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetAllCandidateQuery).Assembly);
        services.AddMediatR(typeof(GetByIdCandidateQuery).Assembly);
        services.AddMediatR(typeof(GetByIdCandidateExperienceQuery).Assembly);
        services.AddMediatR(typeof(CreateCandidateCommand).Assembly);
        services.AddMediatR(typeof(CreateCandidateExperienceCommand).Assembly);
        services.AddMediatR(typeof(DeleteCandidateCommand).Assembly);
        services.AddMediatR(typeof(DeleteCandidateExperienceCommand).Assembly);
        services.AddMediatR(typeof(UpdateCandidateCommand).Assembly);
        services.AddMediatR(typeof(UpdateCandidateExperienceCommand).Assembly);
    }
}
