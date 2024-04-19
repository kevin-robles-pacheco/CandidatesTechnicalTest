using MediatR;
using TechnicalTest.Domain.DTOs;
using TechnicalTest.Infraestructure.Services.Candidates.Queries;

namespace TechnicalTest.DataAccess.Clients.Database.Handlers;

public class GetByIdCandidateExperienceHandler : IRequestHandler<GetByIdCandidateExperienceQuery, CandidateExperienceDto>
{
    private readonly CandidateDbContext _dbContext;

    public GetByIdCandidateExperienceHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CandidateExperienceDto> Handle(GetByIdCandidateExperienceQuery request, CancellationToken cancellationToken)
    {
        var candidateExperiences = await _dbContext.CandidateExperiences.FindAsync(new object[] { request.id }, cancellationToken);

        if (candidateExperiences is null)
        {
            return null;
        }

        return new CandidateExperienceDto
        {
            IdCandidateExperience = candidateExperiences.IdCandidateExperience,
            IdCandidate = candidateExperiences.IdCandidate,
            Company = candidateExperiences.Company,
            Job = candidateExperiences.Job,
            Description = candidateExperiences.Description,
            Salary = candidateExperiences.Salary,
            BeginDate = candidateExperiences.BeginDate,
            EndDate = candidateExperiences.EndDate,
            InsertDate = candidateExperiences.InsertDate,
            ModifyDate = candidateExperiences.ModifyDate
        };
    }
}
