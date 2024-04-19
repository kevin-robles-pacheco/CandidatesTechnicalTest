using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.Business.Services;

namespace TechnicalTest.Business;

public static class ServiceExtensions
{
    public static void AddBusinessLayer(this IServiceCollection services)
    {
        services.AddScoped<CandidateServices>();
    }
}
