using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.Business.Handlers;

namespace TechnicalTest.Business;

public static class ServiceExtensions
{
    public static void AddBusinessLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetAllCandidateHandler).Assembly);
        services.AddMediatR(typeof(GetByIdCandidateHandler).Assembly);
        services.AddMediatR(typeof(GetByIdCandidateExperienceHandler).Assembly);
        services.AddMediatR(typeof(CreateCandidateHandler).Assembly);
        services.AddMediatR(typeof(CreateCandidateExperienceHandler).Assembly);
        services.AddMediatR(typeof(DeleteCandidateHandler).Assembly);
        services.AddMediatR(typeof(DeleteCandidateExperienceHandler).Assembly);
        services.AddMediatR(typeof(UpdateCandidateHandler).Assembly);
        services.AddMediatR(typeof(UpdateCandidateExperienceHandler).Assembly);
    }
}
